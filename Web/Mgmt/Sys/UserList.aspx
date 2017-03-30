﻿<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/MasterPage/List.Master" CodeBehind="UserList.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.UserList" %>

<%@ Import Namespace="CourseMgmt.Web.Common" %>
<%@ Import Namespace="CourseMgmt.BizLogic.Util" %>

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
                            <td>&nbsp;&nbsp; 名称：<asp:TextBox runat="server" ID="searchName" CssClass="TextBox04" />
                                &nbsp;&nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="Button03" Style="width: 44px;" Text="搜索" OnClick="btnSearch_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </asp:PlaceHolder>
            </td>
            <td align="right" class="SearchBg01">
                <asp:Button Visible="False" runat="server" ID="btnAdd" CssClass="Button03" Style="width: 44px;" Text="添加" OnClick="btnAdd_Click"></asp:Button>
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
                                <th>用户名</th>
                                <th>姓名</th>
                                <th width="70">性别</th>
                                <th width="100">手机号码</th>
                                <th width="50">序号</th>
                                <th width="150px">操作</th>
                            </tr>
                            <asp:Repeater ID="rpList" runat="server" OnItemCommand="rpList_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td class="align-center">
                                            <asp:CheckBox ID="cbID" class="check cbx" ToolTip='<%# Eval("ID") %>' runat="server" />
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("ID") %>
                                        </td>
                                        <td>
                                            <%#Eval("UserName") %>
                                        </td>
                                        <td>
                                            <%#Eval("RealName") %>
                                        </td>
                                        <td class="align-center">
                                            <%# EnumTypeHelper.GetDescriptionFromEnum(typeof(SexType),Eval("Sex")) %>
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("Mobile") %>
                                        </td>
                                        <td class="align-center">
                                            <%#Eval("OrderNum") %>
                                        </td>
                                        <td class="align-center">
                                            <a class="fancybox link-view" href='UserPwdEdit.aspx?UserID=<%# Eval("ID") %>' title="重置密码">重置密码</a>
                                            &nbsp;
                                            <a class="fancybox link-edit" href='UserEdit.aspx?UserID=<%# Eval("ID") %>' title="修改">修改</a>
                                            &nbsp;
                                            <asp:LinkButton ID="btDelete" CommandName="Delete" CssClass="link-del confirm" ToolTip="删除" Text="删除" CommandArgument='<%# Eval("ID") %>' runat="server" />
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
