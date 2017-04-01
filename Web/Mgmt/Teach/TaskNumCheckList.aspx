<%@ Page Title="检查作业" Language="C#" MasterPageFile="~/MasterPage/ListLarge.Master" CodeBehind="TaskNumCheckList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Teach.TaskNumCheckList" %>

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
                                <th width="40" rowspan="3">序号</th>
                                <th width="80" rowspan="3">学号</th>
                                <th width="60" rowspan="3">姓名</th>
                                <th style="background: #fff;" colspan="21">理论教学（50分）</th>
                                <th colspan="9">实践教学（30分）</th>
                                <th style="background: #fff;" colspan="3">期末考查（20分）</th>
                            </tr>
                            <tr>
                                <th style="background: #fff;" nowrap="nowrap" colspan="2">课堂态度<br />
                                    （10分）</th>
                                <th style="background: #fff;" nowrap="nowrap" colspan="3">问题研讨<br />
                                    （10分）</th>
                                <th style="background: #fff;" nowrap="nowrap" colspan="4">话题演讲<br />
                                    （5分）</th>
                                <th nowrap="nowrap" colspan="3">理论作业1<br />
                                    （5分）</th>
                                <th nowrap="nowrap" colspan="3">理论作业2<br />
                                    （5分）</th>
                                <th nowrap="nowrap" colspan="3">理论作业3<br />
                                    （5分）</th>
                                <th style="background: #fff;" nowrap="nowrap" colspan="3">知行讲堂<br />
                                    （10分）</th>
                                <th nowrap="nowrap" colspan="3">实践项目1<br />
                                    （10分）</th>
                                <th nowrap="nowrap" colspan="3">实践项目2<br />
                                    （10分）</th>
                                <th nowrap="nowrap" colspan="3">实践项目3<br />
                                    （10分）</th>
                                <th style="background: #fff;" nowrap="nowrap" colspan="3">课程论文（20分）</th>
                            </tr>
                            <tr>
                                <th style="background: #fff;" nowrap="nowrap">出勤<br />
                                    （5分）</th>
                                <th style="background: #fff;" nowrap="nowrap">纪律<br />
                                    （5分）</th>
                                <th style="background: #fff;" nowrap="nowrap">小组讨论<br />
                                    （3分）</th>
                                <th style="background: #fff;" nowrap="nowrap">师生互动<br />
                                    （4分）</th>
                                <th style="background: #fff;" nowrap="nowrap">发言质量<br />
                                    （3分）</th>
                                <th style="background: #fff;" nowrap="nowrap">演讲内容<br />
                                    （2分）</th>
                                <th style="background: #fff;" nowrap="nowrap">演讲技巧<br />
                                    （1分）</th>
                                <th style="background: #fff;" nowrap="nowrap">演讲效果<br />
                                    （1分）</th>
                                <th style="background: #fff;" nowrap="nowrap">脱稿<br />
                                    （1分）</th>
                                <th nowrap="nowrap">理论阐述<br />
                                    （2分）</th>
                                <th nowrap="nowrap">联系实际<br />
                                    （2分）</th>
                                <th nowrap="nowrap">观点表达<br />
                                    （1分）</th>
                                <th nowrap="nowrap">理论阐述<br />
                                    （2分）</th>
                                <th nowrap="nowrap">联系实际<br />
                                    （2分）</th>
                                <th nowrap="nowrap">观点表达<br />
                                    （1分）</th>
                                <th nowrap="nowrap">理论阐述<br />
                                    （2分）</th>
                                <th nowrap="nowrap">联系实际<br />
                                    （2分）</th>
                                <th nowrap="nowrap">观点表达<br />
                                    （1分）</th>
                                <th style="background: #fff;" nowrap="nowrap">参与态度<br />
                                    （2分）</th>
                                <th style="background: #fff;" nowrap="nowrap">内容记录<br />
                                    （4分）</th>
                                <th style="background: #fff;" nowrap="nowrap">感悟表达<br />
                                    （4分）</th>
                                <th nowrap="nowrap">参与态度<br />
                                    （2分）</th>
                                <th nowrap="nowrap">小组合作<br />
                                    （4分）</th>
                                <th nowrap="nowrap">报告撰写<br />
                                    （4分）</th>
                                <th nowrap="nowrap">参与态度<br />
                                    （2分）</th>
                                <th nowrap="nowrap">小组合作<br />
                                    （4分）</th>
                                <th nowrap="nowrap">报告撰写<br />
                                    （4分）</th>
                                <th nowrap="nowrap">参与态度<br />
                                    （2分）</th>
                                <th nowrap="nowrap">小组合作<br />
                                    （4分）</th>
                                <th nowrap="nowrap">报告撰写<br />
                                    （4分）</th>
                                <th style="background: #fff;" nowrap="nowrap">知识掌握<br />
                                    （8分）</th>
                                <th style="background: #fff;" nowrap="nowrap">观点表达<br />
                                    （8分）</th>
                                <th style="background: #fff;" nowrap="nowrap">行文逻辑<br />
                                    （4分）</th>
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
                                        <td class="align-center" colspan="2">—
                                        </td>
                                        <td class="align-center" colspan="3">—
                                        </td>
                                        <td class="align-center" colspan="4">—
                                        </td>
                                        <td class="align-center" colspan="3" style='color: <%# (decimal)Eval("TaskScore1") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore1") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" colspan="3" style='color: <%# (decimal)Eval("TaskScore2") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore2") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" colspan="3" style='color: <%# (decimal)Eval("TaskScore3") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore3") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" colspan="3">—
                                        </td>
                                        <td class="align-center" colspan="3" style='color: <%# (decimal)Eval("TaskScore4") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore4") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" colspan="3" style='color: <%# (decimal)Eval("TaskScore5") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore5") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" colspan="3" style='color: <%# (decimal)Eval("TaskScore6") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore6") >0 ?"✔":"✘" %>
                                        </td>
                                        <td class="align-center" colspan="3" style='color: <%# (decimal)Eval("TaskScore7") >0 ?"blue":"red" %>'><%# (decimal)Eval("TaskScore7") >0 ?"✔":"✘" %>
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
