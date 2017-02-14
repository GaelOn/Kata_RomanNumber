using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata_RomanNumber_TDD
{
    //public class ArabianToRomanNumberConverter
    //{
    //    public string Convert(int toBeConverted)
    //    {
    //        var romanNumber = new StringBuilder();
    //        var romanNumberUnitProvider = new RomanUnit();
    //        foreach (var currentUnit in romanNumberUnitProvider)
    //        {
    //            while (toBeConverted >= currentUnit)
    //            {
    //                romanNumber.Append(RomanUnit.TransformToUnit(currentUnit));
    //                toBeConverted -= currentUnit;
    //            }
    //        }
    //        return romanNumber.ToString();
    //    }
    //}

    //public class RomanToArabianNumberConverter
    //{
    //    public int Convert(string toBeConverted)
    //    {
    //        var romanNumberUnitProvider = (new RomanUnit()) as IEnumerable<string>;
    //        int arabianNumber = 0;
    //        foreach (var currentUnit in romanNumberUnitProvider)
    //        {
    //            while (toBeConverted.StartsWith(currentUnit, StringComparison.Ordinal))
    //            {
    //                arabianNumber += RomanUnit.TransformBackFromUnit(currentUnit);
    //                toBeConverted = toBeConverted.Substring(currentUnit.Length);
    //            }
    //        }
    //        return arabianNumber;
    //    }
    //}

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
