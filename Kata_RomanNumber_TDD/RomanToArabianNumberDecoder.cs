using System;

namespace Kata_RomanNumber_TDD
{
    public class RomanToArabianNumberDecoder : BaseDecoder<string, int>
    {
        public RomanToArabianNumberDecoder(string decodableRest) : base(decodableRest, new RomanToArabianNumberDecodingData()) { }

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
