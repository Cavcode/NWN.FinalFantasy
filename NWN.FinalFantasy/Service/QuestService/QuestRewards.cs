﻿using static NWN.FinalFantasy.Core.NWScript.NWScript;

namespace NWN.FinalFantasy.Service.QuestService
{
    public interface IQuestReward
    {
        /// <summary>
        /// If true, this reward will become available for the player to select.
        /// If false, this reward will be given regardless if other rewards are selectable.
        /// Note that if the quest doesn't allow reward selection, this is given to them every time no matter what.
        /// </summary>
        bool IsSelectable { get; }

        /// <summary>
        /// The name of the reward as it shows in the 'Select a Reward' menu.
        /// If the quest doesn't allow reward selection, this does nothing.
        /// </summary>
        string MenuName { get; }

        /// <summary>
        /// The actions to take when this reward is given to a player.
        /// </summary>
        /// <param name="player">The player receiving the reward.</param>
        void GiveReward(uint player);
    }

    public class GoldReward : IQuestReward
    {
        public int Amount { get; }
        public bool IsSelectable { get; }
        public string MenuName => Amount + " Gil";

        public GoldReward(int amount, bool isSelectable)
        {
            Amount = amount;
            IsSelectable = isSelectable;
        }

        public void GiveReward(uint player)
        {
            GiveGoldToCreature(player, Amount);
        }
    }


    public class ItemReward : IQuestReward
    {
        public bool IsSelectable { get; }
        public string MenuName { get; }
        private readonly string _resref;
        private readonly int _quantity;

        public ItemReward(string resref, int quantity, bool isSelectable)
        {
            _resref = resref;
            _quantity = quantity;
            IsSelectable = isSelectable;

            var tempStorage = GetObjectByTag("TEMP_QUEST_ITEM_STORAGE");
            var tempItem = CreateItemOnObject(resref, tempStorage, quantity);
            var name = GetName(tempItem);
            DestroyObject(tempItem, 0.1f);

            if (_quantity > 1)
                MenuName = _quantity + "x " + name;
            else
                MenuName = name;
        }


        public void GiveReward(uint player)
        {
            CreateItemOnObject(_resref, player, _quantity);
        }
    }
}
