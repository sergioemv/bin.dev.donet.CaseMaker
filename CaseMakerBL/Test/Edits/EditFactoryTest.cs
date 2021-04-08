using System.Collections;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Entities.Utils;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Edits
{
    [TestFixture] 
    public class EditFactoryTest
    {
        
        private CompoundEdit ce;
        [SetUp]
        protected void setUp()
        {
             ce = new CompoundEdit();
        }


        [Test]
        public void CreateChangePropertyEditTest()
        {
            Element element = new Element();
            string name2 = "Name 2";
            element.Name = "Name 1";
            ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(element, "Name", name2));
            element.Name = name2;
            ce.End();
            ce.Undo();
            Assert.AreEqual(element.Name,"Name 1");
            ce.Redo();
            Assert.AreEqual(element.Name, "Name 2");
        }

        [Test]
        public void CreateAddObjectEditTest()
        {
            Element element = new Element();
            EquivalenceClass equivalenceClass = new EquivalenceClass();
            ce.AddEdit(EditFactory.instance.CreateAddObjectEdit(element,equivalenceClass));
            element.AddEquivalenceClass(equivalenceClass);
            ce.End();
            ce.Undo();
            Assert.IsFalse(element.EquivalenceClasses.Contains(equivalenceClass));
            ce.Redo();
            Assert.IsTrue(element.EquivalenceClasses.Contains(equivalenceClass));
        }

        [Test]
        public void CreateRemoveObjectEditTest()
        {
            Element element = new Element();
            EquivalenceClass equivalenceClass = new EquivalenceClass(element);
            ce.AddEdit(EditFactory.instance.CreateRemoveObjectEdit(element, equivalenceClass));
            ce.End();
            ce.Undo();
            Assert.IsTrue(element.EquivalenceClasses.Contains(equivalenceClass));
            ce.Redo();
            Assert.IsFalse(element.EquivalenceClasses.Contains(equivalenceClass));
        }

        [Test]
        public void CreateAddElementEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            Element element = new Element();
            ce.AddEdit(EditFactory.instance.CreateAddElementEdit(structure, element));
            structure.AddElement(element);
            ce.End();
            ce.Undo();
            Assert.IsFalse(structure.Elements.Contains(element));
            ce.Redo();
            Assert.IsTrue(structure.Elements.Contains(element));
        }

        [Test]
        public void CreateRemoveElementEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            Element element = new Element(structure);
            ce.AddEdit(EditFactory.instance.CreateRemoveElementEdit(structure, element));
            structure.RemoveElement(element);
            ce.End();
            ce.Undo();
            Assert.IsTrue(structure.Elements.Contains(element));
            ce.Redo();
            Assert.IsFalse(structure.Elements.Contains(element));
        }

        [Test]
        public void CreateAddEquivalenceClassEditTest()
        {
            Element element = new Element();
            EquivalenceClass equivalenceClass = new EquivalenceClass(element);
            ce.AddEdit(EditFactory.instance.CreateAddEquivalenceClassEdit(element, equivalenceClass));
            element.AddEquivalenceClass(equivalenceClass);
            ce.End();
            ce.Undo();
            Assert.IsFalse(element.EquivalenceClasses.Contains(equivalenceClass));
            ce.Redo();
            Assert.IsTrue(element.EquivalenceClasses.Contains(equivalenceClass));
        }

        [Test]
        public void CreateRemoveEquivalenceClassEditTest()
        {
            Element element = new Element();
            EquivalenceClass equivalenceClass = new EquivalenceClass(element);
            ce.AddEdit(EditFactory.instance.CreateRemoveEquivalenceClassEdit(element, equivalenceClass));
            element.AddEquivalenceClass(equivalenceClass);
            ce.End();
            ce.Undo();
            Assert.IsTrue(element.EquivalenceClasses.Contains(equivalenceClass));
            ce.Redo();
            Assert.IsFalse(element.EquivalenceClasses.Contains(equivalenceClass));
        }

        [Test]
        public void CreateAddEffectEditTest()
        {
            EquivalenceClass equivalenceClass = new EquivalenceClass();
            Effect effect = new Effect();
            ce.AddEdit(EditFactory.instance.CreateAddEffectEdit(equivalenceClass, effect));
            equivalenceClass.AddEffect(effect);
            ce.End();
            ce.Undo();
            Assert.IsFalse(equivalenceClass.Effects.Contains(effect));
            ce.Redo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
        }

        [Test]
        public void CreateRemoveEffectEditTest()
        {
            EquivalenceClass equivalenceClass = new EquivalenceClass();
            Effect effect = new Effect();
            equivalenceClass.AddEffect(effect);
            ce.AddEdit(EditFactory.instance.CreateRemoveEffectEdit(equivalenceClass, effect));
            equivalenceClass.RemoveEffect(effect);
            ce.End();
            ce.Undo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            ce.Redo();
            Assert.IsFalse(equivalenceClass.Effects.Contains(effect));
        }

        [Test]
        public void CreateAddRequirementEditTest()
        {
            Effect effect = new Effect();
            Requirement req = new Requirement();
            ce.AddEdit(EditFactory.instance.CreateAddRequirementEdit(effect,req));
            effect.AddRequirement(req);
            ce.End();
            ce.Undo();
            Assert.IsFalse(effect.Requirements.Contains(req));
            ce.Redo();
            Assert.IsTrue(effect.Requirements.Contains(req));
        }

        [Test]
        public void CreateRemoveRequirementEditTest()
        {
            Effect effect = new Effect();
            Requirement req = new Requirement();
            effect.AddRequirement(req);
            ce.AddEdit(EditFactory.instance.CreateRemoveRequirementEdit(effect, req));
            effect.RemoveRequirement(req);
            ce.End();
            ce.Undo();
            Assert.IsTrue(effect.Requirements.Contains(req));
            ce.Redo();
            Assert.IsFalse(effect.Requirements.Contains(req));
        }

        [Test]
        public void CreateAddExpectedResultEditTest()
        {
            Effect effect = new Effect();
            ExpectedResult req = new ExpectedResult();
            ce.AddEdit(EditFactory.instance.CreateAddExpectedResultEdit(effect, req));
            effect.AddExpectedResult(req);
            ce.End();
            ce.Undo();
            Assert.IsFalse(effect.ExpectedResults.Contains(req));
            ce.Redo();
            Assert.IsTrue(effect.ExpectedResults.Contains(req));
        }

        [Test]
        public void CreateRemoveExpectedResultEditTest()
        {
            Effect effect = new Effect();
            ExpectedResult req = new ExpectedResult();
            effect.AddExpectedResult(req);
            ce.AddEdit(EditFactory.instance.CreateRemoveExpectedResultEdit(effect, req));
            effect.RemoveExpectedResult(req);
            ce.End();
            ce.Undo();
            Assert.IsTrue(effect.ExpectedResults.Contains(req));
            ce.Redo();
            Assert.IsFalse(effect.ExpectedResults.Contains(req));
        }

        [Test]
        public void CreateAddDependencyEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            Dependency dependency = new Dependency();
            ce.AddEdit(EditFactory.instance.CreateAddDependencyEdit(structure, dependency));
            structure.AddDependency(dependency);
            ce.End();
            ce.Undo();
            Assert.IsFalse(structure.Dependencies.Contains(dependency));
            ce.Redo();
            Assert.IsTrue(structure.Dependencies.Contains(dependency));
        }

        [Test]
        public void CreateRemoveDependencyEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            Dependency dependency = new Dependency(structure);
            
            ce.AddEdit(EditFactory.instance.CreateRemoveDependencyEdit(structure, dependency));
            structure.RemoveDependency(dependency);
            ce.End();
            ce.Undo();
            Assert.IsTrue(structure.Dependencies.Contains(dependency));
            ce.Redo();
            Assert.IsFalse(structure.Dependencies.Contains(dependency));
        }

        [Test]
        public void CreateAddCombinationEditTest()
        {
            Dependency dependency = new Dependency();
            Combination combination = new Combination();
            ce.AddEdit(EditFactory.instance.CreateAddCombinationEdit(dependency,combination));
            dependency.AddCombination(combination);
            ce.End();
            ce.Undo();
            Assert.IsFalse(dependency.Combinations.Contains(combination));
            ce.Redo();
            Assert.IsTrue(dependency.Combinations.Contains(combination));
        }

        [Test]
        public void CreateRemoveCombinationEditTest()
        {
            Dependency dependency = new Dependency();
            Combination combination = new Combination(dependency);
            ce.AddEdit(EditFactory.instance.CreateRemoveCombinationEdit(dependency, combination));
            dependency.RemoveCombination(combination);
            ce.End();
            ce.Undo();
            Assert.IsTrue(dependency.Combinations.Contains(combination));
            ce.Redo();
            Assert.IsFalse(dependency.Combinations.Contains(combination));
        }

        [Test]
        public void CreateAddTestCaseEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            TestCase testCase = new TestCase();
            ce.AddEdit(EditFactory.instance.CreateAddTestCaseEdit(structure,testCase));
            structure.AddTestCase(testCase);
            ce.End();
            ce.Undo();
            Assert.IsFalse(structure.TestCases.Contains(testCase));
            ce.Redo();
            Assert.IsTrue(structure.TestCases.Contains(testCase));
        }

        [Test]
        public void CreateRemoveTestCaseEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            TestCase testCase = new TestCase(structure);
            ce.AddEdit(EditFactory.instance.CreateRemoveTestCaseEdit(structure, testCase));
            structure.RemoveTestCase(testCase);
            ce.End();
            ce.Undo();
            Assert.IsTrue(structure.TestCases.Contains(testCase));
            ce.Redo();
            Assert.IsFalse(structure.TestCases.Contains(testCase));
        }

        [Test]
        public void CreateAddStdCombinationEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            StdCombination stdCombination = new StdCombination();
            ce.AddEdit(EditFactory.instance.CreateAddStdCombinationEdit(structure, stdCombination));
            structure.AddStdCombination(stdCombination);
            ce.End();
            ce.Undo();
            Assert.IsFalse(structure.StdCombinations.Contains(stdCombination));
            ce.Redo();
            Assert.IsTrue(structure.StdCombinations.Contains(stdCombination));
        }

        [Test]
        public void CreateRemoveStdCombinationEditTest()
        {
            TestCasesStructure structure = new TestCasesStructure();
            StdCombination stdCombination = new StdCombination();
            ce.AddEdit(EditFactory.instance.CreateRemoveStdCombinationEdit(structure, stdCombination));
            structure.AddStdCombination(stdCombination);
            ce.End();
            ce.Undo();
            Assert.IsTrue(structure.StdCombinations.Contains(stdCombination));
            ce.Redo();
            Assert.IsFalse(structure.StdCombinations.Contains(stdCombination));
        }
    }
}