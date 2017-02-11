using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;

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

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestConversion(int intendedValue, string toBeConverted)
        {
            var convertionResult = _converter.Convert(toBeConverted);
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }
}