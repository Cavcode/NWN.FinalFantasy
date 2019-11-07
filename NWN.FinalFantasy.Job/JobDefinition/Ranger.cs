﻿using System.Collections.Generic;
using NWN.FinalFantasy.Core.NWScript.Enumerations;
using NWN.FinalFantasy.Job.Enumeration;

namespace NWN.FinalFantasy.Job.JobDefinition
{
    internal class Ranger: JobDefinitionBase
    {
        public Ranger()
        {
            Name = "Ranger";
            Description = "Combatant which specializes in attacking from afar with ranged attacks.";
            GF = GuardianForce.Valefor;

            HPRating = ProficiencyRating.B;
            MPRating = ProficiencyRating.E;
            STRRating = ProficiencyRating.A;
            DEXRating = ProficiencyRating.B;
            CONRating = ProficiencyRating.A;
            INTRating = ProficiencyRating.E;
            WISRating = ProficiencyRating.E;
            CHARating = ProficiencyRating.C;

            WeaponTypes.AddRange(new []
            {
                BaseItemType.ShortBow,
                BaseItemType.Longbow,
                BaseItemType.LightCrossbow,
                BaseItemType.HeavyCrossbow,
                BaseItemType.Shortsword,
                BaseItemType.HandAxe,
                BaseItemType.ThrowingAxe
            });
        }
    }
}
