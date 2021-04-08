using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;
using CaseMaker.Policies;

namespace CaseMaker.Generation.TestCases
{

    internal class WorkflowTestCasesGenerator : AbstractTestCaseGenerator
    {
        
        public WorkflowTestCasesGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxPositiveTestCases, State state) : base(deps,structure,maxPositiveTestCases)

        {
            genState = state;
        }


        protected override IUndoableEdit FillTestCases(IList<TestCase> testCases)
        {
            CompoundEdit ce = new CompoundEdit();
	   //for each combination in the dependency a test case must be created in the same order of the combination
	        foreach (Dependency dependency in  dependencies)
		        foreach (Combination combination in dependency.GetCombinations(genState))
		   {
		       TestCase testCase = new TestCase();

		       ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCase, "Origin", TestCaseOrigin.GENERATED));
		       testCase.Origin = TestCaseOrigin.GENERATED;
		       testCases.Add(testCase);
		        ce.AddEdit(PolicyFactory.instance.AddCombinationToTestCasePolicy(testCase,combination));
		   }
	    return ce;
        }

    }       
}