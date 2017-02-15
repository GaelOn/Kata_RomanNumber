namespace Kata_RomanNumber_TDD
{
    public class DecoderFactory<TIn, TOut> : IFactory<TIn, IDecoder<TIn, TOut>>
    {
        private IFactory<IDecodingReferential<TIn, TOut>> _referentialFactory;
        private readonly IFactory<IDecodingReferential<TIn, TOut>, TIn, IDecoder<TIn, TOut>> _decoderFactory;

        public DecoderFactory(IFactory<IDecodingReferential<TIn, TOut>> referentialFactory,
                              IFactory<IDecodingReferential<TIn, TOut>, TIn, IDecoder<TIn, TOut>> decoderFactory)
        {
            _referentialFactory = referentialFactory;
            _decoderFactory = decoderFactory;
        }

        public IDecoder<TIn, TOut> Create(TIn input)
        {
            return _decoderFactory.Create(_referentialFactory.Create(), input);
        }
    }

}
