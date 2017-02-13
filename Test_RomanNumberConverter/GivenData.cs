using NUnit.Framework;
using System.Collections;

namespace Test_RomanNumberConverter
{

    public static class GivenData
    {
        public static IEnumerable BadRomanNumberCase
        {
            get
            {
                yield return new TestCaseData("IIII", "The character I is repeated 4 times which is forbiden for RomanNumber.", "because I is repeated 4 times");
                yield return new TestCaseData("XXXX", "The character X is repeated 4 times which is forbiden for RomanNumber.", "because X is repeated 4 times");
                yield return new TestCaseData("LLLL", "The character L is repeated 4 times which is forbiden for RomanNumber.", "because L is repeated 4 times");
                yield return new TestCaseData("CCCC", "The character C is repeated 4 times which is forbiden for RomanNumber.", "because C is repeated 4 times");
                yield return new TestCaseData("DDDD", "The character D is repeated 4 times which is forbiden for RomanNumber.", "because D is repeated 4 times");
                yield return new TestCaseData("XIIII", "The character I is repeated 4 times which is forbiden for RomanNumber.", "because I is repeated 4 times");
                yield return new TestCaseData("A", "The character A is not allowed in roman number.", "because A is not a valid character in roman number");
                yield return new TestCaseData("E", "The character E is not allowed in roman number.", "because E is not a valid character in roman number");
                yield return new TestCaseData("O", "The character O is not allowed in roman number.", "because O is not a valid character in roman number");
                yield return new TestCaseData("CAX", "The character A is not allowed in roman number.", "because A is not a valid character in roman number");
                yield return new TestCaseData("MAD", "The character A is not allowed in roman number.", "because A is not a valid character in roman number");
                yield return new TestCaseData("LEX", "The character E is not allowed in roman number.", "because E is not a valid character in roman number");
                yield return new TestCaseData("ZIX", "The character Z is not allowed in roman number.", "because Z is not a valid character in roman number");
                yield return new TestCaseData("BADCASE", "The character B is not allowed in roman number.", "because B is not a valid character in roman number");
                yield return new TestCaseData("IL", "The combinaison IL is not an allowed one for roman number.", "because IL is not an allowed combinaison for roman number");
                yield return new TestCaseData("IC", "The combinaison IC is not an allowed one for roman number.", "because IC is not an allowed combinaison for roman number");
                yield return new TestCaseData("ID", "The combinaison ID is not an allowed one for roman number.", "because ID is not an allowed combinaison for roman number");
                yield return new TestCaseData("IM", "The combinaison IM is not an allowed one for roman number.", "because IM is not an allowed combinaison for roman number");
                yield return new TestCaseData("VX", "The combinaison VX is not an allowed one for roman number.", "because VX is not an allowed combinaison for roman number");
                yield return new TestCaseData("VL", "The combinaison VL is not an allowed one for roman number.", "because VL is not an allowed combinaison for roman number");
                yield return new TestCaseData("VC", "The combinaison VC is not an allowed one for roman number.", "because VC is not an allowed combinaison for roman number");
                yield return new TestCaseData("VD", "The combinaison VD is not an allowed one for roman number.", "because VD is not an allowed combinaison for roman number");
                yield return new TestCaseData("VM", "The combinaison VM is not an allowed one for roman number.", "because VM is not an allowed combinaison for roman number");
                yield return new TestCaseData("XD", "The combinaison XD is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("XM", "The combinaison XM is not an allowed one for roman number.", "because XM is not an allowed combinaison for roman number");
                yield return new TestCaseData("LC", "The combinaison LC is not an allowed one for roman number.", "because LC is not an allowed combinaison for roman number");
                yield return new TestCaseData("LD", "The combinaison LD is not an allowed one for roman number.", "because LD is not an allowed combinaison for roman number");
                yield return new TestCaseData("LM", "The combinaison LM is not an allowed one for roman number.", "because LM is not an allowed combinaison for roman number");
                yield return new TestCaseData("DM", "The combinaison DM is not an allowed one for roman number.", "because DM is not an allowed combinaison for roman number");
                yield return new TestCaseData("XDVII", "The combinaison XD is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("MMMMMXDVII", "The combinaison XD is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("MMMMDVLII", "The combinaison VL is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("DMVLII", "The combinaison DM is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("LVX", "The combinaison VX is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("DIC", "The combinaison IC is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("DVC", "The combinaison VC is not an allowed one for roman number.", "because XD is not an allowed combinaison for roman number");
                yield return new TestCaseData("IVI", "The combinaison IV can not be followed by I for roman number.", "because IVI is not an allowed combinaison for roman number");
                yield return new TestCaseData("XLX", "The combinaison XL can not be followed by X for roman number.", "because XLX is not an allowed combinaison for roman number");
                yield return new TestCaseData("CDC", "The combinaison CD can not be followed by C for roman number.", "because CDC is not an allowed combinaison for roman number");
            }
        }

        public static IEnumerable RepetionThatShouldPass
        {
            get
            {
                yield return new TestCaseData("MMMM");
            }
        }

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
                yield return new TestCaseData(900, "CM");
                yield return new TestCaseData(924, "CMXXIV");
                yield return new TestCaseData(949, "CMXLIX");
                yield return new TestCaseData(976, "CMLXXVI");
                yield return new TestCaseData(994, "CMXCIV");
                yield return new TestCaseData(1000, "M");
                yield return new TestCaseData(1003, "MIII");
                yield return new TestCaseData(1048, "MXLVIII");
                yield return new TestCaseData(3066, "MMMLXVI");
                yield return new TestCaseData(3143, "MMMCXLIII");
                yield return new TestCaseData(2299, "MMCCXCIX");
                yield return new TestCaseData(5369, "MMMMMCCCLXIX");
                yield return new TestCaseData(1374, "MCCCLXXIV");
                yield return new TestCaseData(4400, "MMMMCD");
                yield return new TestCaseData(8476, "MMMMMMMMCDLXXVI");
                yield return new TestCaseData(3494, "MMMCDXCIV");
                yield return new TestCaseData(1500, "MD");
                yield return new TestCaseData(3624, "MMMDCXXIV");
                yield return new TestCaseData(2639, "MMDCXXXIX");
                yield return new TestCaseData(1643, "MDCXLIII");
                yield return new TestCaseData(4671, "MMMMDCLXXI");
                yield return new TestCaseData(1747, "MDCCXLVII");
                yield return new TestCaseData(9994, "MMMMMMMMMCMXCIV");
            }
        }
    }
}