using System;
using System.Collections.Generic;

namespace CaseMaker.Entities.Testdata
{
    public class TestData : IEquatable<TestData>, IComparable<TestData>
    {
        private int contTestDataSet;
        private string description;
        private int id;
        private int riskLevel = 0;
        private string name;
        private TestDataStructure testDataStruct;
        private IList<StructureTypeData> structureTypeDatas;
        private string testCaseInTestData;

        public virtual int ContTestDataSet
        {
            get { return contTestDataSet; }
            set { contTestDataSet = value; }
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

        public virtual int RiskLevel
        {
            get { return riskLevel; }
            set { riskLevel = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual TestDataStructure TestDataStruct
        {
            get { return testDataStruct; }
            set { testDataStruct = value; }
        }

        public virtual IList<StructureTypeData> StructureTypeDatas
        {
            get { return structureTypeDatas; }
            set { structureTypeDatas = value; }
        }

        public virtual string TestCaseInTestData
        {
            get { return testCaseInTestData; }
            set { testCaseInTestData = value; }
        }


        public bool Equals(TestData other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(TestData other)
        {
            throw new NotImplementedException();
        }
    }
}