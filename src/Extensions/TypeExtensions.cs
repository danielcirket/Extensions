using System;
using System.Reflection;

namespace Extensions
{
    public static class TypeExtensions
    {
        public static bool Implements(this Type source, Type type)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.GetTypeInfo().IsAssignableFrom(source.GetTypeInfo());
        }
        public static bool Implements(this Type source, params Type[] types)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));


            foreach(var type in types)
            {
                if (!type.GetTypeInfo().IsAssignableFrom(source.GetTypeInfo()))
                    return false;
            }

            return true;
        }
    }
}
