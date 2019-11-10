﻿using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Job.Event;

namespace NWN.FinalFantasy.Job.Scripts.ApplyFeats
{
    internal class OnJobChanged: ApplyFeatsBase
    {
        public static void Main()
        {
            var data = Script.GetScriptData<JobChanged>();
            var player = data.Player;
            Apply(player);
        }
    }
}
