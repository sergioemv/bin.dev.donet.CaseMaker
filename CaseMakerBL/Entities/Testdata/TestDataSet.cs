using System;

namespace CaseMaker.Entities.Testdata
{
    public class TestDataSet : IEquatable<TestDataSet>, IComparable<TestDataSet>
    {
        private string description;
        private int id;
        private string reportFormat;
        private TestDataCombination testDataCombination;
        private string name;
        private TestDataStructure testDataStructure;


        public virtual TestDataCombination TestDataCombination
        {
            get { return testDataCombination; }
            set { testDataCombination = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string ReportFormat
        {
            get { return reportFormat; }
            set { reportFormat = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual TestDataStructure TestDataStructure
        {
            get { return testDataStructure; }
            set { testDataStructure = value; }
        }


        public bool Equals(TestDataSet other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(TestDataSet other)
        {
            throw new NotImplementedException();
        }
    }
}