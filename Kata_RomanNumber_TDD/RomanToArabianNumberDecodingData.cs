using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

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
