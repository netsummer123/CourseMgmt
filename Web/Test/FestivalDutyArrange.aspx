<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FestivalDutyArrange.aspx.cs"
    Inherits="FestivalDutyArrange" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>节日值班安排维护</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../@Theme/WS//Style1/Css/Css.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="Css/js/calendar.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
    
    function SelectUserWithoutType()
    {
       var returnValue = window.showModalDialog("Function.Web/UserChooser.aspx?SelectType=User&nocache=" + Math.random() * 10000 + "&ReturnValueFormat=" + encodeURI("tbUserDisplayName:DisplayName|tbUserID:ID|tbUserName:Name"), document, "dialogWidth:800px;dialogHeight:600px;status:yes;resizable:no");
    }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div class="EditPageForm" id="MainList" style="background-color: White; padding-top: 36px;">
                <table border="0" cellspacing="0" cellpadding="0" class="FormTable">
                    <tr>
                        <td class="FieldName">
                            值班人员
                        </td>
                        <td class="FieldInput">
                            <asp:TextBox ID="tbUserDisplayName" runat="server" CssClass="InputReadOnly" Style="width: 150px;"></asp:TextBox>
                            <asp:TextBox ID="tbUserID" runat="server" CssClass="InputReadOnly" Width="0px"></asp:TextBox>
                            <asp:TextBox ID="tbUserName" runat="server" CssClass="InputReadOnly" Width="0px"></asp:TextBox>
                            <asp:Button ID="btnSelectUser" runat="server" CssClass="InputBtn" Text="选择人员" OnClick="btnSelectUser_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldName">
                            值班时间
                        </td>
                        <td class="FieldInput">
                            <asp:TextBox ID="tbArrangeTime" runat="server" CssClass="InputReadOnly" Style="width: 150px;"
                                onfocus="calendar();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldName">
                            安排类别
                        </td>
                        <td class="FieldInput">
                            <asp:DropDownList ID="ddlArrangeType" runat="server" CssClass="Input" Style="width: 150px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldName">
                            值班要求
                        </td>
                        <td class="FieldInput">
                            <asp:TextBox ID="tbDemand" runat="server" CssClass="InputLarge" Style="width: 250px;
                                height: 80px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trMessage" runat="server" visible="false">
                        <td class="FieldName">
                            值班留言
                        </td>
                        <td class="FieldInput">
                            <asp:TextBox ID="tbMessage" runat="server" CssClass="InputLarge" Style="width: 250px;
                                height: 80px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="FieldInput" align="center" colspan="2">
                            <asp:Button ID="btnMessage" runat="server" CssClass="InputBtn" Text="留 言" Visible="false"
                                OnClick="btnMessage_Click" />
                            <asp:Button ID="btnSave" runat="server" CssClass="InputBtn" Text="保 存" Visible="false"
                                OnClick="btnSave_Click" />
                            <asp:Button ID="btnModify" runat="server" CssClass="InputBtn" Text="修 改" Visible="false"
                                OnClick="btnModify_Click" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="InputBtn" Text="删 除" Visible="false"
                                OnClick="btnDelete_Click" />
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
