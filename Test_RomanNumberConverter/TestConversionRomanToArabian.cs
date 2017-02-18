using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;
using RomanNumberContract;
using System;
using Autofac;
using RomanNumberData;
using RomanNumberAlgorithm;

namespace Test_RomanNumberConverter
{

    [TestFixture]
    public class TestConversionRomanToArabianNumber
    {
        IConverter _generalConverter;
        RomanToArabianNumberConverter _specializedConverter;
        RomanNumber.RomanNumberBuilder _romanNumberBuilder;
        IFactory<string, IDecoder<string, int>> _romanToArabianNumberDecoderFactory;

        [SetUp]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new RomanNumberModule());
            builder.RegisterModule(new RomanNumberDataModule());
            builder.RegisterModule(new RomanNumberAlgorithmModule());
            var container = builder.Build();
            _specializedConverter = container.Resolve<RomanToArabianNumberConverter>();
            _generalConverter    = container.Resolve<IConverter>();
            _romanNumberBuilder  = container.Resolve<RomanNumber.RomanNumberBuilder>();
            _romanToArabianNumberDecoderFactory = container.Resolve<IFactory<string, IDecoder<string, int>>>();
        }

        [Test, TestCaseSource(typeof(GivenData), "BadRomanNumberCase")]
        public void TestValidation_When_Try_Valid_Bad_Case_Then_Throw_ValidationException(string notConvertible, string intendedErrorMess, string because)
        {
            Action romanNumberBuilder = () => _romanNumberBuilder.BuildRomanNumber(notConvertible);
            romanNumberBuilder.ShouldThrow<ValidationException>(because).WithMessage(intendedErrorMess);
        }

        [Test, TestCaseSource(typeof(GivenData), "RepetionThatShouldPass")]
        public void TestValidation_When_M_Is_Used_Then_It_Can_Be_Repeated_As_Many_Time_As_Required(string convertible)
        {
            Action romanNumberBuilder = () => _romanNumberBuilder.BuildRomanNumber(convertible);
            romanNumberBuilder.ShouldNotThrow<ValidationException>("because M can be repeated as many time as required");
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestDecoding(int intendedValue, string toBeConverted)
        {
            var convertionResult = _generalConverter.Convert(_romanToArabianNumberDecoderFactory.Create(toBeConverted));
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestConversion(int intendedValue, string toBeConverted)
        {
            var romanNumber = _romanNumberBuilder.BuildRomanNumber(toBeConverted);
            var convertionResult = _specializedConverter.Convert(romanNumber);
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }
}