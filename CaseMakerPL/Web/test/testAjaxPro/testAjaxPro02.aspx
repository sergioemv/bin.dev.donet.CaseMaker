<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testAjaxPro02.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <%-- <script type="text/javascript" src="../../javascript/json.js"></script>--%>
    <script type="text/javascript" src="../../Javascript/jquery.js"></script>

    <script type="text/javascript">
    jQuery.noConflict();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <script language="javascript" type="text/javascript">
            
                function message(str){
                    alert(str.value); 
                }
            
                function Test(){
                 MyClasses.HelloWorld(message);
                
                }
            </script>

            <a href="#" onclick="Test();">hola </a>
        </div>
    </form>
</body>
</html>
