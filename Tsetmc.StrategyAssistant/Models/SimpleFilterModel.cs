using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tsetmc.StrategyAssistant.Models
{
    public class SimpleFilterModel
    {
        public byte Market { get; set; }

        public decimal YesterdayAllowedChange {  get; set; }

        public decimal PositiveMinChange {  get; set; }

        public decimal PositiveMaxChange {  get; set; }

    }
}