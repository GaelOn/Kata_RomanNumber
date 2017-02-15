using System;

namespace Kata_RomanNumber_TDD
{
    public class RomanToArabianNumberDecoder : BaseDecoder<string, int>
    {
        public RomanToArabianNumberDecoder(string decodableRest) 
            : base(new RomanToArabianNumberDecodingData(), decodableRest) { }

        public RomanToArabianNumberDecoder(IFactory<IDecodingReferential<string, int>> dataProviderFactory, string decodableRest) 
            : base(dataProviderFactory.Create(), decodableRest) { }

        public RomanToArabianNumberDecoder(IDecodingReferential<string, int> dataProvider, string decodableRest)
            : base(dataProvider, decodableRest) { }

        public override void AppendDecodeValue(string codeUnit)
        {
            _returnValue += DecodingData.Decode(codeUnit);
            _decodableRest = _decodableRest.Substring(codeUnit.Length);
        }

        public override bool CanDecode(string codeUnit)
        {
            return _decodableRest.StartsWith(codeUnit, StringComparison.Ordinal);
        }
    }

}
