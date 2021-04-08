<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCState.ascx.cs" Inherits="UCState" %>
<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>

<script language="javascript" type="text/javascript">

        function OnafterItemSelected<%=ClientID%>(controlID){
           var inn = ISGetObject(controlID);
           <%=onItemChangeJSWrite()%>
        }

        function <%=getJSUpdateCallGrid()%>
		{
           var inn = ISGetObject("<%=WebCombo1.ClientID%>");
           grid.AddInput("<%=eParameters.eStateVale.ToString()%>", inn.Value);
	    }
	    
	    function <%=setValueByJs()%>(key){
            var combo = ISGetObject("<%=WebCombo1.ClientID%>");
            combo.SetSelectedIndex(key);
        }
	    

</script>

<%--<ISWebCombo:WebCombo ID="WebCombo1" runat="server" Height="15px" UseDefaultStyle="True"
    Width="123px" OnInitializeDataSource="WebCombo1_InitializeDataSource" DataValueField="StateId"
    DataTextField="StateName">
    <Columns>
        <ISWebCombo:WebComboColumn BaseFieldName="StateId" Hidden="True" HeaderText="StateId"
            Name="StateId" />
        <ISWebCombo:WebComboColumn BaseFieldName="StateName" HeaderText="StateName" Name="StateName" />
        <ISWebCombo:WebComboColumn BaseFieldName="StateDescription" HeaderText="StateDescription"
            Name="StateDescription" />
    </Columns>
    <LayoutSettings ComboMode="MultipleColumns" TextBoxMode="ReadOnly">
    </LayoutSettings>
    <FlyPostBackSettings PostControlState="False" PostHiddenFields="False" PostViewState="False" />
</ISWebCombo:WebCombo>
--%>
<ISWebCombo:WebCombo ID="WebCombo1" runat="server" Height="15px" UseDefaultStyle="True"
    Width="30px" OnInitializeDataSource="WebCombo1_InitializeDataSource" DataValueField="StateId"
    DataTextField="StateName">
    <Columns>
        <ISWebCombo:WebComboColumn BaseFieldName="StateId" Hidden="True" HeaderText="StateId"
            Name="StateId" />
        <ISWebCombo:WebComboColumn BaseFieldName="StateName" HeaderText="StateName" Name="StateName" />
        <ISWebCombo:WebComboColumn BaseFieldName="StateDescription" HeaderText="StateDescription"
            Name="StateDescription" />
    </Columns>
    <LayoutSettings ComboMode="MultipleColumns" TextBoxMode="ReadOnly">
    </LayoutSettings>
    <FlyPostBackSettings PostControlState="False" PostHiddenFields="False" PostViewState="False" />
</ISWebCombo:WebCombo>
