<%@ Page Title="学生注册" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Biz.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <input id="hdSelectedTreeItemId" type="hidden" runat="server" />
    <input id="hdSelectedRoleId" type="hidden" runat="server" />
    <asp:PlaceHolder runat="server" ID="phData">
        <table cellpadding="5" border="0" class="TableFormB" valign="top" width="100%">
            <tr>
                <th class="required" width="200">系部
                </th>
                <td>
                    <asp:DropDownList ID="tbxDepartmentType" runat="server" CssClass="TextBox04 validate[required] validate-skip" AutoPostBack="True" OnSelectedIndexChanged="tbxDepartmentType_OnSelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th class="required">入学年份
                </th>
                <td>
                    <asp:DropDownList ID="tbxRegYear" runat="server" CssClass="TextBox04 validate[required] validate-skip" AutoPostBack="True" OnSelectedIndexChanged="tbxRegYear_OnSelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th class="required">班级
                </th>
                <td>
                    <asp:DropDownList ID="tbxDepartmentID" runat="server" CssClass="TextBox04 validate[required]" MaxLength="20"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th class="required">学号
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
                <th class="required">手机号码
                </th>
                <td>
                    <asp:TextBox ID="tbxMobile" runat="server" CssClass="TextBox04 validate[required,custom[mobile]]" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th class="required">密码</th>
                <td>
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" CssClass="TextBox04 input-medium validate[required,minSize[6]]" MaxLength="20"></asp:TextBox>
                    <span class="help">密码至少输入6位</span>
                </td>
            </tr>
            <tr>
                <th class="required">确认密码</th>
                <td>
                    <asp:TextBox ID="tbxRepeatPassword" runat="server" TextMode="Password" CssClass="TextBox04 input-medium validate[required,equals[ctl00_cphContent_tbxPassword]]" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    <div style="margin-top: 5px; margin-left: 300px;">
        <asp:Button runat="server" ID="btnSave" Text="注 册" CssClass="Button04" OnClick="btnSave_Click" />
    </div>
</asp:Content>

