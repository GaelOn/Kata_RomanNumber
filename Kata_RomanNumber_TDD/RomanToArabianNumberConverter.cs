using System;

namespace Kata_RomanNumber_TDD
{
    public class RomanToArabianNumberConverter
    {
        private readonly IConverter _converter;
        private readonly Func<string, IDecoder<string, int>> _factoryMethod;

        public RomanToArabianNumberConverter(IConverter converter)
        {
            _converter = converter;
        }

        public RomanToArabianNumberConverter(Func<string, IDecoder<string, int>> factoryMethod, IConverter converter)
        {
            _converter = converter;
            _factoryMethod = factoryMethod;
        }

        public RomanToArabianNumberConverter(IFactory<string, IDecoder<string, int>> factory, IConverter converter)
        {
            _converter = converter;
            _factoryMethod = arg => factory.Create(arg);
        }

        public int Convert(RomanNumber toBeConverted)
        {
            var decoder = _factoryMethod(toBeConverted.Value);
            return _converter.Convert(decoder);
        }
    }

}
