using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;

namespace UQuery.Container
{
    public class Database 
    {
        private readonly bool needUnion;
        private readonly Database[] subDatabases;
        private readonly string databaseName;
        private readonly DatabaseField[] databaseFields;
        private readonly DatabaseField privaryKey;
        private readonly DatabaseField[] foreignKey;
        public bool NeedUnion => needUnion;
        private Database(string databaseName, params DatabaseField[] databaseFields) 
        {
            this.needUnion = false;
            this.databaseName = databaseName;
            this.databaseFields = databaseFields;
            List<DatabaseField> list = new List<DatabaseField>();
            foreach (var databaseField in databaseFields)
            {
                if (databaseField.KeyType == DbKeyType.PRIVARY_KEY)
                {
                    privaryKey = databaseField;
                }
                else if (databaseField.KeyType == DbKeyType.FOREIGN_KEY)
                {
                    list.Add(databaseField);
                }
            }
            this.foreignKey = list.ToArray();
        }
        private Database(string databasesName, params Database[] subDatabases) 
        {
            this.needUnion = true;
            this.databaseName = databasesName;
            this.subDatabases = subDatabases;
            this.databaseFields = subDatabases[0].databaseFields;
            List<DatabaseField> list = new List<DatabaseField>();
            foreach (var databaseField in databaseFields)
            {
                if (databaseField.KeyType == DbKeyType.PRIVARY_KEY)
                {
                    privaryKey = databaseField;
                }
                else if (databaseField.KeyType == DbKeyType.FOREIGN_KEY)
                {
                    list.Add(databaseField);
                }
            }
            this.foreignKey = list.ToArray();
        }
        public static Database Create(string databaseName, params DatabaseField[] databaseFields)
        {
            return new Database(databaseName, databaseFields);
        }
        public static Database Create(string databasesName, params Database[] databases)
        {
            return new Database(databasesName, databases);
        }
        public int Contains(DatabaseIndex[] fields) 
        {
            List<DatabaseIndex> list = databaseFields.Select(x => x.DatabaseIndex).ToList();
            return fields.Intersect(list).Count();
        }
        public DatabaseIndex[] LackOf(DatabaseIndex[] fields)
        {
            List<DatabaseIndex> list = databaseFields.Select(x => x.DatabaseIndex).ToList();
            return fields.Except(list).ToArray();
        }
        public bool ContainsAny(DatabaseIndex[] fields) 
        {
            return Contains(fields) > 0;
        }
    }
}