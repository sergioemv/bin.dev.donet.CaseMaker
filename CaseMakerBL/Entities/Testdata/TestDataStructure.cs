using System;
using System.Collections.Generic;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Entities.Testdata
{
    public class TestDataStructure : IEquatable<TestDataStructure>, IComparable<TestDataStructure>
    {
        private int id;
        private string description;
        private string name;
        private IList<StructureTypeData> structureTypeDatas;
        private IList<TestCase> testCases;
        private IList<TestDataSet> testDataSets;
        private TestDataSetReportUnit testDataSetReportUnit;
        private TestObject testObject;
        private string versionTestData;
        private IList<Variable> variables;
        private IList<TestData> testDatas;
        private DateTime creationDate;


        public virtual TestDataSetReportUnit TestDataSetReportUnit
        {
            get { return testDataSetReportUnit; }
            set { testDataSetReportUnit = value; }
        }

        public virtual TestObject TestObject
        {
            get { return testObject; }
            set
            {
                testObject = value;
                Id = testObject.Id;
            }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual IList<TestCase> TestCases
        {
            get { return testCases; }
            set { testCases = value; }
        }

        public virtual string VersionTestData
        {
            get { return versionTestData; }
            set { versionTestData = value; }
        }

        public virtual IList<Variable> Variables
        {
            get { return variables; }
            set { variables = value; }
        }

        public virtual IList<StructureTypeData> StructureTypeDatas
        {
            get { return structureTypeDatas; }
            set { structureTypeDatas = value; }
        }

        public virtual IList<TestDataSet> TestDataSets
        {
            get { return testDataSets; }
            set { testDataSets = value; }
        }

        public virtual IList<TestData> TestDatas
        {
            get { return testDatas; }
            set { testDatas = value; }
        }

        public virtual DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }


        public bool Equals(TestDataStructure other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(TestDataStructure other)
        {
            throw new NotImplementedException();
        }
    }
}