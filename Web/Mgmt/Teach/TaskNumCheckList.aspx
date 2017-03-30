<%@ Page Title="检查作业" Language="C#" MasterPageFile="~/MasterPage/List.Master" CodeBehind="TaskNumCheckList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Teach.TaskNumCheckList" %>

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
                                <td style="color: red;">&nbsp;&nbsp;
                                        请依次选择系部、年份、班级、课程
                                </td>
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
                            </table>
                        </asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" valign="top">
                        <table cellspacing="0" cellpadding="0" border="0" class="InfolistA2" width="100%">
                            <tr>
                                <th width="40" rowspan="2">序号</th>
                                <th width="80" rowspan="2">学号</th>
                                <th width="60" rowspan="2">姓名</th>
                                <th colspan="7">理论教学（50分）</th>
                                <th colspan="3">实践教学（30分）</th>
                                <th rowspan="2">期末<br />
                                    考查<br />
                                    （20）</th>
                            </tr>
                            <tr>
                                <th nowrap="nowrap">课堂<br />
                                    出勤<br />
                                    （10）</th>
                                <th nowrap="nowrap">课堂<br />
                                    表现<br />
                                    （10）</th>
                                <th nowrap="nowrap">课堂<br />
                                    参与<br />
                                    （5）</th>
                                <th nowrap="nowrap">作业1<br />
                                    （5）</th>
                                <th nowrap="nowrap">作业2<br />
                                    （5）</th>
                                <th nowrap="nowrap">作业3<br />
                                    （5）</th>
                                <th nowrap="nowrap">知行<br />
                                    讲堂<br />
                                    （10）</th>
                                <th nowrap="nowrap">公益基地<br />
                                    项目1<br />
                                    （10）</th>
                                <th nowrap="nowrap">公益基地<br />
                                    项目2<br />
                                    （10）</th>
                                <th nowrap="nowrap">校内基地<br />
                                    项目<br />
                                    （10）</th>
                            </tr>
                            <asp:Repeater ID="rpList" runat="server" OnItemCommand="rpList_ItemCommand" OnItemDataBound="rpList_OnItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td class="align-center"><%# Container.ItemIndex+1 %>
                                        </td>
                                        <td class="align-center"><%# Eval("UserName") %>
                                        </td>
                                        <td class="align-center"><%# Eval("RealName") %>
                                        </td>
                                        <td class="align-center">—
                                        </td>
                                        <td class="align-center">—
                                        </td>
                                        <td class="align-center">—
                                        </td>
                                        <td class="align-center" style='color: <%# (decimal)Eval("TaskScore1") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore1") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" style='color: <%# (decimal)Eval("TaskScore2") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore2") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" style='color: <%# (decimal)Eval("TaskScore3") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore3") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center">—
                                        </td>
                                        <td class="align-center" style='color: <%# (decimal)Eval("TaskScore4") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore4") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" style='color: <%# (decimal)Eval("TaskScore5") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore5") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" style='color: <%# (decimal)Eval("TaskScore6") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore6") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" style='color: <%# (decimal)Eval("TaskScore7") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore7") >0 ?"✔":"✘" %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
