using System.Collections.Generic;

namespace RomanNumberContract
{
    public interface IDecodingReferential<TEncode, TDecode>
    {
        TDecode Decode(TEncode encodeUnitValue);
        IEnumerable<TEncode> EncodeUnit { get; }
    }
}
