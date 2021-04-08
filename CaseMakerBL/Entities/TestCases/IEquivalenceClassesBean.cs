using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IEquivalenceClassesBean
    {
        IList<EquivalenceClass> EquivalenceClasses { get; set; }

        void AddEquivalenceClass(EquivalenceClass equivalenceClass);
        void RemoveEquivalenceClass(EquivalenceClass equivalenceClass);
    }
}