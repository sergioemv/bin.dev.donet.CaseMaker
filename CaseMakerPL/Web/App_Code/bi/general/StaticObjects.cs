using System;
using bi.general.appData;
using bi.general.appData.wcmConstants;
using CaseMakerWebUtils.storeData;

//using CMUtils.language;

/// <summary>
/// Contain objects that can be accesed without instanciate them.
///  Done by: portiz 27-12-07
/// </summary>
public class StaticObjects
{
    #region Constants

    #endregion

    #region Enumerates

    #endregion

    #region Auxiliar classes

    #endregion

    #region Attributes

    private static wcmConstants _myWcmConstants;
    private static ApplicationData _myApplicationData;
    private static StoraDataList _myStoraDataList;

    //TODO: Paulo, repair this Language
    //private static LanguageManager _myLanguageManager; 

    #endregion

    #region Properties

    #endregion

    #region Private, protected methods

    #endregion

    #region Public methods

    /// <summary>
    /// Gets the object that represents the general constants of casemaker
    /// </summary>
    public static wcmConstants getWCMConstants
    {
        get
        {
            if (_myWcmConstants == null)
                _myWcmConstants = new wcmConstants();
            return _myWcmConstants;
        }
    }

    /// <summary>
    /// Gets the object that saves the information of the application
    /// </summary>
    public static ApplicationData getApplicationData
    {
        get
        {
            if (_myApplicationData == null)
                _myApplicationData = new ApplicationData();
            return _myApplicationData;
        }
    }


    //TODO: Paulo, repair this (language)
    ///// <summary>
    ///// Gets the object that saves the information of the application
    ///// </summary>
    //public static LanguageManager getLanguageManager {
    //    get {
    //        if (_myLanguageManager == null)
    //            _myLanguageManager = new LanguageManager();
    //        return _myLanguageManager;
    //    }
    //}


    /// <summary>
    /// Gets the object store data in config.xml file
    /// </summary>
    public static StoraDataList getStoreData
    {
        get
        {
            //this object fills in global.asax
            if (_myStoraDataList == null)
                throw new Exception("StoreDataList not initialized");
            return _myStoraDataList;
        }
        set { _myStoraDataList = value; }
    }

    #endregion
}