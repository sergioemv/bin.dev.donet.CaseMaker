using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Policies;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Policies
{
    [TestFixture]
    public class RiskLevelManagerTest
    {

        private Dependency dep;
        private Combination combi5;
        private Combination combi4;
        private Combination combi3;
        private Combination combi1;
        private Combination combi2;
        private TestCase test1;
        private TestCase test2;
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
        private Effect effect1;

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

            combi1 = new Combination(dep);
            combi2 = new Combination(dep);
            combi3 = new Combination(dep);
            combi4 = new Combination(dep);
            combi5 = new Combination(dep);

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
 
            test1.AddEquivalenceClass(eq33);
            test1.AddCombination(combi4);

            test2.AddCombination(combi3);
            test2.AddCombination(combi4);
        }


        [Test]
        public void ApplyRiskLevelToChildrenTest()
        {
            effect1 = new Effect(structure);
            RiskLevelManager rlm = new RiskLevelManager(effect1);
            eq11.AddEffect(effect1);
            effect1.RiskLevel = 6;
            IUndoableEdit edit = rlm.ApplyRiskLevelToChildren();

            Assert.AreEqual(6,eq11.RiskLevel);
            Assert.AreEqual(6, combi2.RiskLevel);
            Assert.AreEqual(6, combi1.RiskLevel);
            Assert.AreEqual(6, test1.RiskLevel);
            ((CompoundEdit)edit).EndAllEdits();
            edit.Undo();
            Assert.AreNotEqual(6, eq11.RiskLevel);
            Assert.AreNotEqual(6, combi2.RiskLevel);
            Assert.AreNotEqual(6, combi1.RiskLevel);
            Assert.AreNotEqual(6, test1.RiskLevel);
            edit.Redo();
        }
    }
}