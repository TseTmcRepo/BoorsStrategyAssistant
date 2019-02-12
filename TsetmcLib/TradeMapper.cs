using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TsetmcLib
{
    internal class TradeMapper
    {
        internal static IEnumerable<T> Map<T>(DataTable dataTable) where T: class, new()
        {
            var mapped = dataTable
                    .AsEnumerable()
                    .Select(x => x.Table.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => x[c]).ToObject<T>())
                    .AsQueryable();
            return mapped;
        }
    }
}