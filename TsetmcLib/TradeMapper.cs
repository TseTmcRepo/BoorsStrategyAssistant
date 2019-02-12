using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TsetmcLib
{
    internal class TradeMapper
    {
        internal static IEnumerable<Trade> Map(DataTable dataTable)
        {
            var mapped = dataTable
                    .AsEnumerable()
                    .Select(x => x.Table.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => x[c]).ToObject<Trade>())
                    .AsQueryable();
            return mapped;
        }
    }
}