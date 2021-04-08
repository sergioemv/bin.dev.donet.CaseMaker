using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Generation.TestCases
{

    internal class NegativeEquivalenceClassesTestCasesGenerator : NegativeTestCasesGenerator
    {
        public NegativeEquivalenceClassesTestCasesGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxNegativeTestCases) : base(deps, structure, maxNegativeTestCases)
        {
        }

        protected override IUndoableEdit FillTestCases(IList<TestCase> testCases)
        {
            return FillTestCasesFromNegativeEquivalenceClasses(testCases);
        }
       

    }       
}