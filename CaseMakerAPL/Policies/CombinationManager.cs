//Author Sergio Moreno
//Business Innovations
using System;
using System.Collections;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using Iesi.Collections.Generic;

namespace CaseMaker.Policies
{
    internal class CombinationManager
    {
        private Combination combination;

        public CombinationManager(Combination combination)
        {
            this.combination = combination;
        }
        public IUndoableEdit DeleteCombination(TestCasesStructure structure)
        {
            CompoundEdit ce = new CompoundEdit();
            
            if (structure != null)
            {
                //delete the reference from all test cases
                foreach (TestCase testCase in structure.TestCases)
                {
                    if (testCase.Combinations.Contains(combination))
                    {
                        ce.AddEdit(
                            EditFactory.instance.CreateRemoveCombinationEdit(testCase, combination));
                        testCase.RemoveCombination(combination);
                    }
                }
                //delete the combination from all other combinations
                foreach (Combination combination1 in combination.ParentDependency.Combinations)
                {
                    if (combination1.Combinations.Contains(combination))
                    {
                        ce.AddEdit(EditFactory.instance.CreateRemoveCombinationEdit(combination1, combination1));
                        combination1.RemoveCombination(combination);
                    }
                }
            }
            ce.AddEdit(EditFactory.instance.CreateRemoveCombinationEdit(combination.ParentDependency, combination));
            combination.ParentDependency.RemoveCombination(combination);
            return ce;
        }
        
        // Determines if a combination can be assigned or not to a test case
        public bool CanBeAssignedToTestCase(TestCase tc)
        {
            //if the combination is already contained then no
            if (tc.Combinations.Contains(combination))
                return false;
            //if the combination is a child combination cannot be assigned either
            if (combination.ParentCombination!=null)
                return false;

            List<EquivalenceClass> tcEqs = (List<EquivalenceClass>) tc.GetAllEquivalenceClasses();
            List<EquivalenceClass> combEqs2 = new List<EquivalenceClass>();
            foreach (EquivalenceClass eq in combination.GetAllEquivalenceClasses())
            {
                if (!tcEqs.Contains(eq))
                    combEqs2.Add(eq);
            }
            foreach (EquivalenceClass equivalenceClass in combEqs2)
            {
                if (tc.GetAllElements().Contains(equivalenceClass.ParentElement))
                    return false;
            }
            return true;
            
        }
   
        public IUndoableEdit MergeCombinations(IList<Combination> combinationsToMerge)
        {
            if (combinationsToMerge.Count<1) throw new ArgumentException("The list of combinations to merge is empty");
            if (combination.Origin != CombinationOrigin.PERMUTATION) throw new InvalidOperationException("The merge is available only for combinations generated by permutation");

            CompoundEdit ce = new CompoundEdit();
            //first merge the effects
            ce.AddEdit(MergeEffects(combinationsToMerge));
            foreach (Combination combi in combinationsToMerge)
            {
                if (!combination.Combinations.Contains(combi)&&combination!=combi)
                {
                    ce.AddEdit(EditFactory.instance.CreateAddCombinationEdit(combination, combi));
                    combination.AddCombination(combi);
                }
            }
            //remove all test cases referenced by the merged combinations (invalid testcases now)
            if (combination.ParentDependency!=null && combination.ParentDependency.ParentStructure!=null)
            {
                ISet<Combination> combinationsMerged = new HashedSet<Combination>(combinationsToMerge);
                IList<TestCase> deletedTCs = new List<TestCase>();
                foreach (TestCase testCase in combination.ParentDependency.ParentStructure.TestCases)
                {
                    ISet<Combination> tcCombinations = new HashedSet<Combination>(testCase.Combinations);
                    if (tcCombinations.Intersect(combinationsMerged).Count>0)
                        //delete the referenced test case
                        deletedTCs.Add(testCase);
                }
                foreach (TestCase tc in deletedTCs)
                {
                    ce.AddEdit(
                        EditFactory.instance.CreateRemoveTestCaseEdit(combination.ParentDependency.ParentStructure, tc));
                        combination.ParentDependency.ParentStructure.RemoveTestCase(tc);
                }
            }

            return ce;
        }

        public IUndoableEdit UnMergeCombinations(EquivalenceClass selectedEquivalenceClass)
        {
        
            if (combination.Origin != CombinationOrigin.PERMUTATION) throw new InvalidOperationException("The Unmerge is available only for combinations generated by permutation");

            if (!combination.GetChildrenCombinationEquivalenceClasses().Contains(selectedEquivalenceClass))
                throw new ArgumentException("The combination does not contain any child combination containing this equivalence class");
            if (combination.EquivalenceClasses.Contains(selectedEquivalenceClass))
                throw new ArgumentException("The combination contains this equivalence class and cannot be separated");

            CompoundEdit ce = new CompoundEdit();
            //1-get all the combinations involved 
            ISet<Combination> allCombinations = new HashedSet<Combination>(combination.Combinations);
            allCombinations.Add(combination);
            //2-get all the combinations involved that directly contains the equivalence class
            ISet<Combination> eqCombinations = new HashedSet<Combination>();
            foreach (Combination eqCombination in allCombinations)
            {
                if (eqCombination.EquivalenceClasses.Contains(selectedEquivalenceClass))
                    eqCombinations.Add(eqCombination);
            }
            //3 remove any hierarchy 
            foreach (Combination allCombination in allCombinations)
            {
                if (allCombination.ParentCombination!=null)
                {
                    ce.AddEdit(
                        EditFactory.instance.CreateRemoveCombinationEdit(allCombination.ParentCombination,
                                                                         allCombination));
                    allCombination.ParentCombination.RemoveCombination(allCombination);
                }
            }
            //4 - merge the combinations that don't contain the equivalence class using the original root combination
            if (allCombinations.Minus(eqCombinations).Count>0)
                ce.AddEdit(MergeCombinations(new List<Combination>(allCombinations.Minus(eqCombinations))));
            //5- merge the combinations that contains the equivalence class using the first combination in the set
            if (eqCombinations.Count > 1)
            {   
                CombinationManager cm = new CombinationManager(FindRootCombination(eqCombinations));
                ce.AddEdit(cm.MergeCombinations(new List<Combination>(eqCombinations)));
            }

            
            return ce;
        }

