using RomanNumberContract;

namespace RomanNumberData
{

    public class ArabianToRomanDecoderFactory : IFactory<IDecodingReferential<int, string>,
                                                         int,
                                                         IDecoder<int, string>>
    {
        public IDecoder<int, string> Create(IDecodingReferential<int, string> referential, int toBeDecoded)
        {
            return new ArabianToRomanNumberDecoder(referential, toBeDecoded);
        }
    }

}
