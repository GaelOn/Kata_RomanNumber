using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata_RomanNumber_TDD
{
    public struct RomanNumber : IEquatable<RomanNumber>
    {
        public readonly string Value;

        private RomanNumber(string representingString)
        {
            Value = representingString;
        }

        public bool Equals(RomanNumber other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(RomanNumber))
            {
                return false;
            }
            return Equals((RomanNumber)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        // use builder to avoid validating un roman number constructor, 
        // because validation throw error
        public static class RomanNumberBuilder
        {

            public static RomanNumber BuildRomanNumber(string maybeRoman)
            {
                Valid(maybeRoman);
                return new RomanNumber(maybeRoman);
            }

            private static void Valid(string toBeValidated)
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

            private static string GetPreviousChar(string oldPreviousChar, string curChar)
            {
                if (RomanUnit.TransformBackFromUnit(oldPreviousChar) < RomanUnit.TransformBackFromUnit(curChar))
                {
                    return oldPreviousChar + curChar;
                }
                return curChar;
            }

            private static void IsValidCharacter(List<string> validChar, string charac)
            {
                if (!validChar.Contains(charac))
                {
                    throw new ValidationException($"The character {charac} is not allowed in roman number.");
                }
            }

            private static void ValidRepetition(string curChar, string previousChar, ref int repetition)
            {
                repetition = (previousChar != "M" && curChar == previousChar) ?
                             repetition + 1 : 1;
                if (repetition > 3)
                {
                    throw new ValidationException($"The character {curChar} is repeated {repetition} times which is forbiden for RomanNumber.");
                }
            }

            private static void ValidCharacterFollowingCombinaison(List<Tuple<string, string>> forbidenValueFollowingCombinaison, string previous, string cur)
            {
                if (forbidenValueFollowingCombinaison.Any(tuple => tuple.Item1 == previous && tuple.Item2 == cur))
                {
                    throw new ValidationException($"The combinaison {previous} can not be followed by {cur} for roman number.");
                }
            }

            private static void ValidAllCombinaisonAreAllowedOne(List<string> validCombinaison, string curChar, string previousChar)
            {
                var twoFollowingChar = previousChar + curChar;
                if (!validCombinaison.Contains(twoFollowingChar) &&
                    RomanUnit.TransformBackFromUnit(previousChar) < RomanUnit.TransformBackFromUnit(curChar))
                {
                    throw new ValidationException($"The combinaison {twoFollowingChar} is not an allowed one for roman number.");
                }
            }

        }
    }
}
