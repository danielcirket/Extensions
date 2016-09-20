using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class IComparableTests
    {
        public class Clamp
        {
            [Fact]
            public static void WhenValueToClampGreaterThanMaxReturnMax()
            {
                var input = 10;

                var result = input.Clamp(0, 1);

                result.Should().Be(1);
            }
            [Fact]
            public static void WhenValueToClampLessThanMinReturnMin()
            {
                var input = -1;

                var result = input.Clamp(0, 1);

                result.Should().Be(0);
            }
            [Fact]
            public static void WhenValueToClampGreaterThanMinAndLessThanMaxReturnValue()
            {
                var input = 1;

                var result = input.Clamp(0, 2);

                result.Should().Be(1);
            }
        }
    }
}
