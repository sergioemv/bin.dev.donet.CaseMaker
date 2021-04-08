using System.Collections;
using CaseMaker.Entities.Testcases;
using CaseMaker.Entities.Utils;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Entities.TestCases
{
    [TestFixture] 
    public class StdCombinationTest
    {



        private TestCasesStructure structure;
        private EquivalenceClass eq33;
        private EquivalenceClass eq32;
        private EquivalenceClass eq31;
        private EquivalenceClass eq23;
        private EquivalenceClass eq22;
        private EquivalenceClass eq21;
        private EquivalenceClass eq13;
        private EquivalenceClass eq12;
        private EquivalenceClass eq11;
        [SetUp]
        protected void setUp()
        {
            //test a combination from 3 elements
            structure = new TestCasesStructure();
            Element elem1 = new Element(structure);
            eq11 = new EquivalenceClass(elem1);
            eq12 = new EquivalenceClass(elem1);
            eq13 = new EquivalenceClass(elem1);
            Element elem2 = new Element(structure);
            eq21 = new EquivalenceClass(elem2);
            eq22 = new EquivalenceClass(elem2);
            eq23 = new EquivalenceClass(elem2);
            Element elem3 = new Element(structure);
            eq31 = new EquivalenceClass(elem3);
            eq32 = new EquivalenceClass(elem3);
            eq33 = new EquivalenceClass(elem3);


        }


        [Test]
        public void GeneratedDescriptionTest()
        {

            eq11.Value = "Valor 1";
            eq12.Value = "Valor Opcional 2";
            eq22.Value = "Valor 2";
            
            StdCombination stdCombi = new StdCombination(structure);
            stdCombi.AddEquivalenceClass(eq11);
            stdCombi.AddEquivalenceClass(eq12);
            stdCombi.AddEquivalenceClass(eq22);
            Assert.AreEqual(stdCombi.GeneratedDescription, "(Element Untitled 1='Valor 1' OR Element Untitled 1='Valor Opcional 2') AND (Element Untitled 2='Valor 2')");

        }

    }
}