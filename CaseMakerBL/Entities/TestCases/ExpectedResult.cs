//Author : Sergio Moreno
//Business Innovations

using System;
using NHibernate.Classic;

namespace CaseMaker.Entities.Testcases
{
    public class ExpectedResult : EntityWithEvents, IEquatable<ExpectedResult>, IComparable<ExpectedResult>
    {
        private int id;
        private string name;
        private Effect parentEffect;

        public ExpectedResult()
        {
        }

        public ExpectedResult(Effect parent)
        {
            if (parent == null) return;
            name = parent.GetNewExpectedResultName();
            parent.AddExpectedResult(this);
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

        public virtual Effect ParentEffect
        {
            get { return parentEffect; }
            set { parentEffect = value; }
        }

        #region IEquatable<ExpectedResult> Members

        public bool Equals(ExpectedResult other)
        {
            if (other == null) return false;
            if (other.ParentEffect != parentEffect) return false;
            return Id.Equals(other.Id);
        }

        #endregion

        #region IComparable<ExpectedResult> Members

        public int CompareTo(ExpectedResult other)
        {
            if (other == null) return -1;
            if (other.ParentEffect != ParentEffect) return ParentEffect.CompareTo(other.ParentEffect);
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

        public override void Validate()
        {
            if (parentEffect==null) return;

            foreach (ExpectedResult result in ParentEffect.ExpectedResults)
            {
                if (!result.Equals(this)&&result.Name.Equals(Name))
                    throw new ValidationFailure("The name of the expected result cannot be repeated"); 
            }
        }
    }
}