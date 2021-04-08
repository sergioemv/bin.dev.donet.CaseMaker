using System;
using System.Collections.Generic;
using AjaxPro;
using CaseMaker.Entities.Testcases;

namespace bi.maskClasses.testCases.CMEffectUIClass
{
    // Autor: portiz
    // Description: this class wraps a effect from CaseMakerBL.
    [AjaxNamespace("CMEffectUIAjaxPro")]
    public class CMEffectUI
    {
        #region Attributes

        private int id;
        private string description;
        private int position;
        private State effectState = State.POSITIVE;
        private int riskLevel;
        private const string NAME_PREFIX = "CE";
        private int hashCodeIdentifier = -1;
        private Effect _RealEffect = null;

        //auxiliar properties
        //--------------------
        private bool isNewEffect = false;
        private int newEffectIndex = 0;
        private bool wasModified = false;

        #endregion

        #region Properties

        [AjaxNonSerializable]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public State EffectState
        {
            get { return effectState; }
            set { effectState = value; }
        }

        public int RiskLevel
        {
            get { return riskLevel; }
            set { riskLevel = value; }
        }

        public string Name
        {
            //get {
            //    if (IsNewEffect)
            //        return "New " + NAME_PREFIX + "_" + NewEffectIndex;
            //    else {
            //        if (Id == 0)
            //            return "New Effect " + Id;
            //        else
            //            return NAME_PREFIX + Id;
            //    }
            //}
            get { return NAME_PREFIX + fixNamePosition(position); }
        }

        public int HashCodeIdentifier
        {
            get
            {
                if (hashCodeIdentifier == -1)
                    return base.GetHashCode();
                else
                    return hashCodeIdentifier;
            }
            set { hashCodeIdentifier = value; }
        }

        public bool IsNewEffect
        {
            get { return isNewEffect; }
            set { isNewEffect = value; }
        }

        public bool WasModified
        {
            get { return wasModified; }
            set { wasModified = value; }
        }

        public override int GetHashCode()
        {
            return HashCodeIdentifier;
        }

        #endregion

        #region Ajax manual callbacs

        [AjaxNonSerializable]
        public int NewEffectIndex
        {
            get { return newEffectIndex; }
            set { newEffectIndex = value; }
        }

        [AjaxNonSerializable]
        public Effect RealEffect
        {
            get { return _RealEffect; }
            set { _RealEffect = value; }
        }

        #endregion

        #region Private Methods

        //Helps to visualize the name of the effect
        private static String fixNamePosition(int __position)
        {
            String result = __position.ToString();
            while (result.Length < 3)
                result = "0" + result;
            return result;
        }

        #endregion

        #region Public Methods

        // Indicates if an object is the same, checking the id of the element.
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            // safe because of the GetType check
            CMEffectUI ele = (CMEffectUI) obj;
            // use this pattern to compare value members
            if (Id == 0 || ele.Id == 0)
                return Name.Equals(ele.Name);
            return (Id.Equals(ele.Id));
        }

        public CMEffectUI()
        {
        }

        public CMEffectUI(Effect __RealEffect)
        {
            id = __RealEffect.Id;
            Description = __RealEffect.Description;
            EffectState = __RealEffect.CurrentState;
            Position = __RealEffect.Position;
            RiskLevel = __RealEffect.RiskLevel;
            hashCodeIdentifier = __RealEffect.GetHashCodeReal();
            _RealEffect = __RealEffect;
        }

        public void copyAttributesToEffectReal(Effect __realEffect)
        {
            __realEffect.Description = Description;
            __realEffect.CurrentState = EffectState;
            __realEffect.RiskLevel = RiskLevel;
            __realEffect.Position = Position;
        }

        public void updateRealReference()
        {
            if (_RealEffect != null)
            {
                _RealEffect.RiskLevel = RiskLevel;
                _RealEffect.CurrentState = EffectState;
                _RealEffect.Description = Description;
                _RealEffect.Position = Position;
                //no reasign hashcode, because the actual hashcode is needed to hash other collections
            }
        }

        #endregion

        #region "Test Metods"

        public static CMEffectUI getTestData()
        {
            CMEffectUI ef = new CMEffectUI();
            ef.Id = 1;
            ef.Description = "description";
            ef.RiskLevel = 6;
            ef.EffectState = State.POSITIVE;
            return ef;
        }

        public static IList<CMEffectUI> getTestDataCollection()
        {
            IList<CMEffectUI> list = new List<CMEffectUI>();

            CMEffectUI ef = new CMEffectUI();
            ef.Id = 1;
            ef.Description = "description1";
            ef.RiskLevel = 6;
            ef.EffectState = State.POSITIVE;

            CMEffectUI ef2 = new CMEffectUI();
            ef.Id = 2;
            ef.Description = "description2";
            ef.RiskLevel = 10;
            ef.EffectState = State.FAULTY;

            list.Add(ef);
            list.Add(ef2);

            return list;
        }

        #endregion
    }
}