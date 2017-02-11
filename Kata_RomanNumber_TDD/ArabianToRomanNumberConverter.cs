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
            var romanNumber = new StringBuilder();
            AppendRomanUnit(romanNumber, toBeConverted);
            return romanNumber.ToString();
        }

        private int AppendRomanUnit(StringBuilder romanNumber, int arabianNumber)
        {
            if (arabianNumber >= 10)
            {
                romanNumber.Append("X");
                arabianNumber -= 10;
            }
            if (arabianNumber >= 5)
            {
                romanNumber.Append("V");
                arabianNumber -= 5;
            }
            if (SpecialCase.ContainsKey(arabianNumber))
            {
                romanNumber.Append(SpecialCase[arabianNumber]);
                arabianNumber = 0;
            }
            if (arabianNumber < 4)
            {
                Append_n_I(arabianNumber, romanNumber);
                arabianNumber = 0;
            }
            return arabianNumber;
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
