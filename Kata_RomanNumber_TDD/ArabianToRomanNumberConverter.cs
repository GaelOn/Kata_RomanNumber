using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberConverter
    {
        public static Dictionary<int, string> SpecialCase;

        static ArabianToRomanNumberConverter()
        {
            SpecialCase = new Dictionary<int, string>();
            SpecialCase.Add(4, "IV");
            SpecialCase.Add(9, "IX");
        }

        public string Convert(int toBeConverted)
        {
            if (SpecialCase.ContainsKey(toBeConverted))
            {
                return SpecialCase[toBeConverted];
            }
            if (toBeConverted >= 10)
            {
                var result_10 = (new StringBuilder()).Append("X");
                toBeConverted = toBeConverted - 10;
                Append_n_I(toBeConverted, result_10);
                return result_10.ToString();
            }
            if (toBeConverted >= 5)
            {
                var result_5 = (new StringBuilder()).Append("V");
                toBeConverted = toBeConverted - 5;
                Append_n_I(toBeConverted, result_5);
                return result_5.ToString();
            }
            var result = new StringBuilder();
            Append_n_I(toBeConverted, result);
            return result.ToString();
        }

        private void Append_n_I(int n, StringBuilder toBeAppended)
        {
            for (int it = 0; it < n; it++)
            {
                toBeAppended.Append("I");
            }
        }
    }
}
