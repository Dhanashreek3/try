using NUnit.Framework;
using System.Collections;

namespace NUnitTestProject
{
    internal class TestDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("100", "trial1");
                yield return new TestCaseData("102", "trial2");

            }
        }
    }
}