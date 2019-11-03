﻿using System;
using System.Globalization;
using NWN.FinalFantasy.Core.NWNX;
using NWN.FinalFantasy.Data;
using NWN.FinalFantasy.Data.Entity;
using static NWN._;

namespace NWN.FinalFantasy.Chat.Command
{
    [CommandDetails("Permanently deletes your character.", CommandPermissionType.Player | CommandPermissionType.DM | CommandPermissionType.Admin)]
    public class Delete : IChatCommand
    {
        /// <summary>
        /// Deletes a player's character. Player must submit the command twice within 30 seconds.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="target"></param>
        /// <param name="targetLocation"></param>
        /// <param name="args"></param>
        public void DoAction(NWGameObject user, NWGameObject target, Location targetLocation, params string[] args)
        {
            string lastSubmission = GetLocalString(user, "DELETE_CHARACTER_LAST_SUBMISSION");
            bool isFirstSubmission = true;

            // Check for the last submission, if any.
            if (!string.IsNullOrWhiteSpace(lastSubmission))
            {
                // Found one, parse it.
                DateTime dateTime = DateTime.Parse(lastSubmission);
                if(DateTime.UtcNow <= dateTime.AddSeconds(30))
                {
                    // Player submitted a second request within 30 seconds of the last one. 
                    // This is a confirmation they want to delete.
                    isFirstSubmission = false;
                }
            }

            // Player hasn't submitted or time has elapsed
            if (isFirstSubmission)
            {
                SetLocalString(user, "DELETE_CHARACTER_LAST_SUBMISSION", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                FloatingTextStringOnCreature(user, "Please confirm your deletion by entering another \"/delete <CD Key>\" command within 30 seconds.");
            }
            else
            {
                var playerID = GetGlobalID(user);
                var entity = DB.Get<Player>(playerID);
                entity.IsDeleted = true;
                DB.Set(entity);

                BootPC(user, "Your character has been deleted.");
                NWNXAdmin.DeletePlayerCharacter(user, true);

            }
        }

        public string ValidateArguments(NWGameObject user, params string[] args)
        {
            if (!GetIsPlayer(user))
                return "You can only delete a player character.";

            string cdKey = GetPCPublicCDKey(user);
            string enteredCDKey = args.Length > 0 ? args[0] : string.Empty;

            if (cdKey != enteredCDKey)
            {
                return "Invalid CD key entered. Please enter the command as follows: \"/delete <CD Key>\". You can retrieve your CD key with the /CDKey chat command.";
            }
            
            return string.Empty;
        }

        public bool RequiresTarget => false;
    }
}
