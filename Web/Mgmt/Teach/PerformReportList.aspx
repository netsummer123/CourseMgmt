<%@ Page Title="学生成绩" Language="C#" MasterPageFile="~/MasterPage/List.Master" CodeBehind="PerformReportList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Teach.PerformReportList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Import Namespace="CourseMgmt.BizLogic.Util" %>
<%@ Import Namespace="CourseMgmt.Web.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function doExport(courseId, deptId) {
            $('#<%=hdCourseID.ClientID%>').val(courseId);
            $('#<%=hdDepartmentID.ClientID%>').val(deptId);
            $('#<%=btnExport.ClientID%>').get(0).click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <input id="hdCourseID" type="hidden" runat="server" />
    <input id="hdDepartmentID" type="hidden" runat="server" />
    <asp:Button ID="btnExport" runat="server" Text="导 出" CssClass="button_img" onmouseover="switchbg(this);"
        onmouseout="switchbg(this);" OnClick="btnExport_Click" Style="display: none;" />
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
                                    <td colspan="2">&nbsp;&nbsp; 
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
                            </table>
                        </asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" valign="top">
                        <table cellspacing="0" cellpadding="0" border="0" class="InfolistA2" width="100%">
                            <tr>
                                <th>系部名称</th>
                                <th width="70">年份</th>
                                <th>班级</th>
                                <th width="80">老师</th>
                                <th>课程</th>
                                <th width="80">成绩报表</th>
                            </tr>
                            <asp:Repeater ID="rpList" runat="server" OnItemCommand="rpList_ItemCommand" OnItemDataBound="rpList_OnItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# EnumTypeHelper.GetDescriptionFromEnum(typeof(SysDeptType),Eval("DepartmentType")) %>
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("RegYear") %>
                                        </td>
                                        <td>
                                            <%#Eval("DepartmentName") %>
                                        </td>
                                        <td>
                                            <%#Eval("TeacherName") %>
                                        </td>
                                        <td>
                                            <%#Eval("CourseName") %>
                                        </td>
                                        <td class="align-center">
                                            <a href='javascript:void(0);' onclick="doExport(<%#Eval("CourseID") %>,<%#Eval("DepartmentID") %>);" class="fancybox link-view" title="下载">下载</a>
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
