<%@ Page Title="我的作业" Language="C#" MasterPageFile="~/MasterPage/List.Master" CodeBehind="TaskList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Stu.TaskList" %>

<%@ Import Namespace="CourseMgmt.BizLogic.Util" %>
<%@ Import Namespace="CourseMgmt.Web.Common" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
                            <td>&nbsp;&nbsp; 课程：<asp:DropDownList runat="server" ID="searchCourseID" CssClass="TextBox04" />
                                &nbsp;&nbsp; 标题：<asp:TextBox runat="server" ID="searchName" CssClass="TextBox04" />
                                &nbsp;&nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="Button03" Style="width: 44px;" Text="搜索" OnClick="btnSearch_Click"></asp:Button>
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
                                <th>课程</th>
                                <th width="150">作业类型</th>
                                <th>标题</th>
                                <th width="100">提交时间</th>
                                <th width="150px">操作</th>
                            </tr>
                            <asp:Repeater ID="rpList" runat="server" OnItemCommand="rpList_ItemCommand" OnItemDataBound="rpList_OnItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("CourseName") %>
                                        </td>
                                        <td class="align-center">
                                            <%# EnumTypeHelper.GetDescriptionFromEnum(typeof(TaskCategory), Eval("CategoryID")) %>
                                        </td>
                                        <td>
                                            <%#Eval("Title") %>
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("FinishTime","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td class="align-center">
                                            <a class="fancybox link-view" href='TaskView.aspx?TaskID=<%# Eval("ID") %>' title="查看">查看</a>
                                            <asp:PlaceHolder runat="server" ID="phItemOp">&nbsp;
                                                <a class="fancybox link-edit" href='TaskEdit.aspx?TaskID=<%# Eval("ID") %>' title="修改">修改</a>
                                                &nbsp;
                                                <asp:LinkButton ID="btDelete" CommandName="Delete" CssClass="link-del confirm" ToolTip="删除" Text="删除" CommandArgument='<%# Eval("ID") %>' runat="server" />
                                            </asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <webdiyer:AspNetPager ID="AspNetPager1" Width="96%" runat="server" CssClass="pager" CurrentPageButtonClass="cpb" NumericButtonCount="5" CustomInfoSectionWidth="200"
                            LayoutType="Table" ShowCustomInfoSection="Left" CustomInfoHTML="<span id='custom'>共%RecordCount%条，每页%PageSize%条，共%PageCount%页</span>"
                            HorizontalAlign="Right" ShowNavigationToolTip="true" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged" PageSize="15">
                        </webdiyer:AspNetPager>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="AspNetPager1" EventName="PageChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
