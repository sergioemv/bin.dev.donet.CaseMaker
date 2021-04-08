using System;
using System.Collections.Generic;

namespace CaseMaker.Entities.Testdata
{
    public interface ICMFormula : ICMValue
    {
        IList<object> Parameter { get; set; }

        FormulaCategory Category { get; }

        Formulas FormulaEnum { get; set; }

        string getFormattedValueResult();

        string getTypeFormula();

        void addParameter(Object p_parameter);

        Object getParameter(FormulaParameter p_formulaParameter);
    }
}