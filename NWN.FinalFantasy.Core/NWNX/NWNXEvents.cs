﻿using System;
using System.Collections.Generic;
using NWN.FinalFantasy.Core.NWScript.Enumerations;

namespace NWN.FinalFantasy.Core.NWNX
{
    public static class NWNXEvents
    {
        /// <summary>
        /// Scripts can subscribe to events.
        /// Some events are dispatched via the NWNX plugin (see NWNX_EVENTS_EVENT_* constants).
        /// Others can be signalled via script code (see NWNX_Events_SignalEvent).
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="script"></param>
        public static void SubscribeEvent(string evt, string script)
        {
            NWNXCore.NWNX_PushArgumentString("NWNX_Events", "SUBSCRIBE_EVENT", script);
            NWNXCore.NWNX_PushArgumentString("NWNX_Events", "SUBSCRIBE_EVENT", evt);
            NWNXCore.NWNX_CallFunction("NWNX_Events", "SUBSCRIBE_EVENT");
        }

        /// <summary>
        /// Pushes event data at the provided tag, which subscribers can access with GetEventData.
        /// This should be called BEFORE SignalEvent.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="data"></param>
        public static void PushEventData(string tag, string data)
        {
            NWNXCore.NWNX_PushArgumentString("NWNX_Events", "PUSH_EVENT_DATA", data);
            NWNXCore.NWNX_PushArgumentString("NWNX_Events", "PUSH_EVENT_DATA", tag);
            NWNXCore.NWNX_CallFunction("NWNX_Events", "PUSH_EVENT_DATA");
        }

        /// <summary>
        /// Signals an event. This will dispatch a notification to all subscribed handlers.
        /// Returns TRUE if anyone was subscribed to the event, FALSE otherwise.
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SignalEvent(string evt, NWGameObject target)
        {
            NWNXCore.NWNX_PushArgumentObject("NWNX_Events", "SIGNAL_EVENT", target);
            NWNXCore.NWNX_PushArgumentString("NWNX_Events", "SIGNAL_EVENT", evt);
            NWNXCore.NWNX_CallFunction("NWNX_Events", "SIGNAL_EVENT");
            return NWNXCore.NWNX_GetReturnValueInt("NWNX_Events", "SIGNAL_EVENT");
        }

        /// <summary>
        /// Retrieves the event data for the currently executing script.
        /// THIS SHOULD ONLY BE CALLED FROM WITHIN AN EVENT HANDLER.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetEventDataString(string tag)
        {
            NWNXCore.NWNX_PushArgumentString("NWNX_Events", "GET_EVENT_DATA", tag);
            NWNXCore.NWNX_CallFunction("NWNX_Events", "GET_EVENT_DATA");
            return NWNXCore.NWNX_GetReturnValueString("NWNX_Events", "GET_EVENT_DATA");
        }


        /// <summary>
        /// 
        /// Skips execution of the currently executing event.
        /// If this is a NWNX event, that means that the base function call won't be called.
        /// This won't impact any other subscribers, nor dispatch for before / after functions.
        /// For example, if you are subscribing to NWNX_ON_EXAMINE_OBJECT_BEFORE, and you skip ...
        /// - The other subscribers will still be called.
        /// - The original function in the base game will be skipped.
        /// - The matching after event (NWNX_ON_EXAMINE_OBJECT_AFTER) will also be executed.
        ///
        /// THIS SHOULD ONLY BE CALLED FROM WITHIN AN EVENT HANDLER.
        /// ONLY WORKS WITH THE FOLLOWING EVENTS:
        /// - Feat events
        /// - Item events
        /// - Healer's Kit event
        /// - CombatMode events
        /// - Party events
        /// - Skill events
        /// - Map events
        /// - Listen/Spot Detection events
        /// - Polymorph events
        /// - DMAction events
        /// - Client connect event
        /// - Spell events
        /// - QuickChat events
        /// - Barter event (START only)
        /// - Trap events
        /// - Sticky Player Name event
        /// </summary>
        public static void SkipEvent()
        {
            NWNXCore.NWNX_CallFunction("NWNX_Events", "SKIP_EVENT");
        }

        /// <summary>
        /// Set the return value of the event.
        ///
        /// THIS SHOULD ONLY BE CALLED FROM WITHIN AN EVENT HANDLER.
        /// ONLY WORKS WITH THE FOLLOWING EVENTS:
        /// - Healer's Kit event
        /// - Listen/Spot Detection events -> "1" or "0"
        /// - OnClientConnectBefore -> Reason for disconnect if skipped
        /// - Ammo Reload event -> Forced ammunition returned
        /// - Trap events -> "1" or "0"
        /// - Sticky Player Name event -> "1" or "0"
        /// </summary>
        /// <param name="data"></param>
        public static void SetEventResult(string data)
        {
            NWNXCore.NWNX_PushArgumentString("NWNX_Events", "EVENT_RESULT", data);
            NWNXCore.NWNX_CallFunction("NWNX_Events", "EVENT_RESULT");
        }

