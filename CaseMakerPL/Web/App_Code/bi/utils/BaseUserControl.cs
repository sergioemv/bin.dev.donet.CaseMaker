using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace utils
{
    /// <summary>
    /// Autor: portiz
    /// BaseUserControl is a base line for web user controls. All user controls that inherits from this, will
    /// be able to use functions defined and desired for controls.
    /// Done by: portiz 2008-01-30
    /// </summary>
    public abstract class BaseUserControl : UserControl
    {
        #region Constants

        #endregion

        #region Enumerates

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

        private String calculateDir = null;

        public String getRelativePathToTheme()
        {
            if (String.IsNullOrEmpty(calculateDir))
            {
                ///Web/test/testCase/testUCEquivalenceClasses/testUCEquivalenceClassEditModal.aspx
                //../../../App_Themes/Default/Images/ImagesDialog/
                calculateDir = "";
                int i = Request.Path.IndexOf("/");
                int count = 0;
                while (i != -1)
                {
                    count++;
                    i = Request.Path.IndexOf("/", i + 1);
                }
                for (int h = 0; h < count - 2; h++)
                    calculateDir += "../";
                calculateDir += "App_Themes/" + SessionObjects.getSessionData.CurrentTheme + "/";
            }
            return calculateDir;
        }

        public IList<WebControl> registerWebControlToUpdate
        {
            get
            {
                if (getMemory("registerComponentsToUpdate") == null)
                    setMemory("registerComponentsToUpdate", new List<WebControl>());
                return getMemory("registerComponentsToUpdate") as IList<WebControl>;
            }
            set { setMemory("registerComponentsToUpdate", value); }
        }

        public IList<HiddenField> registerComponentsToUpdateHidden
        {
            get
            {
                if (getMemory("registerComponentsToUpdateHidden") == null)
                    setMemory("registerComponentsToUpdateHidden", new List<HiddenField>());
                return getMemory("registerComponentsToUpdateHidden") as List<HiddenField>;
            }
            set { setMemory("registerComponentsToUpdateHidden", value); }
        }

        public String getJSUpdateCallGrid()
        {
            return "getJSUpdateCallGrid" + ClientID + "(grid)";
        }

        /// <summary>
        /// Indicate if the events are the adecuate to initialize a component
        /// </summary>
        /// <returns></returns>
        public bool mustInitialize()
        {
            return (!Page.IsPostBack && !Page.IsCallback);
        }

        /// <summary>
        /// Get an object from the temporary memory from session objects
        /// </summary>
        /// <param name="__strKey">A key whichone a object was hashed.</param>
        /// <returns>If the key exists, returns a object, else returns null.</returns>
        public Object getMemory(String __strKey)
        {
            return SessionObjects.getMemoryManager.TempMemory.getMemory(ClientID + __strKey);
        }

        /// <summary>
        /// Set an object from the temporary memory from session objects
        /// </summary>
        /// <param name="__strKey">A key for hashing.</param>
        /// <param name="__obj">The object to save.</param>
        public void setMemory(String __strKey, Object __obj)
        {
            SessionObjects.getMemoryManager.TempMemory.setMemory(ClientID + __strKey, __obj);
        }

        /// <summary>
        /// Gets the base paht of themes, including the current theme..
        /// </summary>
        /// <returns></returns>
        public String getAppThemeBaseDir()
        {
            String appThemedir = StaticObjects.getApplicationData.Root_Path +
                                 "App_Themes/" +
                                 SessionObjects.getSessionData.CurrentTheme +
                                 "/";
            return appThemedir;
        }

        #endregion

        #region Abstract methods to be overriden

        public abstract void Initialize();
        protected abstract void InitializeComponents();
        protected abstract void RegisterResources();
        protected abstract void RegisterScripts();
        protected abstract void SetCurrentLanguage();

        #endregion
    }
}