﻿using NWN.FinalFantasy.Core.Event;

// ReSharper disable once CheckNamespace
namespace NWN.Scripts
{
    public class door_on_death
    {
        public static void Main()
        {
            ScriptRunner.RunScriptEvents(NWGameObject.OBJECT_SELF, "ON_DEATH_");
        }
    }
}