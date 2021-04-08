using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface ITestCasesBean
    {
        IList<TestCase> TestCases { get; set; }
        void AddTestCase(TestCase testCase);
        void RemoveTestCase(TestCase testCase);
    }
}