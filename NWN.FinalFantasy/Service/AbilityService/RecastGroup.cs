﻿using System;

namespace NWN.FinalFantasy.Service.AbilityService
{
    // Note: Short names are what's displayed on the recast Gui element. They are limited to 14 characters.
    public enum RecastGroup
    {
        [RecastGroup("Invalid", "Invalid")]
        Invalid = 0,
        [RecastGroup("One-Hour Ability", "1-Hr Ability")] 
        OneHourAbility = 1,
        [RecastGroup("Fire", "Fire")]
        Fire = 2,
        [RecastGroup("Blizzard", "Blizzard")]
        Blizzard = 3,
        [RecastGroup("Thunder", "Thunder")]
        Thunder = 4,
        [RecastGroup("Warp", "Warp")]
        Warp = 5,
        [RecastGroup("Blaze Spikes", "Blaze Spikes")]
        BlazeSpikes = 5,
        [RecastGroup("Elemental Spread", "Elem. Spread")]
        ElementalSpread = 6,
        [RecastGroup("Sleep", "Sleep")]
        Sleep = 7,
        [RecastGroup("Subtle Blow", "Subtle Blow")]
        SubtleBlow = 8,
        [RecastGroup("Inner Healing", "Inner Healing")]
        InnerHealing = 9,
        [RecastGroup("Valor", "Valor")]
        Valor = 10,
        [RecastGroup("Chakra", "Chakra")]
        Chakra = 11,
        [RecastGroup("Electric Fist", "Elec. Fist")]
        ElectricFist = 12,
        [RecastGroup("Defender", "Defender")]
        Defender = 13,
        [RecastGroup("Ironclad", "Ironclad")]
        Ironclad = 14,
        [RecastGroup("Spiked Defense", "Spiked Def.")]
        SpikedDefense = 15,
        [RecastGroup("Provoke I", "Provoke I")]
        Provoke1 = 16,
        [RecastGroup("Provoke II", "Provoke II")]
        Provoke2 = 17,
        [RecastGroup("Flash", "Flash")]
        Flash = 18,
        [RecastGroup("Bash", "Bash")]
        Bash = 19,
        [RecastGroup("Cover", "Cover")]
        Cover = 20,
        [RecastGroup("Flee", "Flee")]
        Flee = 21,
        [RecastGroup("Hide", "Hide")]
        Hide = 22,
        [RecastGroup("Wasp Sting", "Wasp Sting")]
        WaspSting = 23,
        [RecastGroup("Shadowstitch", "Shadowstitch")]
        Shadowstitch = 24,
        [RecastGroup("Sneak Attack", "Sneak Atk.")]
        SneakAttack = 25,
        [RecastGroup("Life Steal", "Life Steal")]
        LifeSteal = 26,
        [RecastGroup("Steal", "Steal")]
        Steal = 27,
        [RecastGroup("Regen", "Regen")]
        Regen = 28,
        [RecastGroup("Raise", "Raise")]
        Raise = 29,
        [RecastGroup("Poisona", "Poisona")]
        Poisona = 30,
        [RecastGroup("Teleport", "Teleport")]
        Teleport = 31,
    }

    public class RecastGroupAttribute: Attribute
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public RecastGroupAttribute(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }
    }
}
