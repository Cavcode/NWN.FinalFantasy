﻿using NWN.FinalFantasy.Core.NWScript.Enumerations;

namespace NWN.FinalFantasy.Chat.Command
{
    [CommandDetails("Plays a read animation.", CommandPermissionType.Player | CommandPermissionType.DM | CommandPermissionType.Admin)]
    public class Read : IChatCommand
    {
        public void DoAction(NWGameObject user, NWGameObject target, Location targetLocation, params string[] args)
        {
            _.AssignCommand(user, () => _.ActionPlayAnimation(AnimationFireForget.Read));
        }

        public string ValidateArguments(NWGameObject user, params string[] args)
        {
            return string.Empty;
        }

        public bool RequiresTarget => false;
    }
}
