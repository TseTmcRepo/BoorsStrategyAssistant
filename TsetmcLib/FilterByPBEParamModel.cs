namespace TsetmcLib
{
    public class FilterByPBEParamModel
    {
        public FilterByPBEParamModel(decimal lastDaysAllowedChange, decimal todayAllowedChange, decimal pbeMinChange, decimal pbeMaxChange, byte market)
        {
            LastDaysAllowedChange = lastDaysAllowedChange;
            TodayAllowedChange = todayAllowedChange;
            PbeMinChange = pbeMinChange;
            PbeMaxChange = pbeMaxChange;
            this.Market = market;
        }
        public decimal LastDaysAllowedChange {get; private set;}
        public decimal TodayAllowedChange {get; private set;}
        public decimal PbeMinChange      {get; private set;}
        public decimal PbeMaxChange { get; private set; }
        public byte Market { get; }
    }
}
