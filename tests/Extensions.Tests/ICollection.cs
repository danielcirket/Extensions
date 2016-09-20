using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class ICollectionTests
    {
        public class UpdateCollection
        {
            [Fact]
            public static void WhenOriginalCollectionIsNullThenThrowsArgumentNullException()
            {
                ReadOnlyCollection<string> originalCollection = null;

                Action act = () => originalCollection.UpdateCollection(new Collection<string>());

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenUpdatedCollectionIsNullThenThrowsArgumentNullException()
            {
                var originalCollection = new ReadOnlyCollection<string>(new List<string>());

                Action act = () => originalCollection.UpdateCollection(null);

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenOriginalCollectionIsReadOnlyThenThrowsInvalidOperationException()
            {
                var originalCollection = new ReadOnlyCollection<string>(new List<string>());

                Action act = () => originalCollection.UpdateCollection(new Collection<string>());

                act.ShouldThrow<InvalidOperationException>();
            }
            [Fact]
            public static void WhenNewItemsInUpdatedCollectionThenShouldBeAddedToOriginalCollection()
            {
                var originalCollection = new Collection<string>(new List<string>());
                var updatedCollection = new Collection<string>(new List<string> { "NewItem" });

                var result1 = originalCollection.Contains("NewItem");

                result1.Should().Be(false);

                originalCollection.UpdateCollection(updatedCollection);

                var result2 = originalCollection.Contains("NewItem");

                result2.Should().Be(true);
            }
            [Fact]
            public static void WhenItemsNotInUpdatedCollectionThenShouldBeRemovedFromoOriginalCollection()
            {
                var originalCollection = new Collection<string>(new List<string> { "ExistingItem" });
                var updatedCollection = new Collection<string>(new List<string>());

                var result1 = originalCollection.Contains("ExistingItem");

                result1.Should().Be(true);

                originalCollection.UpdateCollection(updatedCollection);

                var result2 = originalCollection.Contains("ExistingItem");

                result2.Should().Be(false);
            }
        }
        public class AddRange
        {
            [Fact]
            public static void WhenSourceIsNullThenThrowsArgumentNullException()
            {
                List<string> originalCollection = null;

                Action act = () => originalCollection.AddRange("");

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenSourceHasItemsAddedThenShouldContainItems()
            {
                var collection = new List<A>();
                var b = new B();
                var c = new B();
                var d = new B();

                collection.AddRange(b, c, d);

                collection[0].Should().Be(b);
                collection[1].Should().Be(c);
                collection[2].Should().Be(d);
            }

            private class A
            {
                public string String { get; set; }
            }
            private class B : A
            {
                public string String2 { get; set; }
            }
        }
    }
}
