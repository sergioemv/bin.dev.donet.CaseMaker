using System;
using System.Collections;
using bi.maskClasses.testCases.CMEquivalenceClassUIClass;
using CaseMaker.Entities.Testcases;
using ISNet.WebUI.WebGrid;

namespace bi.maskClasses.testCases.CMElementUIClass
{
    /// <summary>
    /// Autor: portiz
    /// Description: This class wraps a Element of the CaseMakerBL
    /// </summary>
    public class CMElementUI : IMaskClass
    {
        #region Private attributes

        private String _objectTypeId = "1";
        private CMEquivalenceClassCollectionUI _equivalentClasses;
        private IEnumerable _owner; //for the collection, that will contain this mask class
        private readonly Element _elementReal;
        // private bool isExpanded=false;

        #endregion

        #region Properties

        [PrimaryKey]
        public int ElementID
        {
            get { return _elementReal.Id; }
            set { _elementReal.Id = value; }
        }

        public string ElementName
        {
            get { return _elementReal.Name; }
            set { _elementReal.Name = value; }
        }

        public string ObjectTypeId
        {
            get { return _objectTypeId; }
            set { _objectTypeId = value; }
        }

        public string Description
        {
            get { return _elementReal.Description; }
            set { _elementReal.Description = value; }
        }

        internal IEnumerable Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public CMEquivalenceClassCollectionUI EquivalentClasses
        {
            get
            {
                if (_equivalentClasses == null)
                {
                    _equivalentClasses = new CMEquivalenceClassCollectionUI(_elementReal.EquivalenceClasses, this);
                }
                return _equivalentClasses;
            }
        }

        //public bool IsExpanded {
        //    get { return isExpanded; }
        //    set { isExpanded = value; }
        //}
        [NonRetrievableAttribute]
        public int Position
        {
            get { return _elementReal.Position; }
            set { _elementReal.Position = value; }
        }

        #endregion

        #region Private methods

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor
        /// </summary>
        public CMElementUI()
        {
            _elementReal = new Element();
            _equivalentClasses = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="__element"></param>
        public CMElementUI(Element __element)
        {
            _elementReal = __element;
            _equivalentClasses = null;
        }

        /// <summary>
        /// Remove the element from the list.
        /// </summary>
        public void Remove()
        {
            CMElementCollectionUI owner = Owner as CMElementCollectionUI;
            if (owner != null) owner.Remove(this);
        }

        /// <summary>
        /// Adds a new equivalence class
        /// </summary>
        /// <returns></returns>
        public CMEquivalenceClassUI addEquivalenceClass()
        {
            EquivalenceClass eq1 = new EquivalenceClass(_elementReal);
            CMEquivalenceClassUI myClass = new CMEquivalenceClassUI(eq1);
            myClass.parentElement = this;
            //if (EquivalentClasses.Count > 1)
            //patch !!!
            EquivalentClasses.Add(myClass);

            return myClass;
        }

        /// <summary>
        /// Append a new equivalenceClass from 
        /// </summary>
        /// <param name="eq"></param>
        public void addEquivalenceClass(CMEquivalenceClassUI eq)
        {
            EquivalentClasses.Add(eq);
            eq.parentElement = this;
        }


        /// <summary>
        /// Indicates if an object is the same, checking the id of the element.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            // safe because of the GetType check
            CMElementUI ele = (CMElementUI) obj;
            // use this pattern to compare value members
            if (!ElementID.Equals(ele.ElementID)) return false;
            return true;
        }

        #endregion

        #region IMaskClass Implementation

        /// <summary>
        /// Return the real object that the class wraps.
        /// </summary>
        /// <returns></returns>
        public Object getRealObject()
        {
            return _elementReal;
        }

        #endregion

        public CMElementUI MakeCopy(TestCasesStructure __testCaseStruct)
        {
            Element newCopyElement = _elementReal.makeCopy(__testCaseStruct);
            CMElementUI newCopyMask = new CMElementUI(newCopyElement);
            return newCopyMask;
        }
    }
}