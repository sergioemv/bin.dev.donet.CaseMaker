//Author : Sergio Moreno
//Business Innovations

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections.Generic;
using NHibernate.Classic;

namespace CaseMaker.Entities.Testcases
{
    public class StdCombination : EntityWithEvents, IEquatable<StdCombination>, IComparable<StdCombination>, IEquivalenceClassesBean, ITestCasesBean
    {
        private int id;
        private int position;
        private string description;
        private const string NAME_PREFIX = "S";
        private TestCasesStructure parentStructure;
        private IList<EquivalenceClass> equivalenceClasses;
        private IList<TestCase> testCases;

        public StdCombination(TestCasesStructure structure)
        {
            if (structure == null) return;
           
            structure.AddStdCombination(this);
            position = structure.GetNewStdCombinationPosition();
        }

        public StdCombination()
        {
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual int Position
        {
            get { return position; }
            set { position = value; }
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

 
        #region IEquatable<StdCombination> Members

        public bool Equals(StdCombination other)
        {
            if (other == null) return false;
            if (other.ParentStructure!=ParentStructure) return false;
            return Id.Equals(other.Id);
        }

        #endregion

        #region IComparable<StdCombination> Members

        public int CompareTo(StdCombination other)
        {
            if (other == null) return -1;
            if (other.ParentStructure != ParentStructure) return ParentStructure.CompareTo(other.ParentStructure);
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

        public virtual string Name
        {
            get { return NAME_PREFIX + Position; }
        }

        #region IEquivalenceClassesBean Members

        public virtual  IList<EquivalenceClass> EquivalenceClasses
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
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses", null, equivalenceClass));
        }

        public void RemoveEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (equivalenceClass == null || !EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Remove(equivalenceClass);
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses", equivalenceClass, null));
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
            if (testCase == null || TestCases.Contains(testCase)) return;
            TestCases.Add(testCase);
            testCase.AssignedStdCombination = this;
            OnChanged(new CMEntitiesEventArgs("TestCases", null, testCase));
        }
        public void RemoveTestCase(TestCase testCase)
        {
            if (testCase == null || !TestCases.Contains(testCase)) return;
            TestCases.Remove(testCase);
            testCase.AssignedStdCombination = null;
            OnChanged(new CMEntitiesEventArgs("TestCases", testCase, null));
        }

        #endregion
        public override void Validate()
        {
            //check null structure
            if (ParentStructure == null) return;

            //check duplicate names 
            foreach (StdCombination st in ParentStructure.StdCombinations)
                if (!st.Equals(this) &&
                    st.Position.Equals(Position))
                    throw new ValidationFailure("Standart Combination position repeated (" + Position + ")");
        }


        public virtual string GeneratedDescription
        {
            get
            {
                StringBuilder builder = new StringBuilder();
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
                    builder.Append(" AND ");
                }
                builder.Remove(builder.Length - 5, 5);
                return builder.ToString();
            }
        }

        public virtual ISet<Element> GetElements()
        {
            HashedSet<Element> elms = new HashedSet<Element>();
            foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
            {
                elms.Add(equivalenceClass.ParentElement);
            }
            return elms;
        }
    }
}