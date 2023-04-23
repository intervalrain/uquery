namespace UQuery.Container
{
    public abstract class Field 
    {
        public string tableName;
        public string fieldName;
        public string alias;

        public Field(string tableName, string fieldName) {
            this.tableName = tableName;
            this.fieldName = fieldName;
        }
        public string GetQuery()
        {
            string postfix = string.IsNullOrWhiteSpace(alias) ? $"As {alias}" : "";
            return $"{tableName}.{fieldName} {postfix}";
        }
    }
}