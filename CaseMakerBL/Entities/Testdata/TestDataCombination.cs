using System;
using System.Collections.Generic;

namespace CaseMaker.Entities.Testdata
{
    public class TestDataCombination : IEquatable<TestDataCombination>, IComparable<TestDataCombination>
    {
        private IList<TestData> testDatas;
        private TestDataStructure testDataStructure;

        public IList<TestData> TestDatas
        {
            get { return testDatas; }
            set { testDatas = value; }
        }

        public virtual TestDataStructure TestDataStructure
        {
            get { return testDataStructure; }
            set { testDataStructure = value; }
        }


        public bool Equals(TestDataCombination other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(TestDataCombination other)
        {
            throw new NotImplementedException();
        }
    }
}