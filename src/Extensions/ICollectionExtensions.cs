using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Extensions
{
    public static class ICollectionExtensions
    {
        public static void UpdateCollection<T>(this ICollection<T> source, ICollection<T> updatedCollection)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (updatedCollection == null)
                throw new ArgumentNullException(nameof(updatedCollection));
            if (source.IsReadOnly)
                throw new InvalidOperationException("Cannot update a read-only collection.");

            var itemsToRemove = new Collection<T>();
            var itemsToAdd = new Collection<T>();

            foreach (var originalItem in source)
                if (!updatedCollection.Contains(originalItem))
                    itemsToRemove.Add(originalItem);

            foreach (var updatedItem in updatedCollection)
                if (!source.Contains(updatedItem))
                    itemsToAdd.Add(updatedItem);

            foreach (var oldItem in itemsToRemove)
                source.Remove(oldItem);

            foreach (var newItem in itemsToAdd)
                source.Add(newItem);
        }
        public static void AddRange<T, S>(this ICollection<T> source, params S[] values) where S : T
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (S value in values)
                source.Add(value);
        }
    }
}
