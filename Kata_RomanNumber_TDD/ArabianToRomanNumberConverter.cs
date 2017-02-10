using System;
namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberConverter
    {
        public string Convert(int toBeConverted)
        {
            if (toBeConverted == 4)
            {
                return "IV";
            }
            if (toBeConverted == 9)
            {
                return "IX";
            }
            if (toBeConverted == 10)
            {
                return "X";
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
