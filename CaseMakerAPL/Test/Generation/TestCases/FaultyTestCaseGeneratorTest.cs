using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Generation.TestCases;
using CaseMaker.Policies;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Generation.TestCases
{
    [TestFixture] 
    public class FaultyTestCaseGeneratorTest
    {

        private Dependency dep;
        private CaseMaker.Entities.Testcases.Combination combi5;
        private CaseMaker.Entities.Testcases.Combination combi4;
        private CaseMaker.Entities.Testcases.Combination combi3;
        private CaseMaker.Entities.Testcases.Combination combi1;
        private CaseMaker.Entities.Testcases.Combination combi2;

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

            combi1 = new CaseMaker.Entities.Testcases.Combination(dep);
            combi2 = new CaseMaker.Entities.Testcases.Combination(dep);
            combi3 = new CaseMaker.Entities.Testcases.Combination(dep);
            combi4 = new CaseMaker.Entities.Testcases.Combination(dep);
            combi5 = new CaseMaker.Entities.Testcases.Combination(dep);

            combi1.AddEquivalenceClass(eq11);
            combi1.AddEquivalenceClass(eq22);
            combi1.AddEquivalenceClass(eq33);


            combi2.AddEquivalenceClass(eq21);
            combi2.AddEquivalenceClass(eq11);
            combi2.AddEquivalenceClass(eq32);

            combi3.AddEquivalenceClass(eq13);
            combi3.AddEquivalenceClass(eq23);
            combi3.AddEquivalenceClass(eq31);

            combi4.AddEquivalenceClass(eq12);
            combi4.AddEquivalenceClass(eq22);
            combi4.AddEquivalenceClass(eq32);

            combi5.AddEquivalenceClass(eq11);
            combi5.AddEquivalenceClass(eq23);
            combi5.AddEquivalenceClass(eq31);

        }

      [Test]
     public void Generate()
      {
          List <Dependency> deps = new List<Dependency>();
          eq22.CurrentState = State.FAULTY;
          combi2.CurrentState = State.FAULTY;
          CompoundEdit ce = new CompoundEdit();
          deps.Add(dep);
          FaultyTestCasesGenerator generator = new FaultyTestCasesGenerator(deps, structure, 10000);
          ce.AddEdit(generator.Generate());
          Assert.IsTrue(structure.TestCases.Count == 2);
          Assert.IsTrue(structure.TestCases[0].EquivalenceClasses.Contains(eq22));
          Assert.IsTrue(structure.TestCases[1].Combinations.Contains(combi2));
          //TODO add more complex tests here


      }
    }
}