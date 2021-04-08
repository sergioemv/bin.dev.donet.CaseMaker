using System;

namespace bi.general.appData.appData
{
    /// <summary>
    /// Saves data for the current session, like current theme
    /// Done by: portiz 2008-01-30
    /// </summary>
    public class SessionData
    {
        #region Constants

        #endregion

        #region Enumerates

        #endregion

        #region Auxiliar classes

        #endregion

        #region Attributes

        private String _strCurrentTheme;

        #endregion

        #region Properties

        /// <summary>
        /// Current theme of the session
        /// </summary>
        public String CurrentTheme
        {
            get { return _strCurrentTheme; }
            set { _strCurrentTheme = value; }
        }

        #endregion

        #region Private, protected methods

        #endregion

        #region Public methods

        //Constructor
        public SessionData()
        {
            _strCurrentTheme = "Default";
        }

        #endregion
    }
}