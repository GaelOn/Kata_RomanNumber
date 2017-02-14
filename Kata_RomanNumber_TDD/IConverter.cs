using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata_RomanNumber_TDD
{

    public interface IConverter
    {
        TOut Convert<TIn, TOut>(IDecoder<TIn, TOut> decoder);
    }
    
}
