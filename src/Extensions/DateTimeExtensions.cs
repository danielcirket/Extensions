using System;

namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWorkingDay(this DateTime source)
        {
            return !source.IsWeekend();
        }
        public static bool IsWeekend(this DateTime source)
        {
            // TODO(Dan): Should this look at the current culture - probably.
            return source.DayOfWeek == DayOfWeek.Saturday || source.DayOfWeek == DayOfWeek.Sunday;
        }
        public static DateTime NextWorkingDay(this DateTime source)
        {
            // TODO(Dan): Should this take into account public holidays?
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var currentDay = source;
            var nextDay = source.AddDays(1);

            while (!nextDay.IsWorkingDay())
                nextDay = nextDay.AddDays(1);

            return nextDay;
        }
        public static int MonthsBetween(this DateTime source, DateTime comparison)
        {
            return Math.Abs((source.Month - comparison.Month) + 12 * (source.Year - comparison.Year));
        }
        public static string ToReadableTime(this DateTime source)
        {
            var utcNow = DateTime.UtcNow;
            var ts = new TimeSpan(utcNow.Ticks - source.ToUniversalTime().Ticks);
            var delta = ts.TotalSeconds;

            if (delta < 60)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 120)
                return "a minute ago";

            if (delta < 3600)
                return ts.Minutes + " minutes ago";

            if (delta < 7200)
                return "an hour ago";

            if (ts.TotalDays <= 1)
                return ts.Hours + " hours ago";

            if (ts.TotalDays > 0 && ts.TotalDays < 2)
                return "yesterday";

            if (ts.TotalDays > 1 && ts.TotalDays < 7)
                return ts.Days + " days ago";

            var weeks = Convert.ToInt32(Math.Ceiling((double)ts.Days / 7));
            var months = utcNow.MonthsBetween(source);

            if (ts.TotalDays < 30 && weeks <= 4)
            {
                return (weeks <= 1)
                    ? "a week ago"
                    : $"{weeks} weeks ago";
            }

            if ((months > 0 || weeks > 4) && ts.TotalDays < 365)
            {
                return months <= 1
                    ? "one month ago"
                    : months + " months ago";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));

            return years <= 1
                ? "one year ago"
                : years + " years ago";
        }
        public static int YearsBetween(this DateTime source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (DateTime.Today.Month < source.Month ||
                DateTime.Today.Month == source.Month &&
                DateTime.Today.Day < source.Day)
            {
                return DateTime.Today.Year - source.Year - 1;
            }
            else
            {
                return DateTime.Today.Year - source.Year;
            }
        }
        public static Age Age(this DateTime source)
        {
            return Age(source, DateTime.Now);
        }
        public static Age Age(this DateTime source, DateTime since)
        {
            if (source > since)
                throw new ArgumentException(nameof(source), $"'{nameof(source)}' should on or before '{nameof(since)}'");

            int years = 0;
            int days = 0;
            int months = 0;

            while (source.Year != since.Year || source.Month != since.Month || source.Day != since.Day)
            {
                if (source.AddYears(1).CompareTo(since) <= 0)
                {
                    years++;
                    source = source.AddYears(1);
                }
                else
                {
                    if (source.AddMonths(1).CompareTo(since) <= 0)
                    {
                        months++;
                        source = source.AddMonths(1);
                    }
                    else
                    {
                        if (source.AddDays(1).CompareTo(since) <= 0)
                        {
                            days++;
                            source = source.AddDays(1);
                        }
                        else
                        {
                            source = since;
                        }
                    }

                }
            }

            return new Age(years, months, days);
        }
        public static long ToEpoch(this DateTime source)
        {
            return Convert.ToInt64((source.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
        }
        public static DateTime ToEndOfDay(this DateTime source)
        {
            return source.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }
        public static DateTime ToStartOfDay(this DateTime source)
        {
            return source.Date;
        }
    }
}
