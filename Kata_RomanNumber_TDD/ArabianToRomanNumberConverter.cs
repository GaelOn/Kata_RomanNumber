namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberConverter
    {
        private readonly IConverter _converter;

        public ArabianToRomanNumberConverter(IConverter converter)
        {
            _converter = converter;
        }

        public RomanNumber Convert(int toBeConverted)
        {
            var decoder = new ArabianToRomanNumberDecoder(toBeConverted);
            var decodingResult = _converter.Convert(decoder);
            return RomanNumber.RomanNumberBuilder.BuildRomanNumber(decodingResult);
        }
    }
}
