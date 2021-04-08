using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;

namespace CaseMaker.Test.Edits
{
    [TestFixture] 
    public class CompoundEditTest
    {
        
        private CompoundEdit ce;
        [SetUp]
        protected void setUp()
        {
             ce = new CompoundEdit();
        }


        [Test]
        public void BasicFunctionality()
        {
            IEditFactory fact = EditFactory.instance;
            Element elem = new Element();
            
            EquivalenceClass equivalenceClass = new EquivalenceClass();
            Effect effect = new Effect();
            ce.AddEdit(fact.CreateAddEquivalenceClassEdit(elem, equivalenceClass));
            elem.AddEquivalenceClass(equivalenceClass);
            ce.AddEdit(fact.CreateAddEffectEdit(equivalenceClass, effect));
            equivalenceClass.AddEffect(effect);
            Assert.IsFalse(ce.CanUndo());
            Assert.IsFalse(ce.CanRedo());
            //finalize all edits so it can be undoed
            ce.EndAllEdits();
            Assert.IsTrue(ce.CanUndo());
            Assert.IsFalse(ce.CanRedo());
            ce.Undo();
            Assert.IsFalse(equivalenceClass.Effects.Contains(effect));
            Assert.IsFalse(elem.EquivalenceClasses.Contains(equivalenceClass));
            ce.Redo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            Assert.IsTrue(elem.EquivalenceClasses.Contains(equivalenceClass));

            ce.Die();
            Assert.IsFalse(ce.CanUndo());
            Assert.IsFalse(ce.CanRedo());

        }

    }
}