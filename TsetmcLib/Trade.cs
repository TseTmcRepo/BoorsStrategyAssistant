using System.Collections.Generic;

namespace TsetmcLib
{
    public class Trade
    {
        public string LVal18AFC { get; set; } // نماد
        public string DEven { get; set; } //   تاريخ
        public decimal ZTotTran { get; set; } //    تعداد معاملات
        public decimal QTotTran5J { get; set; } //    حجم - تعداد سهام معامله شده
        public decimal QTotCap { get; set; } // معاملات
        public string InsCode { get; set; } // نماد
        public string LVal30 { get; set; } // نام
        public decimal PClosing { get; set; } // نهايي
        public decimal PDrCotVal { get; set; } // قيمت معامله شده
        public decimal PriceChange { get; set; } // قيمت
        public decimal PriceMin { get; set; } // قيمت
        public decimal PriceMax { get; set; } // قيمت
        public decimal PriceFirst { get; set; } //   قيمت اولين معامله
        public decimal PriceYesterday { get; set; }     //قيمت ديروز

        public decimal DailyChange => PriceYesterday != 0 ? (PClosing - PriceYesterday) / PriceYesterday*100 : 0;

        public override bool Equals(object obj)
        {
            var trade = obj as Trade;
            return trade != null &&
                   InsCode == trade.InsCode;
        }

        public override int GetHashCode()
        {
            var hashCode = -2088206300;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(InsCode);
            return hashCode;
        }
    }

}
