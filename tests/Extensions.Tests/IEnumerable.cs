using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class IEnumerableTests
    {
        public class DoesNotContain
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                IEnumerable<string> input = null;

                Action act = () => input.DoesNotContain("test");

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenSourceContainsItemThenShouldReturnFalse()
            {
                IEnumerable<string> input = new List<string>
            {
                "This",
                "Is",
                "A",
                "Test"
            };

                var result = input.DoesNotContain("Test");

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenSourceDoesNotContainItemThenShouldReturnTrue()
            {
                IEnumerable<string> input = new List<string>
            {
                "This",
                "Is",
                "A",
                "Test"
            };

                var result = input.DoesNotContain("Example");

                result.Should().Be(true);
            }
        }
        public class None
        {
            [Fact]
            public static void WhenSourceIsNullThenNoneShouldThrowArgumentNullException()
            {
                IEnumerable<string> input = null;

                Action act = () => input.None();

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenSourceContainsNoItemsThenShouldReturnTrue()
            {
                IEnumerable<string> input = new List<string>();

                var result = input.None();

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenSourceContainsItemsThenShouldReturnFalse()
            {
                IEnumerable<string> input = new List<string> { "Test" };

                var result = input.None();

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenSourceIsNullWithPredicateThenShouldThrowArgumentNullException()
            {
                IEnumerable<string> input = null;

                Action act = () => input.None(x => x == "test");

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenSourceContainsItemThatMatchesPredicateThenShouldReturnFalse()
            {
                IEnumerable<string> input = new List<string> { "Test" };

                var result = input.None(x => x == "Test");

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenSourceContainsNoItemsThatMatchesPredicateThenShouldReturnTrue()
            {
                IEnumerable<string> input = new List<string> { "Test" };

                var result = input.None(x => x == "Missing");

                result.Should().Be(true);
            }
        }
        public class IsNullOrEmpty
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldReturnTrue()
            {
                IEnumerable<string> input = null;

                var result = input.IsNullOrEmpty();

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenSourceIsEmptyThenShouldReturnTrue()
            {
                IEnumerable<string> input = new List<string>();

                var result = input.IsNullOrEmpty();

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenSourceIsNotEmptyShouldReturnFalse()
            {
                IEnumerable<string> input = new List<string> { "Item" };

                var result = input.IsNullOrEmpty();

                result.Should().Be(false);
            }
        }
        public class Chunk
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                List<int> input = null;

                Action act = () => input.Chunk(1);

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenChunkSizeLessThanOneThenShouldThrowArgumentException()
            {
                var input = new List<int>();

                Action act = () => input.Chunk(-1);

                act.ShouldThrow<ArgumentException>();
            }
            [Fact]
            public static void WhenSourceContainsLessItemsThanChunkSizeThenShouldReturnSingleChunkContainingSourceItems()
            {
                List<int> input = new List<int> { 1, 2, 3, 4, 5 };

                var result = input.Chunk(10);

                result.Count().Should().Be(1);
                result.ToList()[0].Count().Should().Be(5);
            }
            [Fact]
            public static void WhenSourceContainsMoreItemsThanChunkSizeThenShouldReturnSingleChunkContainingSourceItems()
            {
                List<int> input = new List<int> { 1, 2, 3, 4, 5 };

                var result = input.Chunk(1);

                result.Count().Should().Be(5);
                result.ToList()[0].Count().Should().Be(1);
            }
        }
        public class Slice
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                IEnumerable<int> input = null;

                Action act = () => input.Slice(0, 1);

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenValidStartAndTakeThenShouldReturnIEnumerableContainingSliceItems()
            {
                IEnumerable<int> input = new List<int> { 1, 2, 3, 4, 5 };
                IEnumerable<int> expected = new List<int> { 1, 2 };

                var result = input.Slice(0, 2);

                result.ShouldBeEquivalentTo(expected);
            }
            [Fact]
            public static void WhenNegativeTakeThenShouldThrowArgumentOutOfRangeException()
            {
                IEnumerable<int> input = new List<int> { 1, 2, 3, 4, 5 };
                IEnumerable<int> expected = new List<int> { 4, 5 };

                Action act = () => input.Slice(0, -2);

                act.ShouldThrow<ArgumentOutOfRangeException>();
            }
            [Fact]
            public static void WhenNegativeStartThenShouldStartFromEndOfSource()
            {
                IEnumerable<int> input = new List<int> { 1, 2, 3, 4, 5 };
                IEnumerable<int> expected = new List<int> { 4, 5 };

                var result = input.Slice(-2, 2);

                result.ShouldBeEquivalentTo(expected);
            }
        }
        public class NotIn
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                IEnumerable<int> input = null;

                Action act = () => input.NotIn(Enumerable.Empty<int>());

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenSourceIsNotNullAndListToSearchIsNullOrEmptyThenShouldReturnEmptyEnumerable()
            {
                IEnumerable<int> input = Enumerable.Empty<int>();

                var result = input.NotIn(Enumerable.Empty<int>());

                result.Should().BeEmpty();
            }
            [Fact]
            public static void Test()
            {
                IEnumerable<TestClass> input = new List<TestClass>
                {
                    new TestClass { Id = 1, Name = "Name1" },
                    new TestClass { Id = 2, Name = "Name2" },
                };
                IEnumerable<TestClass> search = new List<TestClass>
                {
                    new TestClass { Id = 1, Name = "Name1" },
                    new TestClass { Id = 3, Name = "Name3" },
                };

                var results = input.NotIn(search, x => x.Id);

                results.Count().Should().Be(1);
                results.First().ShouldBeEquivalentTo(new TestClass { Id = 2, Name = "Name2" });
            }

            public class TestClass
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
        }
    }
}
