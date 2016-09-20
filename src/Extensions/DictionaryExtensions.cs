using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> KeysNotIn<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> destination)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            if (source.None() || destination.None())
                return source;

            var result = new Dictionary<TKey, TValue>();

            foreach (var item in source)
            {
                if (!destination.ContainsKey(item.Key))
                    result.Add(item.Key, item.Value);
            }

            return result;
        }
    }
}
