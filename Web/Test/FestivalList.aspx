<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FestivalList.aspx.cs" Inherits="FestivalList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>节日设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../@Theme/WS/Style1/Css/Css.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box01">
            <tr>
                <td class="PageToolBar">
                    <table border="0" cellpadding="0" cellspacing="0" class="PageToolBarItem" align="left"
                        style="height: 24px">
                        <tr>
                            <td valign="middle">&nbsp;&nbsp; 选择年份
                                <asp:DropDownList ID="ddlYear" runat="server"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:Button ID="btnRefresh" runat="server" Style="display: none" />&nbsp;&nbsp;
                            </td>
                            <td valign="middle">&nbsp;&nbsp;
                                <asp:LinkButton ID="btnNewFestvial" runat="server">
                                    <img src="../@Theme/WS/UI Standard/icon/Action/add.gif" border="0" align="absmiddle" /> 添加假日</asp:LinkButton>&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" id="MainTable">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="PageGridHeader TableFix">
                        <tr>
                            <td align="center">法定假日</td>
                            <td align="center">开始时间</td>
                            <td align="center">结束时间</td>
                            <td align="center">最新修改时间</td>
                            <td width="50" align="center">编辑</td>
                            <td width="50" align="center">删除</td>
                        </tr>
                         <tr>
                            <td align="center" class="info">法定假日</td>
                            <td align="center">开始时间</td>
                            <td align="center">结束时间</td>
                            <td align="center">最新修改时间</td>
                            <td width="50" align="center">编辑</td>
                            <td width="50" align="center">删除</td>
                        </tr> <tr>
                            <td align="center" class="info">法定假日</td>
                            <td align="center">开始时间</td>
                            <td align="center">结束时间</td>
                            <td align="center">最新修改时间</td>
                            <td width="50" align="center" class="info"><a>编辑</a></td>
                            <td width="50" align="center">删除</td>
                        </tr>
                    </table>
                    <div id="MainList" class="ScrollDiv" style="border-right-width: 1px">
                        
                        <asp:GridView ID="gvFestivalList" runat="server" AutoGenerateColumns="False" Width="100%"
                            ShowHeader="False" BorderWidth="0px" CellPadding="0" CssClass="TableFix">
                            <Columns>
                                <asp:BoundField HeaderText="FestivalCode" DataField="FestivalCode" ReadOnly="True"
                                    Visible="False" />
                                <asp:BoundField HeaderText="法定假日" DataField="FestivalName">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="开始时间" DataField="StartTime">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="结束时间" DataField="EndTime">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="最新修改时间" DataField="CreateTime">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:ButtonField CommandName="Edit" HeaderText="编辑" Text="编辑">
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="Delete" HeaderText="删除" Text="删除">
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                </asp:ButtonField>
                            </Columns>
                            <RowStyle CssClass="info" />
                            <EmptyDataRowStyle CssClass="info" />
                            <EmptyDataTemplate>
                                <center>
                                    &gt; &gt; 尚未设置法定假日 &lt; &lt;</center>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
