// Author Sergio Moreno
// a Factory for edits 

using System;
using System.Reflection;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Edits
{
    
    public class EditFactory:IEditFactory
    {
        public readonly static IEditFactory instance = new EditFactory();
        public IUndoableEdit CreateChangePropertyEdit(object owner,string  property, object value)
        {
            //get the original value
            Type type = owner.GetType();
            PropertyInfo pinfo = type.GetProperty(property);
            object oldvalue = pinfo.GetValue(owner, null);
            DefaultEdit<object> pe = new DefaultEdit<object>(owner,ChangeProperty,ChangeProperty);
            pe.UndoParams = new PropertyEditParameters(property, oldvalue);
            pe.RedoParams = new PropertyEditParameters(property, value);
            return pe;
        }

        public IUndoableEdit CreateAddObjectEdit(object owner, object related)
        {
             return new DefaultEdit<object>(owner, AddObject, RemoveObject,related);
        }

       
        public IUndoableEdit CreateRemoveObjectEdit(object owner, object related)
        {
            return new DefaultEdit<object>(owner, RemoveObject, AddObject, related);
            
        }

        public IUndoableEdit CreateAddElementEdit(IElementsBean owner, Element element)
        {
            return new DefaultEdit<IElementsBean>(owner,AddElement,RemoveElement,element);
        }


        public IUndoableEdit CreateRemoveElementEdit(IElementsBean owner, Element element)
        {
            return new DefaultEdit<IElementsBean>(owner, RemoveElement, AddElement,element);
        }

        public IUndoableEdit CreateAddEquivalenceClassEdit(IEquivalenceClassesBean owner,
                                                           EquivalenceClass equivalenceClass)
        {
            return new DefaultEdit<IEquivalenceClassesBean>(owner, AddEquivalenceClass, RemoveEquivalenceClass,equivalenceClass);
        }

        public IUndoableEdit CreateRemoveEquivalenceClassEdit(IEquivalenceClassesBean owner,
                                                              EquivalenceClass equivalenceClass)
        {
            return new DefaultEdit<IEquivalenceClassesBean>(owner, RemoveEquivalenceClass, AddEquivalenceClass,equivalenceClass);
            
        }

        public IUndoableEdit CreateAddEffectEdit(IEffectsBean owner, Effect effect)
        {
            return new DefaultEdit<IEffectsBean>(owner, AddEffect, RemoveEffect, effect);
            
        }

        public IUndoableEdit CreateRemoveEffectEdit(IEffectsBean owner, Effect effect)
        {
            return new DefaultEdit<IEffectsBean>(owner, RemoveEffect, AddEffect, effect);
        }

        public IUndoableEdit CreateAddRequirementEdit(IRequirementsBean owner, Requirement req)
        {
            return new DefaultEdit<IRequirementsBean>(owner, AddRequirement, RemoveRequirement, req);
        }

        public IUndoableEdit CreateRemoveRequirementEdit(IRequirementsBean owner, Requirement req)
        {
            return new DefaultEdit<IRequirementsBean>(owner, RemoveRequirement, AddRequirement, req);
        }

        public IUndoableEdit CreateAddExpectedResultEdit(Effect owner, ExpectedResult res)
        {
            return new DefaultEdit<Effect>(owner, AddExpectedResult, RemoveExpectedResult, res);
        }

        public IUndoableEdit CreateRemoveExpectedResultEdit(Effect owner, ExpectedResult res)
        {
            return new DefaultEdit<Effect>(owner, RemoveExpectedResult,AddExpectedResult, res);
        }

        public IUndoableEdit CreateAddDependencyEdit(IDependencyBean owner, Dependency dep)
        {
            return new DefaultEdit<IDependencyBean>(owner, AddDependency, RemoveDependency, dep);
        }

        public IUndoableEdit CreateRemoveDependencyEdit(IDependencyBean owner, Dependency dep)
        {
            return new DefaultEdit<IDependencyBean>(owner, RemoveDependency, AddDependency, dep);
        }

        public IUndoableEdit CreateAddCombinationEdit(ICombinationsBean owner, Combination combi)
        {
            return new DefaultEdit<ICombinationsBean>(owner, AddCombination, RemoveCombination, combi);
        }

        public IUndoableEdit CreateRemoveCombinationEdit(ICombinationsBean owner, Combination combi)
        {
            return new DefaultEdit<ICombinationsBean>(owner, RemoveCombination, AddCombination, combi);
        }

        public IUndoableEdit CreateAddTestCaseEdit(ITestCasesBean owner, TestCase testCase)
        {
            return new DefaultEdit<ITestCasesBean>(owner, AddTestCase, RemoveTestCase, testCase);
        }

        public IUndoableEdit CreateRemoveTestCaseEdit(ITestCasesBean owner, TestCase testCase)
        {
            return new DefaultEdit<ITestCasesBean>(owner, RemoveTestCase, AddTestCase, testCase);
        }

        public IUndoableEdit CreateAddStdCombinationEdit(IStdCombinationsBean owner, StdCombination combi)
        {
            return new DefaultEdit<IStdCombinationsBean>(owner, AddStdCombination, RemoveStdCombination, combi);
        }

        public IUndoableEdit CreateRemoveStdCombinationEdit(IStdCombinationsBean owner, StdCombination combi)
        {
            return new DefaultEdit<IStdCombinationsBean>(owner, RemoveStdCombination, AddStdCombination, combi);
        }

        public IUndoableEdit CreateChangeRiskLevelEdit(IRiskLevelObject riskLevelObject, int riskLevel)
        {
            DefaultEdit<object> pe = new DefaultEdit<object>(riskLevelObject,ChangeRiskLevel,ChangeRiskLevel);
            pe.UndoParams = new PropertyEditParameters("", riskLevelObject.RiskLevel);
            pe.RedoParams = new PropertyEditParameters("", riskLevel);
            return pe;
        }



        public IUndoableEdit CreateChangeStateEdit(IStateObject stateObject, State state)
        {
            DefaultEdit<object> pe = new DefaultEdit<object>(stateObject, ChangeState, ChangeState);
            pe.UndoParams = new PropertyEditParameters("", stateObject.CurrentState);
            pe.RedoParams = new PropertyEditParameters("", state);
            return pe;

        }

    

        #region Utility static reflexive methods 
        private static void ChangeProperty(object receiver, DefaultEditParams editParams)
        {
            PropertyEditParameters dep = editParams as PropertyEditParameters;
            if (dep == null) return;
            Type type = receiver.GetType();
            PropertyInfo pinfo = type.GetProperty(dep.PropertyName);
            pinfo.SetValue(receiver,dep.Value,null);
        }
        private static void RemoveObject(object receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            // the method works only if the relation of the related is defined by a method called "Remove[related.Type]"
            Type type = receiver.GetType();
            Type relatedType = rep.Related.GetType();
            MethodInfo minfo = type.GetMethod("Remove" + relatedType.Name);
            if (minfo == null) return;
            object[] param = new object[1];
            param[0] = rep.Related;
            minfo.Invoke(receiver, param);
        }

        private static void AddObject(object receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;           
            if (rep ==null) return;
            // the method works only if the relation of the related is defined by a method called "Add[related.Type]"
            Type type = receiver.GetType();
            Type relatedType = rep.Related.GetType();
            MethodInfo minfo = type.GetMethod("Add" + relatedType.Name);
            if (minfo==null) return;
            object[] param = new object[1];
            param[0] = rep.Related;
            minfo.Invoke(receiver,param);
        }

        #endregion

        #region Test Cases utility static specific methods
        private static void AddElement(IElementsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddElement((Element) rep.Related);
        }
        private static void RemoveElement(IElementsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveElement((Element)rep.Related);
        }

        private static void AddEquivalenceClass(IEquivalenceClassesBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddEquivalenceClass((EquivalenceClass)rep.Related);
        }
        private static void RemoveEquivalenceClass(IEquivalenceClassesBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveEquivalenceClass((EquivalenceClass)rep.Related);
        }

        private static void AddEffect(IEffectsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddEffect((Effect)rep.Related);
        }
        private static void RemoveEffect(IEffectsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveEffect((Effect)rep.Related);
        }

        private static void AddRequirement(IRequirementsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddRequirement((Requirement)rep.Related);
        }
        private static void RemoveRequirement(IRequirementsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveRequirement((Requirement)rep.Related);
        }

        private static void AddExpectedResult(Effect receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddExpectedResult((ExpectedResult)rep.Related);
        }
        private static void RemoveExpectedResult(Effect receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveExpectedResult((ExpectedResult)rep.Related);
        }
        
        private static void AddDependency(IDependencyBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddDependency((Dependency)rep.Related);
        }
        private static void RemoveDependency(IDependencyBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveDependency((Dependency)rep.Related);
        }

        private static void AddCombination(ICombinationsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddCombination((Combination)rep.Related);
        }
        private static void RemoveCombination(ICombinationsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveCombination((Combination)rep.Related);
        }

        private static void AddTestCase(ITestCasesBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddTestCase((TestCase)rep.Related);
        }
        private static void RemoveTestCase(ITestCasesBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveTestCase((TestCase)rep.Related);
        }

        private static void AddStdCombination(IStdCombinationsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.AddStdCombination((StdCombination)rep.Related);
        }
        private static void RemoveStdCombination(IStdCombinationsBean receiver, DefaultEditParams editParams)
        {
            RelationEditParameters rep = editParams as RelationEditParameters;
            if (rep == null) return;
            receiver.RemoveStdCombination((StdCombination)rep.Related);
        }

        private static void ChangeState(object receiver, DefaultEditParams editParams)
        {
            PropertyEditParameters parm = editParams as PropertyEditParameters;
            if (parm != null)
                ((IStateObject)receiver).CurrentState = (State)parm.Value;
        }


        private static void ChangeRiskLevel(Object receiver, DefaultEditParams editParams)
        {
            PropertyEditParameters parm = editParams as PropertyEditParameters;
            if (parm != null)
                ((IRiskLevelObject)receiver).RiskLevel = (int)parm.Value;

        }
        #endregion
    }

    
}