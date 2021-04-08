//Author Sergio Moreno
//Business Innovations
using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Generation;
using CaseMaker.Generation.Combinations;
using CaseMaker.Generation.TestCases;

namespace CaseMaker.Policies
{
    public interface IPolicyFactory
{    
        IUndoableEdit DeleteAllCombinationsPolicy(Dependency dep);
        IUndoableEdit DeleteCombinationPolicy(Combination combination, TestCasesStructure structure);
        IUndoableEdit DeleteCommonTestCasesPolicy(TestCasesStructure structure, State tcState, IList<Dependency> deps);
        IUndoableEdit AddCombinationToTestCasePolicy(TestCase tc, Combination combi);
        IUndoableEdit AddEquivalenceClassToTestCase(EquivalenceClass equivalenceClass, TestCase testCase);

        IUndoableEdit GenerateCombinations(CombinationsGenerationOperation operation, Dependency dependency,
                                           int MaxNumberofCombinations, CombinationsGenerationOption options);

        IUndoableEdit GenerateTestCases(TestCasesGenerationOperation operation, IList<Dependency> dependencies,
                                        int maxTestCases);

        IUndoableEdit GenerateOneWiseTestCases(TestCasesStructure structure, int maxTestCases);

        IUndoableEdit MergeCombination(Combination combination, IList<Combination> combinationsToMerge);

        IList<Combination> FindCombinationsToMerge(Combination combination, EquivalenceClass equivalenceClass);

        IUndoableEdit UnMergeCombinations(Combination combination, EquivalenceClass equivalenceClass);

        IUndoableEdit ApplyRiskLevel(IRiskLevelObject riskObject, int newRiskLevel);

        IUndoableEdit ApplyState(IStateObject stateObject, State newState);

    }

    public class PolicyFactory : IPolicyFactory
    {
        public static readonly IPolicyFactory instance = new PolicyFactory();
        
        #region IPolicyFactory Members

        public IUndoableEdit DeleteAllCombinationsPolicy(Dependency dep)
        {
            DependencyManager dm = new DependencyManager(dep);
            return dm.DeleteAllCombinations();
        }

        public IUndoableEdit DeleteCombinationPolicy(Combination combination,TestCasesStructure structure)
        {
            CombinationManager cm = new CombinationManager(combination);
            return cm.DeleteCombination(structure);
        }

        public IUndoableEdit DeleteCommonTestCasesPolicy(TestCasesStructure structure, State tcState, IList<Dependency> deps)
        {
            StructureManager sm = new StructureManager(structure);
            return sm.DeleteCommonTestCases(tcState, deps);
        }

        public IUndoableEdit AddCombinationToTestCasePolicy(TestCase tc, Combination combi)
        {
            TestCaseManager tm = new TestCaseManager(tc);
            return tm.AddCombination(combi);
        }

        public IUndoableEdit AddEquivalenceClassToTestCase(EquivalenceClass equivalenceClass, TestCase testCase)
        {
            TestCaseManager tm = new TestCaseManager(testCase);
            return tm.AddEquivalenceClass(equivalenceClass);
        }

        public IUndoableEdit GenerateCombinations(CombinationsGenerationOperation operation, Dependency dependency,
                                                  int maxNumberofCombinations, CombinationsGenerationOption options)
        {
            IGenerator gen;
            if (operation == CombinationsGenerationOperation.ALLPAIRS)
                gen = new AllPairsCombinationsGenerator(dependency, maxNumberofCombinations, options);
            else
                gen = new PermutationCombinationsGenerator(dependency, maxNumberofCombinations, options);
            return gen.Generate();
        }

        public IUndoableEdit GenerateTestCases(TestCasesGenerationOperation operation, IList<Dependency> dependencies,
                                               int maxTestCases)
        {
            IGenerator gen;
            if (dependencies.Count==0)
                throw new ArgumentException("The dependencies list cannot be empty");
            TestCasesStructure structure = dependencies[0].ParentStructure;
            switch(operation)
            {
                case TestCasesGenerationOperation.ALL:
                    gen = new AllTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                case TestCasesGenerationOperation.FAULTY:
                    gen = new FaultyTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                case TestCasesGenerationOperation.FAULTY_COMBINATIONS:
                    gen = new FaultyCombinationTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                case TestCasesGenerationOperation.FAULTY_EQUIVALENCECLASSES:
                    gen = new FaultyEquivalenceClassesTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                case TestCasesGenerationOperation.NEGATIVE:
                    gen = new NegativeTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                case TestCasesGenerationOperation.NEGATIVE_COMBINATIONS:
                    gen = new NegativeCombinationTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                case TestCasesGenerationOperation.NEGATIVE_EQUIVALENCECLASSES:
                    gen = new NegativeEquivalenceClassesTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                
                case TestCasesGenerationOperation.POSITIVE:
                    gen = new PositiveTestCasesGenerator(dependencies, structure, maxTestCases);
                    break;
                case TestCasesGenerationOperation.WORKFLOW_POSITIVE:
                    gen = new WorkflowTestCasesGenerator(dependencies, structure, maxTestCases, State.POSITIVE);
                    break;
                case TestCasesGenerationOperation.WORKFLOW_NEGATIVE:
                    gen = new WorkflowTestCasesGenerator(dependencies, structure, maxTestCases, State.NEGATIVE);
                    break;
                case TestCasesGenerationOperation.WORKFLOW_FAULTY:
                    gen = new WorkflowTestCasesGenerator(dependencies, structure, maxTestCases, State.POSITIVE);
                    break;
                default:
                    throw new NotImplementedException("Operation not implemented");

            }
            return gen.Generate();
        }

        public IUndoableEdit GenerateOneWiseTestCases(TestCasesStructure structure, int maxTestCases)
        {
            IGenerator gen = new OneWiseTestCasesGenerator(structure, maxTestCases);
            return gen.Generate();
        }

        public IUndoableEdit MergeCombination(Combination combination, IList<Combination> combinationsToMerge)
        {
            CombinationManager cm = new CombinationManager(combination);
            return cm.MergeCombinations(combinationsToMerge);
        }

        public IList<Combination> FindCombinationsToMerge(Combination combination, EquivalenceClass equivalenceClass)
        {
            CombinationManager cm = new CombinationManager(combination);
            return cm.FindMergeableCombinations(equivalenceClass);
        }

        public IUndoableEdit UnMergeCombinations(Combination combination, EquivalenceClass equivalenceClass)
        {
            CombinationManager cm = new CombinationManager(combination);
            return cm.UnMergeCombinations(equivalenceClass);
        }

        public IUndoableEdit ApplyRiskLevel(IRiskLevelObject riskObject, int newRiskLevel)
        {
            RiskLevelManager rlm = new RiskLevelManager(riskObject);
            return rlm.ChangeRiskLevel(newRiskLevel);
        }

        public IUndoableEdit ApplyState(IStateObject stateObject, State newState)
        {
            StateObjectManager sto = new StateObjectManager(stateObject);
            return sto.ChangeState(newState);
        }

        #endregion
    }

   
}
