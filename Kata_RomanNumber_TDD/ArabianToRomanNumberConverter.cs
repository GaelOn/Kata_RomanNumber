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

        public static List<string> GetValidCharacterWithLengthOne()
        {
            return GetCharactereByLength(1);
        }

        public static List<string> GetValidCharacterWithLengthTwo()
        {
            return GetCharactereByLength(2);
        }

        private static List<string> GetCharactereByLength(int length)
        {
            return Member.Where(kv => kv.Value.Length == length)
                         .Select(kv => kv.Value)
                         .ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return Member.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static string TransformToUnit(int number)
        {
            return Member[number];
        }

        public static int TransformBackFromUnit(string unit)
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
                    romanNumber.Append(RomanUnit.TransformToUnit(currentUnit));
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
            var romanNumberUnitProvider = (new RomanUnit()) as IEnumerable<string>;
            Valid(toBeConverted);
            int arabianNumber = 0;
            foreach (var currentUnit in romanNumberUnitProvider)
            {
                while (toBeConverted.StartsWith(currentUnit, StringComparison.Ordinal))
                {
                    arabianNumber += RomanUnit.TransformBackFromUnit(currentUnit);
                    toBeConverted = toBeConverted.Substring(currentUnit.Length);
                }
            }
            return arabianNumber;
        }

        private void Valid(string toBeValidated)
        {
            var validChar = RomanUnit.GetValidCharacterWithLengthOne();
            var validCombinaison = RomanUnit.GetValidCharacterWithLengthTwo();
            // init the one pass validation algo
            string previousChar = toBeValidated[0].ToString();
            int repetition = 1;
            IsValidCharacter(validChar, previousChar);
            for (int i = 1; i < toBeValidated.Length; i++)
            {
                var curChar = toBeValidated[i].ToString();
                IsValidCharacter(validChar, curChar);
                ValidRepetition(curChar, previousChar, ref repetition);
                ValidAllCombinaisonAreAllowedOne(validCombinaison, curChar, previousChar);
                previousChar = curChar;
            }
        }

        private void IsValidCharacter(List<String> validChar, string charac)
        {
            if (!validChar.Contains(charac))
            {
                throw new ValidationException($"The character {charac} is not allowed in roman number.");
            }
        }

        private void ValidRepetition(string curChar, string previousChar, ref int repetition)
        {
            repetition = (previousChar != "M" && curChar == previousChar) ? 
                         repetition + 1 : 1;
            if (repetition > 3)
            {
                throw new ValidationException($"The character {curChar} is repeated {repetition} times which is forbiden for RomanNumber.");
            }
        }

        private void ValidAllCombinaisonAreAllowedOne(List<string> validCombinaison, string curChar, string previousChar)
        {
            var twoFollowingChar = previousChar + curChar;
            if (!validCombinaison.Contains(twoFollowingChar) &&
                RomanUnit.TransformBackFromUnit(previousChar) < RomanUnit.TransformBackFromUnit(curChar))
            {
                throw new ValidationException($"The combinaison {twoFollowingChar} is not an allowed one for roman number.");
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
