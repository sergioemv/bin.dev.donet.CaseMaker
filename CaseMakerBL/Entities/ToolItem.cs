using System;

namespace CaseMaker.Entities
{
    public class ToolItem : EntityWithEvents, IEquatable<ToolItem>, IComparable<ToolItem>
    {

        private int id;
        private string name;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public  virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Equals(ToolItem other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }

        public int CompareTo(ToolItem other)
        {
            if (other == null) return -1;
            return Name.CompareTo(other.Name);
        }
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