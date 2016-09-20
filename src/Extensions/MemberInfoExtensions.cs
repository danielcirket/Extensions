using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Extensions
{
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Gets whether or not the given member is marked with the specified attribute type (at least once).
        /// </summary>
        /// <param name="source">The extended MemberInfo.</param>
        /// <param name="includeInheritors">Whether or not to include inheritors of this type in the decision.</param>
        /// <returns>True if the specified attribute is applied at least once to the member, false if not.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "Correct rule, but I'm copying the way the existing GetCustomAttribute methods work.")]
        public static bool HasCustomAttribute<TAttribute>(this MemberInfo source, bool includeInheritors = false) where TAttribute : Attribute
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.GetCustomAttribute<TAttribute>(includeInheritors) != null;
        }
    }
}
