using System;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class DateTimeTests
    {
        public class IsWorkingDay
        {
            [Fact]
            public static void WhenWeekdayThenReturnsTrue()
            {
                var input = new DateTime(2015, 11, 27);

                var result = input.IsWorkingDay();

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenWeekendThenReturnsFalse()
            {
                var input = new DateTime(2015, 11, 28);

                var result = input.IsWorkingDay();

                result.Should().Be(false);
            }
        }
        public class IsWeekend
        {
            [Fact]
            public static void WhenWeekendDateThenReturnsTrue()
            {
                var input = new DateTime(2015, 11, 28);

                var result = input.IsWeekend();

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenNotWeekendDateThenReturnsFalse()
            {
                var input = new DateTime(2015, 11, 27);

                var result = input.IsWeekend();

                result.Should().Be(false);
            }
        }
        public class NextWorkingDay
        {
            [Fact]
            public static void WhenSaturdayDateThenNextWorkingDayReturnsNextMondayDate()
            {
                var input = new DateTime(2015, 11, 28);
                var expected = new DateTime(2015, 11, 30);

                var result = input.NextWorkingDay();

                result.Should().Be(expected);
            }
            [Fact]
            public static void WhenSundayDateThenNextWorkingDayReturnsNextMondayDate()
            {
                var input = new DateTime(2015, 11, 29);
                var expected = new DateTime(2015, 11, 30);

                var result = input.NextWorkingDay();

                result.Should().Be(expected);
            }
            [Fact]
            public static void WhenWeekdayDateThenReturnsNextWeekdayDate()
            {
                var input = new DateTime(2015, 11, 25);
                var expected = new DateTime(2015, 11, 26);

                var result = input.NextWorkingDay();

                result.Should().Be(expected);
            }
            [Fact]
            public static void WhenFridayDateThenReturnsNextMondayDate()
            {
                var input = new DateTime(2015, 11, 27);
                var expected = new DateTime(2015, 11, 30);

                var result = input.NextWorkingDay();

                result.Should().Be(expected);
            }
            [Fact]
            public static void WhenWeekdayDateThenDoesNotReturnSameDate()
            {
                var input = new DateTime(2015, 11, 27);
                var expected = new DateTime(2015, 11, 27);

                var result = input.NextWorkingDay();

                result.Should().NotBe(expected);
            }
        }
        public class MonthsBetween
        {
            [Theory]
            [InlineData(2)]
            [InlineData(4)]
            [InlineData(6)]
            [InlineData(8)]
            [InlineData(10)]
            public static void ForXMonthsDifferenceShouldReturnX(int monthsAgo)
            {
                var now = DateTime.UtcNow;
                var input = DateTime.UtcNow.AddMonths(-monthsAgo);

                var result = now.MonthsBetween(input);

                result.Should().Be(monthsAgo);
            }
        }
        public class ToReadableTime
        {
            [Fact]
            public static void WhenDateLessThanOrOneSecondAgoThenReturnsOneSecondAgo()
            {
                var input = DateTime.Now.AddSeconds(-1);

                var result = input.ToReadableTime();

                result.Should().Be("one second ago");
            }
            [Theory]
            [InlineData(15)]
            [InlineData(30)]
            [InlineData(45)]
            public static void WhenDateXSecondAgoButLessThanSixtySecondsAgoThenReturnsXSecondsAgo(int secondsAgo)
            {
                var input = DateTime.Now.AddSeconds(-secondsAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"{secondsAgo} seconds ago");
            }
            [Fact]
            public static void WhenDateGreaterThanOneMinuteAgoButLessThanTwoMinutesAgoThenReturnsAMinuteAgo()
            {
                var input = DateTime.Now.AddMinutes(-1).AddSeconds(-30);

                var result = input.ToReadableTime();

                result.Should().Be("a minute ago");
            }
            [Theory]
            [InlineData(15)]
            [InlineData(30)]
            [InlineData(45)]
            public static void WhenDateXMinutesAgoButLessThanSixtyMinutesAgoThenReturnsXMinutesAgo(int minutesAgo)
            {
                var input = DateTime.Now.AddMinutes(-minutesAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"{minutesAgo} minutes ago");
            }
            [Theory]
            [InlineData(60)]
            [InlineData(90)]
            [InlineData(119)]
            public static void WhenDateGreaterThanOrOneHourAgoButLessThanTwoHoursAgoThenReturnsAnHourAgo(int minutesAgo)
            {
                var input = DateTime.Now.AddMinutes(-minutesAgo);

                var result = input.ToReadableTime();

                result.Should().Be("an hour ago");
            }
            [Theory]
            [InlineData(2)]
            [InlineData(12)]
            [InlineData(23)]
            public static void WhenDateXHoursAgoAndGreaterThanOneHourAgoButLessThanTwentyFourHoursAgoThenReturnsXHourAgo(int hoursAgo)
            {
                var input = DateTime.Now.AddHours(-hoursAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"{hoursAgo} hours ago");
            }
            [Fact]
            public static void WhenDateIsYesterdayReturnsYesterday()
            {
                var input = DateTime.Now.AddDays(-1).AddHours(-1);

                var result = input.ToReadableTime();

                result.Should().Be($"yesterday");
            }
            [Theory]
            [InlineData(2)]
            [InlineData(5)]
            [InlineData(6)]
            public static void WhenDateIsGreaterThanYesterdayAndLessThanOneWeekAgoThenReturnXDaysAgo(int daysAgo)
            {
                var input = DateTime.Now.AddDays(-daysAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"{daysAgo} days ago");
            }
            [Theory]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            public static void WhenDateIsGreaterThanAWeekAgoAndLessThanOneMonthAgoThenReturnXWeeksAgo(int weeksAgo)
            {
                var input = DateTime.Now.AddDays(-(7 * weeksAgo));

                var result = input.ToReadableTime();

                result.Should().Be($"{weeksAgo} weeks ago");
            }
            [Theory]
            [InlineData(1)]
            public static void WhenDateIsOneMonthAgoAndLessThanTwoMonthsAgoThenReturnsAMonthAgo(int monthsAgo)
            {
                var input = DateTime.Now.AddMonths(-monthsAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"one month ago");
            }
            [Theory]
            [InlineData(2)]
            [InlineData(4)]
            [InlineData(6)]
            [InlineData(8)]
            [InlineData(10)]
            public static void WhenDateIsGreaterThanOneMonthAgoAndLessThanOneYearAgoThenReturnsXMonthsAgo(int monthsAgo)
            {
                var input = DateTime.Now.AddMonths(-monthsAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"{monthsAgo} months ago");
            }
            [Theory]
            [InlineData(1)]
            public static void WhenDateIsOneYearAgoAndLessThanTwoYearsAgoThenReturnsAYearAgo(int yearsAgo)
            {
                var input = DateTime.Now.AddYears(-yearsAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"one year ago");
            }
            [Theory]
            [InlineData(2)]
            [InlineData(4)]
            [InlineData(6)]
            [InlineData(8)]
            [InlineData(10)]
            public static void WhenDateIsGreaterThanOneYearAgoThenReturnsXYearsAgo(int yearsAgo)
            {
                var input = DateTime.Now.AddYears(-yearsAgo);

                var result = input.ToReadableTime();

                result.Should().Be($"{yearsAgo} years ago");
            }
        }       
        public class YearsBetween
        {
            [Fact]
            public static void WhenInputIsMoreThanAYearAgoThenShouldReturnCorrectNumberOfYears()
            {
                var input = new DateTime(2000, 01, 01);

                var result = input.YearsBetween();

                result.Should().Be(DateTime.Today.Year - input.Year);
            }
            [Fact]
            public static void WhenInputIsLessThanAYearAgoThenShouldReturnZero()
            {
                var input = DateTime.Now.AddYears(-1).AddDays(1);

                var result = input.YearsBetween();

                result.Should().Be(0);
            }

        }
        public class Age
        {
            [Fact]
            public static void WhenInputIsAfterSinceThenShouldThrowArgumentException()
            {
                var input = DateTime.Now.AddYears(1);

                Action act = () => input.Age();

                act.ShouldThrow<ArgumentException>();
            }
            [Fact]
            public static void WhenInputIsOneYearAgoThenShouldReturnOneYear()
            {
                var input = DateTime.Now.AddYears(-1);

                var result = input.Age();

                result.Years.Should().Be(1);
                result.Months.Should().Be(0);
                result.Days.Should().Be(0);
            }
            [Fact]
            public static void WhenInputIsOneMonthAgoThenShouldReturnOneMonth()
            {
                var input = DateTime.Now.AddMonths(-1);

                var result = input.Age();

                result.Years.Should().Be(0);
                result.Months.Should().Be(1);
                result.Days.Should().Be(0);
            }
            [Fact]
            public static void WhenInputIsOneDayAgoThenShouldReturnOneDay()
            {
                var input = DateTime.Now.AddDays(-1);

                var result = input.Age();

                result.Years.Should().Be(0);
                result.Months.Should().Be(0);
                result.Days.Should().Be(1);
            }
            [Fact]
            public static void WhenInputIsOneYearOneMonthAndOneDayAgoThenShouldReturnOneYearOneMonthAndOneDay()
            {
                var input = DateTime.Now.AddDays(-1).AddMonths(-1).AddYears(-1);

                var result = input.Age();

                result.Years.Should().Be(1);
                result.Months.Should().Be(1);
                result.Days.Should().Be(1);
            }
            [Fact]
            public static void WhenInputIsSameThenShouldReturnZero()
            {
                var input = DateTime.Now;

                var result = input.Age();

                result.Years.Should().Be(0);
                result.Months.Should().Be(0);
                result.Days.Should().Be(0);
            }
        }
        public class ToEpoch
        {
            [Fact]
            public static void WhenInputIsValidShouldReturnExpectedEpochTime()
            {
                var input = new DateTime(2016, 01, 01);

                var result = input.ToEpoch();

                result.Should().Be(1451606400);
            }
            [Fact]
            public static void WhenInputIsBefore1970ShouldReturnNegativeEpochTime()
            {
                var input = DateTime.MinValue;

                var result = input.ToEpoch();

                result.Should().Be(-62135596800);
            }
        }
    }
}
