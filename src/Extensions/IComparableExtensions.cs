using System;

namespace Extensions
{
    public static class IComparableExtensions
    {
        public static T Clamp<T>(this T source, T min, T max) where T : IComparable<T>
        {
            if (source.CompareTo(min) < 0)
                return min;
            else if (source.CompareTo(max) > 0)
                return max;
            else
                return source;
        }
        public static bool IsBetween<T>(this T source, T min, T max, bool inclusive = true) where T : IComparable<T>
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (inclusive)
                return source.CompareTo(min) >= 0 && source.CompareTo(max) <= 0;

            return source.CompareTo(min) > 0 && source.CompareTo(max) < 0;
        }
    }
}
