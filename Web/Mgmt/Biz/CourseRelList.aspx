<%@ Page Title="老师设定管理" Language="C#" MasterPageFile="~/MasterPage/List.Master" CodeBehind="CourseRelList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Biz.CourseRelList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <input id="hdSelectedTreeItemId" type="hidden" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <table cellspacing="0" cellpadding="0" border="0" class="Table04" valign="top" width="100%">
        <tr>
            <td align="left" class="SearchBg01" colspan="5">
                <asp:PlaceHolder runat="server" ID="phSearch">
                    <table cellspacing="0" cellpadding="0" border="0" class="TableFormA">
                        <tr>
                            <td>&nbsp;&nbsp; 当前课程：<asp:Literal runat="server" ID="ltlCourseName" />
                            </td>
                        </tr>
                    </table>
                </asp:PlaceHolder>
            </td>
            <td align="right" class="SearchBg01">
                <asp:Button runat="server" ID="btnAdd" CssClass="Button03" Style="width: 44px;" Text="添加" OnClick="btnAdd_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellspacing="0" cellpadding="0" border="0" class="InfolistA2" width="100%">
                            <tr>
                                <th width="40">
                                    <input id="cbxAll" type="checkbox" title="全选" onclick="checkAll(this);" />
                                </th>
                                <th width="80">老师</th>
                                <th>班级</th>
                                <th width="100px">操作</th>
                            </tr>
                            <asp:Repeater ID="rpList" runat="server" OnItemCommand="rpList_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td class="align-center">
                                            <asp:CheckBox ID="cbID" class="check cbx" ToolTip='<%# Eval("TeacherID") %>' runat="server" />
                                        </td>
                                        <td>
                                            <%#Eval("TeacherName") %>
                                        </td>
                                        <td>
                                            <%#Eval("DeptNames") %>
                                        </td>
                                        <td class="align-center">
                                            <a class="fancybox link-edit" href='CourseRelEdit.aspx?CourseID=<%# CourseID %>&TeacherID=<%# Eval("TeacherID") %>' title="修改">修改</a>
                                            &nbsp;
                                            <asp:LinkButton ID="btDelete" CommandName="Delete" CssClass="link-del confirm" ToolTip="删除" Text="删除" CommandArgument='<%# Eval("TeacherID") %>' runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
