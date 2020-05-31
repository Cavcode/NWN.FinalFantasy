﻿using System.Collections.Generic;
using NWN.FinalFantasy.Core.NWScript.Enum;
using NWN.FinalFantasy.Enumeration;
using NWN.FinalFantasy.Service.StatusEffectService;
using static NWN.FinalFantasy.Core.NWScript.NWScript;
using Random = NWN.FinalFantasy.Service.Random;

namespace NWN.FinalFantasy.Feature.StatusEffectDefinition
{
    public class PoisonStatusEffectDefinition: IStatusEffectListDefinition
    {
        public Dictionary<StatusEffectType, StatusEffectDetail> BuildStatusEffects()
        {
            var builder = new StatusEffectBuilder();
            Poison1(builder);
            Poison2(builder);
            Poison3(builder);

            return builder.Build();
        }

        private static void Poison1(StatusEffectBuilder builder)
        {
            builder.Create(StatusEffectType.Poison1)
                .Name("Poison I")
                .EffectIcon(137)
                .TickAction((activator, target) =>
                {
                    var damage = Random.D4(1);

                    AssignCommand(activator, () =>
                    {
                        ApplyEffectToObject(DurationType.Instant, EffectDamage(damage, DamageType.Acid), target);
                    });
                });
        }

        private static void Poison2(StatusEffectBuilder builder)
        {
            builder.Create(StatusEffectType.Poison2)
                .Name("Poison II")
                .EffectIcon(138)
                .TickAction((activator, target) =>
                {
                    var damage = Random.D8(1);

                    AssignCommand(activator, () =>
                    {
                        ApplyEffectToObject(DurationType.Instant, EffectDamage(damage, DamageType.Acid), target);
                    });
                });
        }

        private static void Poison3(StatusEffectBuilder builder)
        {
            builder.Create(StatusEffectType.Poison3)
                .Name("Poison III")
                .EffectIcon(152)
                .TickAction((activator, target) =>
                {
                    var damage = Random.D6(2);

                    AssignCommand(activator, () =>
                    {
                        ApplyEffectToObject(DurationType.Instant, EffectDamage(damage, DamageType.Acid), target);
                    });
                });
        }
    }
}
