﻿using System;
using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.NWNX;
using NWN.FinalFantasy.Core.NWScript.Enumerations;
using NWN.FinalFantasy.Data.Repository;
using NWN.FinalFantasy.Job.Message;

namespace NWN.FinalFantasy.Job.Event
{
    internal class AdjustClass
    {
        public static void Main()
        {
            var data = Script.GetScriptData<JobChanged>();
            var newJob = data.NewJob;
            var player = NWGameObject.OBJECT_SELF;
            var playerID = _.GetGlobalID(player);
            var playerEntity = PlayerRepo.Get(playerID);
            var jobEntity = JobRepo.Get(playerID, newJob);
            playerEntity.CurrentJob = newJob;

            NWNXCreature.SetClassByPosition(player, ClassPosition.First, newJob);
            NWNXCreature.SetLevelByPosition(player, ClassPosition.First, jobEntity.Level);
            PlayerRepo.Set(playerEntity);
        }
    }
}
