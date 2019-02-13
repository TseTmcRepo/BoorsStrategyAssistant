using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsetmcLib
{
    public class TseDayCollectionGenerator : IDayCollectionGenearator
    {
        private List<ActiveDate> dates = BaseData.GetActiveTradeDates();
        public Days GenerateByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Days GenerateToday()
        {
            return new Days
            {
                TodayInt = Convert.ToInt32(dates[0].DEven),
                Yesterday = Convert.ToInt32(dates[1].DEven),
                TwoDaysAgo = Convert.ToInt32(dates[2].DEven)
            };
        }
    }
}
