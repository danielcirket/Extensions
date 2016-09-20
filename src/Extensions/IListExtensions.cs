using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class IListExtensions
    {
        public static T BinarySearch<T, TKey>(this IList<T> source, Func<T, TKey> keySelector, TKey key) where TKey : IComparable<TKey>
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            int min = 0;
            int max = source.Count - 1;

            while (min < max)
            {
                int mid = (max + min) / 2;
                T midItem = source[mid];
                TKey midKey = keySelector(midItem);
                int comp = midKey.CompareTo(key);
                if (comp < 0)
                {
                    min = mid + 1;
                }
                else if (comp > 0)
                {
                    max = mid - 1;
                }
                else
                {
                    return midItem;
                }
            }
            if (min == max && keySelector(source[min]).CompareTo(key) == 0)
            {
                return source[min];
            }

            throw new KeyNotFoundException("Item not found");
        }
    }
}
