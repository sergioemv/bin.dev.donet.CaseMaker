using System;
using System.Collections.Generic;
using System.ComponentModel;
using CaseMaker.Entities.Testdata.Formula;

namespace CaseMaker.Entities.Testdata
{
    public enum Formulas
    {
        [Description("Date")] DATE,
        [Description("AddDay")] ADD_DAY,
        [Description("AddMonth")] ADD_MONTH,
        [Description("AddYear")] ADD_YEAR,
        [Description("DateNow")] DATE_NOW,
        [Description("DayWeek")] DAY_WEEK,
        [Description("DiffDate")] DIFF_DATE,
        [Description("Hour")] HOUR,
        [Description("Month")] MONTH,
        [Description("Second")] SECOND,
        [Description("Today")] TODAY,
        [Description("Year")] YEAR,
        [Description("Abs")] ABS,
        [Description("Ceil")] CEIL,
        [Description("Floor")] FLOOR,
        [Description("Difference")] DIFFERENCE,
        [Description("Div")] DIV,
        [Description("Exp")] EXP,
        [Description("Fact")] FACT,
        [Description("Ln")] LN,
        [Description("Log")] LOG,
        [Description("Log10")] LOG_10,
        [Description("Max")] MAX,
        [Description("Min")] MIN,
        [Description("Pow")] POW,
        [Description("Product")] PRODUCT,
        [Description("Random")] RANDOM
    }

    public enum FormulaParameter
    {
        [Description("Year")] YEAR,
        [Description("Month")] MONTH,
        [Description("Day")] DAY,
        [Description("Date")] DATE,
        [Description("Date1")] DATE1,
        [Description("Date2")] DATE2,
        [Description("Hour")] HOUR,
        [Description("Number")] NUMBER,
        [Description("Num_Decimals")] DECIMAL,
        [Description("NumX")] NUMBERX,
        [Description("NumY")] NUMBERY,
        [Description("Base")] BASE,
        [Description("Power")] POWER
    }


    internal class CMFormulas
    {
        private Formulas formula;

        public CMFormulas(Formulas p_formula)
        {
            formula = p_formula;
        }

        public Formulas Formula
        {
            get { return formula; }
        }

        public static ICMFormula createFormula(Formulas p_formula)
        {
            ICMFormula icmformula;
            switch (p_formula)
            {
                case Formulas.DATE:
                    icmformula = (ICMFormula) new CMDateFormula();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("p_formula");
            }
            return icmformula;
        }

        public static string getName(Formulas p_formula)
        {
            string name;
            switch (p_formula)
            {
                case Formulas.DATE:
                    name = p_formula.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("p_formula");
            }
            return name;
        }

        public static FormulaCategory getCategory(Formulas p_formula)
        {
            FormulaCategory formulaCategory;
            switch (p_formula)
            {
                case Formulas.DATE:
                    formulaCategory = FormulaCategory.DATE_AND_TIME;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("p_formula");
            }
            return formulaCategory;
        }

        public static string getDescription(Formulas p_formula)
        {
            string description;
            switch (p_formula)
            {
                case Formulas.DATE:
                    description =
                        "Returns the string that represents a determined date. (Year = yyyy; Month = MM; Day = DD ).";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("p_formula");
            }
            return description;
        }

        public static string getCanonicalFormula(Formulas p_formula)
        {
            string canonicalFormula;
            switch (p_formula)
            {
                case Formulas.DATE:
                    canonicalFormula = ("Date" + "(" + "Year" + "; " + "Month" + "; " + "Day" + ")");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("p_formula");
            }
            return canonicalFormula;
        }

        public static IList<FormulaParameter> getAllowedParameter(Formulas p_formula)
        {
            IList<FormulaParameter> formulaParameter;
            switch (p_formula)
            {
                case Formulas.DATE:
                    formulaParameter = new List<FormulaParameter>();
                    formulaParameter.Add(FormulaParameter.YEAR);
                    formulaParameter.Add(FormulaParameter.MONTH);
                    formulaParameter.Add(FormulaParameter.DAY);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("p_formula");
            }
            return formulaParameter;
        }

        public static string getTypeFormula(Formulas p_formula)

        {
            return "";
        }
    }
}