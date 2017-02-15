namespace Kata_RomanNumber_TDD
{
    public interface IDecoder<TIn, TOut>
    {
        bool CanDecode(TIn codeUnit);
        void AppendDecodeValue(TIn codeUnit);
        IDecodingReferential<TIn, TOut> DecodingData { get; }
        TOut Value { get; }
    }

}
