using System;
using utils;

public partial class _Default : BasePage
{
    #region Attributes

    #endregion

    #region Properties

    #endregion

    #region Private methods

    #endregion

    #region Overriden methods

    public override void Initialize()
    {
    }

    protected override void InitializeComponents()
    {
    }

    protected override void RegisterResources()
    {
    }

    protected override void RegisterScripts()
    {
        RegisterMasterPageScripts(Master as MasterPage);
        SessionObjects.getScriptResourceManager.registerAllScripts(this);
    }

    #endregion

    #region Form events

    /// <summary>
    /// When the form loads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && !Page.IsCallback)
        {
            Initialize();
            InitializeComponents();
            RegisterResources();
            RegisterScripts();
        }
    }

    #endregion
}