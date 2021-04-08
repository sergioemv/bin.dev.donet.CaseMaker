using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Generation;
using CaseMaker.Generation.Combinations;
using CaseMaker.Policies;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Policies
{
    [TestFixture] 
    public class CombinationManagerTest
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
        public void DeleteCombination()
        {
            CombinationManager man = new CombinationManager(combi4);
            CompoundEdit ce = (CompoundEdit) man.DeleteCombination(structure);
            ce.EndAllEdits();
            Assert.IsFalse(test1.Combinations.Contains(combi4));
            Assert.IsFalse(test2.Combinations.Contains(combi4));
            Assert.IsFalse(dep.Combinations.Contains(combi4));
            ce.Undo();
            Assert.IsTrue(test1.Combinations.Contains(combi4));
            Assert.IsTrue(test2.Combinations.Contains(combi4));
            Assert.IsTrue(dep.Combinations.Contains(combi4));
        }

        [Test]
        public void CanBeAssignedToTestCase()
        {
            test2.RemoveCombination(combi4);
            CombinationManager man3 = new CombinationManager(combi3);
            Assert.IsFalse(man3.CanBeAssignedToTestCase(test1));
            CombinationManager man5 = new CombinationManager(combi5);
            Assert.IsTrue(man5.CanBeAssignedToTestCase(test1));
            CombinationManager man4 = new CombinationManager(combi4);
            //combination already assigned
            Assert.IsFalse(man4.CanBeAssignedToTestCase(test1));
            //child combination
            Assert.IsFalse(man4.CanBeAssignedToTestCase(test2));
            //compatible combination
            combi5.AddEquivalenceClass(eq13);
            combi5.AddEquivalenceClass(eq23);
            combi5.AddEquivalenceClass(eq31);
            Assert.IsTrue(man5.CanBeAssignedToTestCase(test2));
            //incompatible combination
            combi5.RemoveEquivalenceClass(eq23);
            combi5.AddEquivalenceClass(eq21);
            Assert.IsFalse(man5.CanBeAssignedToTestCase(test2));
        }
       
        [Test]
        public void FindMergeableCombinationsTest()
        {
            //generate combinations
            CompoundEdit ce = new CompoundEdit();
            Dependency dep2 = new Dependency(structure);
            foreach (Element element in structure.Elements)
            {
                dep2.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep2.AddEquivalenceClass(equivalenceClass);
                }
            }
            IGenerator gen = new PermutationCombinationsGenerator(dep2, 80000, CombinationsGenerationOption.OVERWRITE);
            //this generates 27 combinations
            ce.AddEdit(gen.Generate());
            //select the combination 02
            Assert.AreEqual(dep2.Combinations[1].Position, 2);
            CombinationManager cm = new CombinationManager(dep2.Combinations[1]);
            IList<Combination> combis =  cm.FindMergeableCombinations(eq33);
            Assert.AreEqual(1, combis.Count);
            Assert.IsTrue(combis.Contains(dep2.Combinations[2]));
            CombinationManager cm1 = new CombinationManager(dep2.Combinations[0]);
            combis = cm1.FindMergeableCombinations(eq23);
            Assert.AreEqual(1, combis.Count);
            Assert.IsTrue(combis.Contains(dep2.Combinations[6]));
        }
        [Test]
        public void MergeCombinationsTest()
        {
            //generate combinations
            CompoundEdit ce = new CompoundEdit();
            Dependency dep2 = new Dependency(structure);
            foreach (Element element in structure.Elements)
            {
                dep2.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep2.AddEquivalenceClass(equivalenceClass);
                }
            }
            IGenerator gen = new PermutationCombinationsGenerator(dep2, 80000, CombinationsGenerationOption.OVERWRITE);
            //this generates 27 combinations
            ce.AddEdit(gen.Generate());
            //select the combination 02
            Assert.AreEqual(dep2.Combinations[1].Position, 2);
            Effect eff8 = new Effect(structure);
            Effect eff9 = new Effect(structure);
            dep2.Combinations[1].AddEffect(eff8);
            dep2.Combinations[2].AddEffect(eff9);
            test1.AddCombination(dep2.Combinations[2]);
            CombinationManager cm = new CombinationManager(dep2.Combinations[1]);
            IList<Combination> combis = cm.FindMergeableCombinations(eq33);
            cm.MergeCombinations(combis);
            Assert.AreEqual(1, combis.Count);
            Assert.IsTrue(combis.Contains(dep2.Combinations[2]));
            Assert.IsTrue(dep2.Combinations[1].Effects.Contains(eff9));
            Assert.IsTrue(dep2.Combinations[2].Effects.Contains(eff8));
            Assert.IsTrue(dep2.Combinations[1].Combinations.Contains(dep2.Combinations[2]));
            Assert.IsFalse(structure.TestCases.Contains(test1));
 
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void UnMergeCombinationsTest()
        {
            //generate a 3 x 3 permutation
            CompoundEdit ce = new CompoundEdit();
            Dependency dep2 = new Dependency(structure);
            foreach (Element element in structure.Elements)
            {
                if (element.Position == 3) continue;
                dep2.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep2.AddEquivalenceClass(equivalenceClass);
                }
            }
            
            IGenerator gen = new PermutationCombinationsGenerator(dep2, 80000, CombinationsGenerationOption.OVERWRITE);
            //this generates 10 combinations
            ce.AddEdit(gen.Generate());
            //select the combination 02
            Assert.AreEqual(dep2.Combinations.Count, 9);
            
            CombinationManager cm = new CombinationManager(dep2.Combinations[0]);

            IList<Combination> combis = cm.FindMergeableCombinations(eq12);
            cm.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[3]));
            combis = cm.FindMergeableCombinations(eq13);
            cm.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[6]));
            combis = cm.FindMergeableCombinations(eq22);
            cm.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[4]));
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[7]));
            Assert.IsFalse(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[8]));
            combis = cm.FindMergeableCombinations(eq23);
            cm.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[2]));
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[5]));
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[8]));

            //now the unmerge
            cm.UnMergeCombinations(eq22);
            Assert.IsFalse(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[1]));
            Assert.IsTrue(dep2.Combinations[1].Combinations.Contains(dep2.Combinations[4]));
            Assert.IsTrue(dep2.Combinations[1].Combinations.Contains(dep2.Combinations[7]));
            Assert.IsTrue(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[3]));
            //this thows an arg exception
            cm.UnMergeCombinations(eq11);
            cm.UnMergeCombinations(eq13);
            Assert.IsFalse(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[8]));
            Assert.IsTrue(dep2.Combinations[8].Combinations.Contains(dep2.Combinations[5]));
        }


        [Test]
        public void UnMergeCombinationsTest2()
        {
            //generate a 3 x 3 permutation
            CompoundEdit ce = new CompoundEdit();
            Dependency dep2 = new Dependency(structure);
            dep = dep2;
            foreach (Element element in structure.Elements)
            {
                if (element.Position == 3) continue;
                dep2.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep2.AddEquivalenceClass(equivalenceClass);
                }
            }

            IGenerator gen = new PermutationCombinationsGenerator(dep2, 80000, CombinationsGenerationOption.OVERWRITE);
            //this generates 10 combinations
            ce.AddEdit(gen.Generate());
            //Merge 
            //merge combination c3 with eq22
            CombinationManager cm = new CombinationManager(dep2.Combinations[2]);
            IList<Combination> combis = cm.FindMergeableCombinations(eq22);
            cm.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[2].Combinations.Contains(dep2.Combinations[1]));
            //merge combination c3 with eq21
            
            combis = cm.FindMergeableCombinations(eq21);
            cm.MergeCombinations(combis);
            Assert.IsTrue(dep.Combinations[2].Combinations.Contains(dep2.Combinations[1]));

            //merge combination c6 with eq22
            CombinationManager cm2 = new CombinationManager(dep2.Combinations[5]);
            combis = cm2.FindMergeableCombinations(eq22);
            cm2.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[5].Combinations.Contains(dep2.Combinations[4]));

            //merge combination c6 with eq21
            combis = cm2.FindMergeableCombinations(eq21);
            cm2.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[5].Combinations.Contains(dep2.Combinations[3]));


            //merge combination c9 with eq22
            CombinationManager cm4 = new CombinationManager(dep.Combinations[8]);
            combis = cm4.FindMergeableCombinations(eq22);
            cm4.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[8].Combinations.Contains(dep2.Combinations[7]));

            //merge combination c9 with eq21
            
            combis = cm4.FindMergeableCombinations(eq21);
            cm4.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[8].Combinations.Contains(dep2.Combinations[6]));

            //merge combination c9 with eq12
            
            combis = cm4.FindMergeableCombinations(eq12);
            cm4.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[8].Combinations.Contains(dep2.Combinations[5]));

            //merge combination c9 with eq11
            
            combis = cm4.FindMergeableCombinations(eq11);
            cm4.MergeCombinations(combis);
            Assert.IsTrue(dep2.Combinations[8].Combinations.Contains(dep2.Combinations[2]));
			
			//unmerge from C9 eq11
            cm4.UnMergeCombinations(eq11);
            Assert.IsFalse(dep2.Combinations[0].Combinations.Contains(dep2.Combinations[0]));
            cm4.UnMergeCombinations(eq21);

            CombinationManager cm5 = new CombinationManager(dep.Combinations[2]);
			//unmerge from C3 eq22            
            cm5.UnMergeCombinations(eq22);
        }
    }
}