using System.Collections.Generic;

namespace Kata_RomanNumber_TDD
{
    public interface IDecodingReferential<TEncode, TDecode>
    {
        TDecode Decode(TEncode encodeUnitValue);
        IEnumerable<TEncode> EncodeUnit { get; }
    }
}
