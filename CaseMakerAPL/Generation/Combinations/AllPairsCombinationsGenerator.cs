using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Generation.Combinations
{
    internal class AllPairsCombinationsGenerator : AbstractCombinationGenerator
    {
        public AllPairsCombinationsGenerator(Dependency dep, int maxCombinations, CombinationsGenerationOption op)
            : base(dep, maxCombinations, op)
        {
        }

        public override IUndoableEdit Generate()
        {
            base.Generate();

            List<string> preprocessedData = PreProcessDependencyData();

            AllPairsAlgorithm algorithm = new AllPairsAlgorithm();
            ArrayList result = algorithm.generateAllPairsCombinations(preprocessedData);
            //now combine each element of each array
            IList<IList<EquivalenceClass>> patterns = createEquivalenceClassPatterns(result);

            return CreateCombinationsFromPatterns(patterns,CombinationOrigin.ALLPAIRS);

        }

       

        private List<string> PreProcessDependencyData()
        {
            List<string> useCaseData = new List<String>();
            int numOfDependentElements = parentDependency.Elements.Count;
            StringBuilder elementsBuffer = new StringBuilder();
            for (int i = 0; i < numOfDependentElements; i++)
            {
                Element element = parentDependency.Elements[i];
                elementsBuffer.Append(element.UniqueId);
                if (i != numOfDependentElements - 1)
                {
                    elementsBuffer.Append("\t");
                }
            }
            useCaseData.Add(elementsBuffer.ToString());

            bool existsDependentEquivalenceClasses = true;
            int equivalenceClassIndex = 0;
            int counterOfNotExistingEquivalenceClasses = 0;
            while (existsDependentEquivalenceClasses)
            {
                StringBuilder equivalenceClassesBuffer = new StringBuilder();
                counterOfNotExistingEquivalenceClasses = 0;

                for (int i = 0; i < numOfDependentElements; i++)
                {
                    Element element = parentDependency.Elements[i];
                    List<EquivalenceClass> dependentEquivalenceClasses = parentDependency.GetEquivalenceClasses(element);

                    int numOfDependentEquivalenceClasses = dependentEquivalenceClasses.Count;
                    EquivalenceClass equivalenceClass;
                    if (equivalenceClassIndex < numOfDependentEquivalenceClasses)
                    {
                        equivalenceClass = dependentEquivalenceClasses[equivalenceClassIndex];
                        equivalenceClassesBuffer.Append(element.UniqueId);
                        equivalenceClassesBuffer.Append(",");
                        equivalenceClassesBuffer.Append(equivalenceClass.UniqueId);
                        if (i != numOfDependentElements - 1)
                        {
                            equivalenceClassesBuffer.Append("\t");
                        }
                    }
                    else
                    {
                        if (i != numOfDependentElements - 1)
                        {
                            equivalenceClassesBuffer.Append("\t");
                        }
                        counterOfNotExistingEquivalenceClasses++;
                    }
                }
                if (counterOfNotExistingEquivalenceClasses == numOfDependentElements)
                {
                    existsDependentEquivalenceClasses = false;
                }
                else
                {
                    useCaseData.Add(equivalenceClassesBuffer.ToString());
                    equivalenceClassIndex++;
                }
            }
            return useCaseData;
        }

        private IList<IList<EquivalenceClass>> createEquivalenceClassPatterns(ArrayList parm)
        {
            IList<IList<EquivalenceClass>> result = new List<IList<EquivalenceClass>>();
            foreach (object pattern in parm)
            {
                ArrayList patternArray = (ArrayList)pattern;
                List<EquivalenceClass> preResult = new List<EquivalenceClass>();
                foreach (object o in patternArray)
                {
                    foreach (EquivalenceClass equivalenceClass in parentDependency.EquivalenceClasses)
                    {
                        string[] splited = ((string)o).Split(',');
                        if (splited[1].Equals(equivalenceClass.UniqueId.ToString()))
                            preResult.Add(equivalenceClass);
                    }
                }
                preResult.Sort();
                result.Add(preResult);
            }
            return result;
        }


    }
   
}
