using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;
using CaseMaker.Policies;

namespace CaseMaker.Generation.TestCases
{

    internal class NegativeTestCasesGenerator : AbstractTestCaseGenerator
    {

        public NegativeTestCasesGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxNegativeTestCases) : base(deps,structure,maxNegativeTestCases)
        {
            genState = State.NEGATIVE;
        }

       

        protected override IUndoableEdit FillTestCases(IList<TestCase> testCases)
        {
            CompoundEdit ce = new CompoundEdit();
            ce.AddEdit(FillTestCasesFromNegativeEquivalenceClasses(testCases));
            ce.AddEdit(FillTestCasesFromNegativeCombinations(testCases));
            return ce;
        }

        protected IUndoableEdit FillTestCasesFromNegativeCombinations(ICollection<TestCase> testCases)
        {

            CompoundEdit ce = new CompoundEdit();
           
            TestCase testCase = null;
            foreach (Dependency dependency in dependencies)
            {
                foreach (Combination combination in dependency.Combinations)
                {
                    if (combination.CurrentState == State.NEGATIVE)
                    {
                        testCase = new TestCase();
                        
                        ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCase,"Origin", TestCaseOrigin.GENERATED));
                        testCase.Origin = TestCaseOrigin.GENERATED;
                        ce.AddEdit(PolicyFactory.instance.AddCombinationToTestCasePolicy(testCase, combination));
                        testCases.Add(testCase);
                    }    
                }
            }
            
            
            return ce;
            
        }

        protected IUndoableEdit FillTestCasesFromNegativeEquivalenceClasses(ICollection<TestCase> testCases)
        {
            CompoundEdit ce = new CompoundEdit();
            
            foreach (Element element in structure.Elements)
            {
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    if (equivalenceClass.CurrentState == State.NEGATIVE)
                    {
                        TestCase testCase = new TestCase();
                        ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCase, "Origin",TestCaseOrigin.GENERATED));
                        testCase.Origin = TestCaseOrigin.GENERATED;
                        ce.AddEdit(PolicyFactory.instance.AddEquivalenceClassToTestCase(equivalenceClass, testCase));
                        testCases.Add(testCase);
                    }    
                }
            }
            
            return ce;
        }


    }       
}