using System;

namespace CaseMaker.Entities.Testdata
{
    public class Variable : IEquatable<Variable>, IComparable<Variable>
    {
        private int id;
        private ICMValue icmvalue;
        private string description;
        private ITestDataFormat testDataFormat;
        private string name;
        private string typeVariable;
        private TestDataStructure testDataStructure;


        public virtual ICMValue ICMValue
        {
            get { return icmvalue; }
            set { icmvalue = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual ITestDataFormat TestDataFormat
        {
            get { return testDataFormat; }
            set { testDataFormat = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string TypeVariable
        {
            get { return typeVariable; }
            set { typeVariable = value; }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual TestDataStructure TestDataStructure
        {
            get { return testDataStructure; }
            set { testDataStructure = value; }
        }


        public bool Equals(Variable other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Variable other)
        {
            throw new NotImplementedException();
        }
    }
}