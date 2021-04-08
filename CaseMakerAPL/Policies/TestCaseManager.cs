using System;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Policies
{
    internal class TestCaseManager
    {
        private TestCase testCase;

        public TestCaseManager(TestCase testCase)
        {
            this.testCase = testCase;
        }


        public IUndoableEdit AddCombination(Combination combi)
        {
            if (testCase == null) throw new Exception("The test case cannot be null"); 
            CompoundEdit ce = new CompoundEdit();
            ce.AddEdit(EditFactory.instance.CreateAddCombinationEdit(testCase, combi));
            testCase.AddCombination(combi);
            RiskLevelManager rlc = new RiskLevelManager(combi);
            ce.AddEdit(rlc.ApplyRiskLevelToChildren());
            StateObjectManager som = new StateObjectManager(combi);
            ce.AddEdit(som.ApplyStateToChildren());


            return ce;
       }

        public IUndoableEdit AddEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (testCase == null) throw new Exception("The test case cannot be null");
            CompoundEdit ce = new CompoundEdit();
            ce.AddEdit(EditFactory.instance.CreateAddEquivalenceClassEdit(testCase, equivalenceClass));
            testCase.AddEquivalenceClass(equivalenceClass);
            RiskLevelManager rlc = new RiskLevelManager(equivalenceClass);
            ce.AddEdit(rlc.ApplyRiskLevelToChildren());
            StateObjectManager som = new StateObjectManager(equivalenceClass);
            ce.AddEdit(som.ApplyStateToChildren());


            return ce;
            
        }
    }

    
}