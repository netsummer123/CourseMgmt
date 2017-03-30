<%@ Page Title="班级编辑" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="DeptEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Biz.DeptEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <input id="hdSelectedTreeItemId" type="hidden" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:PlaceHolder runat="server" ID="phData">
                <table cellpadding="5" border="0" class="TableFormB" valign="top" width="100%">
                    <tr>
                        <th class="required" width="200">系部名称
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxDepartmentType" runat="server" CssClass="TextBox04 validate[required]" MaxLength="50"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">年份
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxRegYear" runat="server" CssClass="TextBox04 validate[required]"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">班级名称
                        </th>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server" CssClass="TextBox04 validate[required]"></asp:TextBox>
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
                <input type="button" class="Button04" onclick="location.href = 'DeptList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

