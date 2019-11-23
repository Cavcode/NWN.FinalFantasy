﻿using System;
using NWN.FinalFantasy.Core.Event;
using NWN.FinalFantasy.Core.Message;
using NWN.FinalFantasy.Core.Messaging;
using NWN.FinalFantasy.Core.NWScript.Enumerations;

// ReSharper disable once CheckNamespace
namespace NWN
{
    public partial class _
    {
        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptArea nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }
        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptAreaOfEffect nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptCreature nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptDoor nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptEncounter nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptModule nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptPlaceable nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptStore nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Returns the event script for the given object and handler.
        ///  Will return "" if unset, the object is invalid, or the object cannot
        ///  have the requested handler.
        /// </summary>
        public static string GetEventScript(NWGameObject oObject, EventScriptTrigger nHandler)
        {
            return GetEventScript(oObject, (int)nHandler);
        }

        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptArea nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }

        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptAreaOfEffect nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }

        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptCreature nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }

        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptDoor nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }

        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptEncounter nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }
        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptModule nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }
        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptPlaceable nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }
        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptStore nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }
        /// <summary>
        ///  Sets the given event script for the given object and handler.
        ///  Returns 1 on success, 0 on failure.
        ///  Will fail if oObject is invalid or does not have the requested handler.
        /// </summary>
        public static bool SetEventScript(NWGameObject oObject, EventScriptTrigger nHandler, string sScript)
        {
            return SetEventScript(oObject, (int)nHandler, sScript);
        }

        /// <summary>
        /// Grants nXpAmount to the creature's current job.
        /// </summary>
        /// <param name="oCreature">The creature receiving the XP</param>
        /// <param name="nXpAmount">The amount of XP to give the creature's current job.</param>
        public static void GiveJobXP(NWGameObject oCreature, int nXpAmount)
        {
            Internal.NativeFunctions.StackPushInteger(nXpAmount);
            NWN.Internal.NativeFunctions.StackPushObject(oCreature != null ? oCreature.Self : NWGameObject.OBJECT_INVALID);
            Internal.NativeFunctions.CallBuiltIn(393);
            Publish.CustomEvent(oCreature, CustomEventPrefix.OnGainJobXP, new JobXPGained(oCreature, nXpAmount));
        }

        /// <summary>
        ///  Display floaty text above the specified creature.
        ///  The text will also appear in the chat buffer of each player that receives the
        ///  floaty text.
        ///  - sStringToDisplay: String
        ///  - oCreatureToFloatAbove
        ///  - bBroadcastToFaction: If this is true then only creatures in the same faction
        ///    as oCreatureToFloatAbove
        ///    will see the floaty text, and only if they are within range (30 metres).
        /// </summary>
        public static void FloatingTextStringOnCreature(NWGameObject oCreatureToFloatAbove, string sStringToDisplay, bool bBroadcastToFaction = false)
        {
            // Note: this method's parameters have been moved around to make the API easier to use. The order in which they are pushed to NWN have not been modified.
            Internal.NativeFunctions.StackPushInteger(bBroadcastToFaction ? 1 : 0);
            Internal.NativeFunctions.StackPushObject(oCreatureToFloatAbove != null ? oCreatureToFloatAbove.Self : NWGameObject.OBJECT_INVALID);
            Internal.NativeFunctions.StackPushString(sStringToDisplay);
            Internal.NativeFunctions.CallBuiltIn(526);
        }

        /// <summary>
        /// Returns the total level of a creature by adding up to three of their classes together.
        /// Returns 0 if there's an error.
        /// </summary>
        /// <param name="creature">The creature to sum levels up for</param>
        /// <returns></returns>
        public static int GetTotalLevel(NWGameObject creature)
        {
            return GetLevelByPosition(ClassPosition.First, creature) +
                   GetLevelByPosition(ClassPosition.Second, creature) +
                   GetLevelByPosition(ClassPosition.Third, creature);
        }

        /// <summary>
        ///  * Returns TRUE if oCreature is a Player Controlled character.
        /// </summary>
        private static bool GetIsPC(NWGameObject oCreature)
        {
            Internal.NativeFunctions.StackPushObject(oCreature != null ? oCreature.Self : NWGameObject.OBJECT_INVALID);
            Internal.NativeFunctions.CallBuiltIn(217);
            return Internal.NativeFunctions.StackPopInteger() == 1;
        }

        /// <summary>
        ///  * Returns TRUE if oCreature is the Dungeon Master.
        ///  Note: This will return FALSE if oCreature is a DM Possessed creature.
        ///  To determine if oCreature is a DM Possessed creature, use GetIsDMPossessed()
        /// </summary>
        private static bool GetIsDM(NWGameObject oCreature)
        {
            Internal.NativeFunctions.StackPushObject(oCreature != null ? oCreature.Self : NWGameObject.OBJECT_INVALID);
            Internal.NativeFunctions.CallBuiltIn(420);
            return Internal.NativeFunctions.StackPopInteger() == 1;
        }

        /// <summary>
        /// Returns true if obj is a player. If obj is a DM, DM-possessed, or any other type of object it will return false.
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>true if player, false otherwise</returns>
        public static bool GetIsPlayer(NWGameObject obj)
        {
            return GetIsPC(obj) && !GetIsDM(obj) && !GetIsDMPossessed(obj);
        }

        /// <summary>
        /// Returns true if obj is a DM or DM-possessed. Players or any other type of object will return false.
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>true if DM or DM-possessed, false otherwise</returns>
        public static bool GetIsDungeonMaster(NWGameObject obj)
        {
            return GetIsDM(obj) || GetIsDMPossessed(obj);
        }

        /// <summary>
        /// Returns true if obj is a non-player, non-DM, non-possessed creature. 
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>true if object is a NPC or false if not</returns>
        public static bool GetIsNPC(NWGameObject obj)
        {
            return !GetIsPlayer(obj) &&
                   !GetIsDungeonMaster(obj) &&
                   GetObjectType(obj) == ObjectType.Creature;
        }

        /// <summary>
        /// Retrieves a unique ID for a given object.
        /// Throws an exception if a player has not been assigned an ID yet.
        /// Assigns a new ID if a non-player has not been assigned an ID yet.
        /// </summary>
        /// <param name="obj">The object to retrieve the ID from</param>
        /// <returns>The ID of the object</returns>
        public static Guid GetGlobalID(NWGameObject obj)
        {
            if (GetIsPC(obj) && !GetIsDM(obj) && !GetIsDMPossessed(obj))
            {
                string tag = GetTag(obj);
                if (String.IsNullOrWhiteSpace(tag))
                    throw new Exception($"Player has not been assigned an ID yet. Player Name: {GetName(obj)}");

                return new Guid(tag);
            }
            else
            {
                var id = GetLocalString(obj, "GLOBAL_ID");
                if (String.IsNullOrWhiteSpace(id))
                {
                    id = Guid.NewGuid().ToString();
                    SetLocalString(obj, "GLOBAL_ID", id);
                }

                return new Guid(id);
            }
        }

        /// <summary>
        /// Gets an area by its resref. Returns OBJECT_INVALID if no area with the given resref can be found.
        /// </summary>
        /// <param name="resRef">The resref to search for.</param>
        /// <returns>An area with the matching resref, or OBJECT_INVALID if no area could be found.</returns>
        public static NWGameObject GetAreaByResRef(string resRef)
        {
            NWGameObject area = GetFirstArea();

            while (GetIsObjectValid(area))
            {
                if (GetResRef(area) == resRef)
                    return area;

                area = GetNextArea();
            }

            return NWGameObject.OBJECT_INVALID;
        }

        /// <summary>
        /// Destroys all items inside an object's inventory.
        /// </summary>
        /// <param name="obj">The objects whose inventory will be wiped.</param>
        public static void DestroyAllInventoryItems(NWGameObject obj)
        {
            NWGameObject item = GetFirstItemInInventory(obj);
            while (GetIsObjectValid(item))
            {
                DestroyObject(item);
                item = GetNextItemInInventory(obj);
            }
        }

        /// <summary>
        /// Returns the number of items in an object's inventory.
        /// Returns -1 if target does not have an inventory
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>-1 if obj doesn't have an inventory, otherwise returns the number of items in the inventory</returns>
        public static int GetInventoryItemCount(NWGameObject obj)
        {
            if (!GetHasInventory(obj)) return -1;

            int count = 0;
            NWGameObject item = GetFirstItemInInventory(obj);
            while (GetIsObjectValid(item))
            {
                count++;
                item = GetNextItemInInventory(obj);
            }

            return count;
        }

        /// <summary>
        /// If creature is currently busy, returns true.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="creature">The creature to check busy status of</param>
        /// <returns>true if busy, false otherwise</returns>
        public static bool GetIsBusy(NWGameObject creature)
        {
            return Convert.ToBoolean(GetLocalInt(creature, "IS_BUSY"));
        }

        /// <summary>
        /// Sets whether creature is busy.
        /// </summary>
        /// <param name="creature">The creature to change the busy status of</param>
        /// <param name="isBusy">true or false</param>
        public static void SetIsBusy(NWGameObject creature, bool isBusy)
        {
            SetLocalInt(creature, "IS_BUSY", Convert.ToInt32(isBusy));
        }


        /// <summary>
        /// 
        /// ----------------------------------------------------------------------------
        /// Add an item property in a safe fashion, preventing unwanted stacking
        /// Parameters:
        ///   oItem     - the item to add the property to
        ///   ip        - the itemproperty to add
        ///   fDuration - set 0.0f to add the property permanent, anything else is temporary
        ///   nAddItemPropertyPolicy - How to handle existing properties. Valid values are:
        ///	     X2_IP_ADDPROP_POLICY_REPLACE_EXISTING - remove any property of the same type, subtype, durationtype before adding;
        ///	     X2_IP_ADDPROP_POLICY_KEEP_EXISTING - do not add if any property with same type, subtype and durationtype already exists;
        ///	     X2_IP_ADDPROP_POLICY_IGNORE_EXISTING - add itemproperty in any case - Do not Use with OnHit or OnHitSpellCast props!
        ///   bIgnoreDurationType  - If set to TRUE, an item property will be considered identical even if the DurationType is different. Be careful when using this
        ///	                          with X2_IP_ADDPROP_POLICY_REPLACE_EXISTING, as this could lead to a temporary item property removing a permanent one
        ///   bIgnoreSubType       - If set to TRUE an item property will be considered identical even if the SubType is different.
        ///
        /// ----------------------------------------------------------------------------
        /// </summary>
        /// <param name="oItem"></param>
        /// <param name="ip"></param>
        /// <param name="fDuration"></param>
        /// <param name="nAddItemPropertyPolicy"></param>
        /// <param name="bIgnoreDurationType"></param>
        /// <param name="bIgnoreSubType"></param>
        public static void SafeAddItemProperty(NWGameObject oItem, ItemProperty ip, float fDuration, AddItemPropertyPolicy nAddItemPropertyPolicy, bool bIgnoreDurationType, bool bIgnoreSubType)
        {
            var nType = GetItemPropertyType(ip);
            var nSubType = GetItemPropertySubType(ip);
            DurationType nDuration;
            // if duration is 0.0f, make the item property permanent
            if (fDuration == 0.0f)
            {

                nDuration = DurationType.Permanent;
            }
            else
            {

                nDuration = DurationType.Temporary;
            }

            DurationType nDurationCompare = nDuration;
            if (bIgnoreDurationType)
            {
                nDurationCompare = DurationType.Invalid;
            }

            if (nAddItemPropertyPolicy == AddItemPropertyPolicy.ReplaceExisting)
            {

                // remove any matching properties
                if (bIgnoreSubType)
                {
                    nSubType = -1;
                }
                RemoveMatchingItemProperties(oItem, nType, nDurationCompare, nSubType);
            }
            else if (nAddItemPropertyPolicy == AddItemPropertyPolicy.KeepExisting)
            {
                // do not replace existing properties
                if (GetItemHasProperty(oItem, ip, nDurationCompare, bIgnoreSubType))
                {
                    return; // item already has property, return
                }
            }
            else //X2_IP_ADDPROP_POLICY_IGNORE_EXISTING
            {

            }

            if (nDuration == DurationType.Permanent)
            {
                AddItemProperty(nDuration, ip, oItem);
            }
            else
            {
                AddItemProperty(nDuration, ip, oItem, fDuration);
            }
        }



        /// <summary>
        /// // ----------------------------------------------------------------------------
        /// Removes all itemproperties with matching nItemPropertyType and
        /// nItemPropertyDuration (a DURATION_TYPE_* constant)
        /// ----------------------------------------------------------------------------
        /// </summary>
        /// <param name="oItem"></param>
        /// <param name="nItemPropertyType"></param>
        /// <param name="nItemPropertyDuration"></param>
        /// <param name="nItemPropertySubType"></param>
        public static void RemoveMatchingItemProperties(NWGameObject oItem, ItemPropertyType nItemPropertyType, DurationType nItemPropertyDuration, int nItemPropertySubType)
        {
            var prop = GetFirstItemProperty(oItem);

            while (GetIsItemPropertyValid(prop))
            {
                // same property type?
                if (GetItemPropertyType(prop) == nItemPropertyType)
                {
                    // same duration or duration ignored?
                    if (GetItemPropertyDurationType(prop) == nItemPropertyDuration || nItemPropertyDuration == DurationType.Invalid)
                    {
                        // same subtype or subtype ignored
                        if (GetItemPropertySubType(prop) == nItemPropertySubType || nItemPropertySubType == -1)
                        {
                            // Put a warning into the logfile if someone tries to remove a permanent ip with a temporary one!
                            /*if (nItemPropertyDuration == DURATION_TYPE_TEMPORARY &&  GetItemPropertyDurationType(ip) == DURATION_TYPE_PERMANENT)
                            {
                               WriteTimestampedLogEntry("x2_inc_itemprop:: IPRemoveMatchingItemProperties() - WARNING: Permanent item property removed by temporary on "+GetTag(oItem));
                            }
                            */
                            RemoveItemProperty(oItem, prop);
                        }
                    }
                }

                prop = GetNextItemProperty(oItem);
            }
        }


        /// <summary>
        /// Returns true if item has given item property. False otherwise.
        /// </summary>
        /// <param name="oItem"></param>
        /// <param name="ipCompareTo"></param>
        /// <param name="nDurationCompare"></param>
        /// <param name="bIgnoreSubType"></param>
        /// <returns></returns>
        public static bool GetItemHasProperty(NWGameObject oItem, ItemProperty ipCompareTo, DurationType nDurationCompare, bool bIgnoreSubType)
        {
            var prop = GetFirstItemProperty(oItem);
            while (GetIsItemPropertyValid(prop))
            {
                if ((GetItemPropertyType(prop) == GetItemPropertyType(ipCompareTo)))
                {
                    if (GetItemPropertySubType(prop) == GetItemPropertySubType(ipCompareTo) || bIgnoreSubType)
                    {
                        if (GetItemPropertyDurationType(prop) == nDurationCompare || nDurationCompare == DurationType.Invalid)
                        {
                            return true; // if duration is not ignored and durationtypes are equal, true
                        }
                    }
                }

                prop = GetNextItemProperty(oItem);
            }

            return false;
        }

        /// <summary>
        /// Removes all item properties of a given type from an item.
        /// </summary>
        /// <param name="oItem"></param>
        /// <param name="nItemPropertyDuration"></param>
        public static void RemoveAllItemProperties(NWGameObject oItem, DurationType nItemPropertyDuration)
        {
            var prop = GetFirstItemProperty(oItem);
            while (GetIsItemPropertyValid(prop))
            {
                if (GetItemPropertyDurationType(prop) == nItemPropertyDuration)
                {
                    RemoveItemProperty(oItem, prop);
                }

                prop = GetNextItemProperty(oItem);
            }
        }


        /// <summary>
        /// Cause the action subject to play an animation
        ///  - nAnimation: ANIMATION_*
        ///  - fSpeed: Speed of the animation
        ///  - fDurationSeconds: Duration of the animation (this is not used for Fire and
        ///    Forget animations)
        /// </summary>
        /// <param name="nAnimation"></param>
        /// <param name="fSpeed"></param>
        public static void ActionPlayAnimation(AnimationFireForget nAnimation, float fSpeed = 1.0f)
        {
            ActionPlayAnimation((int)nAnimation, fSpeed, 0.0f);
        }

        /// <summary>
        /// Cause the action subject to play an animation
        ///  - nAnimation: ANIMATION_*
        ///  - fSpeed: Speed of the animation
        ///  - fDurationSeconds: Duration of the animation (this is not used for Fire and
        ///    Forget animations)
        /// </summary>
        /// <param name="nAnimation"></param>
        /// <param name="fSpeed"></param>
        /// <param name="fDurationSeconds"></param>
        public static void ActionPlayAnimation(AnimationLooping nAnimation, float fSpeed = 1.0f, float fDurationSeconds = 0.0f)
        {
            ActionPlayAnimation((int)nAnimation, fSpeed, fDurationSeconds);
        }

        private static void ActionPlayAnimation(int nAnimation, float fSpeed = 1.0f, float fDurationSeconds = 0.0f)
        {
            Internal.NativeFunctions.StackPushFloat(fDurationSeconds);
            Internal.NativeFunctions.StackPushFloat(fSpeed);
            Internal.NativeFunctions.StackPushInteger((int)nAnimation);
            Internal.NativeFunctions.CallBuiltIn(40);
        }
    }
}
