using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;
using CaseMaker.Policies;
using Iesi.Collections.Generic;

namespace CaseMaker.Generation.Combinations
{
    public  enum CombinationsGenerationOption
    {
        UPDATE,OVERWRITE
    }
    public enum CombinationsGenerationOperation
    {
        PERMUTATION,
        ALLPAIRS
    }
    internal class AbstractCombinationGenerator : IGenerator
    {
        protected Dependency parentDependency;
        protected long maxCombinations;
        protected CombinationsGenerationOption generationOption;


      public AbstractCombinationGenerator(Dependency dep, long maxCombinations, CombinationsGenerationOption option)
      {
          parentDependency = dep;
          this.maxCombinations = maxCombinations;
          generationOption = option;
      }

        public virtual IUndoableEdit Generate()
        {
            ValidateModel();
            return null;
        }

        protected virtual void ValidateModel()
        {
             if (parentDependency==null) 
                throw new ArgumentException(Resources.AbstractCombinationGenerator_ValidateModel_Dependency);
             if (parentDependency.Elements.Count<2)
                 throw new ArgumentException(Resources.AbstractCombinationGenerator_ValidateModel_ElementsNeeded);
             if (maxCombinations == 0)
                 throw new ArgumentException(Resources.AbstractCombinationGenerator_ValidateModel_MaximalNumberOfCombHigh);
            if (parentDependency.EquivalenceClasses.Count<=2)
                throw new ArgumentException(Resources.AbstractCombinationGenerator_ValidateModel_NeededEquivalenceClasses);
        }

        protected void RemoveRepeatedPatterns(IList<IList<EquivalenceClass>> patterns)
        {
            //patterns.Equals()
            List<IList<EquivalenceClass>> l_patterns = new List<IList<EquivalenceClass>>(patterns);
            foreach (IList<EquivalenceClass> list in l_patterns)
            {
                HashedSet<EquivalenceClass> eqSet = new HashedSet<EquivalenceClass>(list);
                foreach (Combination combination in parentDependency.Combinations)
                {
                    HashedSet<EquivalenceClass> combiEqSet = new HashedSet<EquivalenceClass>(combination.EquivalenceClasses);
                    if (eqSet.Equals(combiEqSet))
                    {
                        patterns.Remove(list);
                    }
                }
            }

        }

        protected IUndoableEdit RemoveInvalidCombinations(IEnumerable<IList<EquivalenceClass>> patterns)
        {
            CompoundEdit ce = new CompoundEdit();
            IPolicyFactory fact = new PolicyFactory();
            //patterns.Equals()
            List<Combination> combinations = new List<Combination>(parentDependency.Combinations);
            foreach (IList<EquivalenceClass> list in patterns)
            {
                HashedSet<EquivalenceClass> eqSet = new HashedSet<EquivalenceClass>(list);
                foreach (Combination combination in parentDependency.Combinations)
                {
                    HashedSet<EquivalenceClass> combiEqSet = new HashedSet<EquivalenceClass>(combination.EquivalenceClasses);
                    if (eqSet.Equals(combiEqSet))
                    {
                        combinations.Remove(combination);
                    }
                }
            }
            foreach (Combination combination in combinations)
            {
                ce.AddEdit(fact.DeleteCombinationPolicy(combination, parentDependency.ParentStructure));
                parentDependency.RemoveCombination(combination);
            }

            return ce;
        }
        protected IUndoableEdit CreateCombinationsFromPatterns(IList<IList<EquivalenceClass>> patterns, CombinationOrigin origin)
        {
            //order the patterns based on equivalenceclasses
            ((List<IList<EquivalenceClass>>)patterns).Sort(new PatternComparer());
            ////create a combination for each pattern in the patterns
            CompoundEdit ce = new CompoundEdit();
            IPolicyFactory pfact = new PolicyFactory();
            ////delete all combinations from the dependency
            if (generationOption == CombinationsGenerationOption.OVERWRITE)
                ce.AddEdit(pfact.DeleteAllCombinationsPolicy(parentDependency));
            else
            {
                ce.AddEdit(RemoveInvalidCombinations(patterns));
                RemoveRepeatedPatterns(patterns);
            }
            ////create the combinations from the pattern and remove the invalid ones
            foreach (IList<EquivalenceClass> list in patterns)
            {
                Combination comb = new Combination();
                ce.AddEdit(EditFactory.instance.CreateAddCombinationEdit(parentDependency, comb));
                parentDependency.AddCombination(comb);

                ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(comb, "Origin", origin));
                comb.Origin = origin;
                foreach (EquivalenceClass equivalenceClass in list)
                {
                    ce.AddEdit(EditFactory.instance.CreateAddEquivalenceClassEdit(comb, equivalenceClass));
                    comb.AddEquivalenceClass(equivalenceClass);
                }
            }
            ////put the positions
            int i = 1;
            foreach (Combination combination in parentDependency.Combinations)
            {
                if (combination.Position != i)
                {
                    ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(combination, "Position", i));
                    combination.Position = i;
                }
                i++;
            }

            return ce;
        }
        internal class PatternComparer : IComparer<IList<EquivalenceClass>>
        {
            #region IComparer<IList<EquivalenceClass>> Members

            public int Compare(IList<EquivalenceClass> x, IList<EquivalenceClass> y)
            {
                int i = 0;
                foreach (EquivalenceClass equivalenceClass in x)
                {
                    if (i < y.Count)
                        if (!equivalenceClass.Equals(y[i]))
                            return equivalenceClass.CompareTo(y[i]);
                    i++;
                }
                return 0;

            }

            #endregion
        }
    }
}