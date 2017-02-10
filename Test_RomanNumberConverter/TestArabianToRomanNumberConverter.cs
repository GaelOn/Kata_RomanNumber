﻿using NUnit.Framework;
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
            }
        }
    }
}