using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kata_RomanNumber_TDD
{

    public abstract class BaseConverter<TIn, TOut, TPreOut> : IConverter<TIn, TOut>
    {
        private TPreOut finalValue;

        public abstract IEnumerable<TIn> InValueProvider { get; }
        public abstract bool CanConvert(TIn maybeConvertible);
        public abstract TOut RetrieveValue(TIn toBeConverted);

        protected abstract TIn Append(TOut convertedValue, TIn toBeConverted);
        protected abstract TOut ReturnFinalValue();

        public TOut Convert(TIn toBeConverted)
        { 
            foreach (var currentUnit in InValueProvider)
            {
                while (CanConvert(currentUnit))
                {
                    toBeConverted = Append(RetrieveValue(currentUnit), toBeConverted);
                }
            }
            return ReturnFinalValue();
        }
    }
    
}
