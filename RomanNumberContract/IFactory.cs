namespace RomanNumberContract
{
    public interface IFactory<out TOut>
    {
        TOut Create();
    }

    public interface IFactory<in TIn, out TOut>
    {
        TOut Create(TIn arg);
    }

    public interface IFactory<in TIn1,in TIn2, out TOut>
    {
        TOut Create(TIn1 arg1, TIn2 arg2);
    }
}
