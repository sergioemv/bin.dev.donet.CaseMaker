using System;
using System.ComponentModel;
using ISNet.WebUI.WebCombo;
using utils;

/// <summary>
/// Autor: portiz
/// This component is a combo that hold integer values from a minimun to a maximun value.
/// By default, minimun value is 0 and maximun value is 10
/// </summary>
public partial class UCRiskLevel : BaseUserControl
{
    protected enum eParameters
    {
        eRiskLEvelValue
    }

    #region Properties

    /// <summary>
    /// Get and set a specific value.
    /// </summary>
    public int Value
    {
        //get { return Convert.ToInt32(wcRiskLevel.SelectedRow.Value); }
        //get { return 5; }
        get
        {
            if (isRequestMode)
            {
                int id = Convert.ToInt32(Request.Form[eParameters.eRiskLEvelValue.ToString()]);
                return id;
            }
            else
                return Convert.ToInt32(wcRiskLevel.SelectedRow.Value);
        }
        set { wcRiskLevel.Value = value.ToString("d"); }
    }

    /// <summary>
    /// Indicates the max value to show
    /// </summary>
    public int maxValue
    {
        get
        {
            if (getMemory("maxValue") == null)
                setMemory("maxValue", 10);
            return Convert.ToInt32(getMemory("maxValue"));
        }
        set { setMemory("maxValue", value); }
    }

    /// <summary>
    /// Indicates the min value to show
    /// </summary>
    public int minValue
    {
        get
        {
            if (getMemory("minValue") == null)
                setMemory("minValue", 0);
            return Convert.ToInt32(getMemory("minValue"));
        }
        set { setMemory("minValue", value); }
    }

    public String onItemChangeJS
    {
        get
        {
            if (ViewState["onItemChangeJS" + ClientID] == null)
                return "";
            return ViewState["onItemChangeJS" + ClientID].ToString();
        }
        set { ViewState["onItemChangeJS" + ClientID] = value; }
    }


    [Browsable(true)]
    [Category("Custom configurations")]
    [Description(
        "Indicates if the behavior of the combo is static (get values by Request) or the values get by normal way to the server."
        )]
    [DefaultValue(false)]
    public bool isRequestMode
    {
        get
        {
            if (getMemory("isRequestMode") == null)
                setMemory("isRequestMode", true);
            return Convert.ToBoolean(getMemory("isRequestMode"));
        }
        set { setMemory("isRequestMode", value); }
    }

    #endregion

    protected String onItemChangeJSWrite()
    {
        if (onItemChangeJS != null)
            return onItemChangeJS + "(inn.Value);";
        else return "";
    }

    #region Private methods

    private void setComboRiskValues()
    {
        if (wcRiskLevel.Rows.Count == 0)
            for (int i = minValue; i <= maxValue; i++)
            {
                WebComboRow wcRow = new WebComboRow();

                WebComboCell wgTCell = new WebComboCell();
                wgTCell.Text = i.ToString();
                wcRow.Cells.Add(wgTCell);

                WebComboCell wgVCell = new WebComboCell();
                wgVCell.Text = i.ToString();
                wcRow.Cells.Add(wgVCell);

                wcRiskLevel.Rows.Add(wcRow);
            }
    }

    #endregion

    #region Public methods

    public void requiresUIRefresh()
    {
        wcRiskLevel.RequiresUIRefresh = true;
    }

    public String setValueByJs()
    {
        return "setValueByJs" + ClientID;
    }

    #endregion

    #region Component methods

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public override void Initialize()
    {
        InitializeComponents();
    }

    protected override void InitializeComponents()
    {
        setComboRiskValues();
        wcRiskLevel.Value = minValue.ToString();
        wcRiskLevel.LayoutSettings.ClientSideEvents.OnAfterItemSelected = "OnafterItemSelected" + ClientID;
    }

    protected override void RegisterResources()
    {
    }

    protected override void RegisterScripts()
    {
    }

    protected override void SetCurrentLanguage()
    {
        throw new NotImplementedException();
    }

    protected void wcRiskLevel_InitializeDataSource(object sender, DataSourceEventArgs e)
    {
        setComboRiskValues();
    }

    #endregion

    public String getJSUpdateCall()
    {
        return "getJSUpdateCall" + ClientID + "()";
    }
}