<%@ Page Title="通知管理" Language="C#" MasterPageFile="~/MasterPage/List.Master" CodeBehind="NoticeList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.NoticeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="../../App_Content/Plugin/fancybox/jquery.fancybox.css" rel="stylesheet" />
    <script src="../../App_Content/Plugin/fancybox/jquery.fancybox.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.fancybox').fancybox({
                'type': 'iframe',
                'width': '1000px',
                'height': '680px',
                'autoSize': false
            });
        });
    </script>
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
                            <td>&nbsp;&nbsp; 标题：<asp:TextBox runat="server" ID="searchTitle" CssClass="TextBox04" />
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
                                <th width="40">
                                    <input id="cbxAll" type="checkbox" title="全选" onclick="checkAll(this);" />
                                </th>
                                <th width="50">编号</th>
                                <th>标题</th>
                                <th width="100">发送者</th>
                                <th width="100">发送时间</th>
                                <th width="60">是否发布</th>
                                <th width="150px">操作</th>
                            </tr>
                            <asp:Repeater ID="rpList" runat="server" OnItemCommand="rpList_ItemCommand" OnItemDataBound="rpList_OnItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td class="align-center">
                                            <asp:CheckBox ID="cbID" class="check cbx" ToolTip='<%# Eval("ID") %>' runat="server" />
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("ID") %>
                                        </td>
                                        <td>
                                            <a class="fancybox link-view" href='NoticeView.aspx?NoticeID=<%# Eval("ID") %>' title="<%#Eval("Title") %>"><%#Eval("Title") %></a>
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("SenderName") %>
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("SendTime","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td class="align-center">
                                            <%#(bool)Eval("IsPublished")?"是":"否"%>
                                        </td>
                                        <td class="align-center">
                                            <a class="fancybox link-view" href='NoticeView.aspx?NoticeID=<%# Eval("ID") %>' title="查看">查看</a>
                                            &nbsp;<a class="link-edit" href='NoticeEdit.aspx?NoticeID=<%# Eval("ID") %>' title="修改">修改</a>
                                            &nbsp;<asp:LinkButton ID="btPublish" CommandName="Publish" ToolTip="发布" Text='<%#(bool)Eval("IsPublished")?"撤回":"发布"%>'
                                                ForeColor="blue" CommandArgument='<%# Eval("ID") %>' runat="server" />&nbsp;
                                            &nbsp;<asp:LinkButton ID="btDelete" CommandName="Delete" CssClass="link-del confirm" ToolTip="删除" Text="删除"
                                                CommandArgument='<%# Eval("ID") %>' runat="server" />
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
