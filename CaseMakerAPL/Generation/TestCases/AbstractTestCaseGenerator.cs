using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;
using CaseMaker.Policies;

namespace CaseMaker.Generation.TestCases
{

    public enum TestCasesGenerationOperation
    {
        ALL,
        FAULTY_COMBINATIONS,
        FAULTY_EQUIVALENCECLASSES,
        FAULTY,
        NEGATIVE_COMBINATIONS,
        NEGATIVE_EQUIVALENCECLASSES,
        NEGATIVE,
        POSITIVE,
        WORKFLOW_POSITIVE,
        WORKFLOW_NEGATIVE,
        WORKFLOW_FAULTY
    }
    internal abstract class AbstractTestCaseGenerator : IGenerator
    {
        protected IList<Dependency> dependencies;
        protected TestCasesStructure structure;
        protected int maxTestCases;
        protected State genState;
        public AbstractTestCaseGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxTestCases)
        {
            dependencies = deps;
            this.structure = structure;
            this.maxTestCases = maxTestCases;
        }

        public virtual IUndoableEdit Generate()
        {
            ValidateModel();
            CompoundEdit ce = new CompoundEdit();
            IPolicyFactory pfact = new PolicyFactory();
            IList<TestCase> generatedTestCases = new List<TestCase>();
            //generate the test cases
            ce.AddEdit(FillTestCases(generatedTestCases));
            //delete the common test cases from the structure
            ce.AddEdit(pfact.DeleteCommonTestCasesPolicy(structure, genState, dependencies));
            if (generatedTestCases.Count + structure.GetTestCases(genState).Count > maxTestCases)
            {
                ce.EndAllEdits();
                ce.Undo();
                throw new Exception("Maximal number of " + EntityWithEvents.GetDescription(genState)+" Test Cases reached");
            }

            //add the new generated test cases
            foreach (TestCase tc in generatedTestCases)
            {
                //check if the structure has the same test cases before insert
                if (!structure.ContainsSameTestCaseByRelations(tc))
                {
                    ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(tc, "Position", structure.GetNewTestCasePosition()));
                    tc.Position = structure.GetNewTestCasePosition();
                    ce.AddEdit(EditFactory.instance.CreateAddTestCaseEdit(structure, tc));
                    structure.AddTestCase(tc);
                }
            }
            return ce;
            
        }

        protected abstract IUndoableEdit FillTestCases(IList<TestCase> cases);

        protected virtual void ValidateModel()
        {
            if (dependencies == null || structure == null)
                throw new Exception("Wrong parameters");
            if (dependencies.Count == 0)
                throw new Exception(Resources.TestCaseGenerator_ValidateModel_noDependenciesAdded);
            //here validations prior to generate the test cases
        }

     
    
       

    }       
}