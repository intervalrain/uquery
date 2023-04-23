using System;

namespace UQuery.Container
{
    public abstract class Filter 
    {
        public Field field;
        public FilterAction action;
        public FilterType type;
        public object value;
        public Filter(Field field, FilterAction action, FilterType type, object value) 
        {
            this.field = field;
            this.action = action;
            this.type = type;
            this.value = value;
        }
        public string GetQuery()
        {
            string text;
            string include = action == FilterAction.IN ? "" : "NOT ";
            switch (type)
            {
                case FilterType.LIST:
                    string[] list = value as string[];
                    text = $" IN ({String.Join(',', list)})";
                    break;
                case FilterType.FURMULA:
                    text = Convert.ToString(value);
                    break;
                case FilterType.REGEXP:
                    text = " REGEXP_LIKE " + Convert.ToString(value);
                    break;
                case FilterType.LIKE:
                    text = $" LIKE %{value}%";
                    break;
                case FilterType.SUBQUERY:
                    text = "(" + ((Query)value).GetQuery() + ")";
                    break;
                case FilterType.NUMBER:
                    text = " = " + Convert.ToInt32(value);
                    break;
                case FilterType.STRING:
                default:
                    text = " = '" + Convert.ToString(value) + "'";
                    break;
            }
            return $"{include}({field.tableName}.{field.fieldName} {text}";
        }
    }
    
}