//Author Sergio Moreno
//Business Innovations
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Policies
{
    public class DependencyManager
    {
        private readonly Dependency dependency;

        public DependencyManager(Dependency dependency)
        {
            this.dependency = dependency;
        }

        public IUndoableEdit DeleteAllCombinations()
        {
            CompoundEdit ce = new CompoundEdit();
            List<Combination> combis = new List<Combination>(dependency.Combinations);
            foreach (Combination combination in combis)
            {
                CombinationManager man = new CombinationManager(combination);
                ce.AddEdit(man.DeleteCombination(dependency.ParentStructure));
            }
            return ce;
        }
    }
}