using System;
using System.Collections.Generic;

namespace CaseMaker.Entities.Testdata
{
    public class CMDefaultParameter : ICMParameter
    {
        private FormulaParameter parameterType;
        private ICMValue result;


        public CMDefaultParameter(FormulaParameter p_formulaParameter)
        {
            parameterType = p_formulaParameter;
        }

        public CMDefaultParameter(FormulaParameter p_formulaParameter, ICMValue p_icmvalue)

        {
            parameterType = p_formulaParameter;
            result = p_icmvalue;
        }


        public FormulaParameter ParameterType
        {
            get { return parameterType; }
            set { parameterType = value; }
        }

        public ICMValue Result
        {
            get { return result; }
            set { result = value; }
        }

        public IList<object> Parameter
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public FormulaCategory Category
        {
            get { throw new NotImplementedException(); }
        }

        public Formulas FormulaEnum
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Formulas getFormulaEnum()
        {
            throw new NotImplementedException();
        }

        public string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public string getTypeFormula()
        {
            throw new NotImplementedException();
        }

        public void addParameter(object p_parameter)
        {
            throw new NotImplementedException();
        }

        public object getParameter(FormulaParameter p_formulaParameter)
        {
            throw new NotImplementedException();
        }

        public object Value
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public object clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(ICMValue other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(ICMValue other)
        {
            throw new NotImplementedException();
        }
    }
}