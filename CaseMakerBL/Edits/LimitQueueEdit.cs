using System.Collections.Generic;

namespace CaseMaker.Edits
{
    public class LimitQueueEdit:CompoundEdit
    {
        private int indexOfNextAdd;
	    private int limit;
	
	    public LimitQueueEdit() {
	        
	        indexOfNextAdd = 0;
	        Limit = 200;
	        
	    }
	
	    public IList<IUndoableEdit> GetEdits() {return edits;}
	    
	    /**
	     * Empty the undo manager, sending each edit a die message
	     * in the process.
	     */
	    public  void DiscardAllEdits() {
	        foreach (IUndoableEdit ed in edits)
                ed.Die();
	        edits.Clear();
	        indexOfNextAdd = 0;
	    }
	
	    /**
	     * Reduce the number of queued edits to a range of size limit,
	     * centered on indexOfNextAdd.
	     */
	    protected void TrimForLimit() {
	        if (Limit >= 0) {
	            int size = edits.Count;
	
	            if (size > Limit) {
	                int halfLimit = Limit/2;
	                int keepFrom = indexOfNextAdd - 1 - halfLimit;
	                int keepTo   = indexOfNextAdd - 1 + halfLimit;
	
	                // These are ints we're playing with, so dividing by two
	                // rounds down for odd numbers, so make sure the limit was
	                // honored properly. 
	
	                if (keepTo - keepFrom + 1 > Limit) {
	                    keepFrom++;
	                }
	
	                // The keep range is centered on indexOfNextAdd,
	                // but odds are good that the actual edits Vector
	                // isn't. Move the keep range to keep it legal.
	
	                if (keepFrom < 0) {
	                    keepTo -= keepFrom;
	                    keepFrom = 0;
	                }
	                if (keepTo >= size) {
	                    int delta = size - keepTo - 1;
	                    keepTo += delta;
	                    keepFrom += delta;
	                }
	
	
	                TrimEdits(keepTo+1, size-1);
	                TrimEdits(0, keepFrom-1);
	            }
	        }
	    }
	
	    /**
	     * Tell the edits in the given range (inclusive) to die, and
	     * remove them from edits. from > to is a no-op.
	     */
	    protected void TrimEdits(int from, int to) {
	        if (from <= to) {
	            for (int i = to; from <= i; i--) {
	                IUndoableEdit e = edits[i];
	                e.Die();
	                edits.RemoveAt(i);
	            }
	
	            if (indexOfNextAdd > to) {
	                indexOfNextAdd -= to-from+1;
	            } else if (indexOfNextAdd >= from) {
	                indexOfNextAdd = from;
	            }
		        }
	    }
	
	 
	  public int Limit
        {
            get { return limit; }
            set {  
	            limit = value;
	            TrimForLimit(); 
            }
        } 
	
	    /**
	     * Returns the the next significant edit to be undone if undo is
	     * called. May return null
	     */
	    protected IUndoableEdit EditToBeUndone() {
	        int i = indexOfNextAdd;
	        while (i > 0) {
	            IUndoableEdit edit = edits[--i];
	            if (edit.isSignificant()) {
	                return edit;
	            }
	        }
	
	        return null;
	    }
	
	    /**
	     * Returns the the next significant edit to be redone if redo is
	     * called. May return null.
	     * <b>Changes:</b> it return the last insignificant <code>Undoable</code> object, so
	     * the <code>redo</code> method redo all <code>Undoable</code> objects up to <code>EditToBeRedone</code>.
	     */
	    protected IUndoableEdit EditToBeRedone() {
	        int count = edits.Count;
	        int i = indexOfNextAdd;
	
	        while (i < count) {
	        		IUndoableEdit edit = edits[i++];
	                if (i >= count ) {
	                    return edit;
	                }
	                IUndoableEdit nextEdit = edits[i];
	                if (nextEdit.isSignificant()) {
	                    return edit;
	                }
	        }
	        return null;
	    }
	
	    /**
	     * Undoes all changes from indexOfNextAdd to edit. Updates indexOfNextAdd accordingly.
	     */
	    protected void UndoTo(IUndoableEdit edit) {
	        bool done = false;
	        while (!done)

      {
	            IUndoableEdit next = edits[--indexOfNextAdd];
	            next.Undo();
	            done = next == edit;
	        }
	    }
	
	    /**
	     * Redoes all changes from indexOfNextAdd to edit. Updates indexOfNextAdd accordingly.
	     */
	    protected void RedoTo(IUndoableEdit edit) {
	        bool done = false;
	        while (!done) {
	            IUndoableEdit next = edits[indexOfNextAdd++];
	            next.Redo();
	            done = next == edit;
	        }
	    }
	
