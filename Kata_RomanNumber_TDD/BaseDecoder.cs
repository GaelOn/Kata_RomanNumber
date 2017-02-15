namespace Kata_RomanNumber_TDD
{
    public abstract class BaseDecoder<TIn, TOut> : IDecoder<TIn, TOut>
    {
        protected TIn _decodableRest;
        protected TOut _returnValue;

        protected BaseDecoder(TIn decodableRest, IDecodingReferential<TIn, TOut> decodingData)
        {
            _decodableRest = decodableRest;
            DecodingData = decodingData;
        }

        public IDecodingReferential<TIn, TOut> DecodingData { get; }

        public TOut Value => _returnValue;

        public abstract void AppendDecodeValue(TIn codeUnit);

        public abstract bool CanDecode(TIn codeUnit);
    }

}
