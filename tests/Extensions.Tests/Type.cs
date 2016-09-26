using System;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class TypeTests
    {
        public class Implements
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                Type input = null;

                Action act = () => input.Implements(typeof(object));

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenImplementsIsNullThenShouldThrowArgumentNullException()
            {
                var input = typeof(string);
                Type implements = null;

                Action act = () => input.Implements(implements);

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenSourceImplementsSuppliedTypeThenShouldReturnTrue()
            {
                var input = typeof(string);

                var result = input.Implements(typeof(object));

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenSourceDoesNotImplementSuppliedTypeThenShouldReturnFalse()
            {
                var input = typeof(string);

                var result = input.Implements(typeof(int));

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenSourceImplementsAllSuppliedTypesThenShouldReturnTrue()
            {
                var input = typeof(A);

                var result = input.Implements(typeof(D), typeof(C), typeof(B));

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenSourceDoesNotImplementAllSuppliedTypesThenShouldReturnFalse()
            {
                var input = typeof(A);

                var result = input.Implements(typeof(E), typeof(D), typeof(C), typeof(B));

                result.Should().Be(false);
            }

            public class A : B { }
            public class B : C { }
            public class C : D { }
            public interface D { }
            public interface E { }
        }
    }
}
