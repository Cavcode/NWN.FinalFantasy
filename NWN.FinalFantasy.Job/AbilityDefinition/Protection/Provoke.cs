﻿using NWN.FinalFantasy.AI;
using NWN.FinalFantasy.Core.NWScript.Enumerations;
using NWN.FinalFantasy.Job.Enumeration;

namespace NWN.FinalFantasy.Job.AbilityDefinition.Protection
{
    internal class Provoke: IAbilityDefinition
    {
        public string Name => "Provoke";
        public Feat Feat => Feat.Provoke;
        public AbilityCategory Category => AbilityCategory.Combat;
        public AbilityGroup Group => AbilityGroup.Individual;
        public bool IsEquippable => true;
        public int APRequired => 50;

        public JobLevel[] JobRequirements => new[]
        {
            new JobLevel(ClassType.Warrior, 5), 
        };

        public int MP(NWGameObject user)
        {
            return 0;
        }

        public string CanUse(NWGameObject user, NWGameObject target)
        {
            if (!_.GetIsNPC(target))
                return "This ability can only be used on NPCs.";

            return null;
        }

        public float CastingTime(NWGameObject user)
        {
            return 0;
        }

        public float CooldownTime(NWGameObject user)
        {
            return 30.0f;
        }

        public void Apply(NWGameObject user)
        {
        }

        public void Impact(NWGameObject user, NWGameObject target)
        {
            Enmity.AdjustEnmity(target, user, 100);
        }
    }
}
