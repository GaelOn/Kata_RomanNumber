namespace RomanNumberContract
{
    public interface IConverter
    {
        TOut Convert<TIn, TOut>(IDecoder<TIn, TOut> decoder);
    }

}
