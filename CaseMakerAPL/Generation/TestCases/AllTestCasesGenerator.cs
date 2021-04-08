using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;
using CaseMaker.Policies;

namespace CaseMaker.Generation.TestCases
{

    internal class AllTestCasesGenerator : AbstractTestCaseGenerator
    {

        public AllTestCasesGenerator(IList<Dependency> deps, TestCasesStructure structure, int maxTestCases) : base(deps,structure,maxTestCases)
        {
     
        }

        public override IUndoableEdit Generate()
        {
            CompoundEdit ce = new CompoundEdit();
            AbstractTestCaseGenerator gen = new PositiveTestCasesGenerator(dependencies, structure, maxTestCases);
            ce.AddEdit(gen.Generate());
            gen = new NegativeTestCasesGenerator(dependencies, structure, maxTestCases);
            ce.AddEdit(gen.Generate());
            gen = new FaultyTestCasesGenerator(dependencies, structure, maxTestCases);
            ce.AddEdit(gen.Generate());
            return ce;
        }

        protected override IUndoableEdit FillTestCases(IList<TestCase> cases)
        {
            throw new NotImplementedException();
        }
    }       
}