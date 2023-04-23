using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using UQuery.Container;

namespace UQuery.DataQuery.CommonDatabase
{
    public class LotDbConfiguration : IDbConfiguration
    {
        public Database[] GetDatabases()
        {
            return new Database[]
            {
                lotDatabase
            };
        }
        private static readonly Database lotDatabase = Database.Create
        (
            "ueda.all_lot",
            DatabaseField.Create("lot",         DatabaseIndex.LOT,           DbKeyType.PRIVARY_KEY),
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,       DbKeyType.FOREIGN_KEY)
        );

    }
}
