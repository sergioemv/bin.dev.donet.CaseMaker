//Author : Sergio Moreno
//Business Innovations

using System;
using System.Collections.Generic;
using CaseMaker.Entities.Utils;
using NHibernate.Classic;

namespace CaseMaker.Entities.Testcases
{
    public class Dependency : EntityWithEvents, ICombinationsBean, IEquatable<Dependency>, IComparable<Dependency>, IElementsBean, IEquivalenceClassesBean
    {
        private int id;
        private const string NAME_PREFIX = "D";
        private string description;
        private int position;
        private IList<Element> elements;
        private IList<EquivalenceClass> equivalenceClasses;
        private TestCasesStructure parentStructure;
        private IList<Combination> combinations;

        public Dependency(TestCasesStructure structure)
        {
            if (structure == null) return;
            structure.AddDependency(this);
            position = structure.GetNewDependencyPosition();
        }

        public Dependency()
        {
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return NAME_PREFIX + Position; }
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

        public virtual int Position
        {
            get { return position; }
            set { position = value; }
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
            Elements.Add(element);
            OnChanged(new CMEntitiesEventArgs("Elements", null, element));
        }

        public virtual void RemoveElement(Element element)
        {
            if (element == null || !Elements.Contains(element)) return;
            Elements.Remove(element);
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
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses", null, equivalenceClass));
        }



        public void RemoveEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (equivalenceClass == null || !EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Remove(equivalenceClass);
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses", equivalenceClass, null));
        }

        #endregion

        #region IEquatable<Dependency> Members

        public bool Equals(Dependency other)
        {
            if (other == null) return false;
            if (other.ParentStructure != ParentStructure) return false;
            if (Id>0 && other.Id>0) return Id.Equals(other.Id);
            return UniqueId.Equals(other.UniqueId);
        }

        #endregion

        #region IComparable<Dependency> Members

        public int CompareTo(Dependency other)
        {
            if (other == null) return -1;
            if (other.ParentStructure != ParentStructure) return ParentStructure.CompareTo(other.ParentStructure);
            return Position.CompareTo(other.Position);
        }

        #endregion

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
            if (combination == null || Combinations.Contains(combination)) return;
            Combinations.Add(combination);
            combination.ParentDependency = this;
            OnChanged(new CMEntitiesEventArgs("Combinations", null, combination));
        }

        public void RemoveCombination(Combination combination)
        {
            if (combination == null || !Combinations.Contains(combination)) return;
            Combinations.Remove(combination);
            combination.ParentDependency = null;
            OnChanged(new CMEntitiesEventArgs("Combinations", combination, null));
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

   

   

     

      

        public override void Validate()
        {
            if (ParentStructure == null) return;

            foreach (Dependency dep in ParentStructure.Dependencies)
            {
                if (!dep.Equals(this) && dep.Position.Equals(Position))
                    throw new ValidationFailure("Dependency position is repeated");
            }
        }

        public virtual int getNewCombinationPosition()
        {
            IdSet set = new IdSet();
            foreach (Combination com in Combinations)
            {
                set.registerId(com.Position);
            }
            return set.NextValidId();
        }

        public virtual List<EquivalenceClass> GetEquivalenceClasses(Element element)
        {
            List<EquivalenceClass> eqs = new List<EquivalenceClass>();
		foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
			if (element.EquivalenceClasses.Contains(equivalenceClass))
				eqs.Add(equivalenceClass);
		return eqs;
        }

        public virtual IList<Combination> GetCombinations(State state)
        {
            List<Combination> combis = new List<Combination>();
            foreach (Combination combination in Combinations)
            {
                if (combination.CurrentState.Equals(state))
                    combis.Add(combination);
            }
            return combis;
        }

        public virtual  Combination GetCombinationAt(int i, State state)
        {
            List<Combination> combins = new List<Combination>(Combinations);
           combins.Sort();
           if (i < combins.Count)
               if (combins[i].CurrentState == state)
                   return combins[i];
            return null;
            
        }
    }
}