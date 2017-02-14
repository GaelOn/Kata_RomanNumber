namespace Kata_RomanNumber_TDD
{
    public class Converter : IConverter
    {
        public TOut Convert<TIn, TOut>(IDecoder<TIn, TOut> decoder)
        {
            foreach (var currentUnit in decoder.DecodingData.EncodeUnit)
            {
                while (decoder.CanDecode(currentUnit))
                {
                    decoder.AppendDecodeValue(currentUnit);
                }
            }
            return decoder.Value;
        }
    }
}
