using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;
using Autofac;

namespace Test_RomanNumberConverter
{
    [TestFixture]
    public class TestConversionArabianToRoman
    {
        IConverter _generalConverter;
        ArabianToRomanNumberConverter _specializeConverter;

        [SetUp]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new RomanNumberModule());
            var container = builder.Build();
            _specializeConverter = container.Resolve<ArabianToRomanNumberConverter>();
            _generalConverter = container.Resolve<IConverter>();
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