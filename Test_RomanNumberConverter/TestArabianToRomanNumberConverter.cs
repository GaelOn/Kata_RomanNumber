using NUnit.Framework;
using FluentAssertions;
using System.Collections;
using Kata_RomanNumber_TDD;

namespace Test_RomanNumberConverter
{
    [TestFixture]
    public class Test
    {
        ArabianToRomanNumberConverter _converter;

        [SetUp]
        public void Init()
        {
            _converter = new ArabianToRomanNumberConverter();
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestCase(int toBeConverted, string intendedValue)
        {
            var convertionResult = _converter.Convert(toBeConverted);
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }

    public static class GivenData
    {
        public static IEnumerable TestBasicCases
        {
            get
            {
                yield return new TestCaseData(1, "I");
                yield return new TestCaseData(2, "II");
                yield return new TestCaseData(3, "III");
                yield return new TestCaseData(4, "IV");
                yield return new TestCaseData(5, "V");
                yield return new TestCaseData(6, "VI");
                yield return new TestCaseData(7, "VII");
                yield return new TestCaseData(8, "VIII");
                yield return new TestCaseData(9, "IX");
                yield return new TestCaseData(10, "X");
                yield return new TestCaseData(11, "XI");
                yield return new TestCaseData(12, "XII");
                yield return new TestCaseData(13, "XIII");
                yield return new TestCaseData(14, "XIV");
                yield return new TestCaseData(15, "XV");
                yield return new TestCaseData(16, "XVI");
                yield return new TestCaseData(17, "XVII");
                yield return new TestCaseData(18, "XVIII");
                yield return new TestCaseData(19, "XIX");
                yield return new TestCaseData(20, "XX");
                yield return new TestCaseData(23, "XXIII");
                yield return new TestCaseData(24, "XXIV");
                yield return new TestCaseData(25, "XXV");
                yield return new TestCaseData(29, "XXIX");
                yield return new TestCaseData(30, "XXX");
                yield return new TestCaseData(34, "XXXIV");
                yield return new TestCaseData(35, "XXXV");
                yield return new TestCaseData(39, "XXXIX");
                yield return new TestCaseData(40, "XL");
                yield return new TestCaseData(42, "XLII");
                yield return new TestCaseData(44, "XLIV");
                yield return new TestCaseData(45, "XLV");
                yield return new TestCaseData(48, "XLVIII");
                yield return new TestCaseData(49, "XLIX");
                yield return new TestCaseData(50, "L");
                yield return new TestCaseData(52, "LII");
                yield return new TestCaseData(60, "LX");
                yield return new TestCaseData(66, "LXVI");
                yield return new TestCaseData(79, "LXXIX");
                yield return new TestCaseData(84, "LXXXIV");
                yield return new TestCaseData(85, "LXXXV");
                yield return new TestCaseData(90, "XC");
                yield return new TestCaseData(92, "XCII");
                yield return new TestCaseData(94, "XCIV");
                yield return new TestCaseData(95, "XCV");
                yield return new TestCaseData(98, "XCVIII");
                yield return new TestCaseData(99, "XCIX");
                yield return new TestCaseData(100, "C");
                yield return new TestCaseData(124, "CXXIV");
                yield return new TestCaseData(139, "CXXXIX");
                yield return new TestCaseData(143, "CXLIII");
                yield return new TestCaseData(171, "CLXXI");
                yield return new TestCaseData(247, "CCXLVII");
                yield return new TestCaseData(299, "CCXCIX");
				yield return new TestCaseData(369, "CCCLXIX");
                yield return new TestCaseData(374, "CCCLXXIV");
                yield return new TestCaseData(400, "CD");
                yield return new TestCaseData(424, "CDXXIV");
                yield return new TestCaseData(449, "CDXLIX");
                yield return new TestCaseData(476, "CDLXXVI");
                yield return new TestCaseData(494, "CDXCIV");
                yield return new TestCaseData(500, "D");
                yield return new TestCaseData(624, "DCXXIV");
                yield return new TestCaseData(639, "DCXXXIX");
                yield return new TestCaseData(643, "DCXLIII");
                yield return new TestCaseData(671, "DCLXXI");
                yield return new TestCaseData(747, "DCCXLVII");
                yield return new TestCaseData(799, "DCCXCIX");
                yield return new TestCaseData(869, "DCCCLXIX");
                yield return new TestCaseData(874, "DCCCLXXIV");
            }
        }
    }
}