using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsetmcLib
{
    public class BaseData
    {
        static string username = "ime.co.ir";
        static string password = "ime.co.ir";
        public static List<ActiveDate> GetActiveTradeDates()
        {
            ServiceReference1.TsePublicV2SoapClient client = new ServiceReference1.TsePublicV2SoapClient();
            var activeDatesDataset = client.NSCStart(username, password);

            var activeDates = CollectionMapper.Map<ActiveDate>(activeDatesDataset.Tables[0]).ToList();
            return activeDates;
        }
    }
}
