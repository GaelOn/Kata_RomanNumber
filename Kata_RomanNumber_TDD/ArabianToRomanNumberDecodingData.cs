using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

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
