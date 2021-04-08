using System.Collections;
using CaseMaker.Entities.Testcases;
using CaseMaker.Entities.Utils;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Entities.TestCases
{
    [TestFixture] 
    public class TestCaseTest
    {

        private Dependency dep;
        private Combination combi5;
        private Combination combi4;
        private Combination combi3;
        private Combination combi1;
        private Combination combi2;

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

            dep = new Dependency(structure);
            foreach (Element element in structure.Elements)
            {
                dep.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep.AddEquivalenceClass(equivalenceClass);
                }
            }


            combi2 = new CaseMaker.Entities.Testcases.Combination(dep);
            combi3 = new CaseMaker.Entities.Testcases.Combination(dep);

            combi5 = new CaseMaker.Entities.Testcases.Combination(dep);




            combi2.AddEquivalenceClass(eq21);
            combi2.AddEquivalenceClass(eq11);
            combi2.AddEquivalenceClass(eq32);

            combi3.AddEquivalenceClass(eq13);
            combi3.AddEquivalenceClass(eq23);
            combi3.AddEquivalenceClass(eq31);



            combi5.AddEquivalenceClass(eq11);
            combi5.AddEquivalenceClass(eq23);
            combi5.AddEquivalenceClass(eq31);
        }


        [Test]
        public void EqualsByRelationsTest()
        {
            TestCase tc1 = new TestCase(structure);
            TestCase tc2 = new TestCase(structure);

            tc1.Combinations.Add(combi2);
            tc1.Combinations.Add(combi3);
            tc1.EquivalenceClasses.Add(eq13);
            tc1.EquivalenceClasses.Add(eq22);

            tc2.Combinations.Add(combi2);
            tc2.Combinations.Add(combi3);
            tc2.EquivalenceClasses.Add(eq13);
            tc2.EquivalenceClasses.Add(eq22);

            Assert.IsTrue(tc1.EqualsByRelations(tc2));
            tc1.RemoveCombination(combi3);

            Assert.IsFalse(tc1.EqualsByRelations(tc2));
        }

        [Test]
        public void GeneratedDescriptionTest()
        {
            TestCase tc1 = new TestCase(structure);

            tc1.Combinations.Add(combi2);
            tc1.Combinations.Add(combi3);
            tc1.EquivalenceClasses.Add(eq13);
            tc1.EquivalenceClasses.Add(eq22);
            Assert.AreEqual(tc1.GeneratedDescription, "[D1.C1:(Element Untitled 2='') AND (Element Untitled 1='') AND (Element Untitled 3='')]\n AND [D1.C2:(Element Untitled 1='') AND (Element Untitled 2='') AND (Element Untitled 3='')]\n AND (Element Untitled 1='')\n AND (Element Untitled 2='')");
             
          
        }

    }
}