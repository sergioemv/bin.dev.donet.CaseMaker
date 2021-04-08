using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Policies;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Policies
{
    [TestFixture] 
    public class StructureManagerTest
    {

        private Dependency dep;
        private Dependency dep2;
        private Dependency dep3;
        
        private TestCase test1;
        private TestCase test2;
        private TestCase test3;
        private TestCase test4;
        private TestCase test5;

        private TestCasesStructure structure;

        [SetUp]
        protected void setUp()
        {
            //test a combination from 3 elements
            structure = new TestCasesStructure();
            Element elem1 = new Element(structure);
            EquivalenceClass eq11 = new EquivalenceClass(elem1);
            EquivalenceClass eq12 = new EquivalenceClass(elem1);
            EquivalenceClass eq13 = new EquivalenceClass(elem1);
            Element elem2 = new Element(structure);
            EquivalenceClass eq21 = new EquivalenceClass(elem2);
            EquivalenceClass eq22 = new EquivalenceClass(elem2);
            EquivalenceClass eq23 = new EquivalenceClass(elem2);
            Element elem3 = new Element(structure);
            EquivalenceClass eq31 = new EquivalenceClass(elem3);
            EquivalenceClass eq32 = new EquivalenceClass(elem3);
            EquivalenceClass eq33 = new EquivalenceClass(elem3);

            dep = new Dependency(structure);
            dep2 = new Dependency(structure);
            dep3 = new Dependency(structure);
            foreach (Element element in structure.Elements)
            {
                dep.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep.AddEquivalenceClass(equivalenceClass);
                }
            }

            Combination combi4;
            Combination combi3;
            Combination combi1;
            Combination combi2;
            combi1 = new Combination(dep);
            combi2 = new Combination(dep2);
            combi3 = new Combination(dep);
            combi4 = new Combination(dep3);

            combi1.AddEquivalenceClass(eq11);
            combi1.AddEquivalenceClass(eq22);
            combi1.AddEquivalenceClass(eq33);


            combi2.AddEquivalenceClass(eq21);
            combi2.AddEquivalenceClass(eq11);
            combi2.AddEquivalenceClass(eq32);

            combi3.AddEquivalenceClass(eq13);
            combi3.AddEquivalenceClass(eq23);
            combi3.AddCombination(combi4);


            test1 = new TestCase(structure);
            test2 = new TestCase(structure);
            test3 = new TestCase(structure);
            test4 = new TestCase(structure);
            test5 = new TestCase(structure);
           

            test1.AddCombination(combi1);
            test1.AddCombination(combi4);

            test2.AddCombination(combi3);
            test2.AddCombination(combi4);

            test3.AddCombination(combi2);
            test3.AddCombination(combi1);

            test4.AddCombination(combi3);

            test5.AddCombination(combi2);
            test5.AddCombination(combi4);
        }

        [Test]
        public void DeleteCommonTestCases()
        {
            StructureManager man = new StructureManager(structure);
            List<Dependency> deps = new List<Dependency>();
            deps.Add(dep3);
            deps.Add(dep2);
            CompoundEdit ce = (CompoundEdit) man.DeleteCommonTestCases(State.POSITIVE, deps);
            Assert.IsTrue(structure.TestCases.Contains(test4));
            Assert.AreEqual(structure.TestCases.Count,1);
            ce.EndAllEdits();
            ce.Undo();
        }
       
    }
}