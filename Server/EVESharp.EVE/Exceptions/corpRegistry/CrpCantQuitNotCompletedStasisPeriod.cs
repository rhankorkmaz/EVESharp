﻿using EVESharp.Types.Collections;

namespace EVESharp.EVE.Exceptions.corpRegistry;

public class CrpCantQuitNotCompletedStasisPeriod : UserError
{
    public CrpCantQuitNotCompletedStasisPeriod (int characterID, int hours, int hoursleft) : base (
        "CrpCantQuitNotCompletedStasisPeriod",
        new PyDictionary
        {
            ["charname"]  = FormatOwnerID (characterID),
            ["hour"]      = hours,
            ["hoursleft"] = hoursleft
        }
    ) { }
}