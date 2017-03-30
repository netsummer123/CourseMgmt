<%@ Page Title="课程编辑" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="CourseEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Biz.CourseEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .ui-datepicker-title select {
            width: 70px !important;
        }
    </style>
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
                        <th class="required" width="200">名称
                        </th>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server" CssClass="TextBox04 validate[required] input-xlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">年份
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxYear" runat="server" CssClass="TextBox04 validate[required]"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">开始时间
                        </th>
                        <td>
                            <asp:TextBox ID="tbxStartTime" runat="server" CssClass="TextBox04 validate[required,custom[date]] datepicker"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">结束时间
                        </th>
                        <td>
                            <asp:TextBox ID="tbxEndTime" runat="server" CssClass="TextBox04 validate[required,custom[date]] datepicker"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>描述
                        </th>
                        <td>
                            <asp:TextBox ID="tbxDescription" runat="server" CssClass="TextBox04 input-xxlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button Visible="False" runat="server" ID="btnSaveAdd" Text="保存新增" CssClass="Button04" OnClick="btnSaveAdd_Click" />
                <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'CourseList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

