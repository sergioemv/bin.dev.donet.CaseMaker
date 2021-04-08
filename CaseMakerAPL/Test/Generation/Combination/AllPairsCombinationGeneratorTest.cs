using CaseMaker.Edits;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using CaseMaker.Generation;
using CaseMaker.Generation.Combinations;
using NUnit.Framework;

namespace CaseMaker.Test.Generation.Combination
{
    [TestFixture] 
    public class AllPairsCombinationGeneratorTest
    {
       
        private TestObject to;
        private Dependency dep;
        private TestCasesStructure structure;
        private Element elem1;
        private EquivalenceClass eq11;
        private EquivalenceClass eq12;
        private EquivalenceClass eq13;
        private Element elem2;
        private EquivalenceClass eq21;
        private EquivalenceClass eq22;
        private EquivalenceClass eq23;
        private EquivalenceClass eq24;
        private Element elem3;
        private EquivalenceClass eq31;
        private EquivalenceClass eq32;
        private EquivalenceClass eq33;

        [SetUp]
        protected void setUp()
        {
            //test a combination from 3 elements
            structure = new TestCasesStructure();
            elem1 = new Element(structure);
            eq11 = new EquivalenceClass(elem1);
            eq12 = new EquivalenceClass(elem1);
            eq13 = new EquivalenceClass(elem1);
            elem2 = new Element(structure);
            eq21 = new EquivalenceClass(elem2);
            eq22 = new EquivalenceClass(elem2);
            eq23 = new EquivalenceClass(elem2);
            eq24 = new EquivalenceClass(elem2);
            elem3 = new Element(structure);
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
            dep.RemoveEquivalenceClass(eq24);
        }

        [Test]
        [Description("Simple generation of 3x3x3 equivalence classes")]
        public void GenerateOverwrite()
        {
            CompoundEdit ce = new CompoundEdit();
            IGenerator gen = new AllPairsCombinationsGenerator(dep, 80000,CombinationsGenerationOption.OVERWRITE);
            ce.AddEdit(gen.Generate());

            Assert.AreEqual(10,dep.Combinations.Count);
            Assert.AreEqual(1,dep.Combinations[0].Position);
            Assert.IsTrue(dep.Combinations[0].EquivalenceClasses.Contains(eq11));
            Assert.IsTrue(dep.Combinations[0].EquivalenceClasses.Contains(eq21));
            Assert.IsTrue(dep.Combinations[0].EquivalenceClasses.Contains(eq31));

            Assert.AreEqual(2, dep.Combinations[1].Position);
            Assert.IsTrue(dep.Combinations[1].EquivalenceClasses.Contains(eq11));
            Assert.IsTrue(dep.Combinations[1].EquivalenceClasses.Contains(eq22));
            Assert.IsTrue(dep.Combinations[1].EquivalenceClasses.Contains(eq32));

            //Assert.AreEqual(3, dep.Combinations[2].Position);
            //Assert.IsTrue(dep.Combinations[2].EquivalenceClasses.Contains(eq11));
            //Assert.IsTrue(dep.Combinations[2].EquivalenceClasses.Contains(eq23));
            //Assert.IsTrue(dep.Combinations[2].EquivalenceClasses.Contains(eq33));

            //Assert.AreEqual(7, dep.Combinations[6].Position);
            //Assert.IsTrue(dep.Combinations[6].EquivalenceClasses.Contains(eq12));
            //Assert.IsTrue(dep.Combinations[6].EquivalenceClasses.Contains(eq22));
            //Assert.IsTrue(dep.Combinations[6].EquivalenceClasses.Contains(eq33));

            ce.EndAllEdits();
            ce.Undo();
            Assert.IsTrue(dep.Combinations.Count == 0);
        }

        [Test]
        [Description("generating 3x3x3 combinations, deleting / adding a equivalence class and updating")]
        public void GenerateUpdateDeleteEquivalence()
        {
            CompoundEdit ce = new CompoundEdit();
            
            IGenerator gen = new AllPairsCombinationsGenerator(dep, 80000, CombinationsGenerationOption.OVERWRITE);
            ce.AddEdit(gen.Generate());
            //deleting an equivalence
            IGenerator genUpdater = new AllPairsCombinationsGenerator(dep, 80000, CombinationsGenerationOption.UPDATE);
            ce.AddEdit(EditFactory.instance.CreateRemoveEquivalenceClassEdit(dep, eq12));
            dep.RemoveEquivalenceClass(eq12);
            ce.AddEdit(genUpdater.Generate());
            Assert.AreEqual(9, dep.Combinations.Count);

            Assert.AreEqual(9, dep.Combinations[8].Position);
            Assert.IsTrue(dep.Combinations[8].EquivalenceClasses.Contains(eq13));
            Assert.IsTrue(dep.Combinations[8].EquivalenceClasses.Contains(eq23));
            Assert.IsTrue(dep.Combinations[8].EquivalenceClasses.Contains(eq31));
         
            ce.EndAllEdits();
            ce.Undo();
            Assert.IsTrue(dep.Combinations.Count == 0);
        }
        //deleting an element

    }
}