        private static Combination FindRootCombination(IEnumerable<Combination> combinations)
        {
            HashedSet<EquivalenceClass> equivalenceClasses = new HashedSet<EquivalenceClass>();
            foreach (Combination combination in combinations)
            {
                equivalenceClasses.AddAll(combination.GetAllEquivalenceClasses());
            }

            foreach (Combination combination1 in combinations)
            {
                CombinationManager cm = new CombinationManager(combination1);
                foreach (EquivalenceClass equivalenceClass in equivalenceClasses)
                {
                    if (cm.FindMergeableCombinations(equivalenceClass).Count > 0)
                        return combination1;
                }
            }
            return null;
        }

        private IUndoableEdit MergeEffects(IList<Combination> combinationsToMerge)
        {
            CompoundEdit ce  = new CompoundEdit();
            foreach (Combination combi in combinationsToMerge)
            {
                foreach (Effect effect in combi.Effects)
                {
                    if (!combination.Effects.Contains(effect))
                    {
                        ce.AddEdit(EditFactory.instance.CreateAddEffectEdit(combination, effect));
                        combination.AddEffect(effect);
                    }
                }
            }
            foreach (Combination combi in combinationsToMerge)
            {
                foreach (Effect effect in combi.Effects)
                {
                    if (!combi.Effects.Contains(effect))
                    {
                        ce.AddEdit(EditFactory.instance.CreateAddEffectEdit(combi, effect));
                        combi.AddEffect(effect);
                    }
                    //update risk level
                    RiskLevelManager rlm = new RiskLevelManager(effect);
                    ce.AddEdit(rlm.ApplyRiskLevelToChildren());
                    //update state
                    StateObjectManager som = new StateObjectManager(effect);
                    ce.AddEdit(som.ApplyStateToChildren());
                }
            }
            return ce;
        }

        public IList<Combination> FindMergeableCombinations(EquivalenceClass selectedEquivalenceClass)
        {
            IList<Combination> mergeCombinations = new List<Combination>();
            //build the pattern to be merged
            IList<EquivalenceClass> mergePattern = BuildMergePattern(combination, selectedEquivalenceClass);     
            //Check what combinations can be merged with this pattern
            foreach (Combination combi in combination.ParentDependency.Combinations) {
          if (combi != combination && combi.ParentCombination==null) { 
              if (CanMergeCombination(combi, mergePattern)) {
        	  			mergeCombinations.Add(combi);
              }
          }
       }
       return mergeCombinations;
      }
      // true if the combination can be merged with the merging pattern passed as parameter
      private bool CanMergeCombination(Combination combi, ICollection<EquivalenceClass> mergePattern) {
          //rule 1 the combination can be merged if the combination contains at least one equivalence class per element of the list
          ISet<Element> patternElements = new HashedSet<Element>();
          foreach (EquivalenceClass equivalenceClass in mergePattern)
          {
              if (!patternElements.Contains(equivalenceClass.ParentElement))
                  patternElements.Add(equivalenceClass.ParentElement);
          }
          foreach (EquivalenceClass equivalenceClass in mergePattern)
          {
              if (combi.GetAllEquivalenceClasses().Contains(equivalenceClass))              
                  patternElements.Remove(equivalenceClass.ParentElement);              
          }
          //the combination does not contain at least one equiv per element
          if (patternElements.Count > 0)
              return false;
        // if one of the equivalence class is not in the combiation or children then no
          foreach (EquivalenceClass equivalenceClass in combi.GetAllEquivalenceClasses())
          {
              if (!mergePattern.Contains(equivalenceClass))
                  return false;
          }
      
          return true;
  	}
      
        private static IList<EquivalenceClass> BuildMergePattern(Combination p_combination, EquivalenceClass p_equivalenceClass)
        {
             List<EquivalenceClass> mergePattern = new List<EquivalenceClass>();
            mergePattern.Add(p_equivalenceClass);

            Element parentElement = p_equivalenceClass.ParentElement;
			//add all equivalence classes from the combination (that are does not have the same parent element)
			foreach (EquivalenceClass eClass in p_combination.EquivalenceClasses) {
           
				if( eClass.ParentElement != parentElement 
						&& ! mergePattern.Contains(eClass)) {
					    mergePattern.Add(eClass);
				}
			}
            //look also in the children combinations recursively
            foreach (Combination childCombination in p_combination.Combinations) {
    	        IList<EquivalenceClass> partOfMergePattern = BuildMergePattern(childCombination, p_equivalenceClass);
                 //add those equivalence classes to the pattern   
                foreach (EquivalenceClass equivalenceClass in partOfMergePattern) {
                    if (!mergePattern.Contains(equivalenceClass))
                        mergePattern.Add(equivalenceClass);
                    }
            }
        return mergePattern;
        }
    }
}