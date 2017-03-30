<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CourseMgmt.Web.SignIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <meta content="all" name="robots" />
    <meta name="Copyright" content="站点网址，版权所有,未经同意不得转载" />
    <meta name="description" content="站点名称" />
    <link href="App_Themes/Login/Style/Css/Css.css" rel="stylesheet" type="text/css" />
    <script src="App_Content/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="App_Content/Plugin/fancybox/jquery.fancybox.css" rel="stylesheet" />
    <script src="App_Content/Plugin/fancybox/jquery.fancybox.js" type="text/javascript"></script>
    <title>登录界面</title>
</head>
<body class="LoginBg">
    <form id="form1" runat="server">
        <div class="Login">
            <div class="Input">
                <p style="margin-bottom: 8px;">
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="TextBox01" TabIndex="1"></asp:TextBox>
                </p>
                <p style="margin-bottom: 6px;">
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="TextBox01" TextMode="password" TabIndex="2"></asp:TextBox>
                </p>
                <p>
                    <asp:TextBox ID="tbValidateCode" Style="width: 232px; margin-left: -40px;" MaxLength="4" runat="server"
                        CssClass="TextBox01" TabIndex="3" onkeypress="TryLogin(event)"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblErrorInfo" runat="server"></asp:Label>
                </p>
            </div>
            <div class="ValidateCode">
                <img src="ValidateCode.aspx?nocache=<%= DateTime.Now.Ticks %>" border="2" style="cursor: pointer;" onclick="GetValCode(this)" alt="换一张" title="换一张" />
            </div>
            <div class="Btn" style="left: 295px;">
                <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_OnClick">
                <img src="App_Themes/Login/Images/space.gif" width="66px" border="0" />
                </asp:LinkButton>
            </div>
            <a class="Register" onclick="openModal();">注 册</a>
            <div class="white-bg">
                <a href="Soft/Chrome.exe">Chrome浏览器下载</a>
            </div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function openModal() {
        $.fancybox({
            'type': 'iframe',
            'width': '800px',
            'height': '600px',
            'autoSize': false,
            'href': './Mgmt/Biz/Register.aspx'
        });
    }

    function closeModal() {
        $.fancybox.close();
    }

    function TryLogin(e) {
        var keyCode;
        if (window.event) {
            keyCode = e.keyCode;
        }
        else if (e.which) {
            keyCode = e.which;
        }
        if (keyCode == 13) {
            document.getElementById('<%=btnLogin.ClientID %>').click();
        }
    }
    //获取登录验证码
    function GetValCode(control) {
        control.src = 'ValidateCode.aspx?nocache=' + Math.random();
    }


</script>
