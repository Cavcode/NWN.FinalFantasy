﻿using System;
using System.Collections.Generic;
using System.Linq;
using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Enumeration;
using NWN.FinalFantasy.Service;
using NWN.FinalFantasy.Service.LootService;
using static NWN.FinalFantasy.Core.NWScript.NWScript;
using Random = NWN.FinalFantasy.Service.Random;

namespace NWN.FinalFantasy.Feature
{
    public class Loot
    {
        private static readonly Dictionary<string, LootTable> _lootTables = new Dictionary<string, LootTable>();

        [NWNEventHandler("mod_load")]
        public static void RegisterLootTables()
        {
            // Get all implementations of spawn table definitions.
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(w => typeof(ILootTableDefinition).IsAssignableFrom(w) && !w.IsInterface && !w.IsAbstract);

            foreach (var type in types)
            {
                var instance = (ILootTableDefinition)Activator.CreateInstance(type);
                var builtTables = instance.BuildLootTables();

                foreach (var table in builtTables)
                {
                    if (string.IsNullOrWhiteSpace(table.Key))
                    {
                        Log.Write(LogGroup.Error, $"Loot table {table.Key} has an invalid key. Values must not be null or white space.");
                        continue;
                    }

                    if (_lootTables.ContainsKey(table.Key))
                    {
                        Log.Write(LogGroup.Error, $"Loot table {table.Key} has already been registered. Please make sure all spawn tables use a unique ID.");
                        continue;
                    }

                    _lootTables[table.Key] = table.Value;
                }
            }
        }

        /// <summary>
        /// When a creature spawns, items which can be stolen are spawned and marked as undroppable.
        /// These items are only available with the Thief ability "Steal" and related perks.
        /// </summary>
        [NWNEventHandler("crea_spawn")]
        public static void SpawnStealLoot()
        {
            var creature = OBJECT_SELF;
            var lootTables = GetLootTableDetails(creature, "STEAL_LOOT_TABLE_");

            foreach (var lootTable in lootTables)
            {
                var (tableName, chance, attempts) = ParseLootTableArguments(lootTable);

                foreach (var item in SpawnLoot(creature, tableName, chance, attempts))
                {
                    SetItemCursedFlag(item, true);
                    SetDroppableFlag(item, false);

                    SetLocalBool(item, "STEAL_ITEM", true);
                }
            }
        }

        /// <summary>
        /// Retrieves the name of the loot table, the chance to spawn an item, and the number of attempts
        /// by a given comma delimited loot table string.
        /// </summary>
        /// <param name="delimitedString">The comma delimited string </param>
        /// <returns>The table name, the percent chance, and the number of attempts</returns>
        private static (string, int, int) ParseLootTableArguments(string delimitedString)
        {
            var data = delimitedString.Split(',');
            var tableName = data[0].Trim();
            var chance = 100;
            var attempts = 1;

            // Second argument: Chance to spawn
            if (data.Length > 1)
            {
                data[1] = data[1].Trim();
                if (!int.TryParse(data[1], out chance))
                {
                    Console.WriteLine($"Loot Table with arguments '{delimitedString}', 'Chance' variable could not be processed. Must be an integer.");
                }
            }

            // Third argument: Attempts to pull from loot table
            if (data.Length > 2)
            {
                data[2] = data[2].Trim();
                if (!int.TryParse(data[1], out attempts))
                {
                    Console.WriteLine($"Loot Table with arguments '{delimitedString}', 'Attempts' variable could not be processed. Must be an integer.");
                }
            }

            // Guards against bad data from builder.
            if (chance > 100)
                chance = 100;

            if (attempts <= 0)
                attempts = 1;


            return (tableName, chance, attempts);
        }

