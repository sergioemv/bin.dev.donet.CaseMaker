using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;
using CaseMaker.Policies;

namespace CaseMaker.Generation.TestCases
{

    internal class PositiveTestCasesGenerator : AbstractTestCaseGenerator
    {

        public PositiveTestCasesGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxPositiveTestCases) : base(deps,structure,maxPositiveTestCases)
        {
     
        }


        protected override IUndoableEdit FillTestCases(IList<TestCase> testCases)
        {
            CompoundEdit ce = new CompoundEdit();
            TestCase testCase = null;
            IList<Combination> rejectedCombinations = new List<Combination>();
            int maxNumOfPositiveCombinations = 0;
             //check wich dependency has the maximal number of positive combniations
            foreach (Dependency dependency in dependencies)
            {
                int numOfPositiveCombinations =  dependency.GetCombinations(State.POSITIVE).Count;
                if (numOfPositiveCombinations > maxNumOfPositiveCombinations) {
                        maxNumOfPositiveCombinations = numOfPositiveCombinations;
                }        
            }
            //create a test case for each of this maximal number
            for (int i = 0; i < maxNumOfPositiveCombinations; i++)
            {
                //create the test case with his attributes
                testCase = new TestCase();
                ce.AddEdit(EditFactory.instance.CreateChangeStateEdit(testCase,  State.POSITIVE));
                testCase.CurrentState = State.POSITIVE;
                ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCase, "Origin", TestCaseOrigin.GENERATED));
                testCase.Origin = TestCaseOrigin.GENERATED;
                testCases.Add(testCase);
                //if( !existsTestCaseWithTheSameValues(testCase, generatedTestCases, p_Structure.getLnkElements())) {

                //}
                foreach (Dependency dependency in dependencies)
                {
                    Combination combination = dependency.GetCombinationAt(i, State.POSITIVE);
                    CombinationManager cm = new CombinationManager(combination);
                    if (combination != null)
                    {
                        if (cm.CanBeAssignedToTestCase(testCase))
                        {
                            ce.AddEdit(PolicyFactory.instance.AddCombinationToTestCasePolicy(testCase, combination));
                        }
                        else
                        {
                            rejectedCombinations.Add(combination);
                        }
                    }
                }
            }
            List<Combination> usedRejectedCombinations = new List<Combination>();
            TestCase testCaseOfRejectedCombinations;
                foreach (Combination rejectedCombination in rejectedCombinations)
                {
                    bool combinationIsAssignedToATestCase = false;
                    foreach (TestCase tc in testCases)
                    {
                        if (!usedRejectedCombinations.Contains(rejectedCombination))
                        {
                            CombinationManager cm = new CombinationManager(rejectedCombination);
                            if (cm.CanBeAssignedToTestCase(tc))
                            {
                                ce.AddEdit(PolicyFactory.instance.AddCombinationToTestCasePolicy(tc,rejectedCombination));
                                combinationIsAssignedToATestCase = true;
                                usedRejectedCombinations.Add(rejectedCombination);
                            }
                        }
                    }
                    if (!combinationIsAssignedToATestCase)
                    {
                                if (!usedRejectedCombinations.Contains(rejectedCombination))
                                {
                                    testCaseOfRejectedCombinations = new TestCase();
                                    ce.AddEdit(EditFactory.instance.CreateChangeStateEdit(testCaseOfRejectedCombinations, State.POSITIVE));
                                    testCaseOfRejectedCombinations.CurrentState = State.POSITIVE;
                                    ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCaseOfRejectedCombinations, "Origin", TestCaseOrigin.GENERATED));
                                    testCaseOfRejectedCombinations.Origin = TestCaseOrigin.GENERATED;
                                    testCases.Add(testCaseOfRejectedCombinations);
                                    ce.AddEdit(PolicyFactory.instance.AddCombinationToTestCasePolicy(testCaseOfRejectedCombinations, rejectedCombination));
                                    usedRejectedCombinations.Add(rejectedCombination);
                                }
                    }
            }
            return ce;
        }

    }       
}