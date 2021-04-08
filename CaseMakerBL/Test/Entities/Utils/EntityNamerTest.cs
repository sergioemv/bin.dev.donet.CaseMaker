using System.Collections;
using CaseMaker.Entities.Testcases;
using CaseMaker.Entities.Utils;
using NUnit.Framework;

namespace CaseMaker.Test.Entities.Utils
{
    [TestFixture] 
    public class EntityNamerTest
    {
        
        private TestCasesStructure structure;
        [SetUp]
        protected void setUp()
        {
            structure = new TestCasesStructure();
            
            Element element = new Element(structure);
            element.Name = "One";

            Element element1 = new Element(structure);
            element1.Name = "Dos";

            Element element2 = new Element(structure);
            element2.Name = "Element Untitled 1";

        }


        [Test]
        public void GenerateName()
        {

           EntityNamer namer = new EntityNamer((IList) structure.Elements, "Element");
            Assert.AreEqual(namer.GenerateName(), "Element Untitled 2");
            Element element = new Element(structure);
            element.Name = "Element Untitled 2";
            Element element2 = new Element(structure);
            element2.Name = "Element Untitled 4";
            Assert.AreEqual(namer.GenerateName(), "Element Untitled 5");
        }

    }
}