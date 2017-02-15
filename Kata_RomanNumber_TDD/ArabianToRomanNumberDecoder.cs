namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberDecoder : BaseDecoder<int, string>
    {
        public ArabianToRomanNumberDecoder(int decodableRest) : base(decodableRest, new ArabianToRomanNumberDecodingData())
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
