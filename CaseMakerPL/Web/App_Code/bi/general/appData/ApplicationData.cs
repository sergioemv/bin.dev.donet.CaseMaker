using System;
using bi.general.enumerates.main;

namespace bi.general.appData
{
    /// <summary>
    /// Saves data for the entire application, like version, defaul theme app and others.
    /// Done by: portiz 2008-01-30
    /// </summary>
    public class ApplicationData
    {
        #region Constants

        #endregion

        #region Enumerates

        #endregion

        #region Auxiliar classes

        #endregion

        #region Attributes

        private readonly String _strVersionNumber;
        private String _strDefaultTheme;
        private String _strRoot_Path;

        #endregion

        #region Properties

        /// <summary>
        /// Version of the system
        /// </summary>
        public String VersionNumber
        {
            get { return _strVersionNumber; }
        }

        /// <summary>
        /// Default theme
        /// </summary>
        public String DefaultTheme
        {
            get { return _strDefaultTheme; }
            set { _strDefaultTheme = value; }
        }

        public string Root_Path
        {
            get { return _strRoot_Path; }
            set { _strRoot_Path = value; }
        }

        #endregion

        #region Private, protected methods

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor of the class
        /// </summary>
        public ApplicationData()
        {
            try
            {
                _strVersionNumber = StaticObjects.getWCMConstants.getValue(eWCMConstants.version_number);
                DefaultTheme = StaticObjects.getWCMConstants.getValue(eWCMConstants.theme);
                _strRoot_Path = StaticObjects.getWCMConstants.getValue(eWCMConstants.root_path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    } //end of class
} //end of namespace