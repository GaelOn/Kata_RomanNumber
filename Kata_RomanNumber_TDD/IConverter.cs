namespace Kata_RomanNumber_TDD
{

    public interface IConverter
    {
        TOut Convert<TIn, TOut>(IDecoder<TIn, TOut> decoder);
    }

}
