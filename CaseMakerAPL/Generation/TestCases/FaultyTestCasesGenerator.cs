using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Policies;

namespace CaseMaker.Generation.TestCases
{

    internal class FaultyTestCasesGenerator : AbstractTestCaseGenerator
    {
        

        public FaultyTestCasesGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxFaultyTestCases)
            : base(deps, structure, maxFaultyTestCases)
        {
            genState = State.FAULTY;
        }

        protected IUndoableEdit FillTestCasesFromFaultyCombinations(ICollection<TestCase> testCases)
        {

            CompoundEdit ce = new CompoundEdit();

            TestCase testCase = null;
            foreach (Dependency dependency in dependencies)
            {
                foreach (Combination combination in dependency.Combinations)
                {
                    if (combination.CurrentState == State.FAULTY)
                    {
                        testCase = new TestCase();

                        ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCase, "Origin", TestCaseOrigin.GENERATED));
                        testCase.Origin = TestCaseOrigin.GENERATED;
                        ce.AddEdit(PolicyFactory.instance.AddCombinationToTestCasePolicy(testCase, combination));
                        testCases.Add(testCase);
                    }
                }
            }


            return ce;

        }

        protected IUndoableEdit FillTestCasesFromFaultyEquivalenceClasses(ICollection<TestCase> testCases)
        {
            CompoundEdit ce = new CompoundEdit();

            foreach (Element element in structure.Elements)
            {
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    if (equivalenceClass.CurrentState == State.FAULTY)
                    {
                        TestCase testCase = new TestCase();
                        ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCase, "Origin", TestCaseOrigin.GENERATED));
                        testCase.Origin = TestCaseOrigin.GENERATED;
                        ce.AddEdit(PolicyFactory.instance.AddEquivalenceClassToTestCase(equivalenceClass, testCase));
                        testCases.Add(testCase);
                    }
                }
            }

            return ce;
        }

        protected override IUndoableEdit FillTestCases(IList<TestCase> cases)
        {
            CompoundEdit ce = new CompoundEdit();
            ce.AddEdit(FillTestCasesFromFaultyEquivalenceClasses(cases));
            ce.AddEdit(FillTestCasesFromFaultyCombinations(cases));
            return ce;
        }
    }
}