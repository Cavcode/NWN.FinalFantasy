﻿using System;
using NWN.FinalFantasy.Core.NWNX;

namespace NWN.FinalFantasy.Core.Dialog
{
    public class OnDialogAction
    {
        internal static void Run(int nodeID)
        {
            NWGameObject player = (_.GetPCSpeaker());
            var playerID = _.GetGlobalID(player);
            PlayerDialog dialog = Conversation.GetActivePlayerDialog(playerID);

            IConversation convo = Conversation.FindConversation(dialog.ActiveDialogName);
            int selectionNumber = nodeID + 1;
            int responseID = nodeID + (DialogConstants.NumberOfResponsesPerPage * dialog.PageOffset);

            if (selectionNumber == DialogConstants.NumberOfResponsesPerPage + 1) // Next page
            {
                dialog.PageOffset = dialog.PageOffset + 1;
            }
            else if (selectionNumber == DialogConstants.NumberOfResponsesPerPage + 2) // Previous page
            {
                dialog.PageOffset = dialog.PageOffset - 1;
            }
            else if (selectionNumber == DialogConstants.NumberOfResponsesPerPage + 3) // Back
            {
                string currentPageName = dialog.CurrentPageName;
                var previous = dialog.NavigationStack.Pop();

                // This might be a little confusing but we're passing the active page as the "old page" to the Back() method.
                // This is because we need to run any dialog-specific clean up prior to moving the conversation backwards.
                convo.Back(player, currentPageName, previous.PageName);

                // Previous page was in a different conversation. Switch to it.
                if (previous.DialogName != dialog.ActiveDialogName)
                {
                    Conversation.Load(player, dialog.DialogTarget, previous.DialogName);
                    dialog = Conversation.GetActivePlayerDialog(playerID);
                    dialog.ResetPage(); 

                    dialog.CurrentPageName = previous.PageName;
                    dialog.PageOffset = 0;
                    // ActiveDialogName will have changed by this point. Get the new conversation.
                    convo = Conversation.FindConversation(dialog.ActiveDialogName);
                    convo.Initialize();
                    _.SetLocalInt(player, "DIALOG_SYSTEM_INITIALIZE_RAN", 1);
                }
                // Otherwise it's in the same conversation. Switch to that.
                else
                {
                    dialog.CurrentPageName = previous.PageName;
                    dialog.PageOffset = 0;
                }
            }
            else if (selectionNumber != DialogConstants.NumberOfResponsesPerPage + 4) // End
            {
                convo.DoAction(player, dialog.CurrentPageName, responseID + 1);
            }
        }
    }
}