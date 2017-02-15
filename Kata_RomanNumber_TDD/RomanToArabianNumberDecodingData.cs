using System.Collections.Generic;

namespace Kata_RomanNumber_TDD
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
