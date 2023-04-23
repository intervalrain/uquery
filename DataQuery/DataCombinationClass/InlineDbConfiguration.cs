using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using UQuery.Container;

namespace UQuery.DataQuery
{
    public class InlineDbConfiguration : IDbConfiguration
    {
        public Database[] GetDatabases()
        {
            return new Database[]
            {
                adhocStep,
                adhocConfig,
                waferInfo
            };
        }
        private static Database adhocStep = Database.Create
        (
            "ueda.adhoc_chart_inline_step",
            DatabaseField.Create("parameter",   DatabaseIndex.PARAMETER,    DbKeyType.PRIVARY_KEY),
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,      DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("stage",       DatabaseIndex.STAGE),
            DatabaseField.Create("step",        DatabaseIndex.STEP),
            DatabaseField.Create("stepname",    DatabaseIndex.STEPNAME)
        );
        private static Database adhocConfig = Database.Create
        (
            "ueda.adhoc_chart_inline_config",
            DatabaseField.Create("parameter",   DatabaseIndex.PARAMETER,    DbKeyType.PRIVARY_KEY),
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,      DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("stage",       DatabaseIndex.STAGE),
            DatabaseField.Create("step",        DatabaseIndex.STEP),
            DatabaseField.Create("stepname",    DatabaseIndex.STEPNAME),
            DatabaseField.Create("recipe",      DatabaseIndex.RECIPE)
        );        
        private static Database aaWaferInfo = Database.Create
        (
            "ueda.edc_aa_wafer_info",
            DatabaseField.Create("paramter",    DatabaseIndex.PARAMETER,    DbKeyType.PRIVARY_KEY),
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,      DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("stage",       DatabaseIndex.STAGE),
            DatabaseField.Create("step",        DatabaseIndex.STEP),
            DatabaseField.Create("stepname",    DatabaseIndex.STEPNAME),
            DatabaseField.Create("recipe",      DatabaseIndex.RECIPE),
            DatabaseField.Create("wafer",       DatabaseIndex.WAFER)
        );
        private static Database cdWaferInfo = Database.Create
        (
            "ueda.edc_cd_wafer_info",
            DatabaseField.Create("cdtype",      DatabaseIndex.PARAMETER,    DbKeyType.PRIVARY_KEY),
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,      DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("lot",         DatabaseIndex.LOT,          DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("stage",       DatabaseIndex.STAGE),
            DatabaseField.Create("step",        DatabaseIndex.STEP),
            DatabaseField.Create("stepname",    DatabaseIndex.STEPNAME),
            DatabaseField.Create("recipe",      DatabaseIndex.RECIPE),
            DatabaseField.Create("wafer",       DatabaseIndex.WAFER)            
        );
        private static Database tkWaferInfo = Database.Create
        (
            "ueda.edc_tk_wafer_info",
            DatabaseField.Create("tktype",      DatabaseIndex.PARAMETER,    DbKeyType.PRIVARY_KEY),
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,      DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("lot",         DatabaseIndex.LOT,          DbKeyType.FOREIGN_KEY),
            DatabaseField.Create("stage",       DatabaseIndex.STAGE),
            DatabaseField.Create("step",        DatabaseIndex.STEP),
            DatabaseField.Create("stepname",    DatabaseIndex.STEPNAME),
            DatabaseField.Create("recipe",      DatabaseIndex.RECIPE),
            DatabaseField.Create("wafer",       DatabaseIndex.WAFER)      
        );
        private static Database waferInfo = Database.Create
        (
            "edc_wafer_info",
            aaWaferInfo,
            cdWaferInfo,
            tkWaferInfo
        );
    }
}
