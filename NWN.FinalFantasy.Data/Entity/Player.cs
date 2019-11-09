﻿using NWN.FinalFantasy.Core.NWScript.Enumerations;

namespace NWN.FinalFantasy.Data.Entity
{
    public class Player: EntityBase
    {
        public int Version { get; set; }
        public ClassType CurrentJob { get; set; }
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public string LocationAreaResref { get; set; }
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        public float LocationZ { get; set; }
        public float LocationOrientation { get; set; }
        public float RespawnLocationX { get; set; }
        public float RespawnLocationY { get; set; }
        public float RespawnLocationZ { get; set; }
        public float RespawnLocationOrientation { get; set; }
        public string RespawnAreaResref { get; set; }
        public bool IsDeleted { get; set; }
    }
}
