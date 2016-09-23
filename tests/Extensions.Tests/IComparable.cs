using System;
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
        public class IsBetween
        {
            [Fact]
            public static void WhenValueIsNullThenShouldThrowArgumentNullException()
            {
                string input = null;

                Action act = () => input.IsBetween("1", "2");

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenValueIsBetweenMinAndMaxThenShouldReturnTrue()
            {
                var input = 5;

                var result = input.IsBetween(1, 10);

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenValueIsNotBetweenMinAndMaxThenShouldReturnFalse()
            {
                var input = 15;

                var result = input.IsBetween(1, 10);

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenValueIsOnBorderAndInclusiveIsFalseThenShouldReturnFalse()
            {
                var input = 10;

                var result = input.IsBetween(1, 10, false);

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenValueIsOnBorderAndInclusiveIsTrueThenShouldReturnTrue()
            {
                var input = 10;

                var result = input.IsBetween(1, 10);

                result.Should().Be(true);
            }
        }
    }
}
