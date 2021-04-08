using System;
using System.Web.UI;

namespace CaseMakerWebUtils.ScriptResourceManager {
    /// <summary>
    /// Manages different list of scripts who can be rendered for different reassons and in diffetent times.
    /// Done by: portiz 2008-01-28
    /// </summary>
    public class ScriptResourceManager {
        #region Attributes

        private readonly String _strRoot;
        private readonly ScriptList _RenderScript;
        private readonly ScriptList _StarUpRenderScript;

        #endregion

        #region Properties

        /// <summary>
        /// Source base path
        /// </summary>
        public String Root {
            get { return _strRoot; }
        }

        /// <summary>
        /// Get a list of scripts that must be always rendered
        /// </summary>
        public ScriptList RenderScript {
            get { return _RenderScript; }
        }


        /// <summary>
        ///  Get a list of scripts that must be rendered at start up.
        /// </summary>
        public ScriptList RenderScriptStarUp {
            get { return _StarUpRenderScript; }
        }

        #endregion

        #region Private, protected methods

        /// <summary>
        /// Register script to the page
        /// </summary>
        /// <param name="__list">List of script paths</param>
        /// <param name="__page"></param>
        private static void registerScriptToPage(ScriptList __list, Page __page) {
            foreach (String strScriptKey in __list.getAllKeys()) {
                if (!__page.ClientScript.IsClientScriptIncludeRegistered(strScriptKey))
                    __page.ClientScript.RegisterClientScriptInclude(strScriptKey, __list.getValue(strScriptKey));
            }
        }

        /// <summary>
        /// Register scripts at the start up of the page.
        /// </summary>
        /// <param name="__list"></param>
        /// <param name="__page"></param>
        private static void registerScriptToPageStart(ScriptList __list, Page __page) {
            foreach (String strScriptKey in __list.getAllKeys()) {
                __page.ClientScript.RegisterStartupScript(__page.GetType(), strScriptKey, __list.getValue(strScriptKey));
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="__strRoot"Base path root></param>
        public ScriptResourceManager(String __strRoot) {
            _RenderScript = new ScriptList(__strRoot);
            _StarUpRenderScript = new ScriptList(__strRoot);
            _strRoot = __strRoot;
        }

        /// <summary>
        /// Delete all scripts paths
        /// </summary>
        public void cleanAllScripts() {
            RenderScript.cleanAllScriptReferences();
            RenderScriptStarUp.cleanAllScriptReferences();
        }


        /// <summary>
        /// Register the scripts in the page
        /// </summary>
        public void registerAllScripts(Page __page) {
            if (!__page.IsPostBack) {
                registerScriptToPage(RenderScript, __page);
                registerScriptToPageStart(RenderScriptStarUp, __page);
            } else
                cleanAllScripts();
        }

        /// <summary>
        /// Render a script in this moment (just if necesary, better use the default renders)
        /// </summary>
        /// <param name="__key"></param>
        /// <param name="path"></param>
        /// <param name="__page"></param>
        public void RenderScriptNow(String __key, String path, Page __page) {
            __page.ClientScript.RegisterClientScriptInclude(__key, _strRoot + path);
        }


        #endregion
    }
}