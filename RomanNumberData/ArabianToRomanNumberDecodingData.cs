using System.Collections.Generic;
using RomanNumberContract;

namespace RomanNumberData
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
