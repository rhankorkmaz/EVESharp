﻿using EVESharp.EVE.Packets.Exceptions;
using EVESharp.PythonTypes.Types.Collections;

namespace EVESharp.EVE.Client.Exceptions.LSC;

public class LSCStandardException : UserError
{
    public LSCStandardException (string type, string message) : base (type, new PyDictionary {["msg"] = message}) { }
}