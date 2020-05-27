﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWN.FinalFantasy.Service.LootService
{
    public class LootTable : List<LootTableItem>
    {
        /// <summary>
        /// Retrieves a random item from the loot table.
        /// Throws an exception if there are no items in the loot table.
        /// </summary>
        /// <returns>A random item from the loot table.</returns>
        public LootTableItem GetRandomItem(int treasureHunterLevel)
        {
            if (Count <= 0)
                throw new Exception("No items are in this loot table.");

            int[] weights = new int[Count];
            for (int x = 0; x < Count; x++)
            {
                var item = this.ElementAt(x);
                var weight = item.Weight;

                // Treasure Hunter perk: Increases weight of rare items by 10 per level.
                if (treasureHunterLevel > 0 && item.IsRare)
                {
                    weight += treasureHunterLevel * 10;
                }

                weights[x] = weight;
            }

            int randomIndex = Random.GetRandomWeightedIndex(weights);
            return this.ElementAt(randomIndex);
        }
    }
}