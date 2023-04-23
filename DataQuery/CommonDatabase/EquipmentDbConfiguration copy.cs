using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using UQuery.Container;

namespace UQuery.DataQuery.CommonDatabase
{
    public class EquipmentDbConfiguration : IDbConfiguration
    {
        public Database[] GetDatabases()
        {
            return new Database[]
            {
                equipmentDatabase
            };
        }
        private static readonly Database equipmentDatabase = Database.Create
        (
            "ueda.adhoc_chart_eq",
            DatabaseField.Create("step",        DatabaseIndex.STEP,          DbKeyType.PRIVARY_KEY),
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,       DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("lot",         DatabaseIndex.LOT,           DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("process_eq",  DatabaseIndex.PROCESS_EQ),
            DatabaseField.Create("measure_eq",  DatabaseIndex.MEASURE_EQ)
        );
    }
}
