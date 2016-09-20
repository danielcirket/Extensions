using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class IList
    {
        public class BinarySearch
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                IList<int> list = null;

                Action act = () => list.BinarySearch(x => x, 1);

                act.ShouldThrow<ArgumentNullException>();
            }

            [Fact]
            public static void WhenKeySelectorIsNullThenShouldThrowArgumentNullException()
            {
                IList<int> list = new List<int>();

                Action act = () => list.BinarySearch(null, 1);

                act.ShouldThrow<ArgumentNullException>();
            }

            [Fact]
            public static void WhenItemExistsInSimpleIntListThenShouldReturnKey()
            {
                IList<int> list = new List<int> { 1, 2, 3, 4, 5 };

                var result = list.BinarySearch(x => x, 4);

                result.Should().Be(4);
            }

            [Fact]
            public static void WhenItemDoesNotExistInSimpleIntListThenShouldThrowKeyNotFoundException()
            {
                IList<int> list = new List<int> { 1, 2, 3, 4, 6 };

                Action act = () => list.BinarySearch(x => x, 5);

                act.ShouldThrow<KeyNotFoundException>();
            }
        }
    }
}
