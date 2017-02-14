using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

namespace Kata_RomanNumber_TDD
{

    public interface IDecodingReferential<TEncode, TDecode>
    {
        TDecode Decode(TEncode encodeUnitValue);
        IEnumerable<TEncode> EncodeUnit { get; }
    }
    
}
