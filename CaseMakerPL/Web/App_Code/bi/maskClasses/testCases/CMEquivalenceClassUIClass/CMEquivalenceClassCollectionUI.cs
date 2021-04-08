using System;
using System.Collections;
using System.Collections.Generic;
using bi.maskClasses.testCases.CMElementUIClass;
using CaseMaker.Entities.Testcases;
using ISNet.WebUI.WebGrid;

namespace bi.maskClasses.testCases.CMEquivalenceClassUIClass
{
    /// <summary>
    /// Autor: portiz
    /// Description: This class represents a collection that holds mask equivalenceClass.
    /// This class also helps to represent the hierarchical rows for isnt.webgrid.
    /// </summary>
    public class CMEquivalenceClassCollectionUI : CollectionBase, IHierarchicalList
    {
        #region Private attributes

        private CMElementUI _parentObject;
        private readonly IList<EquivalenceClass> _equivalenceClassListReal;
        private readonly IList<CMEquivalenceClassUI> _AddedEqClassList;
        private readonly IList<CMEquivalenceClassUI> _RemovedEqClassList;

        #endregion

        #region Private methods

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="__listEquivalenceClasses"></param>
        /// <param name="__element"></param>
        public CMEquivalenceClassCollectionUI(IList<EquivalenceClass> __listEquivalenceClasses, CMElementUI __element)
        {
            _parentObject = __element;
            _AddedEqClassList = new List<CMEquivalenceClassUI>();
            _RemovedEqClassList = new List<CMEquivalenceClassUI>();
            _equivalenceClassListReal = __listEquivalenceClasses;
            if (__listEquivalenceClasses.Count > 0)
            {
                foreach (EquivalenceClass equivalenceClass in __listEquivalenceClasses)
                {
                    CMEquivalenceClassUI eq = new CMEquivalenceClassUI(equivalenceClass);
                    eq.parentElement = __element;
                    eq.Owner = this;
                    List.Add(eq);
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CMEquivalenceClassCollectionUI()
        {
            _AddedEqClassList = new List<CMEquivalenceClassUI>();
            _RemovedEqClassList = new List<CMEquivalenceClassUI>();
            _equivalenceClassListReal = null;
        }

        public void Add(CMEquivalenceClassUI __eqClassMask)
        {
            //verify if exist!
            if (!existEquivalence(__eqClassMask))
            {
                __eqClassMask.Owner = this;
                List.Add(__eqClassMask);
            }

            _AddedEqClassList.Add(__eqClassMask);
            //if (_parentObject != null) {
            //    Element el = _parentObject.getRealObject() as Element;
            //    if (el != null)
            //        el.AddEquivalenceClass(__eqClassMask.getRealObject() as EquivalenceClass);
            //}
        }


        public CMEquivalenceClassUI FindByID(int __EquivalenceClassId)
        {
            foreach (CMEquivalenceClassUI o in InnerList)
            {
                if (o.EquivalenceClassId == __EquivalenceClassId)
                    return o;
            }
            return null;
        }

        public Boolean existEquivalence(CMEquivalenceClassUI eq)
        {
            foreach (CMEquivalenceClassUI e in InnerList)
                if (e.Equals(eq))
                    return true;
            return false;
        }

        public CMEquivalenceClassUI Item(int Index)
        {
            if (Index >= List.Count)
                throw new Exception("Out of bound.");
            return (CMEquivalenceClassUI) List[Index];
        }

        public void Remove(CMEquivalenceClassUI eq)
        {
            List.Remove(eq);
            _RemovedEqClassList.Add(eq);
            if (_parentObject != null)
            {
                Element el = _parentObject.getRealObject() as Element;
                if (el != null)
                    el.RemoveEquivalenceClass(eq.getRealObject() as EquivalenceClass);
            }
        }

        public void copyFromClone(CMEquivalenceClassCollectionUI __clonedList)
        {
            //remove deleted eq. classes
            foreach (CMEquivalenceClassUI ecClonned in __clonedList.getRemovedEquivalenceClasses())
            {
                CMEquivalenceClassUI eq = FindByID(ecClonned.EquivalenceClassId);
                Remove(eq);
            }

            //Modify equivalence classes masks
            foreach (CMEquivalenceClassUI eq in List)
            {
                CMEquivalenceClassUI eqCloned = __clonedList.FindByID(eq.EquivalenceClassId);
                eq.copyFromClone(eqCloned);
            }

            //add new eq. classes
            foreach (CMEquivalenceClassUI ecClonned in __clonedList.getAddedEquivalenceClasses())
            {
                CMEquivalenceClassUI newEq = new CMEquivalenceClassUI(_parentObject, ecClonned);
            }

            //delete the list from the cloned
            __clonedList.clearListAddRemove();
        }

        public IList<CMEquivalenceClassUI> getAddedEquivalenceClasses()
        {
            return _AddedEqClassList;
        }

        public IList<CMEquivalenceClassUI> getRemovedEquivalenceClasses()
        {
            return _RemovedEqClassList;
        }

        public void clearListAddRemove()
        {
            _AddedEqClassList.Clear();
            _RemovedEqClassList.Clear();
        }

        #endregion

        #region IHierarchicalList Members

        public Type ItemType
        {
            get { return typeof (CMEquivalenceClassUI); }
        }

        #endregion
    }
}