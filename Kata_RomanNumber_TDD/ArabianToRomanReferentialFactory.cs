namespace Kata_RomanNumber_TDD
{

    public class ArabianToRomanReferentialFactory : IFactory<IDecodingReferential<int, string>>
    {
        public IDecodingReferential<int, string> Create()
        {
            return new ArabianToRomanNumberDecodingData();
        }
    }

}
