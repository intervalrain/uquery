using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using UQuery.Container;
using UQuery.DataQuery;
using UQuery.DataQuery.CommonDatabase;

namespace UQuery.DataQuery
{
    public class DataQueryService
    {
        private readonly IDbConfiguration partialDbConfiguration;
        private readonly IDbConfiguration commonDbConfiguration;
        public DataQueryService(int classKey)
        {
            this.commonDbConfiguration = new CommonDbConfiguration();
            switch (classKey)
            {
                case 5:
                    this.partialDbConfiguration = new InlineDbConfiguration();
                    break;
                case 23:
                    this.partialDbConfiguration = new WATDbConfiguration();
                    break;
                default:
                    break;
            }
        }
        private Database GetMasterDatabase(DatabaseIndex[] fields)
        {
            Database[] dbs = partialDbConfiguration.GetDatabases();
            Database masterDb = dbs[0];
            int matches = 0;
            foreach (Database db in dbs)
            {
                int num = db.Contains(fields);
                if (num > matches)
                {
                    matches = num;
                    masterDb = db;
                }
            }
            return masterDb;
        }
        private Database[] GetSlaveDatabases(DatabaseIndex[] fields)
        {
            Database[] dbs = commonDbConfiguration.GetDatabases();
            List<Database> list = new List<Database>();
            foreach (Database db in dbs)
            {
                if (db.ContainsAny(fields)){
                    list.Add(db);
                }
            }
            return list.ToArray();
        }
        public bool GetDatabases(DatabaseIndex[] fields, out Database masterDB, out Database[] slaveDBs)
        {
            masterDB = GetMasterDatabase(fields);
            DatabaseIndex[] lack = masterDB.LackOf(fields);
            slaveDBs = GetSlaveDatabases(lack);
            
            if (masterDB == null) return false;
            return true;
        }
        // public Field GetField()
        // {

        // }
    }
}
