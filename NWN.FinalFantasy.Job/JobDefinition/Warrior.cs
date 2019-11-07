﻿using System.Collections.Generic;
using NWN.FinalFantasy.Core.NWScript.Enumerations;
using NWN.FinalFantasy.Job.Enumeration;

namespace NWN.FinalFantasy.Job.JobDefinition
{
    internal class Warrior: JobDefinitionBase
    {
        public Warrior()
        {
            Name = "Warrior";
            Description = "Melee fighter which specializes in a variety of weapons and armor.";
            GF = GuardianForce.Ifrit;

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
                BaseItemType.Longsword,
                BaseItemType.Greatsword,
                BaseItemType.Greataxe,
                BaseItemType.Battleaxe,

                BaseItemType.SmallShield,
                BaseItemType.LargeShield,
                BaseItemType.TowerShield
            });

            AddAbility(1, AbilityType.MightyStrikes);
            AddAbility(3, AbilityType.DefenseBonus1);
        }
    }
}
