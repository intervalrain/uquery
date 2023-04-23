using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;

namespace UQuery.Container
{
    public class DatabaseField
    {
        private readonly string fieldName;
        private readonly DatabaseIndex databaseIndex;
        private readonly DbKeyType keyType;

        public string FieldName => fieldName;
        public DatabaseIndex DatabaseIndex => databaseIndex;
        public DbKeyType KeyType => keyType;
        private DatabaseField(string fieldName, DatabaseIndex databaseIndex, DbKeyType keyType)
        {
            this.fieldName = fieldName;
            this.databaseIndex = databaseIndex;
            this.keyType = keyType;
        }
        public static DatabaseField Create(string fieldName, DatabaseIndex databaseIndex)
        {
            return new DatabaseField(fieldName, databaseIndex, DbKeyType.NONE);
        }

        public static DatabaseField Create(string fieldName, DatabaseIndex databaseIndex, DbKeyType keyType)
        {
            return new DatabaseField(fieldName, databaseIndex, keyType);
        }
        public string GetDisplayName()
        {
            DatabaseIndex value = this.databaseIndex;
            var field = value.GetType().GetField(value.ToString());
            if (field != null) 
            {
                var attr = field.GetCustomAttributes(typeof(DatabaseIndex), true).SingleOrDefault() as DisplayNameAttribute;
                if (attr != null) {
                    return attr.Value;
                }
            }
            return Convert.ToString(value);
        }
    }
}
