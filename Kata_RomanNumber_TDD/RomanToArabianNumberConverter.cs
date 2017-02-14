namespace Kata_RomanNumber_TDD
{

    public class RomanToArabianNumberConverter
    {
        private readonly IConverter _converter;

        public RomanToArabianNumberConverter(IConverter converter)
        {
            _converter = converter;
        }

        public int Convert(RomanNumber toBeConverted)
        {
            var decoder = new RomanToArabianNumberDecoder(toBeConverted.Value);
            return _converter.Convert(decoder);
        }
    }
    
}
