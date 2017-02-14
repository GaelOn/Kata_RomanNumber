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
        private static Dictionary<int, string> MapIntergerValueToRomanValue;
        private static List<Tuple<string, string>> ForbidenCharacterFollowingCombinaison;

        static RomanUnit()
        {
            MapIntergerValueToRomanValue = new Dictionary<int, string>();
            MapIntergerValueToRomanValue.Add(1000, "M");
            MapIntergerValueToRomanValue.Add(900, "CM");
            MapIntergerValueToRomanValue.Add(500, "D");
            MapIntergerValueToRomanValue.Add(400, "CD");
            MapIntergerValueToRomanValue.Add(100, "C");
            MapIntergerValueToRomanValue.Add(90, "XC");
            MapIntergerValueToRomanValue.Add(50, "L");
            MapIntergerValueToRomanValue.Add(40, "XL");
            MapIntergerValueToRomanValue.Add(10, "X");
            MapIntergerValueToRomanValue.Add(9, "IX");
            MapIntergerValueToRomanValue.Add(5, "V");
            MapIntergerValueToRomanValue.Add(4, "IV");
            MapIntergerValueToRomanValue.Add(1, "I");
            ForbidenCharacterFollowingCombinaison = new List<Tuple<string, string>>();
            ForbidenCharacterFollowingCombinaison.Add(new Tuple<string, string>("IV", "I"));
            ForbidenCharacterFollowingCombinaison.Add(new Tuple<string, string>("IX", "I"));
            ForbidenCharacterFollowingCombinaison.Add(new Tuple<string, string>("XL", "X"));
            ForbidenCharacterFollowingCombinaison.Add(new Tuple<string, string>("XC", "X"));
            ForbidenCharacterFollowingCombinaison.Add(new Tuple<string, string>("CD", "C"));
            ForbidenCharacterFollowingCombinaison.Add(new Tuple<string, string>("CM", "M"));
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
            return MapIntergerValueToRomanValue.Where(kv => kv.Value.Length == length)
                         .Select(kv => kv.Value)
                         .ToList();
        }

        public static List<Tuple<string, string>> GetForbidenCharacterFollowingCombinaison()
        {
            return ForbidenCharacterFollowingCombinaison;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return MapIntergerValueToRomanValue.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static string TransformToUnit(int number)
        {
            return MapIntergerValueToRomanValue[number];
        }

        public static int TransformBackFromUnit(string unit)
        {
            return MapIntergerValueToRomanValue.FirstOrDefault(kv => kv.Value == unit).Key;
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return MapIntergerValueToRomanValue.Values.GetEnumerator();
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
            var forbidenCharacterFollowingCombinaison = RomanUnit.GetForbidenCharacterFollowingCombinaison();
            // init the one pass validation algo
            string previousChar = toBeValidated[0].ToString();
            int repetition = 1;
            IsValidCharacter(validChar, previousChar);
            for (int i = 1; i < toBeValidated.Length; i++)
            {
                var curChar = toBeValidated[i].ToString();
                IsValidCharacter(validChar, curChar);
                ValidRepetition(curChar, previousChar, ref repetition);
                ValidCharacterFollowingCombinaison(forbidenCharacterFollowingCombinaison, previousChar, curChar);
                ValidAllCombinaisonAreAllowedOne(validCombinaison, curChar, previousChar);
                previousChar = GetPreviousChar(previousChar, curChar);
            }
        }

        private string GetPreviousChar(string oldPreviousChar, string curChar)
        {
            if (RomanUnit.TransformBackFromUnit(oldPreviousChar) < RomanUnit.TransformBackFromUnit(curChar))
            {
                return oldPreviousChar + curChar;
            }
            return curChar;
        }

        private void IsValidCharacter(List<string> validChar, string charac)
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

        private void ValidCharacterFollowingCombinaison(List<Tuple<string, string>> forbidenValueFollowingCombinaison, string previous, string cur)
        {
            if (forbidenValueFollowingCombinaison.Any(tuple => tuple.Item1 == previous && tuple.Item2 == cur))
            {
                throw new ValidationException($"The combinaison {previous} can not be followed by {cur} for roman number.");
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
