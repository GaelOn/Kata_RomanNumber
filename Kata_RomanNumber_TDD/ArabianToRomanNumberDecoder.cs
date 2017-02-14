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
