using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<int> GetUnitAsInteger()
        {
            return MapIntergerValueToRomanValue.Keys;
        }

        public static IEnumerable<string> GetUnitAsString()
        {
            return MapIntergerValueToRomanValue.Values;
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
}
