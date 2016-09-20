using System;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class VersionTests
    {
        public class CompareTo
        {
            // Major        - 1.x.x.x
            // Minor        - x.1.x.x
            // Build        - x.x.1.x
            // Revision     - x.x.x.1

            [Fact]
            public static void WhenSourceVersionIsNullThenShouldThrowArgumentNullException()
            {
                Version version = null;

                Action act = () => version.CompareTo(new Version(), 0);

                act.ShouldThrow<ArgumentException>();
            }
            [Fact]
            public static void WhenCompareToIsNullThenShouldReturnOne()
            {
                var version = new Version(1, 0, 0, 0);
                Version versionToCompare = null;

                var result = version.CompareTo(versionToCompare, VersionComparison.Major);

                result.Should().Be(1);
            }
            [Fact]
            public static void WhenSignificantPartsToCompareIsZeroThenShouldReturnZero()
            {
                var version = new Version(1, 0, 0, 0);
                var versionToCompare = new Version(1, 0, 0, 0);

                var result = version.CompareTo(versionToCompare);

                result.Should().Be(0);
            }
            [Fact]
            public static void WhenComparingMatchingMajorVersionsOnlyThenShouldReturnZero()
            {
                var version = new Version(1, 0, 0, 0);
                var versionToCompare = new Version(1, 0, 0, 0);

                var result = version.CompareTo(versionToCompare, VersionComparison.Major);

                result.Should().Be(0);
            }
            [Fact]
            public static void WhenComparingMatchingMajorAndMinorVersionsOnlyThenShouldReturnZero()
            {
                var version = new Version(1, 0, 0, 0);
                var versionToCompare = new Version(1, 0, 0, 0);

                var result = version.CompareTo(versionToCompare, VersionComparison.Major | VersionComparison.Minor);

                result.Should().Be(0);
            }
            [Fact]
            public static void WhenComparingMatchingMajorAndMinorAndBuildVersionsOnlyThenShouldReturnZero()
            {
                var version = new Version(1, 0, 0, 0);
                var versionToCompare = new Version(1, 0, 0, 0);

                var result = version.CompareTo(versionToCompare, VersionComparison.Major | VersionComparison.Minor | VersionComparison.Build);

                result.Should().Be(0);
            }
            [Fact]
            public static void WhenComparingMatchingMajorAndMinorAndBuildAndRevisionVersionsOnlyThenShouldReturnZero()
            {
                var version = new Version(1, 1, 1, 1);
                var versionToCompare = new Version(1, 1, 1, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.All);

                result.Should().Be(0);
            }
            [Fact]
            public static void WhenComparingDifferentMajorVersionThenShouldReturnOneWhenSourceHasHigherVersion()
            {
                var version = new Version(2, 1, 1, 1);
                var versionToCompare = new Version(1, 1, 1, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.Major);

                result.Should().Be(1);
            }
            [Fact]
            public static void WhenComparingDifferentMajorVersionThenShouldReturnMinusOneWhenSourceHasLowerVersion()
            {
                var version = new Version(1, 1, 1, 1);
                var versionToCompare = new Version(2, 1, 1, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.Major);

                result.Should().Be(-1);
            }
            [Fact]
            public static void WhenComparingDifferentMinorVersionThenShouldReturnOneSourceHasHigherVersion()
            {
                var version = new Version(1, 2, 1, 1);
                var versionToCompare = new Version(1, 1, 1, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.Major | VersionComparison.Minor);

                result.Should().Be(1);
            }
            [Fact]
            public static void WhenComparingDifferentMinorVersionThenShouldReturnMinusOneSourceHasLowerVersion()
            {
                var version = new Version(1, 1, 1, 1);
                var versionToCompare = new Version(1, 2, 1, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.Major | VersionComparison.Minor);

                result.Should().Be(-1);
            }
            [Fact]
            public static void WhenComparingDifferentBuildVersionThenShouldReturnOneWhenSourceHasHigherVersion()
            {
                var version = new Version(1, 1, 2, 1);
                var versionToCompare = new Version(1, 1, 1, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.Build);

                result.Should().Be(1);
            }
            [Fact]
            public static void WhenComparingDifferentBuildVersionThenShouldReturnMinusOneWhenSourceHasLowerVersion()
            {
                var version = new Version(1, 1, 1, 1);
                var versionToCompare = new Version(1, 1, 2, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.Build);

                result.Should().Be(-1);
            }
            [Fact]
            public static void WhenComparingDifferentRevisionVersionThenShouldReturnOneSourceHasHigherVersion()
            {
                var version = new Version(1, 1, 1, 2);
                var versionToCompare = new Version(1, 1, 1, 1);

                var result = version.CompareTo(versionToCompare, VersionComparison.Revision);

                result.Should().Be(1);
            }
            [Fact]
            public static void WhenComparingDifferentRevisionVersionThenShouldReturnMinusOneSourceHasLowerVersion()
            {
                var version = new Version(1, 1, 1, 1);
                var versionToCompare = new Version(1, 1, 1, 2);

                var result = version.CompareTo(versionToCompare, VersionComparison.Revision);

                result.Should().Be(-1);
            }
        }
    }
}
