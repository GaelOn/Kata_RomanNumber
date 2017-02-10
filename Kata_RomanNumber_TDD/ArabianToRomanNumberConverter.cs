using System;
namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberConverter
    {
        public string Convert(int toBeConverted)
        {
            if (toBeConverted == 1)
            {
                return "I";
            }
            if (toBeConverted == 2)
            {
                return "II";
            }
            return "III";
        }
    }
}
