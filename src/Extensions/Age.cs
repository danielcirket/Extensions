using System;

namespace Extensions
{
    public struct Age
    {
        public int Years { get; }
        public int Months { get; }
        public int Days { get; }

        public Age(int years, int months, int days)
        {
            if (years < 0)
                throw new ArgumentOutOfRangeException(nameof(years));

            if (months < 0 || months > 12)
                throw new ArgumentOutOfRangeException(nameof(years));

            if (days < 0 || days > 31)
                throw new ArgumentOutOfRangeException(nameof(years));

            Years = years;
            Months = months;
            Days = days;
        }
    }
}
