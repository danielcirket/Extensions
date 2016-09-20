using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Extensions
{
    public static class GenericExtensions
    {
        public static bool IsAnyOf<T>(this T source, params T[] list)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return list.Contains(source);
        }
        public static bool IsNull<T>(this T source)
        {
            return source == null;
        }
        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }
    }
}
