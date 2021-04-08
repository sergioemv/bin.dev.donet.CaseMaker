//Author : Sergio Moreno
//Business Innovations

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Iesi.Collections.Generic;
using NHibernate.Classic;

namespace CaseMaker.Entities.Testcases
{
    public enum TestCaseOrigin
    {
        [Description("Generated")]
        GENERATED,
        [Description("Manual")]
        MANUAL
    }
    public class TestCase : EntityWithEvents, IEquatable<TestCase>, IComparable<TestCase>, IEquivalenceClassesBean, ICombinationsBean, IRiskLevelObject, IStateObject
    {
        private int id;
        private int position;
        private string description;
        private TestCasesStructure parentStructure;
        private State currentState = State.POSITIVE;
        private int riskLevel;
        private IList<Combination> combinations;
        private IList<EquivalenceClass> equivalenceClasses;
        private StdCombination assignedStdCombination;
        private const string NAME_PREFIX = "T";
        private TestCaseOrigin origin = TestCaseOrigin.GENERATED;

        public TestCase(TestCasesStructure structure)
        {
            if (structure == null) return;
            structure.AddTestCase(this);
            position = structure.GetNewTestCasePosition();
        }

        public TestCase()
        {
        }
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual TestCasesStructure ParentStructure
        {
            get { return parentStructure; }
            set { parentStructure = value; }
        }

        #region IStateObject Members

        public virtual State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public ISet<IStateObject> GetParentObjectStates()
        {
            ISet<IStateObject> list = new HashedSet<IStateObject>();
            foreach (Combination combination in Combinations)
            {
                list.Add(combination);
            }
            foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
            {
                list.Add(equivalenceClass);
            }
            
            return list;

        }

        public ISet<IStateObject> GetChildrenObjectStates()
        {
            return null;
        }

        #endregion

        public virtual int RiskLevel
        {
            get { return riskLevel; }
            set { riskLevel = value; }
        }

        public virtual ISet<IRiskLevelObject> GetParentRiskLevels()
        {
            HashedSet<IRiskLevelObject> list = new HashedSet<IRiskLevelObject>();
            foreach (Combination combination in Combinations)
            {
                list.Add(combination);
            }
            foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
            {
                list.Add(equivalenceClass);
            }
            
            return list;
        }

        public virtual ISet<IRiskLevelObject> GetChildrenRiskLevels()
        {
            return null;
        }

        #region ICombinationsBean Members

        public virtual IList<Combination> Combinations
        {
            get
            {
                if (combinations == null)
                    combinations = new List<Combination>();
                return combinations;
            }
            set { combinations = value; }
        }

        public void AddCombination(Combination combination)
        {
            if (combination==null||Combinations.Contains(combination)) return;
            Combinations.Add(combination);
            OnChanged(new CMEntitiesEventArgs("Combinations",null,combination));
        }

       
        public void RemoveCombination(Combination combination)
        {
            if (combination==null||!Combinations.Contains(combination)) return;
            Combinations.Remove(combination);
            OnChanged(new CMEntitiesEventArgs("Combinations",combination,null));
        }

        #endregion

        #region IEquivalenceClassesBean Members
        public virtual IList<EquivalenceClass> EquivalenceClasses
        {
            get
            {
                if (equivalenceClasses == null)
                    equivalenceClasses = new List<EquivalenceClass>();
                return equivalenceClasses;
            }
            set { equivalenceClasses = value; }
        }

        public void AddEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (equivalenceClass == null || EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Add(equivalenceClass);
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses",null,equivalenceClass));
        }

        public void RemoveEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (equivalenceClass == null || !EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Remove(equivalenceClass);
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses", equivalenceClass,null));
        }

        #endregion

        #region IEquatable<TestCase> Members

        public bool Equals(TestCase other)
        {
            if (other == null) return false;
            if (other.ParentStructure != ParentStructure) return false;
            if  (Id>0 && other.Id>0) return Id.Equals(other.Id);
            return UniqueId.Equals(other.UniqueId);
        }

        #endregion

        #region IComparable<TestCase> Members

        public int CompareTo(TestCase other)
        {
            if (other == null) return -1;
            if (other.ParentStructure != ParentStructure) return other.ParentStructure.CompareTo(ParentStructure);
            if (other.CurrentState != CurrentState) return CurrentState.CompareTo(other.CurrentState);
            return Position.CompareTo(other.Position);
        }

