using System.ComponentModel;

namespace CaseMaker.Entities.Testcases
{
    public enum State:  byte 
    {
        [Description("+")]
        POSITIVE= 0,
        [Description("-")]
        NEGATIVE = 1,
        [Description("F")]
        FAULTY = 2,
        [Description("I")]
        IRRELEVANT = 3
    }

}