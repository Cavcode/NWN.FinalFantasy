﻿using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.Event.AreaOfEffect;

// ReSharper disable once CheckNamespace
namespace NWN.Scripts
{
    public class aoe_on_userdef
    {
        internal static void Main()
        {
            Script.RunScriptEvents(NWGameObject.OBJECT_SELF, AreaOfEffectPrefix.OnUserDefined);
        }
    }
}