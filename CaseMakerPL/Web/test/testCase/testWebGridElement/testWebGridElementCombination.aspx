<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testWebGridElementCombination.aspx.cs"
    Inherits="testWebGridElementCombination" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
    TagPrefix="ISWebDesktop" %>

<%@ Register Src="../../../WebUserControls/Workspace/Project/TestObject/TestCases/WebGridElement/WebGridElement.ascx"
    TagName="WebGridElement" TagPrefix="uc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body id="body" runat="server" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
        <div>

            <script language="javascript" type="text/javascript">
            
                function show(){
                    alert("Ejecutando función enganchada");
                }
            </script>

            <uc1:WebGridElement ID="WebGridElement1" runat="server" />
            <table style="width: 61%">
                <tr>
                    <td style="width: 229px">
                        Get selected items, only when grid shows the selection checkboxs (combination template)</td>
                    <td style="width: 77px">
                    <input type="button" name="updateChecked" value="update Checked" onclick="<%=WebGridElement1.jsUpdateCheckedEquivalenceClass()%>;" />
                        <ISWebDesktop:WebButton ID="WebButton1" runat="server" AutoPostback="True" Height="20px"
                            OnClicked="WebButton1_Clicked" Text="See in server">
                            <FlyPostBackSettings PostHiddenFields="True" PostInputControls="True" PostViewState="True" />
                        </ISWebDesktop:WebButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
