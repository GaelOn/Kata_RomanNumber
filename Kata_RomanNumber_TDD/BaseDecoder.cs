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

    public abstract class BaseDecoder<TIn, TOut> : IDecoder<TIn, TOut>
    {
        protected TIn _decodableRest;
        protected TOut _returnValue;

        protected BaseDecoder(TIn decodableRest, IDecodingReferential<TIn, TOut> decodingData)
        {
            _decodableRest = decodableRest;
            DecodingData = decodingData;
        }

        public IDecodingReferential<TIn, TOut> DecodingData { get; }

        public TOut Value => _returnValue;

        public abstract void AppendDecodeValue(TIn codeUnit);

        public abstract bool CanDecode(TIn codeUnit);
    }
    
}
