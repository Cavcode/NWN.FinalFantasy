﻿using NWN.FinalFantasy.Core.Contracts;

namespace NWN.FinalFantasy.AI.Scripts.Default
{
    public class OnPerception: IScript
    {
        public void Main()
        {
            _.ExecuteScript("nw_c2_default2", NWGameObject.OBJECT_SELF);
        }
    }
}
