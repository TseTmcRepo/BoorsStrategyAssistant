using System;

namespace TsetmcLib
{
    public class DayCollectionGenearator
    {
        public Days GenerateToday()
        {

            var today = DateTime.Now;
            return GenerateByDate(today);
        }

        public Days GenerateByDate(DateTime date)
        {
            System.Globalization.CultureInfo cultureinfo =new System.Globalization.CultureInfo("en-US");
            if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Thursday)
                throw new Exception("No business day");
            var yesterday = date.AddDays(-1);
            yesterday = GetPreviousDayExceptHoliday(yesterday);
            var twodaysago = yesterday.AddDays(-1);
            twodaysago = GetPreviousDayExceptHoliday(twodaysago);

            return new Days
            {
                TodayInt = Convert.ToInt32(date.ToString("yyyyMMdd",cultureinfo)),
                Yesterday = Convert.ToInt32(yesterday.ToString("yyyyMMdd",cultureinfo)),
                TwoDaysAgo = Convert.ToInt32(twodaysago.ToString("yyyyMMdd",cultureinfo))
            };
        }


        private DateTime GetPreviousDayExceptHoliday(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Friday)
                day = day.AddDays(-2);
            return day;
        }
    }
}

