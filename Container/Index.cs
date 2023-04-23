using System.Collections.Generic;

namespace UQuery.Container
{
    public class Index 
    {
        public DatabaseIndex databaseIndex;
        public Field field;
        public string displayName;
        public List<Pair<Field,Field>> joinCond;
        public Index(DatabaseIndex databaseIndex, Field field, string displayName, List<Pair<Field,Field>> joinCond) 
        {
            this.databaseIndex = databaseIndex;
            this.field = field;
            this.displayName = displayName;
            this.joinCond = joinCond;
        }
        public Index(DatabaseIndex databaseIndex, Field field, string displayName) 
            : this(databaseIndex, field, displayName, null) {}
    }
}