using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMDateNowFormula : CMAbstractFormula
    {
        public CMDateNowFormula()
        {
            FormulaEnum = Formulas.DATE_NOW;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            return DateTime.Now;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}