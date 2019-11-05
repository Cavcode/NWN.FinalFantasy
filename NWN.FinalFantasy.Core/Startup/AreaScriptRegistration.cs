﻿using System.Collections.Generic;
using NWN.FinalFantasy.Core.Event.Area;
using NWN.FinalFantasy.Core.Message;
using NWN.FinalFantasy.Core.Messaging;
using NWN.FinalFantasy.Core.Utility;
using static NWN._;

namespace NWN.FinalFantasy.Core.Startup
{
    public static class AreaScriptRegistration
    {
        private static readonly List<string> _onEnterScripts = new List<string>();
        private static readonly List<string> _onExitScripts = new List<string>();
        private static readonly List<string> _onHeartbeatScripts = new List<string>();
        private static readonly List<string> _onUserDefinedScripts = new List<string>();

        /// <summary>
        /// Registers this registry and subscribes to associated events.
        /// This should only be called one time within the preload script.
        /// </summary>
        internal static void Register()
        {
            SubscribeEvents();
            LoadAreaScripts();
            AssignScripts();
        }

        /// <summary>
        /// Whenever a new area is created, add the registered scripts to the area.
        /// </summary>
        private static void SubscribeEvents()
        {
            MessageHub.Instance.Subscribe<AreaCreated>((msg) => AssignScripts(msg.Area));
        }

        private static void LoadAreaScripts()
        {
            NWGameObject module = GetModule();
            _onEnterScripts.AddRange(LocalVariableTool.FindByPrefix(module, $"AREA_{AreaScriptPrefix.OnEnter}"));
            _onExitScripts.AddRange(LocalVariableTool.FindByPrefix(module, $"AREA_{AreaScriptPrefix.OnExit}"));
            _onHeartbeatScripts.AddRange(LocalVariableTool.FindByPrefix(module, $"AREA_{AreaScriptPrefix.OnHeartbeat}"));
            _onUserDefinedScripts.AddRange(LocalVariableTool.FindByPrefix(module, $"AREA_{AreaScriptPrefix.OnUserDefined}"));
        }

        /// <summary>
        /// Iterates over all areas in the module and assigns registered scripts to them.
        /// These scripts may come from various sources, such as Startup scripts in other projects.
        /// </summary>
        private static void AssignScripts()
        {
            NWGameObject area = GetFirstArea();

            while(GetIsObjectValid(area))
            {
                AssignScripts(area);

                area = GetNextArea();
            }
        }

        /// <summary>
        /// Assigns registered scripts to a specific area.
        /// These scripts may come from various sources, such as Startup scripts in other projects.
        /// </summary>
        /// <param name="area">The area to assign scripts to.</param>
        internal static void AssignScripts(NWGameObject area)
        {
            foreach (var onEnter in _onEnterScripts)
            {
                var varName = AreaScriptPrefix.OnEnter + LocalVariableTool.GetOpenScriptID(area, AreaScriptPrefix.OnEnter);
                SetLocalString(area, varName, onEnter);
            }

            foreach (var onExit in _onExitScripts)
            {
                var varName = AreaScriptPrefix.OnExit + LocalVariableTool.GetOpenScriptID(area, AreaScriptPrefix.OnExit);
                SetLocalString(area, varName, onExit);
            }

            foreach (var onHeartbeat in _onHeartbeatScripts)
            {
                var varName = AreaScriptPrefix.OnHeartbeat + LocalVariableTool.GetOpenScriptID(area, AreaScriptPrefix.OnHeartbeat);
                SetLocalString(area, varName, onHeartbeat);
            }

            foreach (var onUserDefined in _onUserDefinedScripts)
            {
                var varName = AreaScriptPrefix.OnUserDefined + LocalVariableTool.GetOpenScriptID(area, AreaScriptPrefix.OnUserDefined);
                SetLocalString(area, varName, onUserDefined);
            }

        }

    }
}
