using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool DoesNotContain<T>(this IEnumerable<T> source, T item)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return !source.Contains(item);
        }
        public static bool None<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return !source.Any();
        }
        public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return !source.Any(predicate);
        }
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var keys = new HashSet<TKey>();

            foreach (TSource element in source)
                if (keys.Add(keySelector(element)))
                    yield return element;
        }
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (chunkSize <= 0)
                throw new ArgumentException($"{nameof(chunkSize)} must be greater than 0", nameof(chunkSize));

            return ChunkInternal(source, chunkSize);
        }
        /// <summary>
        /// If the start index is negative, the slice takes from the end of the source.
        /// For e.g. -5, 5 will take 5 from the end of the IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int startIndex, int take)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (take < 0)
                throw new ArgumentOutOfRangeException(nameof(take), $"{nameof(take)} cannot be less than 0.");

            return SliceInternal(source, startIndex, take);
        }
        public static IEnumerable<T> NotIn<T>(this IEnumerable<T> source, IEnumerable<T> list)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (list.IsNullOrEmpty())
                return Enumerable.Empty<T>();

            return source.Where(item => !list.Contains(item));
        }
        public static IEnumerable<T> NotIn<T, TKey>(this IEnumerable<T> source, IEnumerable<T> list, Func<T, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (list.IsNullOrEmpty())
                return Enumerable.Empty<T>();

            return source.Where(item => !list.Any(x => keySelector(x).Equals(keySelector(item))));
        }
        public static string ToString<T>(this IEnumerable<T> source, string separater)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return ToString(source, item => item.ToString(), separater);
        }
        public static string ToString<T>(this IEnumerable<T> source, Func<T, string> valueSelector, string separater)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var sb = new StringBuilder();

            foreach (var item in source)
                sb.Append($"{valueSelector(item)}{separater}");

            return sb.TrimEnd(", ").ToString();
        }

        private static IEnumerable<IEnumerable<T>> ChunkInternal<T>(IEnumerable<T> source, int chunkSize)
        {
            var chunk = new List<T>();

            foreach (var x in source)
            {
                chunk.Add(x);
                if (chunk.Count >= chunkSize)
                {
                    yield return chunk;
                    chunk = new List<T>();
                }
            }

            if (chunk.Any())
                yield return chunk;
        }
        private static IEnumerable<T> SliceInternal<T>(IEnumerable<T> source, int startIndex, int take)
        {
            var index = 0;
            var count = 0;

            // Optimise item count for ICollection interfaces.
            if (source is ICollection<T>)
                count = ((ICollection<T>)source).Count;
            else if (source is ICollection)
                count = ((ICollection)source).Count;
            else
                count = source.Count();

            //Get start/ end indexes, negative numbers start at the end of the collection.
            if (startIndex < 0)
                startIndex += count;

            foreach (var item in source)
            {
                if (index >= startIndex + take)
                    yield break;

                if (index >= startIndex)
                    yield return item;

                ++index;
            }
        }
    }
}
