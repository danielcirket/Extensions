using System;

namespace Extensions
{
    [Flags]
    public enum VersionComparison
    {
        Major = 1 << 1,
        Minor = 2 << 1,
        Build = 3 << 1,
        Revision = 4 << 1,
        All = Major & Minor & Build & Revision
    }
}
