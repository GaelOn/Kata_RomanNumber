namespace Kata_RomanNumber_TDD
{
    public class RomanToArabianReferentialFactory : IFactory<IDecodingReferential<string, int>>
    {
        public IDecodingReferential<string, int> Create()
        {
            return new RomanToArabianNumberDecodingData();
        }
    }

}
