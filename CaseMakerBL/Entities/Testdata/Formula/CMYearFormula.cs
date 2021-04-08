using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMYearFormula : CMAbstractFormula
    {
        public CMYearFormula()
        {
            FormulaEnum = Formulas.YEAR;
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