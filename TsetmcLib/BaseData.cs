using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsetmcLib
{
    public class BaseData
    {
        public static List<ActiveDate> GetActiveTradeDates()
        {
            return Enumerable.Empty<ActiveDate>().ToList();
        }
    }
}
