using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    internal class CMDateFormula : CMAbstractFormula
    {
        public CMDateFormula()
        {
            FormulaEnum = Formulas.DATE;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            int param1 = (int) getCalculatedParameter(FormulaParameter.YEAR);
            int param2 = (int) getCalculatedParameter(FormulaParameter.MONTH);
            int param3 = (int) getCalculatedParameter(FormulaParameter.DAY);
            DateTime date;
            try
            {
                date = new DateTime(param1, param2, param3);
            }
            catch
            {
                throw new Exception();
            }
            return date;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}