	    /**
	     * If this LimitQueueEdit is inProgress, undo the last significant
	     * UndoableEdit before indexOfNextAdd, and all insignificant edits back to
	     * it. Updates indexOfNextAdd accordingly.
	     *
	     * <p>If not inProgress, indexOfNextAdd is ignored and super's routine is
	     * called.</p>
	     *
	     * @see CompoundEdit#end
	     */
	    public override void Undo() {
	        if (inProgress) {
	            IUndoableEdit edit = EditToBeUndone();
	            if (edit == null) {
	                throw new CannotUndoException();
	            }
	            UndoTo(edit);
	        } else {
	            base.Undo();
	        }
	    }
	
	    /**
	     * Overridden to preserve usual semantics: returns true if an undo
	     * operation would be successful now, false otherwise
	     */
	    public  override bool CanUndo() {
	        if (inProgress) {
	            IUndoableEdit edit = EditToBeUndone();
	            return edit != null && edit.CanUndo();
	        } else {
	            return base.CanUndo();
	        }
	    }
	
	    /**
	     * If this <code>LimitQueueEdit</code> is <code>inProgress</code>,
	     * redoes the last significant <code>UndoableEdit</code> at
	     * <code>indexOfNextAdd</code> or after, and all insignificant
	     * edits up to it. Updates <code>indexOfNextAdd</code> accordingly.
	     *
	     * <p>If not <code>inProgress</code>, <code>indexOfNextAdd</code>
	     * is ignored and super's routine is called.</p>
	     *
	     * @see CompoundEdit#end
	     */
	    public override void Redo(){
	        if (inProgress) {
	            IUndoableEdit edit = EditToBeRedone();
	            if (edit == null) {
	                throw new CannotRedoException();
	            }
	            RedoTo(edit);
	        } else {
	            base.Redo();
	        }
	    }
	
	    /**
	     * Overridden to preserve usual semantics: returns true if a redo
	     * operation would be successful now, false otherwise
	     */
	    public override bool CanRedo() {
	        if (inProgress) {
	            IUndoableEdit edit = EditToBeRedone();
	            return edit != null && edit.CanRedo();
	        } else {
	            return base.CanRedo();
	        }
	    }
	
	    /**
	     * If inProgress, inserts anEdit at indexOfNextAdd, and removes
	     * any old edits that were at indexOfNextAdd or later. The die
	     * method is called on each edit that is removed is sent, in the
	     * reverse of the order the edits were added. Updates
	     * indexOfNextAdd.
	     *
	     * <p>If not <code>inProgress</code>, acts as a
	     * <code>CompoundEdit</code>.
	     *
	     * @param anEdit the edit to be added
	     * @see CompoundEdit#end
	     * @see CompoundEdit#addEdit
	     */
	    public override bool AddEdit(IUndoableEdit anEdit) {
	        bool retVal;
	
	        // Trim from the indexOfNextAdd to the end, as we'll
	        // never reach these edits once the new one is added.
	        int sizeEdits = edits.Count;
	        TrimEdits(indexOfNextAdd, sizeEdits-1);
	        
            if (anEdit is CompoundEdit)
                ((CompoundEdit)anEdit).EndAllEdits();
            

	        retVal = base.AddEdit(anEdit);
		    if (inProgress) {
		        retVal = true;
		    }   
	
	        // Maybe super added this edit, maybe it didn't (perhaps
	        // an in progress compound edit took it instead. Or perhaps
	        // this LimitQueueEdit is no longer in progress). So make sure
	        // the indexOfNextAdd is pointed at the right place.
	        indexOfNextAdd = edits.Count;
	
	        // Enforce the limit
	        TrimForLimit();
	        return retVal;
	    }
	
	
	    /**
	     * Sending end() to an LimitQueueEdit turns it into a plain old
	     * (ended) CompoundEdit.
	     *
	     * <p> Calls super's end() method (making inProgress false), then
	     * sends die() to the unreachable edits at indexOfNextAdd and
	     * beyond, in the reverse of the order in which they were added.
	     *
	     * @see CompoundEdit#end
	     */
	    public override void End() {
		    base.End();
	        TrimEdits(indexOfNextAdd, edits.Count-1);
	    }
	
	 
	    /**
	     * Returns a string that displays and identifies this
	     * object's properties.
	     *
	     * @return a String representation of this object
	     */
	    public override string ToString() {
	        return base.ToString() + " limit: " + limit +
	            " indexOfNextAdd: " + indexOfNextAdd;
	    }
	

    }
}