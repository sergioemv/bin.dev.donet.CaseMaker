using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Policies;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Policies
{
    [TestFixture] 
    public class DependencyManagerTest
    {

        private Dependency dep;
        private Combination combi4;
        private Combination combi3;
        private Combination combi1;
        private Combination combi2;
        private TestCase test1;
        private TestCase test2;
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
            foreach (Element element in structure.Elements)
            {
                dep.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep.AddEquivalenceClass(equivalenceClass);
                }
            }

            combi1 = new Combination(dep);
            combi2 = new Combination(dep);
            combi3 = new Combination(dep);
            combi4 = new Combination(dep);

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
           

            test1.AddCombination(combi1);
            test1.AddEquivalenceClass(eq23);
            test1.AddEquivalenceClass(eq33);
            test1.AddCombination(combi4);

            test2.AddCombination(combi3);
            test2.AddCombination(combi4);
        }

        [Test]
        public void DeleteAllCombinations()
        {
            DependencyManager man = new DependencyManager(dep);
            CompoundEdit ce = (CompoundEdit) man.DeleteAllCombinations();
            ce.EndAllEdits();
            Assert.IsFalse(test1.Combinations.Contains(combi4));
            Assert.IsFalse(test2.Combinations.Contains(combi3));
            Assert.IsFalse(dep.Combinations.Contains(combi4));
            Assert.IsFalse(dep.Combinations.Contains(combi2));
            Assert.IsFalse(dep.Combinations.Contains(combi1));
            Assert.IsFalse(dep.Combinations.Contains(combi3));
            ce.Undo();
            Assert.IsTrue(test1.Combinations.Contains(combi4));
            Assert.IsTrue(test2.Combinations.Contains(combi3));
            Assert.IsTrue(dep.Combinations.Contains(combi4));
            Assert.IsTrue(dep.Combinations.Contains(combi2));
            Assert.IsTrue(dep.Combinations.Contains(combi1));
            Assert.IsTrue(dep.Combinations.Contains(combi3));
        }
       
    }
}