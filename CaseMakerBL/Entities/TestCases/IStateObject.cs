using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IStateObject
    {   
        State CurrentState{ get; set;}
        ISet<IStateObject> GetParentObjectStates();
        ISet<IStateObject> GetChildrenObjectStates();
    }
}