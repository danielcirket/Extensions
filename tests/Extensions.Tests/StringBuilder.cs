using System.Text;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class StringBuilderTests
    {
        public class TrimStart
        {
            [Fact]
            public static void WhenNoCharactersSuppliedThenShouldRemoveWhitespaceCharactersFromStart()
            {
                var input = new StringBuilder().Append(" Test");
                var expected = "Test";

                var result = input.TrimStart();

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenCharacterSuppliedThatIsFirstCharacterThenShouldRemoveCharacterFromStart()
            {
                var input = new StringBuilder().Append("xTest");
                var expected = "Test";

                var result = input.TrimStart('x');

                result.ToString().Should().Be(expected);
            }
            
            [Fact]
            public static void WhenMultipleCharactersSuppliedThatAreFirstCharactersThenShouldRemoveCharactersFromStart()
            {
                var input = new StringBuilder().Append("xyzTest");
                var expected = "Test";

                var result = input.TrimStart('x', 'y', 'z');

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenCharacterSuppliedThatDoesNotMatchStartThenShouldNotRemoveFromStart()
            {
                var input = new StringBuilder().Append("keepTest");
                var expected = "keepTest";

                var result = input.TrimStart('x');

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenStringSuppliedMatchesStartThenShouldRemoveStringFromStart()
            {
                var input = new StringBuilder().Append("removeTest");
                var expected = "Test";

                var result = input.TrimStart("remove");

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenStringSuppliedThatDoesNotMatchStartThenShouldNotRemoveFromStart()
            {
                var input = new StringBuilder().Append("keepTest");
                var expected = "keepTest";

                var result = input.TrimStart("remove");

                result.ToString().Should().Be(expected);
            }
        }

        public class TrimEnd
        {
            [Fact]
            public static void WhenNoCharactersSuppliedThenShouldRemoveWhitespaceCharactersFromEnd()
            {
                var input = new StringBuilder().Append("Test ");
                var expected = "Test";

                var result = input.TrimEnd();

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenCharacterSuppliedThatIsLastCharacterThenShouldRemoveCharacterFromEnd()
            {
                var input = new StringBuilder().Append("Testx");
                var expected = "Test";

                var result = input.TrimEnd('x');

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenMultipleCharactersSuppliedThatAreLastCharacterThenShouldRemoveMatchingCharacterFromEnd()
            {
                var input = new StringBuilder().Append("Testxyz");
                var expected = "Testxy";

                var result = input.TrimEnd('x', 'y', 'z');

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenCharacterSuppliedThatDoesNotMatchEndThenShouldNotRemoveFromEnd()
            {
                var input = new StringBuilder().Append("keepTest");
                var expected = "keepTest";

                var result = input.TrimEnd('x');

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenStringSuppliedMatchesEndThenShouldRemoveStringFromEnd()
            {
                var input = new StringBuilder().Append("Testremove");
                var expected = "Test";

                var result = input.TrimEnd("remove");

                result.ToString().Should().Be(expected);
            }

            [Fact]
            public static void WhenStringSuppliedThatDoesNotMatchEndThenShouldNotRemoveFromEnd()
            {
                var input = new StringBuilder().Append("Testkeep");
                var expected = "Testkeep";

                var result = input.TrimStart("remove");

                result.ToString().Should().Be(expected);
            }
        }
    }
}
