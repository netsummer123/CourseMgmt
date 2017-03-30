<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfigCenterPage.aspx.cs"
    Inherits="Page_ConfigCenterPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <meta content="all" name="robots" />
    <meta name="Copyright" content="站点名称,版权所有,未经同意不得转载" />
    <meta name="description" content="站点名称" />
    <title>统一配置中心</title>
    <link href="../App_Themes/Default/Style/Css/Css.css" rel="stylesheet" type="text/css" />
    <style>
         .TableFormB {
          
            border-collapse: collapse;
        }
         .TableFormB tr td, .TableFormB tr th {
          
              border: 1px solid #ADD2FF; 	

         }
    </style>
</head>
<body class="Center">
    <form runat="server">
        <table cellspacing="0" cellpadding="0" border="0" class="Tab_List01" id="Tab_List01">
            <tr>
                <th width="16" class="TabHeader_Left">&nbsp;
                </th>
                <th class="TabHeader_Center">
                    <table cellspacing="0" cellpadding="0" border="0" class="TableAdd" width="99.9%">
                        <tr>
                            <td class="Add">当前位置：&nbsp;统一配置中心
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </th>
                <th width="10" class="TabHeader_Right">&nbsp;
                </th>
            </tr>
            <tr>
                <td width="16" class="TabCenter_Left">&nbsp;
                </td>
                <td class="TabCenter_Center" id="TabCenter2" valign="top">
                    <div class="CenterHeight01" id="CenterHeight01">
                        <table cellpadding="5" border="0" class="TableFormB">
                            <tr>
                                <th width="300">&nbsp;
                                </th>
                                <td width="400">&nbsp;
                                </td>

                                <th>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxPushToWebDelay"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    发布到网站的信息的延迟时间：
                                </th>
                                <td>
                                    <asp:TextBox ID="tbxPushToWebDelay" runat="server" CssClass="TextBox04" Width="200"></asp:TextBox>&nbsp;&nbsp;分钟
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbxPushToWebDelay"
                                    ErrorMessage="数值必须介于0~1000" Type="Integer" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTxsBackToPlatformDelay"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    通讯社回流到内容聚合平台的延迟时间：
                                </th>
                                <td>
                                    <asp:TextBox ID="tbxTxsBackToPlatformDelay" runat="server" CssClass="TextBox04" Width="200"></asp:TextBox>&nbsp;&nbsp;分钟
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbxTxsBackToPlatformDelay"
                                    ErrorMessage="数值必须介于0~1000" Type="Integer" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
                                </td>

                                <th>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxVipPushToUnvipDelay"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    VIP产品发送给非VIP客户的发送延迟时间：
                                </th>
                                <td>
                                    <asp:TextBox ID="tbxVipPushToUnvipDelay" runat="server" CssClass="TextBox04" Width="200"></asp:TextBox>&nbsp;&nbsp;分钟
                                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tbxVipPushToUnvipDelay"
                                    ErrorMessage="数值必须介于0~1000" Type="Integer" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxPushToBSDelay"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    发送给B/S端的延迟时间：
                                </th>
                                <td>
                                    <asp:TextBox ID="tbxPushToBSDelay" runat="server" CssClass="TextBox04" Width="200"></asp:TextBox>&nbsp;&nbsp;分钟
                                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tbxPushToBSDelay"
                                    ErrorMessage="数值必须介于0~1000" Type="Integer" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
                                </td>

                                <th>快讯是否发送到B/S端：
                                </th>
                                <td>
                                    <asp:CheckBox runat="server" ID="cbkIsQuickNewsPushToBS" Text="是" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxContractMobileReminderTime"
                                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    合同到期手机提醒时间:
                                </th>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxContractMobileReminderTime" CssClass="TextBox04"
                                        Width="200"></asp:TextBox>&nbsp;&nbsp;
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxContractMobileReminderTime"
                                    ValidationExpression="([0-1][0-9]|2[0-3]):([0-5][0-9])" ErrorMessage="时间格式不正确，格式如XX:XX"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>

                                <td colspan="2" align="center" class="ToolBar">
                                    <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td width="10" class="TabCenter_Right">&nbsp;
                </td>
            </tr>
            <tr>
                <td width="16" class="TabFoot_Left"></td>
                <td class="TabFoot_Center"></td>
                <td width="10" class="TabFoot_Right"></td>
            </tr>
        </table>

        <script>
            function PageResize1() {
                var height = document.documentElement.clientHeight;
                var MainFrame = document.getElementById("TabCenter2");

                if (height > 10)
                    MainFrame.style.height = height - 65 + "px";
                try { document.frames["TabCenter2"].PageResize(); } catch (e) { }
            }

            function PageResize2() {
                var width = document.documentElement.clientWidth;
                var MainFrame = document.getElementById("Tab_List01");

                if (width > 10)
                    MainFrame.style.width = width - 18 + "px";
                try { document.frames["Tab_List01"].PageResize(); } catch (e) { }
            }

            function PageResize3() {
                var height = document.documentElement.clientHeight;
                var MainFrame = document.getElementById("CenterHeight01");

                if (height > 10)
                    MainFrame.style.height = height - 90 + "px";
                try { document.frames["CenterHeight01"].PageResize(); } catch (e) { }
            }


            function PageResize() {
                PageResize1();
                PageResize2();
                PageResize3();
            }
            PageResize();
            window.onresize = PageResize;
        </script>

    </form>
</body>
</html>