        #endregion

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        private string Name
        {
            get { return NAME_PREFIX + Position; }
        }

        public virtual TestCaseOrigin Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public virtual int Position
        {
            get { return position; }
            set { position = value; }
        }

        public virtual StdCombination AssignedStdCombination
        {
            get { return assignedStdCombination; }
            set { assignedStdCombination = value; }
        }

        public virtual IList<Dependency> Dependencies
        {
            get
            {
                List<Dependency> deps = new List<Dependency>();
                foreach (Combination combination in Combinations)
                {
                    if (!deps.Contains(combination.ParentDependency))
                        deps.Add(combination.ParentDependency);
                }
                return deps;
            }
        }
        //Gets all the equivalence classes asigned to this test case including combinations and std combinations and equivalence classes
        public virtual IList<EquivalenceClass> GetAllEquivalenceClasses()
        {
            List<EquivalenceClass> eqs = new List<EquivalenceClass>(EquivalenceClasses);
            foreach (Combination combination in Combinations)
            {
                eqs.AddRange(combination.GetAllEquivalenceClasses());
            }
            
            if (AssignedStdCombination!=null)
                eqs.AddRange(AssignedStdCombination.EquivalenceClasses);
            return eqs;
        }
        public override void Validate()
        {
            //check null structure
            if (ParentStructure == null) return;
               
            //check duplicate names 
            foreach (TestCase tc in ParentStructure.TestCases)
                if (!tc.Equals(this) &&
                    tc.Position.Equals(Position))
                    throw new ValidationFailure("Test Case position repeated ("+Position+")");
        }
        //returns all the related elements to this test case
        public virtual IList<Element> GetAllElements()
        {
            List<Element> elems = new List<Element>();
            foreach (EquivalenceClass equivalenceClass in GetAllEquivalenceClasses())
            {
                if (!elems.Contains(equivalenceClass.ParentElement))
                    elems.Add(equivalenceClass.ParentElement);
            }
            return elems;
        }
        //If the test case has the same combinations and equivalence classes
        public virtual  bool EqualsByRelations(TestCase tc)
        {
            foreach (EquivalenceClass equivalenceClass in tc.EquivalenceClasses)
            {
                if (!EquivalenceClasses.Contains(equivalenceClass))
                    return false;
            }
            
            foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
            {
                if (!tc.EquivalenceClasses.Contains(equivalenceClass))
                    return false;
            }

            foreach (Combination combi in tc.Combinations)
            {
                if (!Combinations.Contains(combi))
                    return false;
            }

            foreach (Combination combi in Combinations)
            {
                if (!tc.Combinations.Contains(combi))
                    return false;
            }

            return true;
        }

        public virtual string GeneratedDescription
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                if (AssignedStdCombination != null)
                {
                    builder.Append("[");
                    builder.Append(AssignedStdCombination.Name);
                    builder.Append(":");
                    builder.Append(AssignedStdCombination.GeneratedDescription);
                    builder.Append("]");
                    builder.Append("\n AND ");
                }
                foreach (Combination combination in Combinations)
                {
                    builder.Append("[");
                    builder.Append(combination.FullName);
                    builder.Append(":");
                    builder.Append(combination.GeneratedDescription);
                    builder.Append("]");
                    builder.Append("\n AND ");
                }
                
            
                foreach (Element element in GetElements())
                {
                    builder.Append("(");
                    foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
                    {
                        if (element.EquivalenceClasses.Contains(equivalenceClass))
                        {
                            builder.Append(element.Name);
                            builder.Append("=");
                            builder.Append("'");
                            builder.Append(equivalenceClass.Value);
                            builder.Append("'");
                            builder.Append(" OR ");
                        }

                    }
                    builder.Remove(builder.Length - 4, 4);
                    builder.Append(")");
                    builder.Append("\n AND ");
                }
                if (builder.ToString().EndsWith("AND "))
                    builder.Remove(builder.Length - 6, 6);


                return builder.ToString();
            }
        }

        public virtual ISet<Element> GetElements()
        {
            HashedSet<Element> elems = new HashedSet<Element>();
            foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
            {
                    elems.Add(equivalenceClass.ParentElement);
            }
            return elems;
        }
    }
}