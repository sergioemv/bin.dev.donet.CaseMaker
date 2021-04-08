using System;

namespace bi.maskClasses.testCases
{
    public interface IMaskClass
    {
        /// <summary>
        /// Returns a real object, that the mask wraps.
        /// </summary>
        /// <returns></returns>
        Object getRealObject();
    }
}