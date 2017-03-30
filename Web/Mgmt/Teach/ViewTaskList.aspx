<%@ Page Title="批改作业" Language="C#" MasterPageFile="~/MasterPage/List.Master" CodeBehind="ViewTaskList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Teach.ViewTaskList" %>

<%@ Import Namespace="CourseMgmt.BizLogic.Util" %>
<%@ Import Namespace="CourseMgmt.Web.Common" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <input id="hdSelectedTreeItemId" type="hidden" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" border="0" class="Table04" valign="top" width="100%">
                <tr>
                    <td align="left" class="SearchBg01" colspan="6">
                        <asp:PlaceHolder runat="server" ID="phSearch">
                            <table cellspacing="0" cellpadding="0" border="0" class="TableFormA">
                                <tr>
                                    <td style="color: red;">&nbsp;&nbsp;
                                        请依次选择系部、年份、班级、课程
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;&nbsp;
                                        系部：<asp:DropDownList ID="searchDepartmentType" runat="server" CssClass="TextBox04" Style="width: 120px;"
                                            AutoPostBack="True" OnSelectedIndexChanged="searchDepartmentType_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp; 
                                        年份：<asp:DropDownList ID="searchRegYear" runat="server" CssClass="TextBox04" Style="width: 70px;"
                                            AutoPostBack="True" OnSelectedIndexChanged="searchRegYear_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp; 
                                        班级：<asp:DropDownList ID="searchDepartmentID" runat="server" CssClass="TextBox04" Style="width: 160px;"
                                            AutoPostBack="True" OnSelectedIndexChanged="searchDepartmentID_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp; 
                                        课程：<asp:DropDownList ID="searchCourseID" runat="server" CssClass="TextBox04" Style="width: 160px;"></asp:DropDownList>
                                        &nbsp;&nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="Button03" Style="width: 44px;" Text="搜索" OnClick="btnSearch_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;&nbsp; 作业类型：<asp:DropDownList ID="searchCategoryID" runat="server" CssClass="TextBox04" Style="width: 218px;"></asp:DropDownList>
                                        &nbsp;&nbsp; 状态：<asp:DropDownList ID="searchStatus" runat="server" CssClass="TextBox04" Style="width: 160px;"></asp:DropDownList>

                                    </td>
                                </tr>
                            </table>
                        </asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" valign="top">

                        <table cellspacing="0" cellpadding="0" border="0" class="InfolistA2" width="100%">
                            <tr>
                                <th width="80">学号</th>
                                <th width="80">姓名</th>
                                <th width="150">学生班级</th>
                                <th>标题</th>
                                <th width="150">作业类型</th>
                                <th width="100">提交时间</th>
                                <th width="100">批改时间</th>
                                <th width="80">状态</th>
                                <th width="100px">操作</th>
                            </tr>
                            <asp:Repeater ID="rpList" runat="server" OnItemCommand="rpList_ItemCommand" OnItemDataBound="rpList_OnItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("UserName") %>
                                        </td>
                                        <td>
                                            <%#Eval("RealName") %>
                                        </td>
                                        <td>
                                            <%#Eval("DepartmentName") %>
                                        </td>
                                        <td>
                                            <%#Eval("Title") %>
                                        </td>
                                        <td class="align-center">
                                            <%# EnumTypeHelper.GetDescriptionFromEnum(typeof(TaskCategory), Eval("CategoryID")) %>
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("FinishTime","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td class="align-center">
                                            <%# (DateTime)Eval("ScoreTime") == DateTime.MinValue?"—":Eval("ScoreTime","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td class="align-center">
                                            <span class="<%# (int)Eval("Status") == 10? "link-edit":"link-view" %>">
                                                <%# EnumTypeHelper.GetDescriptionFromEnum(typeof(TaskStatus), Eval("Status")) %>
                                            </span>
                                        </td>
                                        <td class="align-center">
                                            <a class="fancybox link-view" href='ViewTaskView.aspx?TaskID=<%# Eval("ID") %>' title="查看">查看</a>
                                            <asp:PlaceHolder runat="server" ID="phItemOp" Visible="False">&nbsp;
                                                <a class="fancybox link-edit" href='ViewTaskEdit.aspx?TaskID=<%# Eval("ID") %>' title="打分">打分</a>
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="AspNetPager1" EventName="PageChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
