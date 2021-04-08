using System.Collections;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Entities.Utils;
using NUnit.Framework;

namespace CaseMaker.Test.Edits
{
    [TestFixture] 
    public class LimitQueueEditTest
    {
        private LimitQueueEdit queue;
 
        [SetUp]
        protected void setUp()
        {
             queue = new LimitQueueEdit();
        }


        [Test]
        public void BasicFunctionality()
        {
            CompoundEdit ce = new CompoundEdit();
            IEditFactory fact = EditFactory.instance;
            Element elem = new Element();
            
            EquivalenceClass equivalenceClass = new EquivalenceClass();
            Effect effect = new Effect();
            ce.AddEdit(fact.CreateAddEquivalenceClassEdit(elem, equivalenceClass));
            elem.AddEquivalenceClass(equivalenceClass);
            ce.AddEdit(fact.CreateAddEffectEdit(equivalenceClass, effect));
            equivalenceClass.AddEffect(effect);
            //a compound edit 
            queue.AddEdit(ce);
            //a simple edit
            queue.AddEdit(fact.CreateChangePropertyEdit(effect, "Description", "Test Description"));
            effect.Description= "Test Description";
            //another edit 
            queue.AddEdit(fact.CreateRemoveEquivalenceClassEdit(elem,equivalenceClass));
            elem.RemoveEquivalenceClass(equivalenceClass);
            //the final edit 
            queue.AddEdit(fact.CreateRemoveEffectEdit(equivalenceClass,effect));
            equivalenceClass.RemoveEffect(effect);
            Assert.IsTrue(queue.CanUndo());
            Assert.IsFalse(queue.CanRedo());

            queue.Undo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            Assert.IsFalse(elem.EquivalenceClasses.Contains(equivalenceClass));
            Assert.IsTrue(queue.CanUndo());
            Assert.IsTrue(queue.CanRedo());

            queue.Undo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            Assert.IsTrue(elem.EquivalenceClasses.Contains(equivalenceClass));
            Assert.IsTrue(effect.Description.Equals("Test Description"));
            Assert.IsTrue(queue.CanUndo());
            Assert.IsTrue(queue.CanRedo());

            queue.Undo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            Assert.IsTrue(elem.EquivalenceClasses.Contains(equivalenceClass));
            Assert.IsTrue(effect.Description == null);
            Assert.IsTrue(queue.CanUndo());
            Assert.IsTrue(queue.CanRedo());

            queue.Undo();
            Assert.IsFalse(equivalenceClass.Effects.Contains(effect));
            Assert.IsFalse(elem.EquivalenceClasses.Contains(equivalenceClass));
            Assert.IsTrue(effect.Description == null);
            Assert.IsFalse(queue.CanUndo());
            Assert.IsTrue(queue.CanRedo());

            queue.Redo();
            queue.Redo();
            queue.Redo();
            queue.Redo();
            Assert.IsTrue(queue.CanUndo());
            Assert.IsFalse(queue.CanRedo());
            Assert.IsTrue(effect.Description.Equals("Test Description"));
            Assert.IsFalse(equivalenceClass.Effects.Contains(effect));
        }

        [Test]
        public void BasicFunctionalityLimit()
        {
            //only 3 edits permited
            queue.Limit = 3;
            CompoundEdit ce = new CompoundEdit();
            IEditFactory fact = EditFactory.instance;
            Element elem = new Element();

            EquivalenceClass equivalenceClass = new EquivalenceClass();
            Effect effect = new Effect();
            ce.AddEdit(fact.CreateAddEquivalenceClassEdit(elem, equivalenceClass));
            elem.AddEquivalenceClass(equivalenceClass);
            ce.AddEdit(fact.CreateAddEffectEdit(equivalenceClass, effect));
            equivalenceClass.AddEffect(effect);
            //a compound edit 
            queue.AddEdit(ce);
            //a simple edit
            queue.AddEdit(fact.CreateChangePropertyEdit(effect, "Description", "Test Description"));
            effect.Description = "Test Description";
            //another edit 
            queue.AddEdit(fact.CreateRemoveEquivalenceClassEdit(elem, equivalenceClass));
            elem.RemoveEquivalenceClass(equivalenceClass);
            //the final edit 
            queue.AddEdit(fact.CreateRemoveEffectEdit(equivalenceClass, effect));
            equivalenceClass.RemoveEffect(effect);
            Assert.IsTrue(queue.CanUndo());
            Assert.IsFalse(queue.CanRedo());

            queue.Undo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            Assert.IsFalse(elem.EquivalenceClasses.Contains(equivalenceClass));
            Assert.IsTrue(queue.CanUndo());
            Assert.IsTrue(queue.CanRedo());

            queue.Undo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            Assert.IsTrue(elem.EquivalenceClasses.Contains(equivalenceClass));
            Assert.IsTrue(effect.Description.Equals("Test Description"));
            Assert.IsTrue(queue.CanUndo());
            Assert.IsTrue(queue.CanRedo());

            queue.Undo();
            Assert.IsTrue(equivalenceClass.Effects.Contains(effect));
            Assert.IsTrue(elem.EquivalenceClasses.Contains(equivalenceClass));
            Assert.IsTrue(effect.Description == null);
            //the firts edit now cannot be undoed
            Assert.IsFalse(queue.CanUndo());
            Assert.IsTrue(queue.CanRedo());

            

            queue.Redo();
            queue.Redo();
            queue.Redo();
            
            Assert.IsTrue(queue.CanUndo());
            Assert.IsFalse(queue.CanRedo());
            Assert.IsTrue(effect.Description.Equals("Test Description"));
            Assert.IsFalse(equivalenceClass.Effects.Contains(effect));
        }
    }
}
