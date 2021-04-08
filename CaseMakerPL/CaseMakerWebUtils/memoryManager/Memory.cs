using System;
using System.Collections;
using System.Web;

namespace CaseMakerWebUtils.memoryManager
{
    /// <summary>
    /// Memory class saves data (casting like objects), in a specific place, hashed by a key.
    /// There are three memory types managed in this class:
    /// *Temporal: saves data in the current session, but temporary (should be erased in the navigation
    /// between modules)
    /// *Session: saves data in the current session, but the purpose is not to be deleted (eg.- the logged user data must 
    /// be available in all the system)
    /// *Application: saves data for all the applications. Data will be accessed by any user.
    /// 
    /// Done by: portiz 27-12-07
    /// </summary>
    public class Memory
    {
        #region Constants

        private const String SPACE_STRING_TEMP = "utils.memoryManager.TEMP";
        private const String SPACE_STRING_SESSION = "utils.memoryManager.SESSION";
        private const String SPACE_STRING_APP = "utils.memoryManager.APP";

        #endregion

        #region Enumerates

        #endregion

        #region Auxiliar classes

        #endregion

        #region Attributes

        private eMemoryType _type;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of memory that represents
        /// </summary>
        public eMemoryType Type
        {
            get { return _type; }
        }

        #endregion

        #region Private, protected methods

        /// <summary>
        /// Get the current memory.
        /// </summary>
        /// <returns>A hashtable where all objects are saved</returns>
        private Hashtable getMemory()
        {
            string strKey;
            switch (Type)
            {
                case eMemoryType.tempMemory:
                    strKey = SPACE_STRING_TEMP;
                    break;
                case eMemoryType.sessionMemory:
                    strKey = SPACE_STRING_SESSION;
                    break;
                default:
                    strKey = SPACE_STRING_APP;
                    break;
            }
            if (Type == eMemoryType.appMemory)
            {
                if (HttpContext.Current.Application[strKey] == null)
                    HttpContext.Current.Application[strKey] = new Hashtable();
                return (Hashtable) HttpContext.Current.Application[strKey];
            }
            else
            {
                if (HttpContext.Current.Session[strKey] == null)
                    HttpContext.Current.Session[strKey] = new Hashtable();
                return (Hashtable) HttpContext.Current.Session[strKey];
            }
        }

        /// <summary>
        /// Sets a hash table with the data
        /// </summary>
        /// <param name="__hashTable">Hash table with data</param>
        private void setMemory(Hashtable __hashTable)
        {
            string strKey;
            switch (Type)
            {
                case eMemoryType.tempMemory:
                    strKey = SPACE_STRING_TEMP;
                    break;
                case eMemoryType.sessionMemory:
                    strKey = SPACE_STRING_SESSION;
                    break;
                default:
                    strKey = SPACE_STRING_APP;
                    break;
            }
            if (Type == eMemoryType.appMemory)
            {
                HttpContext.Current.Application[strKey] = __hashTable;
            }
            else
                HttpContext.Current.Session[strKey] = __hashTable;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor
        /// By default, the temporary memory is set.
        /// </summary>
        public Memory()
        {
            //default
            _type = eMemoryType.tempMemory;
        }

        /// <summary>
        /// Constructor with a certain type or memory.
        /// </summary>
        /// <param name="__type"></param>
        public Memory(eMemoryType __type)
        {
            _type = __type;
        }

        /// <summary>
        /// Set al object to the memory, to be saved.
        /// </summary>
        /// <param name="__strKey">Key to hash</param>
        /// <param name="__obj">Object to save</param>
        public void setMemory(String __strKey, Object __obj)
        {
            getMemory()[__strKey] = __obj;
        }

        /// <summary>
        /// Get an object from the memory.
        /// </summary>
        /// <param name="__strKey">Key of hashing</param>
        /// <returns>Object saved (or null, if hash key-object are nor correct)</returns>
        public Object getMemory(String __strKey)
        {
            return getMemory()[__strKey];
        }

        /// <summary>
        /// Delete all objects in memory.
        /// </summary>
        public void clearMemory()
        {
            //Garbage collector will erase them.
            setMemory(null);
        }

        #endregion
    }
}