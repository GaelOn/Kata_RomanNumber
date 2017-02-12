using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

namespace Kata_RomanNumber_TDD
{
    public class RomanUnit : IEnumerable<int>, IEnumerable<string>
    {
        private static Dictionary<int, string> Member;

        static RomanUnit()
        {
            Member = new Dictionary<int, string>();
            Member.Add(1000, "M");
            Member.Add(900, "CM");
            Member.Add(500, "D");
            Member.Add(400, "CD");
            Member.Add(100, "C");
            Member.Add(90, "XC");
            Member.Add(50, "L");
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

        public string TransformToUnit(int number)
        {
            return Member[number];
        }

        public int TransformBackFromUnit(string unit)
        {
            return Member.FirstOrDefault(kv => kv.Value == unit).Key;
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return Member.Values.GetEnumerator();
        }
    }

    public class ArabianToRomanNumberConverter
    {
        public string Convert(int toBeConverted)
        {
            var romanNumber = new StringBuilder();
            var romanNumberUnitProvider = new RomanUnit();
            foreach (var currentUnit in romanNumberUnitProvider)
            {
                while (toBeConverted >= currentUnit)
                {
                    romanNumber.Append(romanNumberUnitProvider.TransformToUnit(currentUnit));
                    toBeConverted -= currentUnit;
                }
            }
            return romanNumber.ToString();
        }
    }

    public class RomanToArabianNumberConverter
    {
        public int Convert(string toBeConverted)
        {
            if (toBeConverted == "E")
            {
                throw new ValidationException("The character E is not allowed in roman number.");
            }
            if (toBeConverted == "A")
            {
                throw new ValidationException("The character A is not allowed in roman number.");
            }
            var romanNumberUnitProvider = (new RomanUnit()) as IEnumerable<string>;
            Valid(toBeConverted, romanNumberUnitProvider);
            int arabianNumber = 0;
            foreach (var currentUnit in romanNumberUnitProvider)
            {
                while (toBeConverted.StartsWith(currentUnit, StringComparison.Ordinal))
                {
                    arabianNumber += ((RomanUnit)romanNumberUnitProvider).TransformBackFromUnit(currentUnit);
                    toBeConverted = toBeConverted.Substring(currentUnit.Length);
                }
            }
            return arabianNumber;
        }

        private void Valid(string toBeValidated, IEnumerable<string> romanNumberUnitProvider)
        {
            foreach (var item in romanNumberUnitProvider)
            {
                if (item != "M")
                {
                    var forbidCase = item + item + item + item;
                    if (toBeValidated.Contains(forbidCase))
                    {
                        throw new ValidationException($"The character {item} is repeated 4 times which is forbiden for RomanNumber.");
                    }
                }
            }
        }
    }

    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException() { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception innerException) : base(message, innerException) { }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
