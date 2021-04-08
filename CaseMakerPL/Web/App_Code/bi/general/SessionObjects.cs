using System;
using System.ComponentModel;
using System.Web;
using bi.general.appData.appData;
using bi.general.enumerates.main;
using CaseMaker.Entities;
using CaseMakerWebUtils.memoryManager;
using CaseMakerWebUtils.ScriptResourceManager;

//using CMUtils.language;

/// <summary>
/// Saves the reference to objects that are in session.
/// Done by: portiz 2008-01-30
/// </summary>
public class SessionObjects {
    #region Enumerates

    /// <summary>
    /// Enumerates for the respective objects
    /// </summary>
    private enum eSessionObjects {
        [Description("Manager of memory")]
        memoryManager_Session,

        languageInfo_Session, //Information of the current language
        languageDispenser_Session, //Information and source of language

        [Description("Resource manager for including files (like javascripts)")]
        scriptResourceManager_Session,

        [Description("Information of the current session")]
        sessionData_Session,

        [Description("The CaseMaker current test object")]
        TestObject_Session,

        [Description("The Element Manager")]
        ElementManager_Session,

        [Description("The Effect Manager")]
        EffectManager_Session
    }

    #endregion

    #region Auxiliar classes

    #endregion

    #region Attributes

    #endregion

    #region Properties

    #endregion

    #region Private, protected methods

    #endregion

    #region Public methods

    /// <summary>
    /// Get the object that represents the information of the current session
    /// </summary>
    public static SessionData getSessionData {
        get {
            String strKey = eSessionObjects.sessionData_Session.ToString();
            if (HttpContext.Current.Session[strKey] == null)
                HttpContext.Current.Session[strKey] = new SessionData();
            return HttpContext.Current.Session[strKey] as SessionData;
        }
    }

    /// <summary>
    /// Get the object that represents the manager for including files (like javascripts)
    /// </summary>
    public static ScriptResourceManager getScriptResourceManager {
        get {
            String strKey = eSessionObjects.scriptResourceManager_Session.ToString();
            if (HttpContext.Current.Session[strKey] == null)
                HttpContext.Current.Session[strKey] =
                    new ScriptResourceManager(StaticObjects.getWCMConstants.getValue(eWCMConstants.root_path));
            return HttpContext.Current.Session[strKey] as ScriptResourceManager;
        }
    }

    /// <summary>
    /// Get the object that represents the manager of memory
    /// </summary>
    public static MemoryManager getMemoryManager {
        get {
            String strKey = eSessionObjects.memoryManager_Session.ToString();
            if (HttpContext.Current.Session[strKey] == null)
                HttpContext.Current.Session[strKey] = new MemoryManager();
            return HttpContext.Current.Session[strKey] as MemoryManager;
        }
    }

    /// <summary>
    /// Gets the current test object. If it doesn't exist.
    /// From database will be readen
    /// </summary>
    public static TestObject getTestObject {
        get {
            String strKey = eSessionObjects.TestObject_Session.ToString();
            if (HttpContext.Current.Session[strKey] == null) {
                HttpContext.Current.Session[strKey] = tempFillTestObject.getTestObject();
            }
            return HttpContext.Current.Session[strKey] as TestObject;
        }
    }

    

    #endregion
}