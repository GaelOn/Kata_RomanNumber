using System;

namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberConverter
    {
        private readonly IConverter _converter;
        private readonly Func<int, IDecoder<int, string>> _factoryMethod;

        public ArabianToRomanNumberConverter(IConverter converter)
        {
            _converter = converter;
            _factoryMethod = (arg) => new ArabianToRomanNumberDecoder(arg);
        }

        public ArabianToRomanNumberConverter(Func<int, IDecoder<int, string>> factoryMethod, IConverter converter)
        {
            _converter = converter;
            _factoryMethod = factoryMethod;
        }

        public ArabianToRomanNumberConverter(IFactory<int, IDecoder<int, string>> factory, IConverter converter)
        {
            _converter = converter;
            _factoryMethod = arg => factory.Create(arg);
        }

        public RomanNumber Convert(int toBeConverted)
        {
            var decoder = _factoryMethod(toBeConverted);
            var decodingResult = _converter.Convert(decoder);
            return RomanNumber.RomanNumberBuilder.BuildRomanNumber(decodingResult);
        }
    }
}
