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

        public class ToDictionary
        {
            [Fact]
            public static void WhenInputIsNullThenShouldThrowArgumentNullException()
            {
                object input = null;

                Action act = () => input.ToDictionary();

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenInputIsNotNullThenShouldReturnDictionaryWhichContainsPropertiesAsKeys()
            {
                var input = new { Id = 1, Name = "Name" };

                var result = input.ToDictionary();

                result.Keys.Count.Should().Be(2);
                result.ContainsKey("Id").Should().Be(true);
                result.ContainsKey("Name").Should().Be(true);
            }
            [Fact]
            public static void WhenInputIsNotNullThenShouldReturnDictionaryWhichContainsPropertyValuesAsValues()
            {
                var input = new { Id = 1, Name = "Name" };

                var result = input.ToDictionary();

                result.Values.Count.Should().Be(2);
                result["Id"].Should().Be(1);
                result["Name"].Should().Be("Name");
            }
            
            // TODO(Dan): Add tests for different property types (e.g. public, protected, private, declared vs inherited etc)
        }
    }
}
