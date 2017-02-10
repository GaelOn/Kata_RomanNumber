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
            if (toBeConverted == 5)
            {
                return "V";
            }
            if (toBeConverted == 6)
            {
                return "VI";
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
