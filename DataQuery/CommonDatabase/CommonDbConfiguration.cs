using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using UQuery.Container;

namespace UQuery.DataQuery.CommonDatabase
{
    public class CommonDbConfiguration : IDbConfiguration
    {
        public Database[] GetDatabases()
        {
            HashSet<Database> hashSet = new HashSet<Database>();
            List<Database[]> dbList = new List<Database[]>
            {
                new LotDbConfiguration().GetDatabases(),
                new ProductDbConfiguration().GetDatabases(),
                new EquipmentDbConfiguration().GetDatabases()
            };
            foreach (Database[] dbs in dbList)
            {
                foreach (Database db in dbs)
                {
                    hashSet.Add(db);
                }
            }
            return hashSet.ToArray();
        }
    }
}