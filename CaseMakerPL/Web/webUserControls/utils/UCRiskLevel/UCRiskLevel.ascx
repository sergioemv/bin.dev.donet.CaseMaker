<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCRiskLevel.ascx.cs" Inherits="UCRiskLevel" %>
<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>

<script language="javascript" type="text/javascript">
        
        function OnafterItemSelected<%=ClientID%>(controlID){
           var inn = ISGetObject(controlID);
           <%=onItemChangeJSWrite()%>
        }
        
        function <%=getJSUpdateCallGrid()%>
		{
           var inn = ISGetObject("<%=wcRiskLevel.ClientID%>");
           grid.AddInput("<%=eParameters.eRiskLEvelValue.ToString()%>", inn.Value);
	    }

        function <%=setValueByJs()%>(key){
            var combo = ISGetObject("<%=wcRiskLevel.ClientID%>");
            combo.SetSelectedIndex(key);
        }


</script>

<ISWebCombo:WebCombo ID="wcRiskLevel" runat="server" UseDefaultStyle="True" Height="20px"
    Width="30px" OnInitializeDataSource="wcRiskLevel_InitializeDataSource">
    <Columns>
        <ISWebCombo:WebComboColumn Bound="False" Name="Column0" />
        <ISWebCombo:WebComboColumn Bound="False" Name="Column1" />
    </Columns>
    <LayoutSettings TextBoxMode="ReadOnly">
        <ClientSideEvents OnAfterItemSelected="OnafterItemSelected" />
    </LayoutSettings>
</ISWebCombo:WebCombo>
