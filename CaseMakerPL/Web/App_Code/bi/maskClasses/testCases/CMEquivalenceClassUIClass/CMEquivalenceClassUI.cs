using System;
using System.Collections;
using bi.maskClasses.testCases.CMElementUIClass;
using CaseMaker.Entities.Testcases;
using ISNet.WebUI.WebGrid;

namespace bi.maskClasses.testCases.CMEquivalenceClassUIClass
{
    /// <summary>
    /// Autor: portiz
    /// Description: This class wraps an equivalence class from CaseMakerBL
    /// </summary>
    public class CMEquivalenceClassUI : IMaskClass
    {
        #region Private attributes

        private IEnumerable _owner;
        private CMElementUI _parentElement = null;
        private readonly EquivalenceClass _equivalenceClassReal;
        private bool isMarked = false;

        #endregion

        #region Properties

        [PrimaryKey()]
        public int EquivalenceClassId
        {
            get { return _equivalenceClassReal.Id; }
            set
            {
                _equivalenceClassReal.Id = Convert.ToInt32(value);
                //markDataChange();
            }
        }

        public string Name
        {
            get { return _equivalenceClassReal.Name; }
            //if get, don't 
        }

        public Byte StateId
        {
            get { return Convert.ToByte(_equivalenceClassReal.CurrentState); }
            set
            {
                State c = (State) Enum.Parse(typeof (State), value.ToString(), true);
                _equivalenceClassReal.CurrentState = c;
            }
        }

        public int RiskLevel
        {
            get { return _equivalenceClassReal.RiskLevel; }
            set { _equivalenceClassReal.RiskLevel = value; }
        }

        public string Value
        {
            get { return _equivalenceClassReal.Value; }
            set { _equivalenceClassReal.Value = value; }
        }

        public string Description
        {
            get { return _equivalenceClassReal.Description; }
            set { _equivalenceClassReal.Description = value; }
        }

        public int ElementId
        {
            get { return _equivalenceClassReal.ParentElement.Id; }
            //set {
            //    if (_equivalenceClassReal.ParentElement != null)
            //        _equivalenceClassReal.ParentElement.Id = value;
            //}
        }

        [NonRetrievableAttribute()]
        public bool IsMarked
        {
            get { return isMarked; }
            set { isMarked = value; }
        }

        [NonRetrievableAttribute()]
        public CMElementUI parentElement
        {
            get { return _parentElement; }
            set { _parentElement = value; }
        }

        public String EffectListResume
        {
            get { return getEffectListResume(); }
        }

        internal IEnumerable Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        #endregion

        #region Private methods

        private String getEffectListResume()
        {
            String resString = "";
            foreach (Effect eff in _equivalenceClassReal.Effects)
            {
                if (String.IsNullOrEmpty(resString))
                    resString = eff.Name;
                else
                    resString += "," + eff.Name;
            }
            return resString;
        }

        private CMEquivalenceClassUI newClone(CMElementUI __ElementParent)
        {
            CMEquivalenceClassUI cloneEquivalence = new CMEquivalenceClassUI(__ElementParent);

            return cloneEquivalence;
        }

        #endregion

        #region Public methods

        public CMEquivalenceClassUI(CMElementUI __maskElement)
        {
            if (__maskElement == null)
            {
                _equivalenceClassReal = new EquivalenceClass();
            }
            else
            {
                _equivalenceClassReal = new EquivalenceClass(__maskElement.getRealObject() as Element);
                __maskElement.addEquivalenceClass(this);
            }
        }

        public CMEquivalenceClassUI(CMElementUI __maskElement, CMEquivalenceClassUI __eqClass)
        {
            _equivalenceClassReal = new EquivalenceClass(__maskElement.getRealObject() as Element);
            __maskElement.addEquivalenceClass(this);
            copyAttributesFrom(__eqClass);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="__equivalenceClass"></param>
        public CMEquivalenceClassUI(EquivalenceClass __equivalenceClass)
        {
            _equivalenceClassReal = __equivalenceClass;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CMEquivalenceClassUI()
        {
            _equivalenceClassReal = new EquivalenceClass();
            //_effectCollection = null;
        }


        public void Remove()
        {
            CMEquivalenceClassCollectionUI owner = Owner as CMEquivalenceClassCollectionUI;
            if (owner != null)
                owner.Remove(this);
            Element realElement = _parentElement.getRealObject() as Element;
            if (realElement != null)
                realElement.RemoveEquivalenceClass(getRealObject() as EquivalenceClass);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            // safe because of the GetType check
            CMEquivalenceClassUI eq = (CMEquivalenceClassUI) obj;
            // use this pattern to compare value members
            if (!EquivalenceClassId.Equals(eq.EquivalenceClassId)) return false;
            return true;
        }

        public void copyAttributesFrom(CMEquivalenceClassUI __eqFrom)
        {
            StateId = __eqFrom.StateId;
            Value = __eqFrom.Value;
            Description = __eqFrom.Description;
            RiskLevel = __eqFrom.RiskLevel;
            isMarked = __eqFrom.isMarked;
        }

        public CMEquivalenceClassUI Clone(CMElementUI __ElementParent)
        {
            CMEquivalenceClassUI cloneEquivalence = newClone(__ElementParent);
            cloneEquivalence.EquivalenceClassId = EquivalenceClassId;
            cloneEquivalence.copyAttributesFrom(this);

            //foreach (CMEffectUI ef in Effects) {
            //    CMEffectUI newEf = ef.Clone();
            //    cloneEquivalence.addEffect(newEf);
            //}
            return cloneEquivalence;
        }

        public void copyFromClone(CMEquivalenceClassUI __ClonedEqClass)
        {
            if (!__ClonedEqClass.EquivalenceClassId.Equals(EquivalenceClassId))
                throw new Exception("The cloned element do not correspond to the target.");


            /*Copy attributes*/
            StateId = __ClonedEqClass.StateId;
            Value = __ClonedEqClass.Value;
            Description = __ClonedEqClass.Description;
            RiskLevel = __ClonedEqClass.RiskLevel;

            /*Copy Effects*/
            //Effects.Copy(__ClonedEqClass.Effects);
        }

        #endregion

        #region Testing methods

        public static CMEquivalenceClassUI getEquivTest()
        {
            CMEquivalenceClassUI eq1 = new CMEquivalenceClassUI();

            //eq1.EquivalenceClassId = 1;
            ////eq1.Name = "equ1";
            //eq1.StateId = 0;
            //eq1.Value = "valor1";
            //eq1.RiskLevel = 10;
            //eq1.Description = "Test equivalenceClass";

            //CMEffectUI ef1 = new CMEffectUI();
            //CMEffectUI ef2 = new CMEffectUI();

            //ef1.EffectId = "1";
            //ef1.EffectName = "effec1";
            //ef1.Description = "description1";
            //ef1.State = "0";
            //ef1.Value = "value1";
            //ef1.RiskLevel = 1;

            //ef2.EffectId = "2";
            //ef2.EffectName = "effec2";
            //ef2.Description = "description2";
            //ef2.State = "0";
            //ef2.Value = "value2";
            //ef2.RiskLevel = 2;


            //eq1.addEffect(ef1);
            //eq1.addEffect(ef2);

            return eq1;
        }

        #endregion

        #region IMaskClass Members

        public Object getRealObject()
        {
            return _equivalenceClassReal;
        }

        #endregion
    }
}