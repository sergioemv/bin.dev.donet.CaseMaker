//Author Sergio Moreno
// port of the java implemementation UndoableEdit
namespace CaseMaker.Edits
{
    public interface IUndoableEdit
    {
        //undo the operation
        void Undo();
        //is the undo possible
        bool CanUndo();
        //redo the operation
        void Redo();
        //is the redo possible
        bool CanRedo();
        
        //May be sent to inform an edit that it should no longer be
        // used. This is a useful hook for cleaning up state no longer
        //needed once undoing or redoing is impossible,
        void Die();
        //This UndoableEdit should absorb <code>anEdit</code>
        //if it can. Returns true
        //if <code.anEdit</code> has been incorporated, false if it has not.
        //Typically the receiver is already in the queue of a
        //<code>LimitQueueEdit</code> (or other <code>UndoableEditListener</code>), 
       //and is being given a chance to incorporate <code>anEdit</code>   
        //rather than letting it be added to the queue in turn 
        //<p>If true is returned, from now on <code>anEdit</code> must return
        //false from <code>canUndo</code> and <code>canRedo</code>,
        //and must throw the appropriate exception on <code>undo</code> or
        //<code>redo</code>.</p>
        bool AddEdit(IUndoableEdit edit);
         //Returns true if this <code>UndoableEdit</code> should replace
         //<code>anEdit</code>. The receiver should incorporate
         //<code>anEdit</code>'s state before returning true.    
         //<p>This message is the opposite of addEdit--anEdit has typically
         //already been queued in a <code>LimitQueueEdit</code> (or other
         //UndoableEditListener), and the receiver is being given a chance
         //to take its place.</p>
         //<p>If true is returned, from now on anEdit must return false from
         //canUndo() and canRedo(), and must throw the appropriate
         //exception on undo() or redo().</p>

        bool ReplaceEdit(IUndoableEdit edit);
        //Returns false if this edit is insignificant--for example one
        //that maintains the userLocked's selection, but does not change any
        //model state. This status can be used by an 
        //<code>UndoableEditListener</code>
        //(like LimitQueueEdit) when deciding which UndoableEdits to present
        //to the userLocked as Undo/Redo options, and which to perform as side
        //effects of undoing or redoing other events.
        bool isSignificant();

        string GetPresentationName();

    }
}