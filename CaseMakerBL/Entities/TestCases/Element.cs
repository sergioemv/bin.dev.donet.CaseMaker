using System;
using System.Collections;
using System.Collections.Generic;
using CaseMaker.Entities.Utils;
using NHibernate.Classic;

namespace CaseMaker.Entities.Testcases
{
    public class Element : EntityWithEvents, IEquatable<Element>, IComparable<Element>, IEquivalenceClassesBean
    {

        private int id;
        private string name = "";
        private string description;
        private int position=-1;
        private TestCasesStructure structure;
        private IList<EquivalenceClass> equivalenceClasses;
        public Element()
        {
        }
        public Element(IElementsBean parent)
        {
            if (parent==null) return;
            parent.AddElement(this);
            if (parent is TestCasesStructure)
            {
                position = (parent as TestCasesStructure).GetNewElementPosition();
                name = (parent as TestCasesStructure).GetNewElementName();
            }

        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public virtual string Name
        {
            get { return name; }
            set
            {
                
                string oldValue = name;
                name = value;
                OnChanged(new CMEntitiesEventArgs("Name",oldValue,value));
            }
        }

        public virtual string Description
        {
            get { return description; }
            set
            {
                string oldValue = description;
                description = value;
                OnChanged(new CMEntitiesEventArgs("Description",oldValue,value));
            }
        }

        public virtual int Position
        {
            get
            {
                return position;
            }
            set
            {
                if (position==value) return;
                
                int oldValue = position;
                position = value;
                OnChanged(new CMEntitiesEventArgs("Position", oldValue,value));
            }
        }

        public virtual TestCasesStructure Structure
        {
            get { return structure; }
            set { structure = value; }
        }

        public virtual int GetNewEquivalenceClassPosition()
        {
            IdSet set = new IdSet();
            foreach (EquivalenceClass element1 in EquivalenceClasses)
            {
                set.registerId(element1.Position);
            }
            return set.NextValidId();
        }

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
            if (EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Add(equivalenceClass);
            equivalenceClass.ParentElement = this;
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses",null,equivalenceClass));
        }

        public void RemoveEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (!EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Remove(equivalenceClass);
            equivalenceClass.ParentElement = null;
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses", equivalenceClass, null));
        }

        #endregion

        #region IEquatable<Element> Members

        public bool Equals(Element other)
        {
            if (other == null) return false;
            if (Structure!=other.Structure)
                return false;
            if (Id>0)
                return Id.Equals(other.Id);
            return UniqueId.Equals(other.UniqueId);
        }

        #endregion

        #region IComparable<Element> Members

        public int CompareTo(Element other)
        {
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

        public override void Validate()
        {
            //check null structure
            if (Structure == null) return;
               
            //check duplicate names 
            foreach (Element elem in Structure.Elements)
                if (!elem.Equals(this) &&
                    elem.Name.Equals(Name))
                    throw new ValidationFailure("Element Name Cannot be duplicated");
        }

        public virtual IList<EquivalenceClass> GetEquivalenceClassesbyState(State state)
        {
            List<EquivalenceClass> eqClasses = new List<EquivalenceClass>();
            foreach (EquivalenceClass eqClass in equivalenceClasses)
            {
                if (eqClass.CurrentState == state )
                    eqClasses.Add(eqClass);
            }
            return eqClasses;
        }
    }
}