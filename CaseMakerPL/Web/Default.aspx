<%@ Page Language="C#" MasterPageFile="~/CaseMaker/Login/masterLogin.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        //Detect browser
        var isInternetExplorer = $.browser.msie; 

        //Detect version of browser
        var browserVersion = parseInt($.browser.version); 


        //prepare a trick to close browser without calling "warning close"
        window.opener = window.self; 
        dateIni=new Date();
	    CalculateDate=""+dateIni.getYear()+dateIni.getDay()+dateIni.getDate()+dateIni.getHours()+dateIni.getMinutes()+dateIni.getSeconds()+dateIni.getTime()+"";

        //Open the new windows
        newWindow=window.open("./CaseMaker/Login/index/index.aspx", CalculateDate, "scrollbars=YES,toolbar=no, menubar=no, directories=no, height="+(screen.height-68)+",width="+(screen.width-10)+", top=0, left=0, copyhistory=no, screen=1,resizable=yes");                             
              
        //must close the original window (this one)
        if (newWindow != null){
            if (isInternetExplorer && browserVersion>=6){ //special trick for internet explorer 7
                var windowClose = window.close;
                window.open("","_self");
                windowClose();
            }else{
                self.window.close(); //cierra la ventana principal sin confirmacion 
            }
        }
	   
    </script>

</asp:Content>
