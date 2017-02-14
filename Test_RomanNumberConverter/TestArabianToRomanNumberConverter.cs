using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;

namespace Test_RomanNumberConverter
{
    [TestFixture]
    public class TestConversionArabianToRoman
    {
        Converter _generalConverter;
        ArabianToRomanNumberConverter _specializeConverter;

        [SetUp]
        public void Init()
        {
            _generalConverter = new Converter();
            _specializeConverter = new ArabianToRomanNumberConverter(_generalConverter);
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestDecoding(int toBeConverted, string intendedValue)
        {
            var convertionResult = _generalConverter.Convert(new ArabianToRomanNumberDecoder(toBeConverted));
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestConversion(int toBeConverted, string intendedValue)
        {
            var intendedRomanNumber = RomanNumber.RomanNumberBuilder.BuildRomanNumber(intendedValue);
            var convertionResult = _specializeConverter.Convert(toBeConverted);
            convertionResult.ShouldBeEquivalentTo(intendedRomanNumber, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }
}