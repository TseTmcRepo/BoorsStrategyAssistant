namespace TsetmcLib
{
    public class AllowedMarketFilter
    {
        public AllowedMarketFilter(decimal yesterdayAllowedChange, decimal positiveMinChange, decimal positiveMaxChange, byte Market)
        {
            YesterdayAllowedChange = yesterdayAllowedChange;
            PositiveMinChange = positiveMinChange;
            PositiveMaxChange = positiveMaxChange;
            this.Market = Market;
        }
        public decimal YesterdayAllowedChange {get; private set;}
        public decimal PositiveMinChange      {get; private set;}
        public decimal PositiveMaxChange { get; private set; }
        public byte Market { get; }
    }
}
