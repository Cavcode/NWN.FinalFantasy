﻿using System.Collections.Generic;
using NWN.FinalFantasy.Core.NWScript.Enum;

namespace NWN.FinalFantasy.Service.PerkService
{
    public class PerkLevel
    {
        public int Price { get; set; }
        public string Description { get; set; }
        public List<Feat> GrantedFeats { get; set; }
        public List<IPerkRequirement> Requirements { get; set; }

        public PerkLevel()
        {
            GrantedFeats = new List<Feat>();
            Requirements = new List<IPerkRequirement>();
        }
    }
}
