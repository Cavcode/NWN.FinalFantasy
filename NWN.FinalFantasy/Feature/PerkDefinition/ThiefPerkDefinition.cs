﻿using System.Collections.Generic;
using NWN.FinalFantasy.Enumeration;
using NWN.FinalFantasy.Service.PerkService;

namespace NWN.FinalFantasy.Feature.PerkDefinition
{
    public class ThiefPerkDefinition: IPerkListDefinition
    {
        public Dictionary<PerkType, PerkDetail> BuildPerks()
        {
            var builder = new PerkBuilder();
            PerfectDodge(builder);
            Opportunist(builder);
            DaggerFinesse(builder);
            Steal(builder);
            Gilfinder(builder);
            TreasureHunter(builder);
            WaspSting(builder);
            Shadowstich(builder);
            LifeSteal(builder);
            SneakAttack(builder);
            Hide(builder);
            Flee(builder);

            return builder.Build();
        }

        private static void PerfectDodge(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.PerfectDodge)
                .Name("Perfect Dodge")
                .Description("Your AC is increased by 50 for 30 seconds.")

                .AddPerkLevel()
                .Description("Grants the Perfect Dodge ability.")
                .RequirementSkill(SkillType.Thievery, 50)
                .RequirementSkill(SkillType.Dagger, 50)
                .RequirementSkill(SkillType.LightArmor, 50)
                .Price(15);
        }

        private static void Opportunist(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.Opportunist)
                .Name("Opportunist")
                .Description("You gain +4 bonus to attack rolls when making an attack of opportunity.")
                
                .AddPerkLevel()
                .Description("Grants the Opportunist ability.")
                .RequirementSkill(SkillType.Dagger, 15)
                .RequirementSkill(SkillType.Thievery, 5)
                .Price(4);
        }

        private static void DaggerFinesse(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.DaggerFinesse)
                .Name("Dagger Finesse")
                .Description("You make melee attack rolls with your DEX if it is higher than your STR. Must be equipped with a dagger.")

                .AddPerkLevel()
                .Description("Grants the Dagger Finesse ability.")
                .RequirementSkill(SkillType.Dagger, 10)
                .RequirementSkill(SkillType.Thievery, 5)
                .Price(4);
        }

        private static void Steal(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.Steal)
                .Name("Steal")
                .Description("Attempt to steal from a selected target.")

                .AddPerkLevel()
                .Description("Attempt to steal from a selected target.")
                .RequirementSkill(SkillType.Thievery, 5)
                .Price(3)

                .AddPerkLevel()
                .Description("Attempt to steal from a selected target.")
                .RequirementSkill(SkillType.Thievery, 15)
                .Price(3)

                .AddPerkLevel()
                .Description("Attempt to steal from a selected target.")
                .RequirementSkill(SkillType.Thievery, 30)
                .Price(3)

                .AddPerkLevel()
                .Description("Attempt to steal from a selected target.")
                .RequirementSkill(SkillType.Thievery, 45)
                .Price(3);
        }

        private static void Gilfinder(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.Gilfinder)
                .Name("Gilfinder")
                .Description("Increases the amount of gil dropped by enemies.")

                .AddPerkLevel()
                .Description("Increases the amount of gil dropped by enemies by 20%.")
                .RequirementSkill(SkillType.Thievery, 25)
                .Price(4)

                .AddPerkLevel()
                .Description("Increases the amount of gil dropped by enemies by 40%.")
                .RequirementSkill(SkillType.Thievery, 40)
                .Price(4);
        }

        private static void TreasureHunter(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.TreasureHunter)
                .Name("Treasure Hunter")
                .Description("Increases the chance of getting treasure.")

                .AddPerkLevel()
                .Description("Increases the chance of getting treasure.")
                .RequirementSkill(SkillType.Thievery, 35)
                .Price(4)

                .AddPerkLevel()
                .Description("Increases the chance of getting treasure.")
                .RequirementSkill(SkillType.Thievery, 50)
                .Price(4);
        }

        private static void WaspSting(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.WaspSting)
                .Name("Wasp Sting")
                .Description("Your next attack poisons your target.")

                .AddPerkLevel()
                .Description("Your next attack poisons your target for 1d4 damage.")
                .RequirementSkill(SkillType.Dagger, 5)
                .Price(2)

                .AddPerkLevel()
                .Description("Your next attack poisons your target for 1d8 damage.")
                .RequirementSkill(SkillType.Dagger, 15)
                .Price(4)

                .AddPerkLevel()
                .Description("Your next attack poisons your target for 2d6 damage.")
                .RequirementSkill(SkillType.Dagger, 25)
                .Price(6);
        }

        private static void Shadowstich(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.Shadowstich)
                .Name("Shadowstich")
                .Description("Your next attack binds your target in place.")

                .AddPerkLevel()
                .Description("Your next attack binds your target for 12 seconds.")
                .RequirementSkill(SkillType.Dagger, 10)
                .Price(2)

                .AddPerkLevel()
                .Description("Your next attack binds your target for 24 seconds.")
                .RequirementSkill(SkillType.Dagger, 20)
                .Price(2);
        }

        private static void LifeSteal(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.LifeSteal)
                .Name("Life Steal")
                .Description("Your next attack steals some HP from your target.")

                .AddPerkLevel()
                .Description("50% of your damage will transfer to HP.")
                .RequirementSkill(SkillType.Dagger, 25)
                .RequirementSkill(SkillType.Thievery, 20)
                .Price(3)

                .AddPerkLevel()
                .Description("100% of your damage will transfer to HP.")
                .RequirementSkill(SkillType.Dagger, 50)
                .RequirementSkill(SkillType.Thievery, 40)
                .Price(3);
        }

        private static void SneakAttack(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.SneakAttack)
                .Name("Sneak Attack")
                .Description("Your next melee attack will do extra damage when striking an enemy from behind.")
                
                .AddPerkLevel()
                .Description("Damage will increase by 50%.")
                .RequirementSkill(SkillType.Thievery, 25)
                .Price(4)

                .AddPerkLevel()
                .Description("Damage will increase by 100%.")
                .RequirementSkill(SkillType.Thievery, 50)
                .Price(4);
        }

        private static void Hide(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.Hide)
                .Name("Hide")
                .Description("You hide from enemies, granting invisibility for a short period of time.")

                .AddPerkLevel()
                .Description("Invisibility lasts between 2 and 5 minutes.")
                .RequirementSkill(SkillType.Thievery, 15)
                .Price(4)

                .AddPerkLevel()
                .Description("Invisibility lasts between 4 and 5 minutes.")
                .RequirementSkill(SkillType.Thievery, 30)
                .Price(2);
        }

        private static void Flee(PerkBuilder builder)
        {
            builder.Create(PerkCategoryType.Thief, PerkType.Flee)
                .Name("Flee")
                .Description("Your movement speed is increased for a short period of time.")

                .AddPerkLevel()
                .Description("Movement speed increased by 40% for 30 seconds.")
                .RequirementSkill(SkillType.Thievery, 25)
                .Price(4)

                .AddPerkLevel()
                .Description("Movement speed increased by 80% for 30 seconds.")
                .RequirementSkill(SkillType.Thievery, 45)
                .Price(4);
        }
    }
}
