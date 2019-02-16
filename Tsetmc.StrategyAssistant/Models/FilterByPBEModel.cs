using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tsetmc.StrategyAssistant.Models
{
    public class FilterByPBEModel
    {
        public byte Market { get; set; }
        public decimal LastDaysAllowedChange { get;  set; }
        public decimal TodayAllowedChange { get;  set; }
        public decimal PbeMinChange { get;  set; }
        public decimal PbeMaxChange { get;  set; }


    }
}