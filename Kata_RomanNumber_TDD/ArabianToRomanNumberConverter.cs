using System;
using RomanNumberContract;

namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberConverter
    {
        private readonly IConverter _converter;
        private readonly Func<int, IDecoder<int, string>> _factoryMethod;

        private readonly RomanNumber.RomanNumberBuilder _romanNumberBuilder;

        public ArabianToRomanNumberConverter(Func<int, IDecoder<int, string>> factoryMethod, 
                                             IConverter converter,
                                             RomanNumber.RomanNumberBuilder romanNumberBuilder)
        {
            _converter = converter;
            _factoryMethod = factoryMethod;
            _romanNumberBuilder = romanNumberBuilder;
        }

        public ArabianToRomanNumberConverter(IFactory<int, IDecoder<int, string>> factory, 
                                             IConverter converter,
                                             RomanNumber.RomanNumberBuilder romanNumberBuilder)
        {
            _converter = converter;
            _factoryMethod = arg => factory.Create(arg);
            _romanNumberBuilder = romanNumberBuilder;
        }

        public RomanNumber Convert(int toBeConverted)
        {
            var decoder = _factoryMethod(toBeConverted);
            var decodingResult = _converter.Convert(decoder);
            return _romanNumberBuilder.BuildRomanNumber(decodingResult);
        }
    }
}
