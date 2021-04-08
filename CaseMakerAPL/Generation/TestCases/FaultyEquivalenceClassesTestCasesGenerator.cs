using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;


namespace CaseMaker.Generation.TestCases
{

    internal class FaultyEquivalenceClassesTestCasesGenerator : FaultyTestCasesGenerator
    {


        public FaultyEquivalenceClassesTestCasesGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxFaultyTestCases)
            : base(deps, structure,maxFaultyTestCases)
        {
          
        }

        protected override IUndoableEdit  FillTestCases(IList<TestCase> cases)
        {
 	        return FillTestCasesFromFaultyEquivalenceClasses(cases);
        }
    
      
    }
}