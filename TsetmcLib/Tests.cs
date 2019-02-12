using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TsetmcLib
{
    public class Tests
    {
        [Theory]
        [InlineData("2019-02-03", 20190203, 20190202, 20190130)]
        [InlineData("2019-02-02", 20190202, 20190130, 20190129)]
        public void should_get_correct_date_collection(string date, int today, int yesterday, int twodaysago)
        {
            // Arrange
            var currentDate = Convert.ToDateTime(date);
            var expectedDays = new Days() { TodayInt = today, Yesterday = yesterday, TwoDaysAgo = twodaysago };

            // Act
            var generator = new DayCollectionGenearator();
            var days = generator.GenerateByDate(currentDate);

            // Assert
            Assert.Equal(expectedDays, days);
        }

        [Fact]
        public void should_get_correct_today_date_collection()
        {
            // Arrange

            var expectedDays = new Days() { TodayInt = 20190203, Yesterday = 20190202, TwoDaysAgo = 20190130 };

            // Act
            var generator = new DayCollectionGenearator();
            var days = generator.GenerateToday();

            // Assert
            Assert.Equal(expectedDays, days);
        }
    }
}
