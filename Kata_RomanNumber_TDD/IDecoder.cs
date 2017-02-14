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

    public interface IDecoder<TIn, TOut>
    {
        bool CanDecode(TIn codeUnit);
        void AppendDecodeValue(TIn codeUnit);
        IDecodingReferential<TIn, TOut> DecodingData { get; }
        TOut Value { get; }
    }
    
}