        private static IEnumerable<uint> SpawnLoot(uint creature, string lootTableName, int chance, int attempts)
        {
            var gilfinderLevel = GetLocalInt(creature, "GILFINDER_LEVEL");
            var gilPercentIncrease = gilfinderLevel * 0.2f;
            var treasureHunterLevel = GetLocalInt(creature, "TREASURE_HUNTER_LEVEL");

            var table = GetLootTableByName(lootTableName);
            for (int x = 1; x <= attempts; x++)
            {
                if (Random.D100(1) > chance) continue;

                var item = table.GetRandomItem(treasureHunterLevel);
                var quantity = Random.Next(item.MaxQuantity) + 1;

                // Gilfinder perk - Increase the quantity of gold found.
                if (item.Resref == "nw_it_gold001")
                {
                    quantity += (int)(quantity * gilPercentIncrease);
                }

                yield return CreateItemOnObject(item.Resref, creature, quantity);
            }
        }

        /// <summary>
        /// When a creature dies, loot tables are spawned based on local variables.
        /// </summary>
        [NWNEventHandler("crea_death")]
        public static void SpawnLoot()
        {
            var creature = OBJECT_SELF;
            var lootTableEntries = GetLootTableDetails(creature, "LOOT_TABLE_");
            foreach (var entry in lootTableEntries)
            {
                var delimitedString = GetLocalString(creature, entry);
                var (tableName, chance, attempts) = ParseLootTableArguments(delimitedString);

                SpawnLoot(creature, tableName, chance, attempts);
            }
        }

        /// <summary>
        /// Retrieves a loot table by its unique name.
        /// If name is not registered, an exception will be raised.
        /// </summary>
        /// <param name="name">The name of the loot table to retrieve.</param>
        /// <returns>A loot table matching the specified name.</returns>
        public static LootTable GetLootTableByName(string name)
        {
            if (!_lootTables.ContainsKey(name))
                throw new Exception($"Loot table '{name}' is not registered. Did you enter the right name?");

            return _lootTables[name];
        }

        /// <summary>
        /// Returns all of the loot table details found on a creature's local variables.
        /// </summary>
        /// <param name="creature">The creature to search.</param>
        /// <param name="lootTablePrefix">The prefix of the loot tables to look for.</param>
        /// <returns>A list of loot table details.</returns>
        private static IEnumerable<string> GetLootTableDetails(uint creature, string lootTablePrefix)
        {
            var lootTables = new List<string>();

            int index = 1;
            var localVariableName = lootTablePrefix + index;
            var localVariable = GetLocalString(creature, localVariableName);

            while (!string.IsNullOrWhiteSpace(localVariable))
            {
                localVariable = GetLocalString(creature, localVariableName);
                if (string.IsNullOrWhiteSpace(localVariable)) break;

                lootTables.Add(localVariable);

                index++;
                localVariableName = lootTablePrefix + index;
            }

            return lootTables;
        }

        /// <summary>
        /// When a creature is hit by another creature with the Gilfinder or Treasure Hunter perk,
        /// a local variable is set on the creature which will be picked up when spawning items.
        /// These will be checked later when the creature dies and loot is spawned.
        /// </summary>
        [NWNEventHandler("item_on_hit")]
        public static void MarkGilfinderAndTreasureHunterOnTarget()
        {
            var player = OBJECT_SELF;
            if (!GetIsPC(player) || GetIsDM(player) || !GetIsObjectValid(player)) return;

            var target = GetSpellTargetObject();
            if (GetIsPC(target) || GetIsDM(target)) return;

            var currentGilfinder = GetLocalInt(target, "GILFINDER_LEVEL");
            var currentTreasureHunter = GetLocalInt(target, "TREASURE_HUNTER_LEVEL");

            var effectiveGilfinderLevel = Perk.GetEffectivePerkLevel(player, PerkType.Gilfinder);
            var effectiveTreasureHunterLevel = Perk.GetEffectivePerkLevel(player, PerkType.TreasureHunter);

            if (effectiveGilfinderLevel > currentGilfinder)
            {
                SetLocalInt(target, "GILFINDER_LEVEL", effectiveGilfinderLevel);
            }

            if (effectiveTreasureHunterLevel > currentTreasureHunter)
            {
                SetLocalInt(target, "TREASURE_HUNTER_LEVEL", effectiveTreasureHunterLevel);
            }
        }
    }
}
