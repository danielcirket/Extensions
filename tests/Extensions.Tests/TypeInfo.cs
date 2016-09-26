using System;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class TypeInfoTests
    {
        public class Implements
        {
            [Fact]
            public static void WhenSourceIsNullThenShouldThrowArgumentNullException()
            {
                TypeInfo input = null;

                Action act = () => input.Implements(typeof(object).GetTypeInfo());

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenImplementsIsNullThenShouldThrowArgumentNullException()
            {
                var input = typeof(string).GetTypeInfo();
                TypeInfo implements = null;

                Action act = () => input.Implements(implements);

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenSourceImplementsSuppliedTypeThenShouldReturnTrue()
            {
                var input = typeof(string).GetTypeInfo();

                var result = input.Implements(typeof(object).GetTypeInfo());

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenSourceDoesNotImplementSuppliedTypeThenShouldReturnFalse()
            {
                var input = typeof(string).GetTypeInfo();

                var result = input.Implements(typeof(int).GetTypeInfo());

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenSourceImplementsAllSuppliedTypesThenShouldReturnTrue()
            {
                var input = typeof(A).GetTypeInfo();

                var result = input.Implements(typeof(D).GetTypeInfo(), typeof(C).GetTypeInfo(), typeof(B).GetTypeInfo());

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenSourceDoesNotImplementAllSuppliedTypesThenShouldReturnFalse()
            {
                var input = typeof(A).GetTypeInfo();

                var result = input.Implements(typeof(E).GetTypeInfo(), typeof(D).GetTypeInfo(), typeof(C).GetTypeInfo(), typeof(B).GetTypeInfo());

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
