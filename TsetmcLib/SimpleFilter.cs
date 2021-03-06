﻿using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TsetmcLib
{
    public class SimpleFilter
    {
        string username = "ime.co.ir";
        string password = "ime.co.ir";

        public List<Trade> GetAllowed(AllowedMarketFilter filter)
        {

            var days = new TseDayCollectionGenerator().GenerateToday();
            var todayTrades = GetLastDayTrades(username, password, filter.Market).ToList();
            var twoDaysAgoTrades = GetSpecdayTrades(username, password, days.TwoDaysAgo, filter.Market).ToList();
            var yesterdayTrades = GetSpecdayTrades(username, password, days.Yesterday, filter.Market).ToList();

            var twoDaysAgoAllowed = twoDaysAgoTrades.Where(t
                => t.DailyChange < filter.YesterdayAllowedChange).ToList();
            var yesterdayAllowed = yesterdayTrades.Where(t
                => twoDaysAgoAllowed.Contains(t) && t.DailyChange > filter.YesterdayAllowedChange).ToList();

            var todayAllowedTrades = todayTrades.Where(t
                => yesterdayAllowed.Contains(t) && t.DailyChange > filter.PositiveMinChange && t.DailyChange < filter.PositiveMaxChange).ToList();

            return todayAllowedTrades;
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
