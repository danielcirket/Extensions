using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class Dictionary
    {
        public class KeysNotIn
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                Dictionary<object, object> input = null;
                var destination = new Dictionary<object, object>();

                Action act = () => input.KeysNotIn(destination);

                act.ShouldThrow<ArgumentException>();
            }
            [Fact]
            public static void WhenDestinationIsNullThenShouldThrowArgumentNullException()
            {
                Dictionary<object, object> input = new Dictionary<object, object>();
                Dictionary<object, object> destination = null;

                Action act = () => input.KeysNotIn(destination);

                act.ShouldThrow<ArgumentException>();
            }
            [Fact]
            public static void WhenSourceOrDestinationIsEmptyThenShouldReturnSource()
            {
                Dictionary<object, object> input = new Dictionary<object, object>();
                Dictionary<object, object> destination = new Dictionary<object, object>();

                var result = input.KeysNotIn(destination);

                result.ShouldBeEquivalentTo(input);
            }
            [Fact]
            public static void WhenSourceHasItemNotInDestinationThenShouldReturnItem()
            {
                Dictionary<int, int> input = new Dictionary<int, int>();
                Dictionary<int, int> destination = new Dictionary<int, int>();

                input.Add(1, 1);
                input.Add(2, 2);

                destination.Add(1, 2);

                var result = input.KeysNotIn(destination);

                result.ContainsKey(2).Should().BeTrue();
            }
            [Fact]
            public static void WhenSourceHasMultipleItemsNotInDestinationThenShouldReturnItems()
            {
                Dictionary<int, int> input = new Dictionary<int, int>();
                Dictionary<int, int> destination = new Dictionary<int, int>();

                input.Add(1, 1);
                input.Add(2, 2);
                input.Add(3, 3);
                input.Add(4, 4);
                input.Add(5, 5);
                input.Add(6, 6);
                input.Add(7, 7);

                destination.Add(1, 1);

                var result = input.KeysNotIn(destination);

                result.ContainsKey(2).Should().BeTrue();
                result[2].Should().Be(2);

                result.ContainsKey(3).Should().BeTrue();
                result[3].Should().Be(3);

                result.ContainsKey(4).Should().BeTrue();
                result[4].Should().Be(4);

                result.ContainsKey(5).Should().BeTrue();
                result[5].Should().Be(5);

                result.ContainsKey(6).Should().BeTrue();
                result[6].Should().Be(6);

                result.ContainsKey(7).Should().BeTrue();
                result[7].Should().Be(7);
            }
        }
    }
}
