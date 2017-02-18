using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;
using RomanNumberContract;
using Autofac;
using RomanNumberData;
using RomanNumberAlgorithm;

namespace Test_RomanNumberConverter
{
    [TestFixture]
    public class TestConversionArabianToRomanNumber
    {
        IConverter _generalConverter;
        ArabianToRomanNumberConverter _specializeConverter;
        RomanNumber.RomanNumberBuilder _romanNumberBuilder;
        IFactory<int, IDecoder<int, string>> _arabianToRomanNumberDecoderFactory;

        [SetUp]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new RomanNumberModule());
            builder.RegisterModule(new RomanNumberDataModule());
            builder.RegisterModule(new RomanNumberAlgorithmModule());
            var container = builder.Build();
            _specializeConverter = container.Resolve<ArabianToRomanNumberConverter>();
            _generalConverter    = container.Resolve<IConverter>();
            _romanNumberBuilder  = container.Resolve<RomanNumber.RomanNumberBuilder>();
            _arabianToRomanNumberDecoderFactory = container.Resolve<IFactory<int, IDecoder<int, string>>>();
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestDecoding(int toBeConverted, string intendedValue)
        {
            var convertionResult = _generalConverter.Convert(_arabianToRomanNumberDecoderFactory.Create(toBeConverted));
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestConversion(int toBeConverted, string intendedValue)
        {
            var intendedRomanNumber = _romanNumberBuilder.BuildRomanNumber(intendedValue);
            var convertionResult = _specializeConverter.Convert(toBeConverted);
            convertionResult.ShouldBeEquivalentTo(intendedRomanNumber, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }
}