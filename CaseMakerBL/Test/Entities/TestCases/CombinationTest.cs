using System.Collections;
using CaseMaker.Entities.Testcases;
using CaseMaker.Entities.Utils;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Entities.TestCases
{
    [TestFixture] 
    public class CombinationTest
    {


        private Combination combi;
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

            Dependency dep = new Dependency(structure);
            foreach (Element element in structure.Elements)
            {
                dep.AddElement(element);
                foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                {
                    dep.AddEquivalenceClass(equivalenceClass);
                }
            }


            combi = new Combination(dep);
            combi2 = new Combination();
            combi.AddCombination(combi2);
        }


        [Test]
        public void GeneratedDescriptionTest()
        {
            Effect eff1 = new Effect(structure);
            Effect eff2 = new Effect(structure);
            Effect eff3 = new Effect(structure);
            Effect eff6 = new Effect(structure);
            eq11.Value = "Valor 1";
            eq12.Value = "Valor Opcional 2";
            eq22.Value = "Valor 2";
            eff2.Description = "Efecto 2";
            eff3.Description = "Effecto Indirecto";
            combi2.AddEffect(eff3);
            eff6.Description = "Efecto de equivalence";
            eq11.AddEffect(eff3);
            combi2.AddEquivalenceClass(eq11);

            combi2.AddEffect(eff2);
            combi.AddEquivalenceClass(eq12);
            combi.AddEquivalenceClass(eq22);
            eq22.AddEffect(eff3);
            combi.AddEffect(eff1);

            Assert.AreEqual(combi.GeneratedDescription, "(Element Untitled 1='Valor Opcional 2' OR Element Untitled 1='Valor 1') AND (Element Untitled 2='Valor 2') THEN {CE1,Effecto Indirecto,Efecto 2}");

        }

    }
}