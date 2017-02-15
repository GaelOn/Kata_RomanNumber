using System.Collections.Generic;

namespace Kata_RomanNumber_TDD
{

    public class ArabianToRomanNumberDecodingData : IDecodingReferential<int, string>
    {
        public IEnumerable<int> EncodeUnit => RomanUnit.GetUnitAsInteger();

        public string Decode(int encodeUnitValue)
        {
            return RomanUnit.TransformToUnit(encodeUnitValue);
        }
    }

}
