using System;
using System.Collections;
using System.Collections.Generic;
using CaseMaker.Entities.Administration;
using CaseMaker.Entities.Utils;
using Iesi.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public class TestCasesStructure:EntityWithEvents, IStdCombinationsBean, ITestCasesBean, IDependencyBean, IRequirementsBean, IEffectsBean, IElementsBean, IEquatable<TestCasesStructure>,IComparable<TestCasesStructure>, IAuditable
    {
        private TestObject parentTestObject;
        private int id;
        private DateTime creationDate;
        private DateTime modDate;
        private IList<Element> elements;
        private IList<Effect> effects;
        private IList<Requirement> requirements;
        private IList<Dependency> dependencies;
        private IList<TestCase> testCases;
        private IList<StdCombination> stdCombinations;
        private ISet<TestCasesStructurePermission> permissions;
        
        public virtual TestObject ParentTestObject
        {
            get
            {
                return parentTestObject;
            }
            set
            {
                parentTestObject = value;
                Id = parentTestObject.Id;
            }
        }

        #region IElementsBean Members
        public virtual IList<Element> Elements
        {
            get
            {
                if (elements == null)
                    elements = new List<Element>();
                return elements;
            }
            set { elements = value; }
        }

        public virtual void AddElement(Element element)
        {
            if (element == null || Elements.Contains(element)) return;
            // if the name of the element is null generate a new one

            Elements.Add(element);
            element.Structure = this;

            OnChanged(new CMEntitiesEventArgs("Elements", null, element));
        }
        public virtual void RemoveElement(Element element)
        {
            if (!Elements.Contains(element)) return;
            Elements.Remove(element);
            element.Structure = null;
            OnChanged(new CMEntitiesEventArgs("Elements", element, null));
        }

        public virtual Element GetElementByName(string name)
        {
            foreach (Element elem in Elements)
            {
                if (elem.Name.Equals(name)) return elem;
            }
            return null;
        }

        #endregion

        #region IEffectsBean Members

        public virtual IList<Effect> Effects
        {
            get
            {
                if (effects == null)
                    effects = new List<Effect>();
                return effects;
            }
            set { effects = value; }
        }

        public void AddEffect(Effect effect)
        {
            if (Effects.Contains(effect) || effect==null) return;
            Effects.Add(effect);
            effect.ParentStructure = this;
            OnChanged(new CMEntitiesEventArgs("Effects",null,effect));
        }
        
        public void RemoveEffect(Effect effect)
        {
            if (!Effects.Contains(effect) || effect == null) return;
            Effects.Remove(effect);
            effect.ParentStructure = null;
            OnChanged(new CMEntitiesEventArgs("Effects",effect,null));
        }

        #endregion

        #region IRequirementsBean Members
        public virtual IList<Requirement> Requirements
        {
            get
            {
                if (requirements == null)
                    requirements = new List<Requirement>();
                return requirements;
            }
            set { requirements = value; }
        }
        public virtual void AddRequirement(Requirement req)
        {
            if (Requirements.Contains(req) || req ==null) return;

            Requirements.Add(req);
            req.ParentStructure = this;
            OnChanged(new CMEntitiesEventArgs("Requirements",null,req));
        }

        public virtual void RemoveRequirement(Requirement req)
        {
           if (req == null || !Requirements.Contains(req)) return;
            Requirements.Remove(req);
            req.ParentStructure = null;
            OnChanged(new CMEntitiesEventArgs("Requirements",req,null));
        }

        #endregion

        #region IDependencyBean Members
        
        public virtual IList<Dependency> Dependencies
        {
            get
            {
                if (dependencies == null)
                    dependencies = new List<Dependency>();
                return dependencies;
            }
            set { dependencies = value; }
        }

        public void AddDependency(Dependency dep)
        {
            if (dep==null||Dependencies.Contains(dep)) return;

            Dependencies.Add(dep);
            dep.ParentStructure = this;
            OnChanged( new CMEntitiesEventArgs("Dependencies",null,dep));
        }

        public void RemoveDependency(Dependency dep)
        {
            if (dep==null||!Dependencies.Contains(dep)) return;
            Dependencies.Remove(dep);
            dep.ParentStructure = null;
            OnChanged( new CMEntitiesEventArgs("Dependencies",dep,null));
        }

        #endregion

        #region ITestCasesBean Members
        public virtual IList<TestCase> TestCases
        {
            get
            {
                if (testCases == null)
                    testCases = new List<TestCase>(); 
                return testCases;
            }
            set { testCases = value; }
        }

        public void AddTestCase(TestCase testCase)
        {
            if (testCase==null || TestCases.Contains(testCase)) return;
            TestCases.Add(testCase);
            testCase.ParentStructure = this;
            OnChanged(new CMEntitiesEventArgs("TestCases", null, testCase));
        }
        public void RemoveTestCase(TestCase testCase)
        {
           if (testCase==null|| !TestCases.Contains(testCase)) return;
            TestCases.Remove(testCase);
            testCase.ParentStructure = null;
            OnChanged(new CMEntitiesEventArgs("TestCases", testCase, null));
        }

        #endregion

        public virtual int Id
        {
            get
            {
                if (ParentTestObject != null)
                    id = parentTestObject.Id;
                return id;
            }
            set { id = value; }
        }

        public virtual DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public virtual DateTime ModDate
        {
            get { return modDate; }
            set { modDate = value; }
        }


        # region permissions
        public virtual ISet<TestCasesStructurePermission> Permissions
        {
            get
            {
                if (permissions == null)
                    permissions = new HashedSet<TestCasesStructurePermission>();
                return permissions;
            }
            set { permissions = value; }
        }
        public virtual void AddPermission(TestCasesStructurePermission perm)
        {
            if (Permissions.Contains(perm)) return;
            Permissions.Add(perm);
            perm.Structure = this;
            OnChanged(new CMEntitiesEventArgs("Permissions",null,perm));
        }

        public virtual void RemovePermission(TestCasesStructurePermission perm)
        {
            if (!Permissions.Contains(perm)) return;
            Permissions.Remove(perm);
            perm.Structure = null;
            OnChanged(new CMEntitiesEventArgs("Permissions",perm,null));
        }
        #endregion

        #region IStdCombinationsBean Members
        public IList<StdCombination> StdCombinations
        {
            get
            {
                if (stdCombinations == null)
                    stdCombinations = new List<StdCombination>();
                return stdCombinations;
            }
            set { stdCombinations = value; }
        }
        public void AddStdCombination(StdCombination stdCombination)
        {
            if (stdCombination == null || StdCombinations.Contains(stdCombination)) return;
            StdCombinations.Add(stdCombination);
            stdCombination.ParentStructure = this;
            OnChanged(new CMEntitiesEventArgs("StdCombinations",null,stdCombination));
        }
        public void RemoveStdCombination(StdCombination stdCombination)
        {
            if (stdCombination == null || !StdCombinations.Contains(stdCombination)) return;
            StdCombinations.Remove(stdCombination);
            stdCombination.ParentStructure = null;
            OnChanged(new CMEntitiesEventArgs("StdCombinations", stdCombination,null));
        }

        #endregion

        public virtual int GetNewElementPosition()
        {
            IdSet set = new IdSet();
            foreach (Element element1 in Elements)
            {
                set.registerId(element1.Position);
            }
            return set.NextValidId();
        }

        public virtual string GetNewElementName()
        {
            EntityNamer namer = new EntityNamer((IList)Elements, "Element");
            return namer.GenerateName(); 
        }

        public virtual int GetNewEffectPosition()
        {
            IdSet set = new IdSet();
            foreach (Effect effect in effects)
            {
                set.registerId(effect.Position);
            }
            return set.NextValidId();
        }

        public virtual int GetNewTestCasePosition()
        {
            IdSet set = new IdSet();
            foreach (TestCase testCase in TestCases)
            {
                set.registerId(testCase.Position);
            }
            return set.NextValidId();
        }

        #region IEquatable<TestCasesStructure> Members

        public bool Equals(TestCasesStructure other)
        {
            if (other==null) return false;
            return ParentTestObject.Equals(other.ParentTestObject);
        }

        #endregion

        #region IComparable<TestCasesStructure> Members

        public int CompareTo(TestCasesStructure other)
        {
            throw new NotImplementedException();
        }

        #endregion
        
        public override int GetHashCode()
        {
            return ParentTestObject.GetHashCode();
        }

        public override string ToString()
        {
            if (ParentTestObject != null)
                return ParentTestObject.Name;
            else
                return "";
        }


        public virtual int GetNewDependencyPosition()
        {
            IdSet set = new IdSet();
            foreach (Dependency dep in Dependencies)
            {
                set.registerId(dep.Position);
            }
            return set.NextValidId();
        }

        public virtual int GetNewStdCombinationPosition()
        {
            IdSet set = new IdSet();
            foreach (StdCombination std in StdCombinations)
            {
                set.registerId(std.Position);
            }
            return set.NextValidId();
        }

        public virtual IList<TestCase> GetTestCases(State state)
        {
            List<TestCase> stateTestCases = new List<TestCase>();
            foreach (TestCase testCase in testCases)
            {
                if (testCase.CurrentState==state)
                    stateTestCases.Add(testCase);
            }
            return stateTestCases;
        }
        //TODO Check this method
        public virtual bool ContainsSameTestCaseByRelations(TestCase tc)
        {
            foreach (TestCase testCase in testCases)
            {
                if (testCase.EqualsByRelations(tc))
                    return true;
            }
            return false;
        }

        
    }
}
