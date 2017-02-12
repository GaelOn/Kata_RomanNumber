using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;
using System;

namespace Test_RomanNumberConverter
{

    [TestFixture]
    public class TestConversionRomanToArabian
    {
        RomanToArabianNumberConverter _converter;

        [SetUp]
        public void Init()
        {
            _converter = new RomanToArabianNumberConverter();
        }

        [Test, TestCaseSource(typeof(GivenData), "BadRomanNumberCase")]
        public void TestValidation(string notConvertible, string intendedErrorMess, string because)
        {
            Action conversion = () => _converter.Convert(notConvertible);
            conversion.ShouldThrow<ValidationException>(because).WithMessage(intendedErrorMess);
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestConversion(int intendedValue, string toBeConverted)
        {
            var convertionResult = _converter.Convert(toBeConverted);
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }
}