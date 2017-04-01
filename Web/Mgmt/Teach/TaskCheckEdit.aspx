<%@ Page Title="手工打分" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="TaskCheckEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Teach.TaskCheckEdit" %>


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
                        <th width="200">学号
                        </th>
                        <td>
                            <asp:TextBox ID="tbxUserName" ReadOnly="True" runat="server" CssClass="TextboxRead "></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>姓名
                        </th>
                        <td>
                            <asp:TextBox ID="tbxRealName" ReadOnly="True" runat="server" CssClass="TextboxRead input-xlarge"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>课堂态度
                        </th>
                        <td>
                            <asp:TextBox ID="tbxRoutineScore1" runat="server" CssClass="TextBox04 validate[required,custom[integer],max[10]]"></asp:TextBox>
                            <span class="help">最高10分</span>
                        </td>
                    </tr>
                    <tr>
                        <th>问题研讨
                        </th>
                        <td>
                            <asp:TextBox ID="tbxRoutineScore2" runat="server" CssClass="TextBox04 validate[required,custom[integer],max[10]]"></asp:TextBox>
                            <span class="help">最高10分</span>
                        </td>
                    </tr>
                    <tr>
                        <th>话题演讲
                        </th>
                        <td>
                            <asp:TextBox ID="tbxRoutineScore3" runat="server" CssClass="TextBox04 validate[required,custom[integer],max[5]]"></asp:TextBox>
                            <span class="help">最高5分</span>
                        </td>
                    </tr>
                    <tr>
                        <th>知行讲堂
                        </th>
                        <td>
                            <asp:TextBox ID="tbxRoutineScore4" runat="server" CssClass="TextBox04 validate[required,custom[integer],max[10]]"></asp:TextBox>
                            <span class="help">最高10分</span>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button runat="server" ID="btnSave" Text="提交" CssClass="Button04" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'TaskCheckList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