        /// <summary>
        /// Returns the current event name
        /// THIS SHOULD ONLY BE CALLED FROM WITHIN AN EVENT HANDLER.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentEvent()
        {
            NWNXCore.NWNX_CallFunction("NWNX_Events", "GET_CURRENT_EVENT");
            return NWNXCore.NWNX_GetReturnValueString("NWNX_Events", "GET_CURRENT_EVENT");
        }

        private static int GetEventDataInt(string tag)
        {
            string data = GetEventDataString(tag);
            return Convert.ToInt32(data);
        }

        private static bool GetEventDataBoolean(string tag)
        {
            int data = GetEventDataInt(tag);
            return data == 1;
        }

        private static float GetEventDataFloat(string tag)
        {
            string data = GetEventDataString(tag);
            return (float)Convert.ToDouble(data);
        }

        private static NWGameObject GetEventDataObject(string tag)
        {
            string data = GetEventDataString(tag);
            return NWNXObject.StringToObject(data);
        }

        // The following methods are specific to our implementation which makes the API a little easier to use.
        // Pattern is: "Event_Action()"

        public static int OnFeatUsed_GetFeatID()
        {
            return GetEventDataInt("FEAT_ID");
        }

        public static int OnFeatUsed_GetSubFeatID()
        {
            return GetEventDataInt("SUBFEAT_ID");
        }

        public static NWGameObject OnFeatUsed_GetTarget()
        {
            return GetEventDataObject("TARGET_OBJECT_ID");
        }

        public static Location OnFeatUsed_GetTargetLocation()
        {
            return _.Location(
                    OnFeatUsed_GetArea(),
                    _.Vector(OnFeatUsed_GetTargetPositionX(), OnFeatUsed_GetTargetPositionY(), OnFeatUsed_GetTargetPositionZ()),
                    0.0f
            );
        }

        public static NWGameObject OnFeatUsed_GetArea()
        {
            return GetEventDataObject("AREA_OBJECT_ID");
        }

        public static float OnFeatUsed_GetTargetPositionX()
        {
            return GetEventDataFloat("TARGET_POSITION_X");
        }

        public static float OnFeatUsed_GetTargetPositionY()
        {
            return GetEventDataFloat("TARGET_POSITION_Y");
        }

        public static float OnFeatUsed_GetTargetPositionZ()
        {
            return GetEventDataFloat("TARGET_POSITION_Z");
        }

        public static NWGameObject OnItemUsed_GetItem()
        {
            return GetEventDataObject("ITEM_OBJECT_ID");
        }

        public static NWGameObject OnItemUsed_GetTarget()
        {
            return GetEventDataObject("TARGET_OBJECT_ID");
        }

        public static Location OnItemUsed_GetTargetLocation()
        {
            NWGameObject user = NWGameObject.OBJECT_SELF;
            var x = GetEventDataFloat("TARGET_POSITION_X");
            var y = GetEventDataFloat("TARGET_POSITION_Y");
            var z = GetEventDataFloat("TARGET_POSITION_Z");
            var vector = _.Vector(x, y, z);

            return _.Location(_.GetArea(user), vector, 0.0f);
        }

        public static int OnItemUsed_GetItemPropertyIndex()
        {
            return GetEventDataInt("ITEM_PROPERTY_INDEX");
        }

        public static int OnItemUsed_GetValue2()
        {
            return GetEventDataInt("TEST_VALUE_2");
        }

        public static NWGameObject OnExamineObject_GetTarget()
        {
            return GetEventDataObject("EXAMINEE_OBJECT_ID");
        }

        public static int OnCastSpell_GetSpellID()
        {
            return GetEventDataInt("SPELL_ID");
        }

        public static int OnCastSpell_GetTargetPositionX()
        {
            return GetEventDataInt("TARGET_POSITION_X");
        }

        public static int OnCastSpell_GetTargetPositionY()
        {
            return GetEventDataInt("TARGET_POSITION_Y");
        }

        public static int OnCastSpell_GetTargetPositionZ()
        {
            return GetEventDataInt("TARGET_POSITION_Z");
        }

        public static NWGameObject OnCastSpell_GetTarget()
        {
            return GetEventDataObject("TARGET_OBJECT_ID");
        }

