using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using UQuery.Container;

namespace UQuery.DataQuery
{
    public class WATDbConfiguration : IDbConfiguration
    {
        public Database[] GetDatabases()
        {
            return new Database[0];
        }
    }
}