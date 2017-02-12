using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata_RomanNumber_TDD
{

    public interface IConverter<TIn, TOut>
    {
        bool CanConvert(TIn maybeConvertible);
        TOut RetrieveValue(TIn toBeConverted);

        TOut Convert(TIn maybeConvertible);
    }
    
}
