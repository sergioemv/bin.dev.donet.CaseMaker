namespace CaseMakerWebUtils.memoryManager
{
    /// <summary>
    /// Define the type of the memory.
    /// 
    /// Done by: portiz 27-12-07
    /// <remarks>
    /// There are three types of memory identified:
    /// <list type="bullet">
    ///     <item>tempMemory: it's temporal, and will be deleted in the pass from one module to other.</item>
    ///     <item>sessionMemory: it's for the current session. not so temporal.</item>
    ///     <item>appMemory: For all the application (all users could see this).</item>
    /// </list>
    /// </remarks>
    /// </summary>
    ///Types of memory available
    public enum eMemoryType
    {
        tempMemory,
        sessionMemory,
        appMemory
    }

    /// <summary>
    /// This class manages the passess of objects and values.
    /// Done by: portiz 27-12-07
    /// </summary>
    public class MemoryManager
    {
        #region Constants

        #endregion

        #region Enumerates

        #endregion

        #region Auxiliar classes

        #endregion

        #region Attributes

        private readonly Memory _tempMemory;
        private readonly Memory _sessionMemory;
        private readonly Memory _AppMemory;

        #endregion

        #region Properties

        /// <summary>
        /// Memory for temporal data
        /// </summary>
        public Memory TempMemory
        {
            get { return _tempMemory; }
        }

        /// <summary>
        /// Memory for session data.
        /// </summary>
        public Memory SessionMemory
        {
            get { return _sessionMemory; }
        }

        /// <summary>
        /// Memory for all the application.
        /// </summary>
        public Memory AppMemory
        {
            get { return _AppMemory; }
        }

        #endregion

        #region Private, protected methods

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public MemoryManager()
        {
            _tempMemory = new Memory(eMemoryType.tempMemory);
            _sessionMemory = new Memory(eMemoryType.sessionMemory);
            _AppMemory = new Memory(eMemoryType.appMemory);
        }

        /// <summary>
        /// Clear the temporally memory data.
        /// </summary>
        public void clearTempMemory()
        {
            _tempMemory.clearMemory();
        }

        #endregion
    }
}