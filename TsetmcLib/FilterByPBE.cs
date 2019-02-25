using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TsetmcLib
{
    public class FilterByPBE
    {
        string username = "ime.co.ir";
        string password = "ime.co.ir";

        public List<Trade> GetAllowed(FilterByPBEParamModel filter)
        {
            var allSymbolInfo = ExcelParser.Excel();

            var days = new TseDayCollectionGenerator().GenerateToday();
            var todayTrades = GetLastDayTrades(username, password, filter.Market).ToList();
            var yesterdayTrades = GetSpecdayTrades(username, password, days.Yesterday, filter.Market).ToList();
            var twodaysagoTrades = GetSpecdayTrades(username, password, days.TwoDaysAgo, filter.Market).ToList();
            var threedaysagoTrades = GetSpecdayTrades(username, password, days.ThreeDaysAgo, filter.Market).ToList();


            var threedaysagoAllowed = threedaysagoTrades.Where(t
                => t.DailyChange < filter.LastDaysAllowedChange).ToList();
            var twodaysagoAllowed = twodaysagoTrades.Where(t
                => threedaysagoAllowed.Contains(t) && t.DailyChange < filter.LastDaysAllowedChange).ToList();
            var yesterdayAllowed = yesterdayTrades.Where(t
                => twodaysagoAllowed.Contains(t) && t.DailyChange < filter.LastDaysAllowedChange).ToList();
            var todayAllowedTrades = todayTrades.Where(t
                => yesterdayAllowed.Contains(t) && t.DailyChange < filter.TodayAllowedChange).ToList();
            var allowed = allSymbolInfo.Where(t
                => todayAllowedTrades.Contains(t) && t.PbE > filter.PbeMinChange && t.PbE < filter.PbeMaxChange).OrderByDescending(o => o.PbE).ThenByDescending(o => o.DailyChange).ToList();
            return allowed;
        }

        private static IEnumerable<Trade> GetLastDayTrades(string username, string password, byte market)
        {
            ServiceReference1.TsePublicV2SoapClient client = new ServiceReference1.TsePublicV2SoapClient();
            var tradesDataset = client.TradeLastDay(username, password, market);

            var trades = CollectionMapper.Map<Trade>(tradesDataset.Tables[0]);
            return trades;
        }

        private static IEnumerable<Trade> GetSpecdayTrades(string username, string password, int date, byte market)
        {
            ServiceReference1.TsePublicV2SoapClient client = new ServiceReference1.TsePublicV2SoapClient();
            var tradesDataset = client.TradeOneDay(username, password, date, market);

            var trades = CollectionMapper.Map<Trade>(tradesDataset.Tables[0]);
            return trades;
        }

    }
}
