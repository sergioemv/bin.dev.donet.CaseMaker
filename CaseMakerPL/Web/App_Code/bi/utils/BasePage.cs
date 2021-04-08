using System;
using System.Reflection;
using System.Web.UI;

namespace utils
{
    /// <summary>
    /// Base page is a base line from web pages. All pages that inherits from this, will
    /// be able to use functions defined and desired for all pages.
    /// Done by: portiz 27-12-07
    /// </summary>
    public abstract class BasePage : Page
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

        /// <summary>
        /// Call the registerMasterPageScripts method allocated in the master page
        /// </summary>
        /// <param name="__masterPage"></param>
        public void RegisterMasterPageScripts(MasterPage __masterPage)
        {
            try
            {
                CallProcedureByName(__masterPage, "registerMasterPageScripts", null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Invoke method of the master page
        /// </summary>
        /// <param name="__masterPage"></param>
        /// <param name="__strFunctionName"></param>
        /// <param name="__parameters"></param>
        public void CallProcedureByName(MasterPage __masterPage, String __strFunctionName, object[] __parameters)
        {
            try
            {
                Type t = __masterPage.GetType();
                t.InvokeMember(__strFunctionName, BindingFlags.InvokeMethod, null, __masterPage, __parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Abstract methods to be overriden

        public abstract void Initialize();
        protected abstract void InitializeComponents();
        protected abstract void RegisterResources();
        protected abstract void RegisterScripts();

        #endregion

        #region Page methods

        protected override void OnPreInit(EventArgs e)
        {
            Theme = SessionObjects.getSessionData.CurrentTheme;
        }
    }

    #endregion
}