        public static int OnCastSpell_GetMultiClass()
        {
            return GetEventDataInt("MULTI_CLASS");
        }

        public static NWGameObject OnCastSpell_GetItem()
        {
            return GetEventDataObject("ITEM_OBJECT_ID");
        }

        public static bool OnCastSpell_GetSpellCountered()
        {
            return GetEventDataBoolean("SPELL_COUNTERED");
        }

        public static bool OnCastSpell_GetCounteringSpell()
        {
            return GetEventDataBoolean("COUNTERING_SPELL");
        }

        public static int OnCastSpell_GetProjectilePathType()
        {
            return GetEventDataInt("PROJECTILE_PATH_TYPE");
        }

        public static bool OnCastSpell_IsInstantSpell()
        {
            return GetEventDataBoolean("IS_INSTANT_SPELL");
        }

        public static NWGameObject OnCombatRoundStart_GetTarget()
        {
            return GetEventDataObject("TARGET_OBJECT_ID");
        }

        public static int OnDMGiveXP_GetAmount()
        {
            return GetEventDataInt("AMOUNT");
        }

        public static NWGameObject OnDMGiveXP_GetTarget()
        {
            return GetEventDataObject("OBJECT");
        }

        public static int OnDMGiveLevels_GetAmount()
        {
            return GetEventDataInt("AMOUNT");
        }

        public static NWGameObject OnDMGiveLevels_GetTarget()
        {
            return GetEventDataObject("OBJECT");
        }

        public static int OnDMGiveGold_GetAmount()
        {
            return GetEventDataInt("AMOUNT");
        }

        public static NWGameObject OnDMGiveGold_GetTarget()
        {
            return GetEventDataObject("OBJECT");
        }

        public static NWGameObject OnDMSpawnObject_GetArea()
        {
            return GetEventDataObject("AREA");
        }
        
        public static NWGameObject OnDMSpawnObject_GetObject()
        {
            return GetEventDataObject("OBJECT");
        }

        public static ObjectType OnDMSpawnObject_GetObjectType()
        {
            // For whatever reason, NWNX uses different object type IDs from standard NWN.
            // I don't want to deal with this nonsense so we'll convert to the correct IDs here.
            int nwnxObjectTypeID = GetEventDataInt("OBJECT_TYPE");

            switch (nwnxObjectTypeID)
            {
                case 5: return ObjectType.Creature;
                case 6: return ObjectType.Item;
                case 7: return ObjectType.Trigger;
                case 9: return ObjectType.Placeable;
                case 12: return ObjectType.Waypoint;
                case 13: return ObjectType.Encounter;
            }

            throw new Exception("Invalid object type: " + nwnxObjectTypeID);
        }

        public static float OnDMSpawnObject_GetPositionX()
        {
            return GetEventDataFloat("POS_X");
        }
        public static float OnDMSpawnObject_GetPositionY()
        {
            return GetEventDataFloat("POS_Y");
        }
        public static float OnDMSpawnObject_GetPositionZ()
        {
            return GetEventDataFloat("POS_Z");
        }

        public static GameDifficulty OnDMChangeDifficulty_GetDifficultySetting()
        {
            return (GameDifficulty) GetEventDataInt("DIFFICULTY_SETTING");
        }

        public static NWGameObject OnDMDisableTrap_GetTrap()
        {
            return GetEventDataObject("TARGET");
        }

        public static List<NWGameObject> DMEvents_GetTargetList(string tagPrefix = "TARGET_")
        {
            var targetCount = GetEventDataInt("NUM_TARGETS");
            var result = new List<NWGameObject>();

            for (int x = 1; x <= targetCount; x++)
            {
                var target = GetEventDataObject(tagPrefix + x);
                result.Add(target);
            }

            return result;
        }

        public static NWGameObject OnDMGiveItem_GetTarget()
        {
            return GetEventDataObject("TARGET");
        }

        public static NWGameObject OnDMGiveItem_GetItem()
        {
            return GetEventDataObject("ITEM");
        }

        public static NWGameObject OnDMJumpToPoint_GetArea()
        {
            return GetEventDataObject("TARGET_AREA");
        }

        public static float OnDMJumpToPoint_GetX()
        {
            return GetEventDataFloat("POS_X");
        }

        public static float OnDMJumpToPoint_GetY()
        {
            return GetEventDataFloat("POS_Y");
        }

        public static float OnDMJumpToPoint_GetZ()
        {
            return GetEventDataFloat("POS_Z");
        }

        public static NWGameObject OnDMPossess_GetTarget()
        {
            return GetEventDataObject("TARGET");
        }
        
    }
}
