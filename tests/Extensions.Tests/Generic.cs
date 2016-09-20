using System;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class GenericTests
    {
        public class IsAnyOf
        {
            [Fact]
            public static void WhenInputIsNullThenShouldThrowArgumentNullException()
            {
                string input = null;

                Action act = () => input.IsAnyOf("This", "is", "a", "test");

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenInputInListOfParametersThenShouldReturnTrue()
            {
                var input = "This";

                var result = input.IsAnyOf("This", "is", "a", "test");

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenInputInNotInListOfParametersThenShouldReturnFalse()
            {
                var input = "Missing";

                var result = input.IsAnyOf("This", "is", "a", "test");

                result.Should().Be(false);
            }
        }
        public class IsNull
        {
            [Fact]
            public static void WhenInputIsNullThenShouldReturnTrue()
            {
                string input = null;

                var result = input.IsNull();

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenInputIsNotNullThenShouldReturnTrue()
            {
                string input = string.Empty;

                var result = input.IsNull();

                result.Should().Be(false);
            }
        }

        public class AsDictionary
        {
            // TODO(Dan): Write these tests
        }
    }
}
