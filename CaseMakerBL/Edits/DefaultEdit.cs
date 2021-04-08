namespace CaseMaker.Edits
{
    public delegate void EditHandle<T>(T receiver, DefaultEditParams editParams);
    public class PropertyEditParameters : DefaultEditParams
    {
        private readonly string propertyName;
        private readonly object value;

        public PropertyEditParameters(string propertyName, object value)
        {
            this.propertyName = propertyName;
            this.value = value;
        }

        public string PropertyName
        {
            get { return propertyName; }
        }

        public object Value
        {
            get { return value; }
        }
    }
    public class RelationEditParameters : DefaultEditParams
    {
        private readonly object related;

        public RelationEditParameters(object related)
        {
            this.related = related;
        }
        public object Related
        {
            get { return related; }
        }
    }
    public interface DefaultEditParams
    {
    }

    public class DefaultEdit<T>:AbstractUndoableEdit
    {
        private readonly T receiver;
        private readonly EditHandle<T> redo;
        private readonly EditHandle<T> undo;
        private DefaultEditParams undoParams;
        private DefaultEditParams redoParams;

        public DefaultEdit(T receiver, EditHandle<T> redo, DefaultEditParams redoParams, EditHandle<T> undo, DefaultEditParams undoParams)
        {
            this.receiver = receiver;
            this.RedoParams = redoParams;
            this.UndoParams = undoParams;
            this.undo = undo;
            this.redo = redo;
        }

        public DefaultEdit(T receiver, EditHandle<T> redo, EditHandle<T> undo )
        {
            this.receiver = receiver;
            this.undo = undo;
            this.redo = redo;
        }

        public DefaultEdit(T receiver, EditHandle<T> redo, EditHandle<T> undo,object related)
        {
            this.receiver = receiver;
            this.undo = undo;
            this.redo = redo;
            SetRelatedObject(related);
        }

        public DefaultEditParams UndoParams
        {
            get { return undoParams; }
            set { undoParams = value; }
        }

        public DefaultEditParams RedoParams
        {
            get { return redoParams; }
            set { redoParams = value; }
        }

        public override void Undo()
        {
            base.Undo();
            if (undo != null)
               undo(receiver,UndoParams);
        }

        public override void Redo()
        {
            base.Redo();
            if (redo != null)
                redo(receiver,RedoParams);
        }

        public void SetRelatedObject(object related)
        {
            UndoParams = new RelationEditParameters(related);
            RedoParams = new RelationEditParameters(related);
        }
    }
}
