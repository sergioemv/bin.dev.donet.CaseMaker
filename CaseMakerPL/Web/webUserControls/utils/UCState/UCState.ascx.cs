using System;
using System.ComponentModel;
using System.Data;
using bi.maskClasses.states.CMEstatesUIClass;
using CaseMaker.Entities.Testcases;
using ISNet.WebUI.WebCombo;
using utils;

/// <summary>
/// Autor: portiz
/// This component represents the states that casemaker manages.
/// </summary>
public partial class UCState : BaseUserControl
{
    protected enum eParameters
    {
        eStateVale
    }

    #region Properties

    [Browsable(false)]
    [Category("Custom configurations")]
    [Description(
        "Indicates if the behavior of the combo is static (get values by Request) or the values get by normal way to the server."
        )]
    public State Value
    {
        get
        {
            State st;
            if (isRequestMode)
                st = (State) Enum.Parse(typeof (State), Request.Form[eParameters.eStateVale.ToString()], true);
            else
                st = (State) Enum.Parse(typeof (State), WebCombo1.SelectedRow.Value, true);
            return st;
        }
        //        set { WebCombo1.Value = value.ToString("d"); }
        set { WebCombo1.Value = value.ToString("d"); }
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


    //public State Value {
    //    get {
    //        return State.POSITIVE;
    //        //State st = (State)Enum.Parse(typeof(State), WebCombo1.SelectedRow.Value, true);
    //        //return st;
    //    }
    //    set { WebCombo1.Value = value.ToString("d"); }
    //}


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

    protected String onItemChangeJSWrite()
    {
        if (onItemChangeJS != null)
            return onItemChangeJS + "(inn.Value);";
        else return "";
    }

    #endregion

    #region Private methods

    private void setComboState()
    {
        //fill the states has an unbound mode
        if (WebCombo1.Rows.Count == 0)
            foreach (DataRow dr in CMStatesUI.getStates().Tables[0].Rows)
            {
                WebComboRow wcRow = new WebComboRow();

                WebComboCell wgTCell = new WebComboCell();
                wgTCell.Text = dr[0].ToString();
                wcRow.Cells.Add(wgTCell);

                // add hidden cell for the value, the column and properties is defined at design time.
                WebComboCell wgVCell = new WebComboCell();
                wgVCell.Text = dr[1].ToString();
                wcRow.Cells.Add(wgVCell);

                WebComboCell wghCell = new WebComboCell();
                wghCell.Text = dr[2].ToString();
                wcRow.Cells.Add(wghCell);

                // add the row to State
                WebCombo1.Rows.Add(wcRow);
            }
    }

    #endregion

    #region Public methods

    public void requiresUIRefresh()
    {
        if (isRequestMode)
            registerWebControlToUpdate.Add(WebCombo1);
        else
            WebCombo1.RequiresUIRefresh = true;
    }

    public String setValueByJs()
    {
        return "setValueByJs" + ClientID;
    }

    public String getJSUpdateCall()
    {
        return "getJSUpdateCall" + ClientID + "()";
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
        setComboState();
        WebCombo1.LayoutSettings.ClientSideEvents.OnAfterItemSelected = "OnafterItemSelected" + ClientID;
        //WebCombo1.Value = "0";
    }

    protected override void RegisterResources()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    protected override void RegisterScripts()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    protected override void SetCurrentLanguage()
    {
        throw new NotImplementedException();
    }

    #endregion

    protected void WebCombo1_InitializeDataSource(object sender, DataSourceEventArgs e)
    {
        setComboState();
    }
}