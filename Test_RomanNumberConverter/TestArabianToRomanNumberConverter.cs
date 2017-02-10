using NUnit.Framework;
using System;
using System.Collections;

namespace Test_RomanNumberConverter
{
    [TestFixture]
    public class Test
    {
        ArabianToRomanNumberConverter _converter;

        [SetUp]
        void Init()
        {
            var _converter = new ArabianToRomanNumberConverter();
        }

        [Test, TestCaseSource(typeof(GivenData), "TestBasicCases")]
        public void TestCase(int toBeConverted, string intendedValue)
        {
            var convertionResult = _converter.Convert(toBeConverted);
            convertionResult.ShouldBeEquivalent(intendedValue, $"because when i try to convert {toBeconverted} then i should get {intendedValue} as a result not {convertionResult}.");
        }
    }

    public static class GivenData
    {
        public static IEnumerable TestBasicCases
        {
            get
            {
                yield return new TestCaseData(1, 'I');
            }
        }
    }
}
