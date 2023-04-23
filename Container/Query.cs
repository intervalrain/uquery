using System.Linq;

namespace UQuery.Container
{
    public abstract class Query {
        public Field[] fields;
        public Filter[] filters;
        public Query (Field[] fields, Filter[] filters) 
        {
            this.fields = fields;
            this.filters = filters;
        }
        public string GetQuery() {
            string text = "Select\n";
            string[] fieldStatement = fields.Select(x => x.GetQuery()).ToArray();
            string[] filterStatement = filters.Select(x => x.GetQuery()).ToArray();

            return text + string.Join(',', fieldStatement) + "\nWhere\n" + string.Join(" And\n", filterStatement);
        }
    }
}