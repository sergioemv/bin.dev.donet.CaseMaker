using System;

namespace CaseMaker.Entities.Testdata
{
    public interface ICMValue : IComparable<ICMValue>, IEquatable<ICMValue>
    {
/********************************************************************
	created:	2008/01/14
	created:	14:1:2008   6:37
	filename: 	D:\DataCaseMaker\webCM\Entities\Testdata\ICMValue.cs
	file path:	D:\DataCaseMaker\webCM\Entities\Testdata
	file base:	ICMValue
	file ext:	cs
	author:		svonborries
	
	purpose:
	 * USE toString() METHOD!!!
	 * It returns the value that has to be put in the Formula column, all Objects that implements this interface, should return
	 * something to put in Formula Column, in the case that User introduce an Natural Object(String, Number, Date), this toString()
	 * must return an empty String ("");
	 * 23/11/2006
	 * svonborries
	 
*********************************************************************/


        /* @return The Object that is the result of the formula, if the formula returns a Date, this method will return that kind of Object
	 * This method calls the calculate() method of any ICMFormula, if it founds an ICMFormula in the parameter List, it will
	 * call the getResult() of this ICMFormula, and it will recursively calculate all the ICMFormulas, until it can return an Object
	 * (Numeric, Date, String).
	 * If it is another kind of data different than ICMFormula, it will take the Object value, the natural kind of data, it won't take
	 * a String, it will return the original Object
	 * 04/10/2006
	 * svonborries
	 * @throws Exception */

        Object Value { get; set; }


        /**
	 * @return A perfect copy of the Object.
	 * 06/12/2006
	 * svonborries
	 */

        Object clone();
    }
}