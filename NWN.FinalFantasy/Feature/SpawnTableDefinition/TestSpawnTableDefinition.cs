﻿using System;
using System.Collections.Generic;
using System.Text;
using NWN.FinalFantasy.Core.NWScript.Enum;
using NWN.FinalFantasy.Service.SpawnService;

namespace NWN.FinalFantasy.Feature.SpawnTableDefinition
{
    public class TestSpawnTableDefinition: ISpawnTableDefinition
    {
        public Dictionary<int, SpawnTable> BuildSpawnTables()
        {
            var builder = SpawnTableBuilder
                .Create(1, "Goblin Spawns")
                .AddSpawn(ObjectType.Creature, "nw_goblina")
                .WithFrequency(50)
                .OnDayOfWeek(DayOfWeek.Saturday)
                .BetweenRealWorldHours(new TimeSpan(18, 40, 0), new TimeSpan(20, 0, 0))
                
                .AddSpawn(ObjectType.Creature, "nw_hobgoblin001")
                .WithFrequency(50)
                .OnDayOfWeek(DayOfWeek.Saturday)
                .BetweenGameHours(13, 14);

            return builder.Build();
        }
    }
}
