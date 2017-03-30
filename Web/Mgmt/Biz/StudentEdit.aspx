<%@ Page Title="学生编辑" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Biz.StudentEdit" %>

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
                        <th class="required" width="200">系部
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxDepartmentType" runat="server" CssClass="TextBox04 validate[required] validate-skip" AutoPostBack="True" OnSelectedIndexChanged="tbxDepartmentType_OnSelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">年份
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
                        <th>手机号码
                        </th>
                        <td>
                            <asp:TextBox ID="tbxMobile" runat="server" CssClass="TextBox04 validate[custom[mobile]]" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">排序
                        </th>
                        <td>
                            <asp:TextBox ID="tbxOrderNum" runat="server" CssClass="TextBox04 input-mini validate[required,custom[integer]]" MaxLength="8"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button Visible="False" runat="server" ID="btnSaveAdd" Text="保存新增" CssClass="Button04" OnClick="btnSaveAdd_Click" />
                <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'StudentList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

