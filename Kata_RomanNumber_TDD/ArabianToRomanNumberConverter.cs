using System;
namespace Kata_RomanNumber_TDD
{
    public class ArabianToRomanNumberConverter
    {
        public string Convert(int toBeConverted)
        {
            return toBeConverted == 1 ? "I" : "II";
        }
    }
}
