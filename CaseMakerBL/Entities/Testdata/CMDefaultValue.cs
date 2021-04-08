using System;

namespace CaseMaker.Entities.Testdata
{
    internal class CMDefaultValue : ICMValue
    {
        private Object value;
        private int id;

        public CMDefaultValue(Object p_value)
        {
            if (p_value is Double)
            {
            }
            if (p_value is float)
            {
            }

            if (p_value is int)
            {
            }


            if (p_value is DateTime)
            {
            }

            if (p_value is string)
            {
            }
        }

        public CMDefaultValue(string p_value)
        {
            if (p_value == null) throw new ArgumentNullException("p_value");
            throw new NotImplementedException();
        }


        public virtual object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public object clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(ICMValue other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(ICMValue other)
        {
            throw new NotImplementedException();
        }
    }
}