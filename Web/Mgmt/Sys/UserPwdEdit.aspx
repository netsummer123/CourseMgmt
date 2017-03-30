<%@ Page Title="修改密码" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" CodeBehind="UserPwdEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.UserPwdEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <input id="hdSelectedTreeItemId" type="hidden" runat="server" />
    <input id="hdSelectedRoleId" type="hidden" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:PlaceHolder runat="server" ID="phData">
                <table cellpadding="5" border="0" class="TableFormB" valign="top" width="100%">
                    <asp:PlaceHolder runat="server" ID="phPwdCheck" Visible="False">
                        <tr>
                            <th class="required" width="200">旧密码</th>
                            <td>
                                <asp:TextBox ID="tbxOldPassword" runat="server" TextMode="Password" CssClass="TextBox04 input-medium validate[required]" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                    <tr>
                        <th class="required" width="200">新密码</th>
                        <td>
                            <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" CssClass="TextBox04 input-medium validate[required,minSize[6]]" MaxLength="20"></asp:TextBox>
                            <span class="help">密码至少输入6位</span>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">确认新密码</th>
                        <td>
                            <asp:TextBox ID="tbxRepeatPassword" runat="server" TextMode="Password" CssClass="TextBox04 input-medium validate[required,equals[ctl00_cphContent_tbxPassword]]" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04" OnClick="btnSave_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

