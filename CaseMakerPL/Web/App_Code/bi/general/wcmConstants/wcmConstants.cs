using System;
using System.Collections;
using bi.general.enumerates.main;

/// <summary>
/// Saves data for the entire application, like version, defaul theme app and others.
/// Done by: portiz 2008-01-30
/// </summary>
namespace bi.general.appData.wcmConstants
{
    /// <summary>
    /// Saves data for the entire application, like version, defaul theme app and others.
    /// Done by: portiz 2008-01-30
    /// </summary>
    public class wcmConstants
    {
        #region Constants

        #endregion

        #region Enumerates

        #endregion

        #region Auxiliar classes

        #endregion

        #region Attributes

        private readonly Hashtable _htConstants;

        #endregion

        #region Properties

        #endregion

        #region Private, protected methods

        /// <summary>
        /// Load the values from the repository
        /// </summary>
        private void loadValues()
        {
            try
            {
                _htConstants.Add(eWCMConstants.root_path.ToString(),
                                 StaticObjects.getStoreData.getData(eWCMConstants.root_path.ToString()).Value);
                _htConstants.Add(eWCMConstants.theme.ToString(),
                                 StaticObjects.getStoreData.getData(eWCMConstants.theme.ToString()).Value);
                _htConstants.Add(eWCMConstants.version_number.ToString(),
                                 StaticObjects.getStoreData.getData(eWCMConstants.version_number.ToString()).Value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor
        /// </summary>
        public wcmConstants()
        {
            try
            {
                _htConstants = new Hashtable();
                loadValues();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Obtain a value from the data list of "constants" (they are really enumerates)
        /// </summary>
        /// <param name="__eValue"></param>
        /// <returns></returns>
        public String getValue(eWCMConstants __eValue)
        {
            if (!_htConstants.ContainsKey(__eValue.ToString()))
                throw new Exception("The key doen't exist");
            return _htConstants[__eValue.ToString()] as String;
        }

        #endregion
    }
}