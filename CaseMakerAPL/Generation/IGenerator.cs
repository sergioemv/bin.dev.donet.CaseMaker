using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Generation
{
    public interface IGenerator
    {
        
        IUndoableEdit Generate();
    }
}