using System;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Edits
{
    public interface IEditFactory
    {
        // generic property changer uses reflection 
        // not recommended for repeated operations (can be slower)
        IUndoableEdit CreateChangePropertyEdit(object owner, string property, object value);
        //add a new object to a multiple association
        IUndoableEdit CreateAddObjectEdit(object owner, object related);
        //remove an object from a multiple asociociation
        IUndoableEdit CreateRemoveObjectEdit(object owner, object related);

        //NON REFLEXIVE METHODS

        //add element edit
        IUndoableEdit CreateAddElementEdit(IElementsBean owner, Element element);
        //remove element edit
        IUndoableEdit CreateRemoveElementEdit(IElementsBean owner, Element element);
        //add equivelence class
        IUndoableEdit CreateAddEquivalenceClassEdit(IEquivalenceClassesBean owner, EquivalenceClass equivalenceClass);
        //remove equivalence class
        IUndoableEdit CreateRemoveEquivalenceClassEdit(IEquivalenceClassesBean owner, EquivalenceClass equivalenceClass);
        //add effect
        IUndoableEdit CreateAddEffectEdit(IEffectsBean owner, Effect effect);
        //remove effect
        IUndoableEdit CreateRemoveEffectEdit(IEffectsBean owner, Effect effect);
        //add requiremente 
        IUndoableEdit CreateAddRequirementEdit(IRequirementsBean owner, Requirement req);
        //remove requirement
        IUndoableEdit CreateRemoveRequirementEdit(IRequirementsBean owner, Requirement req);
        //add expected result
        IUndoableEdit CreateAddExpectedResultEdit(Effect owner, ExpectedResult res);
        //remove expected result
        IUndoableEdit CreateRemoveExpectedResultEdit(Effect owner, ExpectedResult res);
        //add Dependency 
        IUndoableEdit CreateAddDependencyEdit(IDependencyBean owner, Dependency dep);
        //remove Dependency
        IUndoableEdit CreateRemoveDependencyEdit(IDependencyBean owner, Dependency dep);
        //add combination
        IUndoableEdit CreateAddCombinationEdit(ICombinationsBean owner, Combination combi);
        //remove combination
        IUndoableEdit CreateRemoveCombinationEdit(ICombinationsBean owner, Combination combi);
        //add test case
        IUndoableEdit CreateAddTestCaseEdit(ITestCasesBean owner, TestCase testCase);
        //remove test case
        IUndoableEdit CreateRemoveTestCaseEdit(ITestCasesBean owner, TestCase testCase);
        //add standart combination
        IUndoableEdit CreateAddStdCombinationEdit(IStdCombinationsBean owner, StdCombination combi);
        //remove standart combination
        IUndoableEdit CreateRemoveStdCombinationEdit(IStdCombinationsBean owner, StdCombination combi);
        //change risk level value 
        IUndoableEdit CreateChangeRiskLevelEdit(IRiskLevelObject riskLevelObject, int riskLevel);
        //change state
        IUndoableEdit CreateChangeStateEdit(IStateObject stateObject, State state);
    }
}