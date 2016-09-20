using System;
using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public class StringTests
    {
        public class HasValue
        {
            [Fact]
            public static void WhenNullInputShouldReturnFalse()
            {
                string input = null;

                var result = input.HasValue();

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenEmptyInputShouldReturnFalse()
            {
                string input = string.Empty;

                var result = input.HasValue();

                result.Should().Be(false);
            }
            [Fact]
            public static void WhenNonEmptyInputShouldReturnFalse()
            {
                string input = "Test String";

                var result = input.HasValue();

                result.Should().Be(true);
            }
        }
        public class ToInt
        {
            [Fact]
            public static void WhenNullInputShouldReturnDefaultValue()
            {
                string input = null;
                var result = input.ToInt();
                result.Should().Be(0);
            }
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            public static void WhenEmptyOrWhitespaceInputShouldReturnDefaultValue(string input)
            {
                var result = input.ToInt();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInvalidIntInputShouldReturnDefaultValue()
            {
                string input = "1A";
                var result = input.ToInt();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenValidIntInputShouldReturnInputAsInt()
            {
                string input = "1";
                var result = input.ToInt();
                result.Should().Be(1);
            }
        }
        public class ToDecimal
        {
            [Fact]
            public static void WhenNullStringShouldReturnDefaultValue()
            {
                string input = null;
                var result = input.ToDecimal();
                result.Should().Be(0);
            }
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            public static void WhenEmptyOrWhitespaceStringShouldReturnDefaultValue(string input)
            {
                var result = input.ToDecimal();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInvalidDecimalStringShouldReturnDefaultValue()
            {
                string input = "1A";
                var result = input.ToDecimal();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenValidDecimalStringShouldReturnInputAsDecimal()
            {
                string input = "1";
                var result = input.ToDecimal();
                result.Should().Be(1);
            }
        }
        public class ToFloat
        {
            [Fact]
            public static void WhenNullStringShouldReturnDefaultValue()
            {
                string input = null;
                var result = input.ToFloat();
                result.Should().Be(0);
            }
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            public static void WhenEmptyOrWhitespaceStringShouldReturnDefaultValue(string input)
            {
                var result = input.ToFloat();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInvalidFloatStringShouldReturnDefaultValue()
            {
                string input = "1A";
                var result = input.ToFloat();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenValidFloatStringShouldReturnInputAsFloat()
            {
                string input = "1.5";
                var result = input.ToFloat();
                result.Should().Be(1.5F);
            }
        }
        public class ToDouble
        {
            [Fact]
            public static void WhenNullStringShouldReturnDefaultValue()
            {
                string input = null;
                var result = input.ToDouble();
                result.Should().Be(0);
            }
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            public static void WhenEmptyOrWhitespaceStringShouldReturnDefaultValue(string input)
            {
                var result = input.ToDouble();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInvalidDoubleStringShouldReturnDefaultValue()
            {
                string input = "1A";
                var result = input.ToDouble();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenValidDoubleStringShouldReturnInputAsDouble()
            {
                string input = "1.5";
                var result = input.ToDouble();
                result.Should().Be(1.5D);
            }
        }
        public class RemoveWhiteSpace
        {
            [Fact]
            public static void WhenNullStringThenShouldThrowArgumentNullException()
            {
                string input = null;

                Action act = () => input.RemoveWhiteSpace();

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenStringContainsWhiteSpaceThenShouldReturnStringWithoutWhiteSpace()
            {
                var input = "This is a string";

                var result = input.RemoveWhiteSpace();

                result.Should().Be("Thisisastring");
            }
            [Fact]
            public static void WhenStringContainsNoWhiteSpaceThenShouldReturnSameInput()
            {
                var input = "ThisIsAString";

                var result = input.RemoveWhiteSpace();

                result.Should().Be("ThisIsAString");
            }
        }
        public class UpperCaseWords
        {
            [Fact]
            public static void WhenNullStringThenShouldThrowArgumentNullException()
            {
                string input = null;

                Action act = () => input.UpperCaseWords();

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenStringContainsLowerCaseWordsThenShouldReturnStringWithCapitalisedWords()
            {
                var input = "This is a string";

                var result = input.UpperCaseWords();

                result.Should().Be("This Is A String");
            }
            [Fact]
            public static void WhenStringContainsNoLowerCaseWordsThenShouldReturnSameInput()
            {
                var input = "This Is A String";

                var result = input.UpperCaseWords();

                result.Should().Be("This Is A String");
            }
        }
        public class CameliseWords
        {
            [Fact]
            public static void WhenNullInputShouldThrowArgumentNullException()
            {
                string input = null;

                Action act = () => input.CameliseWords();

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenInputContainsSpacesShouldReturnCamelisedInputWithSpacesRemoved()
            {
                string input = "This is a test";

                var result = input.CameliseWords();

                result.Should().Be("ThisIsATest");
            }
            [Fact]
            public static void WhenInputContainsHyphensShouldReturnCamelisedInputWithHyphensRemoved()
            {
                string input = "This-is-a-test";

                var result = input.CameliseWords();

                result.Should().Be("ThisIsATest");
            }
            [Fact]
            public static void WhenInputContainsUnderscoresShouldReturnCamelisedInputWithHyphensRemoved()
            {
                string input = "This_is_a_test";

                var result = input.CameliseWords();

                result.Should().Be("ThisIsATest");
            }
            [Fact]
            public static void WhenInputWordsStartWithLowercaseShouldReturnCamelisedInput()
            {
                string input = "This is a test";

                var result = input.CameliseWords();

                result.Should().Be("ThisIsATest");
            }
        }
        public class ToEnum
        {
            [Fact]
            public static void WhenStringIsNullThenShouldThrowArgumentNullException()
            {
                string input = null;

                Action act = () => input.ToEnum<ParseEnumTestEnum>();

                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenStringExistsAsNameInEnumThenShouldReturnEnumWithMatchingValue()
            {
                var input = "Two";

                var result = input.ToEnum<ParseEnumTestEnum>();

                result.Should().Be(ParseEnumTestEnum.Two);
            }
            [Fact]
            public static void WhenStringExistsAsNameInEnumButDifferentCaseThenShouldReturnEnumWithMatchingValue()
            {
                var input = "two";

                var result = input.ToEnum<ParseEnumTestEnum>();

                result.Should().Be(ParseEnumTestEnum.Two);
            }
            [Fact]
            public static void WhenStringExistsAsNameInEnumButDifferentCaseThenShouldThrowExceptionWhenStrictCasing()
            {
                var input = "two";

                Action act = () => input.ToEnum<ParseEnumTestEnum>(false);

                act.ShouldThrow<Exception>();
            }

            private enum ParseEnumTestEnum
            {
                One = 1,
                Two,
                Three
            }
        }
        public class Contains
        {
            [Fact]
            public static void WhenInputIsNullThenShouldThrowArgumentNullException()
            {
                string input = null;

                Action act = () => input.Contains("", StringComparison.OrdinalIgnoreCase);

                act.ShouldThrow<ArgumentNullException>();
            }
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            public static void WhenInputToFindIsNullThenShouldReturnTrue(string search)
            {
                var input = "This is a string";

                var result = input.Contains(search, StringComparison.OrdinalIgnoreCase);

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenInputToFindExistsInInputThenShouldReturnTrue()
            {
                var input = "This is a string";

                var result = input.Contains("string", StringComparison.OrdinalIgnoreCase);

                result.Should().Be(true);
            }
            [Fact]
            public static void WhenInputToFindDoesNotExistInInputThenShouldReturnFalse()
            {
                var input = "This is a string";

                var result = input.Contains("value", StringComparison.OrdinalIgnoreCase);

                result.Should().Be(false);
            }
        }
        public class Truncate
        {
            [Fact]
            public static void WhenNullInputShouldThrowArgumentNullException()
            {
                string input = null;
                Action act = () => input.Truncate(1);
                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenMaxLengthLessThanZeroThenShouldThrowArgumentException()
            {
                var input = string.Empty;

                Action act = () => input.Truncate(-1);

                act.ShouldThrow<ArgumentOutOfRangeException>();
            }
            [Theory]
            [InlineData("")]
            public static void WhenInputIsNullOrEmptyShouldReturnInput(string input)
            {
                var result = input.Truncate(1);

                result.Should().Be(input);
            }
            [Fact]
            public static void WhenInputLengthLessThanMaxLengthThenShouldReturnInput()
            {
                var input = "This is a test";

                var result = input.Truncate(50);

                result.Should().Be(input);
            }
            [Fact]
            public static void WhenInputLengthGreaterThanMaxLengthThenShouldReturnInputTruncatedToMaxLength()
            {
                var input = "This is a test";

                var result = input.Truncate(10);

                result.Should().Be("This is a ");
                result.Length.Should().Be(10);
            }

        }
        public class TrimStart
        {
            [Fact]
            public static void WhenNullInputShouldThrowArgumentNullException()
            {
                string input = null;
                Action act = () => input.TrimStart(" ");
                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenInputStartsWithTrimWordThenShouldReturnTrimmedInput()
            {
                var input = "TestInput";

                var result = input.TrimStart("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputStartsWithMultipleTrimWordsThenShouldReturnTrimmedInput()
            {
                var input = "TestTestTestInput";

                var result = input.TrimStart("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputDoesNotStartWithTrimWordThenShouldReturnInput()
            {
                var input = "InputTestTestTestInput";

                var result = input.TrimStart("Test");

                result.Should().Be(input);
            }
        }
        public class TrimEnd
        {
            [Fact]
            public static void WhenNullInputShouldThrowArgumentNullException()
            {
                string input = null;
                Action act = () => input.TrimEnd(" ");
                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenInputEndsWithTrimWordThenShouldReturnTrimmedInput()
            {
                var input = "InputTest";

                var result = input.TrimEnd("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputEndsWithMultipleTrimWordsThenShouldReturnTrimmedInput()
            {
                var input = "InputTestTestTest";

                var result = input.TrimEnd("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputDoesNotEndWithTrimWordThenShouldReturnInput()
            {
                var input = "InputTestTestTestInput";

                var result = input.TrimEnd("Test");

                result.Should().Be(input);
            }
        }
        public class Trim
        {
            [Fact]
            public static void WhenNullInputShouldThrowArgumentNullException()
            {
                string input = null;
                Action act = () => input.Trim(" ");
                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenInputEndsWithTrimWordThenShouldReturnTrimmedInput()
            {
                var input = "InputTest";

                var result = input.Trim("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputEndsWithMultipleTrimWordsThenShouldReturnTrimmedInput()
            {
                var input = "InputTestTestTest";

                var result = input.Trim("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputDoesNotEndWithTrimWordThenShouldReturnInput()
            {
                var input = "InputTestTestTestInput";

                var result = input.Trim("Test");

                result.Should().Be(input);
            }
            [Fact]
            public static void WhenInputStartsWithTrimWordThenShouldReturnTrimmedInput()
            {
                var input = "TestInput";

                var result = input.Trim("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputStartsWithMultipleTrimWordsThenShouldReturnTrimmedInput()
            {
                var input = "TestTestTestInput";

                var result = input.Trim("Test");

                result.Should().Be("Input");
            }
            [Fact]
            public static void WhenInputDoesNotStartWithTrimWordThenShouldReturnInput()
            {
                var input = "InputTestTestTestInput";

                var result = input.Trim("Test");

                result.Should().Be(input);
            }
            [Fact]
            public static void WhenInputStartsAndEndsWithTrimWordThenShouldReturnInput()
            {
                var input = "InputTestTestTestInput";

                var result = input.Trim("Input");

                result.Should().Be("TestTestTest");
            }
            [Fact]
            public static void WhenInputStartsAndEndsWithTrimWordAndAlsoContainsTrimWordThenShouldReturnInputTrimmed()
            {
                var input = "InputTestInputTestInputTestInput";

                var result = input.Trim("Input");

                result.Should().Be("TestInputTestInputTest");
            }

        }
        public class Parse
        {
            [Fact]
            public static void WhenNullInputShouldThrowArgumentNullException()
            {
                string input = null;
                Action act = () => input.Parse<int>();
                act.ShouldThrow<ArgumentNullException>();
            }
            [Fact]
            public static void WhenInputIsEmptyThenShouldReturnDefaultValue()
            {
                string input = string.Empty;
                var result = input.Parse<int>();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInputIsValidIntThenShouldReturnParsedValue()
            {
                string input = "123";
                var result = input.Parse<int>();
                result.Should().Be(123);
            }
            [Fact]
            public static void WhenInputIsInvalidIntThenShouldReturnDefaultValue()
            {
                string input = "123a";
                var result = input.Parse<int>();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInputIsValidDecimalThenShouldReturnParsedValue()
            {
                string input = "123.123";
                var result = input.Parse<decimal>();
                result.Should().Be(123.123m);
            }
            [Fact]
            public static void WhenInputIsInvalidDecimalThenShouldReturnDefaultValue()
            {
                string input = "123a";
                var result = input.Parse<decimal>();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInputIsValidFloatThenShouldReturnParsedValue()
            {
                string input = "123.123";
                var result = input.Parse<float>();
                result.Should().Be(123.123f);
            }
            [Fact]
            public static void WhenInputIsInvalidFloatThenShouldReturnDefaultValue()
            {
                string input = "123a";
                var result = input.Parse<float>();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInputIsValidDoubleThenShouldReturnParsedValue()
            {
                string input = "123.123";
                var result = input.Parse<double>();
                result.Should().Be(123.123);
            }
            [Fact]
            public static void WhenInputIsInvalidDoubleThenShouldReturnDefaultValue()
            {
                string input = "123a";
                var result = input.Parse<double>();
                result.Should().Be(0);
            }
            [Fact]
            public static void WhenInputIsValidEnumValueThenShouldReturnParsedValue()
            {
                string input = "2";
                var result = input.Parse<ParseTestEnum>();
                result.Should().Be(ParseTestEnum.Two);
            }
            [Fact]
            public static void WhenInputIsInvalidEnumValueThenShouldReturnDefaultValue()
            {
                string input = "invalid";
                var result = input.Parse<ParseTestEnum>();
                result.Should().Be(ParseTestEnum.Zero);
            }
            [Fact]
            public static void WhenTypeDoesNotContainTryParseMethodThenShouldThrowMissingMethodException()
            {
                string input = "123";
                Action act = () => input.Parse<object>();
                act.ShouldThrow<MissingMethodException>();
            }
            [Fact]
            public static void WhenTryParseMethodIsNotStaticThenShouldArgumentExceptionException()
            {
                string input = "123";
                Action act = () => input.Parse<ParseNonStaticMethod>();
                act.ShouldThrow<ArgumentException>();
            }
            [Fact]
            public static void WhenInputIsValidDateTimeThenShouldReturnParsedValue()
            {
                string input = "31/01/2016";
                var result = input.Parse<DateTime>();
                result.Should().Be(new DateTime(2016, 01, 31));
            }

            private enum ParseTestEnum
            {
                Zero,
                One = 1,
                Two = 2,
                Three = 3
            }
            private class ParseNonStaticMethod
            {
                public bool TryParse(string input, out ParseNonStaticMethod output)
                {
                    output = null;
                    return true;
                }
            }
        }
    }
}
