using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using UQuery.Container;

namespace UQuery.DataQuery.CommonDatabase
{
    public class ProductDbConfiguration : IDbConfiguration
    {
        public Database[] GetDatabases()
        {
            return new Database[]
            {
                productDatabase
            };
        }

        private static readonly Database productDatabase = Database.Create
        (
            "ueda.all_product",
            DatabaseField.Create("product",     DatabaseIndex.PRODUCT,       DbKeyType.PRIVARY_KEY)
        );
    }
}
