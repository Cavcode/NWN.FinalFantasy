﻿using System;
using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.NWScript.Enum;
using NWN.FinalFantasy.Entity;
using NWN.FinalFantasy.Service;
using static NWN.FinalFantasy.Core.NWScript.NWScript;

namespace NWN.FinalFantasy.Feature
{
    public class PersistentLocation
    {
        /// <summary>
        /// Saves a player's position to the database.
        /// </summary>
        /// <param name="player">The player whose data will be stored to the database.</param>
        private static void PerformSave(uint player)
        {
            var area = GetArea(player);
            var position = GetPosition(player);
            var orientation = GetFacing(player);
            var playerID = GetObjectUUID(player);
            var entity = DB.Get<Player>(playerID) ?? new Player();

            entity.LocationX = position.X;
            entity.LocationY = position.Y;
            entity.LocationZ = position.Z;
            entity.LocationOrientation = orientation;
            entity.LocationAreaResref = GetResRef(area);

            DB.Set(playerID, entity);
        }

        /// <summary>
        /// Saves a player's location on area enter.
        /// </summary>
        [NWNEventHandler("area_enter")]
        public static void SaveLocationOnAreaEnter()
        {
            var player = GetEnteringObject();
            var area = GetArea(player);
            var areaResref = GetResRef(area);
            if (!GetIsPC(player) || GetIsDM(player) || areaResref == "ooc_area") return;

            PerformSave(player);
        }

        /// <summary>
        /// Saves a player's location on rest.
        /// </summary>
        [NWNEventHandler("mod_rest")]
        public static void SaveLocationOnRest()
        {
            var player = GetLastPCRested();
            if (!GetIsPC(player) || GetIsDM(player) || GetLastRestEventType() != RestEventType.Started) return;

            PerformSave(player);
        }

        /// <summary>
        /// Saves a player's location on module exit.
        /// </summary>
        [NWNEventHandler("mod_exit")]
        public static void SaveLocationOnModuleExit()
        {
            var player = GetExitingObject();
            if (!GetIsPC(player) || GetIsDM(player)) return;

            PerformSave(player);
        }

        /// <summary>
        /// Loads a player's location if they enter an area with the tag "ooc_area".
        /// </summary>
        [NWNEventHandler("area_enter")]
        public static void LoadLocation()
        {
            var player = GetEnteringObject();
            var area = GetArea(player);
            var areaTag = GetTag(area);

            // Must be a player entering the OOC entry area, otherwise we exit early.
            if (!GetIsPC(player) || GetIsDM(player) || areaTag != "ooc_area") return;

            var playerID = GetObjectUUID(player);
            var dbPlayer = DB.Get<Player>(playerID);

            if (dbPlayer == null) return;

            var locationArea = Cache.GetAreaByResref(dbPlayer.LocationAreaResref);
            var position = Vector(dbPlayer.LocationX, dbPlayer.LocationY, dbPlayer.LocationZ);

            var location = Location(locationArea, position, dbPlayer.LocationOrientation);

            AssignCommand(player, () =>
            {
                ActionJumpToLocation(location);
            });
        }
    }
}
