using System;

namespace CaseMaker.Entities.Testdata
{
    public class CMLinkElement : ICMValue
    {
        private int id;

        private string linkKey = "";

        private ITestDataFormat testDataFormat = null;

        private bool isGlobal = true;

        private Object value = null;

        public CMLinkElement(string p_linkKey)
        {
            if (p_linkKey == null) throw new ArgumentNullException("p_linkKey");
            throw new NotImplementedException();
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string LinkKey
        {
            get { return linkKey; }
            set { linkKey = value; }
        }

        public ITestDataFormat TestDataFormat
        {
            get { return testDataFormat; }
            set { testDataFormat = value; }
        }

        public bool IsGlobal
        {
            get { return isGlobal; }
            set { isGlobal = value; }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
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