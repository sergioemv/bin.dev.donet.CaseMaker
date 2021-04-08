using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMAddDayFormula : CMAbstractFormula
    {
        public CMAddDayFormula()
        {
            FormulaEnum = Formulas.ADD_DAY;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            DateTime param1 = (DateTime) getCalculatedParameter(FormulaParameter.DATE);
            double param2 = (long) getCalculatedParameter(FormulaParameter.DAY);
            param1.AddDays(param2);
            return param1;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}