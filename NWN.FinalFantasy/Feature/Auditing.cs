﻿using NWN.FinalFantasy.Core;
using NWN.FinalFantasy.Core.NWNX;
using NWN.FinalFantasy.Core.NWNX.Enum;
using NWN.FinalFantasy.Core.NWScript;
using NWN.FinalFantasy.Service;
using static NWN.FinalFantasy.Core.NWScript.NWScript;

namespace NWN.FinalFantasy.Feature
{
    public class Auditing
    {
        /// <summary>
        /// Writes an audit log when a player connects to the server.
        /// </summary>
        [NWNEventHandler("mod_enter")]
        public static void AuditClientConnection()
        {
            

            var player = GetEnteringObject();
            string ipAddress = GetPCIPAddress(player);
            string cdKey = GetPCPublicCDKey(player);
            string account = GetPCPlayerName(player);
            string pcName = GetName(player);

            var log = $"{pcName} - {account} - {cdKey} - {ipAddress}: Connected to server";
            Log.Write(LogGroup.Connection, log);
        }

        /// <summary>
        /// Writes an audit log when a player disconnects from the server.
        /// </summary>
        [NWNEventHandler("mod_exit")]
        public static void AuditClientDisconnection()
        {
            var player = GetEnteringObject();
            string ipAddress = GetPCIPAddress(player);
            string cdKey = GetPCPublicCDKey(player);
            string account = GetPCPlayerName(player);
            string pcName = GetName(player);

            var log = $"{pcName} - {account} - {cdKey} - {ipAddress}: Connected to server";
            Log.Write(LogGroup.Connection, log);
        }

        /// <summary>
        /// Writes an audit log when a player sends a chat message.
        /// </summary>
        [NWNEventHandler("on_nwnx_chat")]
        public static void AuditChatMessages()
        {
            static string BuildRegularLog()
            {
                var sender = Chat.GetSender();
                var chatChannel = Chat.GetChannel();
                var message = Chat.GetMessage();
                var ipAddress = GetPCIPAddress(sender);
                var cdKey = GetPCPublicCDKey(sender);
                var account = GetPCPlayerName(sender);
                var pcName = GetName(sender);

                var logMessage = $"{pcName} - {account} - {cdKey} - {ipAddress} - {chatChannel}: {message}";

                return logMessage;
            }

            static string BuildTellLog()
            {
                var sender = Chat.GetSender();
                var receiver = Chat.GetTarget();
                var chatChannel = Chat.GetChannel();
                var message = Chat.GetMessage();
                var senderIPAddress = GetPCIPAddress(sender);
                var senderCDKey = GetPCPublicCDKey(sender);
                var senderAccount = GetPCPlayerName(sender);
                var senderPCName = GetName(sender);
                var receiverIPAddress = GetPCIPAddress(receiver);
                var receiverCDKey = GetPCPublicCDKey(receiver);
                var receiverAccount = GetPCPlayerName(receiver);
                var receiverPCName = GetName(receiver);

                var logMessage = $"{senderPCName} - {senderAccount} - {senderCDKey} - {senderIPAddress} - {chatChannel} (SENT TO {receiverPCName} - {receiverAccount} - {receiverCDKey} - {receiverIPAddress}): {message}";
                return logMessage;
            }

            var channel = Chat.GetChannel();
            string log;

            // We don't log server messages because there isn't a good way to filter them.
            if (channel == ChatChannel.ServerMessage) return;

            if (channel == ChatChannel.DMTell ||
                channel == ChatChannel.PlayerTell)
            {
                log = BuildTellLog();
            }
            else
            {
                log = BuildRegularLog();
            }

            Log.Write(LogGroup.Chat, log);
        }
    }
}
