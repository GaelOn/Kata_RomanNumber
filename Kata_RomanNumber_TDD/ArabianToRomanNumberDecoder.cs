using System;

namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberDecoder : BaseDecoder<int, string>
    {
        public ArabianToRomanNumberDecoder(int decodableRest) 
            : base(new ArabianToRomanNumberDecodingData(), decodableRest) 
        {
            _returnValue = string.Empty;
        }

        public ArabianToRomanNumberDecoder(IFactory<IDecodingReferential<int, string>> dataProviderFactory, int decodableRest) 
            : base(dataProviderFactory.Create(), decodableRest)
        {
            _returnValue = string.Empty;
        }

        public ArabianToRomanNumberDecoder(IDecodingReferential<int, string> dataProvider, int decodableRest)
            : base(dataProvider, decodableRest)
        {
            _returnValue = string.Empty;
        }

        public override void AppendDecodeValue(int codeUnit)
        {
            _returnValue += DecodingData.Decode(codeUnit);
            _decodableRest -= codeUnit;
        }

        public override bool CanDecode(int codeUnit)
        {
            return _decodableRest >= codeUnit;
        }
    }
}
