﻿using NWN.FinalFantasy.Core.Event;

// ReSharper disable once CheckNamespace
namespace NWN.Scripts
{
    public class crea_on_convo
    {
        public static void Main()
        {
            ScriptRunner.RunScriptEvents(NWGameObject.OBJECT_SELF, "ON_CONVERSATION_");
        }
    }
}