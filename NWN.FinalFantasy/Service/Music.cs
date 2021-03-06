﻿using System;
using System.Collections.Generic;
using System.Linq;
using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.NWNX;
using static NWN.FinalFantasy.Core.NWScript.NWScript;

namespace NWN.FinalFantasy.Service
{
    public class Music
    {
        private static readonly Dictionary<int, Song> _songs = new Dictionary<int,Song>();
        private static readonly Dictionary<int, Song> _playerBattleSongs = new Dictionary<int, Song>();

        public class Song
        {
            public int ID { get; }
            public string DisplayName { get; }

            public Song(int id, string displayName)
            {
                ID = id;
                DisplayName = displayName;
            }
        }

        /// <summary>
        /// When the module loads, read the ambientmusic.2da file for all active songs.
        /// Add these to the cache.
        /// </summary>
        [NWNEventHandler("mod_load")]
        public static void LoadSongList()
        {
            const string File = "ambientmusic";
            int rowCount = Util.Get2DARowCount(File);

            for (int row = 0; row < rowCount; row++)
            {
                var description = Get2DAString(File, "Description", row);
                var displayName = Get2DAString(File, "DisplayName", row);
                var isAvailableAsBattleSong = Get2DAString(File, "PlayerBattleSong", row) == "1";

                // Skip record if a name cannot be determined.
                if (string.IsNullOrWhiteSpace(description) &&
                    string.IsNullOrWhiteSpace(displayName)) continue;

                string name = string.IsNullOrWhiteSpace(description) ?
                    displayName :
                    GetStringByStrRef(Convert.ToInt32(description));

                var song = new Song(row, name);
                _songs[row] = song;

                if (isAvailableAsBattleSong)
                {
                    _playerBattleSongs[row] = song;
                }
            }
        }

        /// <summary>
        /// When a player enters the server, if a battle theme has been selected by the player,
        /// apply the battle theme to the player.
        /// </summary>
        [NWNEventHandler("area_enter")]
        public static void ApplyBattleThemeToPlayer()
        {
            var player = GetEnteringObject();
            if (!GetIsPC(player) || GetIsDM(player)) return;

            var playerId = GetObjectUUID(player);
            var dbPlayer = DB.Get<Entity.Player>(playerId);
            if (dbPlayer.Settings.BattleThemeId == null) return;
            var area = OBJECT_SELF;
            var battleThemeId = dbPlayer.Settings.BattleThemeId ?? MusicBackgroundGetBattleTrack(area);

            Player.MusicBackgroundChangeTimeToggle(player, MusicBackgroundGetDayTrack(area), false);
            Player.MusicBackgroundChangeTimeToggle(player, MusicBackgroundGetNightTrack(area), true);
            Player.MusicBattleChange(player, battleThemeId);
        }

        /// <summary>
        /// Retrieves all of the songs loaded from the 2DA file.
        /// </summary>
        /// <returns>A list of available songs.</returns>
        public static List<Song> GetAllSongs()
        {
            return _songs.Values.ToList();
        }

        /// <summary>
        /// Retrieves all battle songs loaded from the 2DA file.
        /// These battle songs are able to be selected by players.
        /// </summary>
        /// <returns>A list of available battle songs players can pick from.</returns>
        public static Dictionary<int, Song> GetBattleSongs()
        {
            return _playerBattleSongs.ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
