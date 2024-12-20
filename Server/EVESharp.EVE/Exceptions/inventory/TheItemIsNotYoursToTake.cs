﻿using EVESharp.Types.Collections;

namespace EVESharp.EVE.Exceptions.inventory;

public class TheItemIsNotYoursToTake : UserError
{
    public TheItemIsNotYoursToTake (string itemInfo) : base ("TheItemIsNotYoursToTake", new PyDictionary {["item"] = itemInfo}) { }

    public TheItemIsNotYoursToTake (int itemID) : this (itemID.ToString ()) { }
}