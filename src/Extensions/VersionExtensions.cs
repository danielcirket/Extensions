using System;

namespace Extensions
{
    public static class VersionExtensions
    {
        public static int CompareTo(this Version source, Version compareTo, VersionComparison significantParts = VersionComparison.All)
        {
            // Major        - 1.x.x.x
            // Minor        - x.1.x.x
            // Build        - x.x.1.x
            // Revision     - x.x.x.1

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (compareTo == null)
                return 1;

            if (source.Major != compareTo.Major && significantParts.HasFlag(VersionComparison.Major))
                if (source.Major > compareTo.Major)
                    return 1;
                else
                    return -1;

            if (source.Minor != compareTo.Minor && significantParts.HasFlag(VersionComparison.Minor))
                if (source.Minor > compareTo.Minor)
                    return 1;
                else
                    return -1;

            if (source.Build != compareTo.Build && significantParts.HasFlag(VersionComparison.Build))
                if (source.Build > compareTo.Build)
                    return 1;
                else
                    return -1;

            if (source.Revision != compareTo.Revision && significantParts.HasFlag(VersionComparison.Revision))
                if (source.Revision > compareTo.Revision)
                    return 1;
                else
                    return -1;

            return 0;
        }
    }
}
