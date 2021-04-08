using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IDependencyBean
    {
        IList<Dependency> Dependencies { get; set; }
        void AddDependency(Dependency dep);
        void RemoveDependency(Dependency dep);
    }
}