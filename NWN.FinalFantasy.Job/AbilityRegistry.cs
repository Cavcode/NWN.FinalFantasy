﻿using System.Collections.Generic;
using NWN.FinalFantasy.Core.NWScript.Enumerations;
using NWN.FinalFantasy.Job.Ability;
using NWN.FinalFantasy.Job.Contracts;

namespace NWN.FinalFantasy.Job
{
    internal class AbilityRegistry
    {
        private static readonly Dictionary<Feat, IAbility> _abilityRegistry = new Dictionary<Feat, IAbility>();

        internal static void Register()
        {
            _abilityRegistry[Feat.TestAbility] = new TestAbility();
        }

        /// <summary>
        /// Returns true if the specified feat is registered.
        /// </summary>
        /// <param name="feat">The feat to check the registration of</param>
        /// <returns>true if registered, false otherwise</returns>
        public static bool IsRegistered(Feat feat)
        {
            return _abilityRegistry.ContainsKey(feat);
        }

        /// <summary>
        /// Retrieves an ability by the feat from the registry.
        /// </summary>
        /// <param name="feat">The feat to use as the key</param>
        /// <returns>An ability associated with the specified feat</returns>
        public static IAbility Get(Feat feat)
        {
            return _abilityRegistry[feat];
        }
    }
}
