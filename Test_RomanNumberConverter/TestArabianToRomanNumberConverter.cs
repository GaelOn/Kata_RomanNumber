﻿using NUnit.Framework;
using FluentAssertions;
using Kata_RomanNumber_TDD;

namespace Test_RomanNumberConverter
{
    [TestFixture]
    public class TestConversionArabianToRoman
    {
        ArabianToRomanNumberConverter _converter;

        [SetUp]
        public void Init()
        {
            _converter = new ArabianToRomanNumberConverter();
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestConversion(int toBeConverted, string intendedValue)
        {
            var convertionResult = _converter.Convert(toBeConverted);
            convertionResult.ShouldBeEquivalentTo(intendedValue, $"because when i try to convert {toBeConverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }
}