﻿using System.Collections.Generic;
using NWN.FinalFantasy.Core.NWScript.Enum;
using NWN.FinalFantasy.Enumeration;
using NWN.FinalFantasy.Service.PerkService;

namespace NWN.FinalFantasy.Feature.PerkDefinition
{
    public class MonkPerkDefinition: IPerkListDefinition
    {
        public Dictionary<PerkType, PerkDetail> BuildPerks()
        {
            var builder = new PerkBuilder();
            HundredFists(builder);
            InnerHealing(builder);
            Valor(builder);
            MonkEvasion(builder);
            CircleKick(builder);
            MartialFinesse(builder);
            VitalityBoost(builder);
            Chakra(builder);
            ElectricFist(builder);
            SubtleBlow(builder);

            return builder.Build();
        }

        private static void HundredFists(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.HundredFists)
                .Name("Hundred Fists")
                .Description("Grants haste to you and increases your number of attacks by 5 for 30 seconds.")
                
                .AddPerkLevel()
                .Description("Grants the Hundred Fists ability.")
                .RequirementSkill(SkillType.Chi, 50)
                .RequirementSkill(SkillType.LightArmor, 50)
                .RequirementSkill(SkillType.Knuckles, 50)
                .Price(15)
                .GrantsFeat(Feat.HundredFists);
        }

        private static void InnerHealing(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.InnerHealing)
                .Name("Inner Healing")
                .Description("Restores your HP.")

                .AddPerkLevel()
                .Description("Restores your HP by 10% of maximum.")
                .RequirementSkill(SkillType.Chi, 5)
                .Price(3)
                .GrantsFeat(Feat.InnerHealing1)

                .AddPerkLevel()
                .Description("Restores your HP by 20% of maximum.")
                .RequirementSkill(SkillType.Chi, 10)
                .Price(3)
                .GrantsFeat(Feat.InnerHealing2)

                .AddPerkLevel()
                .Description("Restores your HP by 30% of maximum.")
                .RequirementSkill(SkillType.Chi, 15)
                .Price(3)
                .GrantsFeat(Feat.InnerHealing3)

                .AddPerkLevel()
                .Description("Restores your HP by 40% of maximum.")
                .RequirementSkill(SkillType.Chi, 20)
                .Price(4)
                .GrantsFeat(Feat.InnerHealing4)

                .AddPerkLevel()
                .Description("Restores your HP by 50% of maximum.")
                .RequirementSkill(SkillType.Chi, 25)
                .Price(4)
                .GrantsFeat(Feat.InnerHealing5);
        }

        private static void Valor(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.Valor)
                .Name("Valor")
                .Description("Restores your party members' HP.")

                .AddPerkLevel()
                .Description("Restores your party members' HP by 20% of maximum.")
                .RequirementSkill(SkillType.Chi, 35)
                .Price(4)
                .GrantsFeat(Feat.Valor1)

                .AddPerkLevel()
                .Description("Restores your party members' HP by 20% of maximum.")
                .RequirementSkill(SkillType.Chi, 50)
                .RequirementSkill(SkillType.Knuckles, 25)
                .Price(4)
                .GrantsFeat(Feat.Valor2);
        }

        private static void MonkEvasion(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.MonkEvasion)
                .Name("Monk Evasion")
                .Description("Wisdom modifier is added to your AC.")
                
                .AddPerkLevel()
                .Description("Grants the Monk Evasion ability.")
                .RequirementSkill(SkillType.Knuckles, 15)
                .RequirementSkill(SkillType.Chi, 10)
                .Price(4);
        }

        private static void CircleKick(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.CircleKick)
                .Name("Circle Kick")
                .Description("You gain an additional free attack against another, nearby enemy. There is a maximum of one free attack per round.")
                
                .AddPerkLevel()
                .Description("Grants the Circle Kick ability.")
                .RequirementSkill(SkillType.Knuckles, 10)
                .RequirementSkill(SkillType.Chi, 5)
                .Price(2);
        }

        private static void MartialFinesse(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.CircleKick)
                .Name("Martial Finesse")
                .Description("You make melee attack rolls with your DEX if it is higher than your STR. Must be equipped with knuckles.")
                
                .AddPerkLevel()
                .Description("Grants the Martial Finesse ability.")
                .RequirementSkill(SkillType.Knuckles, 10)
                .RequirementSkill(SkillType.Chi, 5)
                .Price(4);
        }

        private static void VitalityBoost(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.VitalityBoost)
                .Name("Vitality Boost")
                .Description("Increases maximum HP.")

                .AddPerkLevel()
                .Description("Increases maximum HP by 15.")
                .RequirementSkill(SkillType.Chi, 10)
                .Price(5)

                .AddPerkLevel()
                .Description("Increases maximum HP by 30.")
                .RequirementSkill(SkillType.Chi, 30)
                .Price(5)

                .AddPerkLevel()
                .Description("Increases maximum HP by 45.")
                .RequirementSkill(SkillType.Chi, 50)
                .Price(5);
        }

        private static void Chakra(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.Chakra)
                .Name("Chakra")
                .Description("Restores the health of a single target.")

                .AddPerkLevel()
                .Description("Restores the health of a single target.")
                .RequirementSkill(SkillType.Chi, 15)
                .Price(4)
                .GrantsFeat(Feat.Chakra1)

                .AddPerkLevel()
                .Description("Restores the health of a single target and removes poison debuffs.")
                .RequirementSkill(SkillType.Chi, 30)
                .Price(4)
                .GrantsFeat(Feat.Chakra2);
        }

        private static void ElectricFist(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.ElectricFist)
                .Name("Electric Fist")
                .Description("Your next melee attack deals electrical damage.")

                .AddPerkLevel()
                .Description("Your next melee attack will deal 2d4 electrical damage.")
                .RequirementSkill(SkillType.Knuckles, 10)
                .RequirementSkill(SkillType.Chi, 5)
                .Price(3)
                .GrantsFeat(Feat.ElectricFist1)

                .AddPerkLevel()
                .Description("Your next melee attack will deal 2d8 electrical damage and has a 50% chance to inflict Static on your target for 30 seconds.")
                .RequirementSkill(SkillType.Knuckles, 30)
                .RequirementSkill(SkillType.Chi, 15)
                .Price(5)
                .GrantsFeat(Feat.ElectricFist2)

                .AddPerkLevel()
                .Description("Your next melee attack will deal 2d8 electrical damage and has a 100% chance to inflict Static on your target for 30 seconds.")
                .RequirementSkill(SkillType.Knuckles, 50)
                .RequirementSkill(SkillType.Chi, 30)
                .Price(5)
                .GrantsFeat(Feat.ElectricFist3);
        }

        private static void SubtleBlow(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Monk, PerkType.SubtleBlow)
                .Name("Subtle Blow")
                .Description("Your melee attacks will restore STM per hit for the next 30 seconds.")

                .AddPerkLevel()
                .Description("Your melee attacks will restore 2 STM per hit for the next 30 seconds.")
                .RequirementSkill(SkillType.Knuckles, 20)
                .RequirementSkill(SkillType.Chi, 20)
                .Price(4)
                .GrantsFeat(Feat.SubtleBlow1)

                .AddPerkLevel()
                .Description("Your melee attacks will restore 4 STM per hit for the next 30 seconds.")
                .RequirementSkill(SkillType.Knuckles, 40)
                .RequirementSkill(SkillType.Chi, 40)
                .Price(4)
                .GrantsFeat(Feat.SubtleBlow2);
        }
    }
}
