using System;
using System.Collections.Generic;
using System.IO;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Policies
{
    public class StructureManager
    {
        private TestCasesStructure structure;

        public StructureManager(TestCasesStructure structure)
        {
            this.structure = structure;
        }

        public IUndoableEdit DeleteCommonTestCases(State state, IList<Dependency> deps)
        {
            if (structure == null)
                throw new NullReferenceException("The structure cannot be null");
            CompoundEdit ce = new CompoundEdit();
            IList<TestCase> deletedTestCases = new List<TestCase>();
            foreach (TestCase testCase in structure.TestCases)
            {
                if (testCase.CurrentState == state)
                    if (hasCommonDependency(testCase,deps))
                        deletedTestCases.Add(testCase);
            }
            foreach (TestCase tc in deletedTestCases)
            {
                ce.AddEdit(EditFactory.instance.CreateRemoveTestCaseEdit(structure, tc));
                structure.RemoveTestCase(tc);
            }
            return ce;
            
        }

        
        //check if any of the dependencies of the test case are contained in a list
        private static bool hasCommonDependency(TestCase owner, ICollection<Dependency> p_DependenciesOfSelected)
        {
            IList<Dependency> p_DependenciesOfTestCase = owner.Dependencies;
            if (p_DependenciesOfTestCase != null)
            {

                int numOfDependenciesOfTestCase = p_DependenciesOfTestCase.Count;
                int numOfDependenciesOfSelected = p_DependenciesOfSelected.Count;
                // if the vector are empty then are equal. . .
                if (numOfDependenciesOfTestCase == 0 && numOfDependenciesOfSelected == 0)
                    return true;
                foreach (Dependency dependency1 in p_DependenciesOfTestCase)
                {
                    if (p_DependenciesOfSelected.Contains(dependency1))
                        return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}