<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FestivalMgmt.aspx.cs" Inherits="FestivalMgmt" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>节日设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../@Theme/WS/Style1/Css/Css.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="../@Theme/WS/Css/js/calendar.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div class="EditPageForm" id="MainList" style="background-color: White; padding-top: 36px;">
                <table border="0" cellspacing="0" cellpadding="0" class="FormTable">
                    <tr>
                        <td class="FieldName">
                            国家法定假日
                        </td>
                        <td class="FieldInput">
                            <asp:DropDownList ID="ddlFestival" runat="server" CssClass="Input" Style="width: 150px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldName">
                            开始时间
                        </td>
                        <td class="FieldInput">
                            <asp:TextBox ID="tbStartTime" runat="server" CssClass="InputReadOnly" Style="width: 150px;"
                                onfocus="calendar();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldName">
                            结束时间
                        </td>
                        <td class="FieldInput">
                            <asp:TextBox ID="tbEndTime" runat="server" CssClass="InputReadOnly" Style="width: 150px;"
                                onfocus="calendar();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="FieldInput" align="center" colspan="2">
                            <asp:Button ID="btnSave" runat="server" CssClass="InputBtn" Text="保 存" />
                        </td>
                    </tr>
                </table>
            </div>
        </center>
    </form>

    <script language="javascript" type="text/javascript">
        function PageResize()
        {
	        var height = document.body.clientHeight;
	        document.getElementById("MainList").style.height = height;
            var width = document.body.clientWidth;
            //if(width > 185)
                 //document.getElementById('').style.width = (width - 170)+"px";
        try
        {
            FocusSelect();
        }catch(e){}
        }
        PageResize();
        
        window.onresize = PageResize;
        
    </script>

</body>
</html>
