using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;

namespace CaseMaker.Generation.Combinations
{
    internal class PermutationCombinationsGenerator:AbstractCombinationGenerator
    {
        public PermutationCombinationsGenerator(Dependency dep, int maxCombinations, CombinationsGenerationOption op) : base(dep, maxCombinations,op)
        {
        }

        public override IUndoableEdit Generate()
        {
           base.Generate();
            List<Element> sortedElements = new List<Element>(parentDependency.Elements);
            sortedElements.Sort();
            List<EquivalenceClass> dependentEquivalenceClasses=null;
            IList<IList<EquivalenceClass>> dependentEquivalenceClassesList = new List<IList<EquivalenceClass>>();
            //create a array based structure of the equivalence classes
            foreach (Element element in sortedElements)
            {
                dependentEquivalenceClasses = new List<EquivalenceClass>();
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    
                    if (parentDependency.EquivalenceClasses.Contains(equivalenceClass))
                    {
                        
                        dependentEquivalenceClasses.Add(equivalenceClass);
                        dependentEquivalenceClasses.Sort();
                    }
                }
                if (dependentEquivalenceClasses.Count>0)
                {
                    dependentEquivalenceClassesList.Add(dependentEquivalenceClasses);
                }
            }
            //now combine each element of each array
             IList<IList<EquivalenceClass>> patterns = new List<IList<EquivalenceClass>>();
            CreateCombinationPatterns(dependentEquivalenceClassesList,0,null,patterns);
            return CreateCombinationsFromPatterns(patterns, CombinationOrigin.PERMUTATION);
        }

        
        

        private static void CreateCombinationPatterns(IList<IList<EquivalenceClass>> list, int currenIndex, List<EquivalenceClass>  pattern, IList<IList<EquivalenceClass>> patterns)
        {
            IList<EquivalenceClass> currentList = list[currenIndex];
            if (pattern == null) pattern = new List<EquivalenceClass>();
            foreach (EquivalenceClass equivalenceClass in currentList)
            {
                if (currenIndex < list.Count-1)
                {
                    if (pattern.Count > currenIndex )
                        pattern.RemoveAt(currenIndex);
                    pattern.Insert(currenIndex , equivalenceClass);
                    CreateCombinationPatterns(list, currenIndex + 1, pattern, patterns);
                }
                else
                {
                    if (pattern.Count > currenIndex)
                        pattern.RemoveAt(currenIndex);
                    pattern.Insert(currenIndex, equivalenceClass);
                    patterns.Add(new List<EquivalenceClass>(pattern));
                    //pattern = null;
                }
            }
        }


        protected override void ValidateModel()
        {
            base.ValidateModel();
            if (GetNumberOfGeneratedCombinations()>maxCombinations)
                throw new ArgumentException(Resources.PermutationCombinationGenerator_ValidateModel_Error);
        }

        private long GetNumberOfGeneratedCombinations()
        {
            long numOfCombinations = 1;
            int numOfEquivalenceClasses = 0;
            foreach (Element element in parentDependency.Elements)
            {
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    if (parentDependency.EquivalenceClasses.Contains(equivalenceClass))
                        numOfEquivalenceClasses++;
                }
                numOfCombinations = numOfCombinations * numOfEquivalenceClasses;
            }
            return numOfCombinations;
        }
    }
}
