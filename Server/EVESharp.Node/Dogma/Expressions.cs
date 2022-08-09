﻿using System.Collections.Generic;
using EVESharp.Database.Inventory;
using EVESharp.EVE.Data.Dogma;
using EVESharp.EVE.Data.Inventory;
using EVESharp.Node.Database;
using EVESharp.PythonTypes.Types.Database;
using Serilog;

namespace EVESharp.Node.Dogma;

public class Expressions : Dictionary <int, Expression>, IExpressions
{
    public Expressions (IDatabaseConnection Database, ILogger Log) : base (Database.InvDgmLoadExpressions (Log))
    {
        Log.Debug ($"Loaded {this.Count} expressions for Dogma");
    }
}