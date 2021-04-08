using System;
using System.Collections.Generic;

namespace CaseMaker.Entities.Testdata
{
    public abstract class CMAbstractFormula : ICMFormula
    {
        private IList<object> parameterList = null;
        private static Formulas formulaEnum;

        public CMAbstractFormula()

        {
            parameterList = new List<Object>();
        }

        public object Value
        {
            get { return calculate(); }
            set { }
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

        public IList<object> Parameter
        {
            get { return parameterList; }
            set { parameterList = value; }
        }

        public FormulaCategory Category
        {
            get { return CMFormulas.getCategory(formulaEnum); }
        }

        public Formulas FormulaEnum
        {
            get { return formulaEnum; }
            set { formulaEnum = value; }
        }

        public abstract string getFormattedValueResult();

        public string getTypeFormula()
        {
            return CMFormulas.getTypeFormula(FormulaEnum);
        }

        public void addParameter(object p_parameter)
        {
            IList<FormulaParameter> list = new List<FormulaParameter>();
            foreach (Object parameter in parameterList)
            {
                list.Add(((CMDefaultParameter) parameter).ParameterType);
            }
            if (!list.Contains((((CMDefaultParameter) p_parameter).ParameterType)))
            {
                parameterList.Add(p_parameter);
            }
        }

        public object getParameter(FormulaParameter p_formulaParameter)
        {
            if (parameterList == null)

            {
                parameterList = new List<Object>();
            }
            foreach (Object obj in parameterList)
            {
                if (((ICMParameter) obj).ParameterType == p_formulaParameter)
                {
                    return obj;
                }
            }
            CMDefaultParameter defaultParam = new CMDefaultParameter(p_formulaParameter);
            parameterList.Add(defaultParam);
            return defaultParam;
        }


        /**
	 * @param formulaParameter, needed to begin a search in the List of parameters that posses any ICMFormula object.
	 * this method if find a ICMFormula as parameters, it calls the method getResult, always returns an Object(Numeric, Date, String).
	 * ready to be used in the ICMFormula where it where call.
	 * 
	 * @return always return an Object (Numeric, Date, String).
	 * 15/11/2006
	 * svonborries
	 * @throws Exception 
	 */

        public Object getCalculatedParameter(FormulaParameter p_formulaParameter)
        {
            foreach (Object parameter in parameterList)
            {
                if (((ICMParameter) parameter).ParameterType == p_formulaParameter)
                {
                    return ((ICMParameter) parameter).Result;
                }
            }
            return null;
        }


        /**
	 * 
	 * 28/09/2006
	 * svonborries
	 * Method used for the calculate of the formula
	 * first than all is necessary to set the respective parameters
	 * in case the formula don't has any parameter, this step is jumped
	 * @throws Exception 
	 */
        public abstract Object calculate();

        public new abstract string ToString();
    }
}