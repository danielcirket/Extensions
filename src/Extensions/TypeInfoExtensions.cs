using System;
using System.Reflection;

namespace Extensions
{
    public static class TypeInfoExtensions
    {
        public static bool Implements(this TypeInfo source, TypeInfo typeInfo)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (typeInfo == null)
                throw new ArgumentNullException(nameof(typeInfo));

            return typeInfo.IsAssignableFrom(source);
        }
        public static bool Implements(this TypeInfo source, params TypeInfo[] typeInfos)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var typeInfo in typeInfos)
            {
                if (!typeInfo.IsAssignableFrom(source))
                    return false;
            }

            return true;
        }
    }
}
