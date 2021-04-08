using System;

namespace bi.maskClasses.testCases
{
    /// <summary>
    /// Delegates an event that receive an element mask.
    /// </summary>
    /// <param name="__element">Receives an element mask</param>
    public delegate void selectedCMElementUI(Object __element);

    /// <summary>
    /// elegates an event that receive an dependency id.
    /// </summary>
    /// <param name="__dependencyId"></param>
    public delegate void selectedCMDependencyUI(int __dependencyId);
}