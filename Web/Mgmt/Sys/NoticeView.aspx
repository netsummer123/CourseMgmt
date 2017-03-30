<%@ Page Title="查看通知" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="NoticeView.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.NoticeView" %>

<%@ Import Namespace="CourseMgmt.Web.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="<%= ResolveUrl("~/App_Themes/Default/Style/Css/InfoPrevView.css") %>" rel="stylesheet" />
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
                        <td>
                            <div class="article">
                                <div class="article-head">
                                    <h1>
                                        <asp:Literal ID="tbxTitle" runat="server"></asp:Literal></h1>
                                </div>
                                <div class="article-content">
                                    <asp:Literal ID="tbxContent" runat="server"></asp:Literal>
                                </div>
                                <asp:Repeater ID="rpAttachment" runat="server">
                                    <HeaderTemplate>
                                        <div class="article-attachments">
                                            <h2>附件列表</h2>
                                            <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# ResolveUrl(SysConsts.FileUploadDirectory + Eval("FilePath")) %>' target="_blank"><%#Eval("FileName")%></a>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

