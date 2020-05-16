﻿using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.NWScript.Enum;
using NWN.FinalFantasy.Entity;
using NWN.FinalFantasy.Enumeration;
using NWN.FinalFantasy.Service;
using static NWN.FinalFantasy.Core.NWScript.NWScript;

namespace NWN.FinalFantasy.Feature
{
    public static class NaturalRegeneration
    {
        private const int BaseNaturalHPRegeneration = 1;
        private const int BaseNaturalMPRegeneration = 1;
        private const int BaseNaturalStaminaRegeneration = 1;
        private const int NumberRequiredTicks = 5; // 5 ticks * 6 seconds = 30 seconds

        /// <summary>
        /// Handles processing natural HP, MP, and Stamina regeneration.
        /// </summary>
        [NWNEventHandler("interval_pc_6s")]
        public static void HandleNaturalRegeneration()
        {
            var player = OBJECT_SELF;
            var playerId = GetObjectUUID(player);
            var dbPlayer = DB.Get<Player>(playerId);
            dbPlayer.RegenerationTick++;

            if (dbPlayer.RegenerationTick >= NumberRequiredTicks)
            {
                var hpAmount = CalculateHPRegenAmount(player);
                var mpAmount = CalculateMPRegenAmount(player);
                var staminaAmount = CalculateStaminaRegenAmount(player);

                Stat.RestoreMP(player, dbPlayer, mpAmount);
                Stat.RestoreStamina(player, dbPlayer, staminaAmount);

                if (hpAmount > 0 && GetCurrentHitPoints(player) < GetMaxHitPoints(player))
                {
                    ApplyEffectToObject(DurationType.Instant, EffectHeal(hpAmount), player);
                }

                dbPlayer.RegenerationTick = 0;
            }

            DB.Set(playerId, dbPlayer);
        }

        /// <summary>
        /// Calculates the amount of HP to regenerate for a player.
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>Amount of HP to restore.</returns>
        private static int CalculateHPRegenAmount(uint player)
        {
            var conModifier = GetAbilityModifier(AbilityType.Constitution, player);
            return BaseNaturalHPRegeneration + (conModifier > 0 ? conModifier : 0);
        }

        /// <summary>
        /// Calculates the amount of MP to regenerate for a player.
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>Amount of MP to restore.</returns>
        private static int CalculateMPRegenAmount(uint player)
        {
            var clearMindBonus = Perk.GetEffectivePerkLevel(player, PerkType.ClearMind) * 2;
            var clarityBonus = Perk.GetEffectivePerkLevel(player, PerkType.Clarity) * 2;
            var chaModifier = GetAbilityModifier(AbilityType.Charisma, player);
            return BaseNaturalMPRegeneration + (chaModifier > 0 ? chaModifier : 0) + clearMindBonus + clarityBonus;
        }

        /// <summary>
        /// Calculates the amount of Stamina to regenerate for a player.
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>Amount of Stamina to restore.</returns>
        private static int CalculateStaminaRegenAmount(uint player)
        {
            var strModifier = GetAbilityModifier(AbilityType.Strength, player);
            return BaseNaturalStaminaRegeneration + (strModifier > 0 ? strModifier : 0);
        }
    }
}
