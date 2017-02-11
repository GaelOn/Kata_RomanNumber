using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kata_RomanNumber_TDD
{
    public class RomanUnit : IEnumerable<int>
    {
        public static Dictionary<int, string> Member;

        static RomanUnit()
        {
            Member = new Dictionary<int, string>();
            Member.Add(40, "XL");
            Member.Add(10, "X");
            Member.Add(9, "IX");
            Member.Add(5, "V");
            Member.Add(4, "IV");
            Member.Add(1, "I");
        }

        public IEnumerator<int> GetEnumerator()
        {
            return Member.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ArabianToRomanNumberConverter
    {
        public string Convert(int toBeConverted)
        {
            var romanNumber = new StringBuilder();
            AppendRomanUnit(romanNumber, toBeConverted);
            return romanNumber.ToString();
        }

        private int AppendRomanUnit(StringBuilder romanNumber, int arabianNumber)
        {
            var romanNumberUnitProvider = new RomanUnit();
            foreach (var currentUnit in romanNumberUnitProvider)
            {
                while (arabianNumber >= currentUnit)
                {
                    romanNumber.Append(RomanUnit.Member[currentUnit]);
                    arabianNumber -= currentUnit;
                }
            } 
            return arabianNumber;
        }
    }
}
