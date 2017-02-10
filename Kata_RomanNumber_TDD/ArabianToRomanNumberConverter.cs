using System;
using System.Collections.Generic;
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
            SpecialCase.Add(10, "X");
            SpecialCase.Add(11, "XI");
            SpecialCase.Add(12, "XII");
        }

        public string Convert(int toBeConverted)
        {
            if (SpecialCase.ContainsKey(toBeConverted))
            {
                return SpecialCase[toBeConverted];
            }
            if (toBeConverted >= 5)
            {
                string result_5 = "V";
                toBeConverted = toBeConverted - 5;
                for (int it = 0; it < toBeConverted; it++)
                {
                    result_5 = result_5 + "I";
                }
                return result_5;
            }
            string result = string.Empty;
            for (int it = 0; it < toBeConverted; it++)
            {
                result = result + "I";
            }
            return result;
        }
    }
}
