using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;
using System;

namespace Test_RomanNumberConverter
{

    [TestFixture]
    public class TestConversionRomanToArabian
    {
        Converter _generalConverter;
        RomanToArabianNumberConverter _specializeConverter;

        [SetUp]
        public void Init()
        {
            _generalConverter = new Converter();
            _specializeConverter = new RomanToArabianNumberConverter(_generalConverter);
        }

        [Test, TestCaseSource(typeof(GivenData), "BadRomanNumberCase")]
        public void TestValidation_When_Try_Valid_Bad_Case_Then_Throw_ValidationException(string notConvertible, string intendedErrorMess, string because)
        {
            Action romanNumberBuilder = () => RomanNumber.RomanNumberBuilder.BuildRomanNumber(notConvertible);
            romanNumberBuilder.ShouldThrow<ValidationException>(because).WithMessage(intendedErrorMess);
        }

        [Test, TestCaseSource(typeof(GivenData), "RepetionThatShouldPass")]
        public void TestValidation_When_M_Is_Used_Then_It_Can_Be_Repeated_As_Many_Time_As_Required(string convertible)
        {
            Action romanNumberBuilder = () => RomanNumber.RomanNumberBuilder.BuildRomanNumber(convertible);
            romanNumberBuilder.ShouldNotThrow<ValidationException>("because M can be repeated as many time as required");
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestDecoding(int intendedValue, string toBeConverted)
        {
            var convertionResult = _generalConverter.Convert(new RomanToArabianNumberDecoder(toBeConverted));
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestConversion(int intendedValue, string toBeConverted)
        {
            var romanNumber = RomanNumber.RomanNumberBuilder.BuildRomanNumber(toBeConverted);
            var convertionResult = _specializeConverter.Convert(romanNumber);
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }
}