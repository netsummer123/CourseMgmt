<%@ Page Title="个人信息" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.UserEdit" %>

<%@ Import Namespace="CourseMgmt.Web.Common" %>

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
                    <tr>
                        <th class="required" width="200">
                            <asp:Literal runat="server" ID="ltlTitle">用户名</asp:Literal>
                        </th>
                        <td>
                            <asp:TextBox ID="tbxUserName" runat="server" CssClass="TextBox04 validate[required]" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">姓名
                        </th>
                        <td>
                            <asp:TextBox ID="tbxRealName" runat="server" CssClass="TextBox04 validate[required]" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">性别
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxSex" runat="server" CssClass="TextBox04 validate[required]"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>手机号码
                        </th>
                        <td>
                            <asp:TextBox ID="tbxMobile" runat="server" CssClass="TextBox04 validate[custom[mobile]]" MaxLength="20"></asp:TextBox>
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

