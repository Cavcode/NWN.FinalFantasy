﻿using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.Event.Door;

// ReSharper disable once CheckNamespace
namespace NWN.Scripts
{
    public class door_on_attacked
    {
        internal static void Main()
        {
            ScriptRunner.RunScriptEvents(NWGameObject.OBJECT_SELF, DoorPrefix.OnAttacked);
        }
    }
}