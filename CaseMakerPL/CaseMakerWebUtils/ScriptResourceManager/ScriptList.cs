using System;
using System.Collections;
using System.Collections.Generic;

namespace CaseMakerWebUtils.ScriptResourceManager
{
    /// <summary>
    /// This class keeps the ubication absolute of the scripts, masking them with the url path.
    /// This is for avoiding inculde the same script and for an easy naming path
    /// EG: javascript/Script.js -> http://locahost:8080/WCM/javascript/Script.js
    /// 
    /// Done by: portiz 2008-01-28
    /// </summary>
    public class ScriptList
    {
        #region Constants

        #endregion

        #region Enumerates

        #endregion

        #region Auxiliar classes

        #endregion

        #region Attributes

        private List<keyValueScript> _htScriptsList;
        private readonly String _strRoot = "";

        #endregion

        #region Properties

        /// <summary>
        /// Gets the base root of all scripts
        /// </summary>
        public String Root
        {
            get { return _strRoot; }
        }

        #endregion

        #region Private, protected methods

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="__strRoot">Base roor for all scripts</param>
        public ScriptList(String __strRoot)
        {
            _htScriptsList = new List<keyValueScript>();
            _strRoot = __strRoot;
        }

        /// <summary>
        /// Delete all scripts
        /// </summary>
        public void cleanAllScriptReferences()
        {
            _htScriptsList.Clear();
        }

        /// <summary>
        /// Get the reference of all the values
        /// </summary>
        /// <returns>ICollection interface</returns>
        public ICollection getAllValues()
        {
            ArrayList l = new ArrayList();
            foreach (keyValueScript kv in _htScriptsList)
            {
                l.Add(kv.Value);
            }
            return l;
        }

        /// <summary>
        /// Get the reference of all the keys
        /// </summary>
        /// <returns>ICollection interface</returns>
        public ICollection getAllKeys()
        {
            ArrayList l = new ArrayList();
            foreach (keyValueScript kv in _htScriptsList)
            {
                l.Add(kv.Key);
            }
            return l;
        }

        /// <summary>
        /// Get a specific script
        /// </summary>
        /// <param name="__strKey">Key of hashing</param>
        /// <returns>A string that represents a script's path</returns>
        public String getValue(String __strKey)
        {
            ArrayList l = new ArrayList();
            foreach (keyValueScript kv in _htScriptsList)
            {
                if (kv.Key.Equals(__strKey))
                    return kv.Value;
            }
            return null;
        }

        /// <summary>
        /// Add a script path and it hash code access
        /// </summary>
        /// <param name="__strKey">Key for hashing</param>
        /// <param name="__strScriptReference">A string that represents a script's path</param>
        public void addScriptReference(String __strKey, String __strScriptReference)
        {
            if (!existScriptReference(__strKey))
                _htScriptsList.Add(new keyValueScript(__strKey, Root + __strScriptReference));
        }

        /// <summary>
        /// Delete a script path
        /// </summary>
        /// <param name="__strKey"></param>
        public void deleteScriptReference(String __strKey)
        {
            foreach (keyValueScript kv in _htScriptsList)
            {
                if (kv.Key.Equals(__strKey))
                {
                    _htScriptsList.Remove(kv);
                }
            }
        }

        /// <summary>
        /// Consult if a script key exists
        /// </summary>
        /// <param name="__strKey">Key of hashing</param>
        /// <returns>True if the hashing key exists</returns>
        public Boolean existScriptReference(String __strKey)
        {
            foreach (keyValueScript kv in _htScriptsList)
            {
                if (kv.Key.Equals(__strKey))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}