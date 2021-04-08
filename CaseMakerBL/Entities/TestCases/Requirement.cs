//Author : Sergio Moreno
//Business Innovations

using System;

namespace CaseMaker.Entities.Testcases
{
    public class Requirement : EntityWithEvents, IEquatable<Requirement>, IComparable<Requirement>
    {
        private int id;
        private string name;
        private TestCasesStructure parentStructure;
       
        public Requirement(){}

        public Requirement(IRequirementsBean bean, string name)
        {
            if (bean == null) return;
            bean.AddRequirement(this);
            this.name = name;
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual TestCasesStructure ParentStructure
        {
            get { return parentStructure; }
            set { parentStructure = value; }
        }

        #region IEquatable<Requirement> Members

        public bool Equals(Requirement other)
        {
            if (other == null) return false;
            if (other.ParentStructure != ParentStructure) return false;
            return Id.Equals(other.Id);
        }

        #endregion

        #region IComparable<Requirement> Members

        public int CompareTo(Requirement other)
        {
            if (other == null) return -1;
            return Name.CompareTo(other.Name);
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

        
    }
}
