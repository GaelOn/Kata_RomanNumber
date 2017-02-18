using System.Collections.Generic;
using RomanNumberContract;

namespace RomanNumberData
{

    public class RomanToArabianNumberDecodingData : IDecodingReferential<string, int>
    {
        public IEnumerable<string> EncodeUnit => RomanUnit.GetUnitAsString();

        public int Decode(string encodeUnitValue)
        {

            return RomanUnit.TransformBackFromUnit(encodeUnitValue);
        }
    }
}
