﻿using System;
using NWN.FinalFantasy.Core.NWScript;
using NWN.FinalFantasy.Core.NWScript.Enum;

namespace NWN.FinalFantasy.Service.SpawnService
{
    public class SpawnTable
    {
        public int RespawnDelayMinutes { get; set; }

        public SpawnTable()
        {
            RespawnDelayMinutes = 5;
        }

        /// <summary>
        /// Retrieves the next spawn resref and object type based on the rules for this specific spawn table.
        /// </summary>
        /// <returns>A tuple cointaining the object type and resref to spawn.</returns>
        public Tuple<ObjectType, string> GetNextSpawnResref()
        {
            return new Tuple<ObjectType, string>(ObjectType.Creature, "nw_goblina");
        }
    }
}
