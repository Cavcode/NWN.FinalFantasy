﻿using System;
using System.Collections.Generic;
using System.Text;
using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.NWNX;
using NWN.FinalFantasy.Core.NWScript.Enum;
using NWN.FinalFantasy.Service;
using static NWN.FinalFantasy.Core.NWScript.NWScript;
using Player = NWN.FinalFantasy.Entity.Player;
using Skill = NWN.FinalFantasy.Core.NWScript.Enum.Skill;

namespace NWN.FinalFantasy.Feature
{
    public class PlayerInitialization
    {
        /// <summary>
        /// Handles 
        /// </summary>
        [NWNEventHandler("mod_enter")]
        public static void InitializePlayer()
        {
            var player = GetEnteringObject();

            if (!GetIsPC(player) || GetIsDM(player)) return;

            var playerId = GetObjectUUID(player);
            var dbPlayer = DB.Get<Player>(playerId) ?? new Player();

            // Already been initialized. Don't do it again.
            if (dbPlayer.Version >= 1) return;

            ClearInventory(player);
            AutoLevelPlayer(player);
            InitializeSkills(player);
            InitializeSavingThrows(player);
            RemoveNWNSpells(player);
            ClearFeats(player);
            GrantBasicFeats(player);
            InitializeHotBar(player);

            dbPlayer.Version = 1;
            DB.Set(playerId, dbPlayer);
        }

        private static void AutoLevelPlayer(uint player)
        {
            // Capture original stats before we level up the player.
            int str = Creature.GetRawAbilityScore(player, Ability.Strength);
            int con = Creature.GetRawAbilityScore(player, Ability.Constitution);
            int dex = Creature.GetRawAbilityScore(player, Ability.Dexterity);
            int @int = Creature.GetRawAbilityScore(player, Ability.Intelligence);
            int wis = Creature.GetRawAbilityScore(player, Ability.Wisdom);
            int cha = Creature.GetRawAbilityScore(player, Ability.Charisma);

            GiveXPToCreature(player, 10000);

            for(int level = 1; level <= 5; level++)
            {
                var @class = GetClassByPosition(1, player);
                LevelUpHenchman(player, @class);
            }

            // Set stats back to how they were on entry.
            Creature.SetRawAbilityScore(player, Ability.Strength, str);
            Creature.SetRawAbilityScore(player, Ability.Constitution, con);
            Creature.SetRawAbilityScore(player, Ability.Dexterity, dex);
            Creature.SetRawAbilityScore(player, Ability.Intelligence, @int);
            Creature.SetRawAbilityScore(player, Ability.Wisdom, wis);
            Creature.SetRawAbilityScore(player, Ability.Charisma, cha);
        }

        /// <summary>
        /// Wipes a player's equipped items and inventory.
        /// </summary>
        /// <param name="player">The player to wipe an inventory for.</param>
        private static void ClearInventory(uint player)
        {
            for (int slot = 0; slot < NUM_INVENTORY_SLOTS; slot++)
            {
                var item = GetItemInSlot((InventorySlot)slot, player);
                if (!GetIsObjectValid(item)) continue;

                DestroyObject(item);
            }

            var inventory = GetFirstItemInInventory(player);
            while (GetIsObjectValid(inventory))
            {
                DestroyObject(inventory);
                inventory = GetNextItemInInventory(player);
            }
        }

        /// <summary>
        /// Initializes all player NWN skills to zero.
        /// </summary>
        /// <param name="player">The player to modify</param>
        private static void InitializeSkills(uint player)
        {
            for (int iCurSkill = 1; iCurSkill <= 27; iCurSkill++)
            {
                var skill = (Skill) (iCurSkill - 1);
                Creature.SetSkillRank(player, skill, 0);
            }
        }

        /// <summary>
        /// Initializes all player saving throws to zero.
        /// </summary>
        /// <param name="player">The player to modify</param>
        private static void InitializeSavingThrows(uint player)
        {
            SetFortitudeSavingThrow(player, 0);
            SetReflexSavingThrow(player, 0);
            SetWillSavingThrow(player, 0);
        }

        /// <summary>
        /// Removes all NWN spells from a player.
        /// </summary>
        /// <param name="player">The player to modify.</param>
        private static void RemoveNWNSpells(uint player)
        {
            var @class = GetClassByPosition(1, player);
            for (int index = 0; index <= 255; index++)
            {
                Creature.RemoveKnownSpell(player, @class, 0, index);
            }
        }

        private static void ClearFeats(uint player)
        {
            int numberOfFeats = Creature.GetFeatCount(player);
            for (int currentFeat = numberOfFeats; currentFeat >= 0; currentFeat--)
            {
                Creature.RemoveFeat(player, Creature.GetFeatByIndex(player, currentFeat - 1));
            }
        }

        private static void GrantBasicFeats(uint player)
        {
            Creature.AddFeatByLevel(player, Feat.ArmorProficiencyLight, 1);
            Creature.AddFeatByLevel(player, Feat.ArmorProficiencyMedium, 1);
            Creature.AddFeatByLevel(player, Feat.ArmorProficiencyHeavy, 1);
            Creature.AddFeatByLevel(player, Feat.ShieldProficiency, 1);
            Creature.AddFeatByLevel(player, Feat.WeaponProficiencyExotic, 1);
            Creature.AddFeatByLevel(player, Feat.WeaponProficiencyMartial, 1);
            Creature.AddFeatByLevel(player, Feat.WeaponProficiencySimple, 1);
            Creature.AddFeatByLevel(player, Feat.UncannyDodge1, 1);
            //Creature.AddFeatByLevel(player, Feat.StructureManagementTool, 1);
            Creature.AddFeatByLevel(player, Feat.OpenRestMenu, 1);
            //Creature.AddFeatByLevel(player, Feat.RenameCraftedItem, 1);
            Creature.AddFeatByLevel(player, Feat.ChatCommandTargeter, 1);
        }


        private static void InitializeHotBar(uint player)
        {
            var openRestMenu = PlayerQuickBarSlot.UseFeat(Feat.OpenRestMenu);
            //var structure = PlayerQuickBarSlot.UseFeat(Feat.StructureManagementTool);
            //var renameCraftedItem = PlayerQuickBarSlot.UseFeat(Feat.RenameCraftedItem);
            var chatCommandTargeter = PlayerQuickBarSlot.UseFeat(Feat.ChatCommandTargeter);

            Core.NWNX.Player.SetQuickBarSlot(player, 0, openRestMenu);
            //NWNXPlayer.SetQuickBarSlot(player, 1, structure);
            //NWNXPlayer.SetQuickBarSlot(player, 2, renameCraftedItem);
            Core.NWNX.Player.SetQuickBarSlot(player, 3, chatCommandTargeter);
        }
    }
}
