using RomanNumberContract;

namespace RomanNumberData
{

    public class RomanToArabianDecoderFactory : IFactory<IDecodingReferential<string, int>,
                                                         string,
                                                         IDecoder<string, int>>
    {
        public IDecoder<string, int> Create(IDecodingReferential<string, int> referential, string toBeDecoded)
        {
            return new RomanToArabianNumberDecoder(referential, toBeDecoded);
        }
    }

}
