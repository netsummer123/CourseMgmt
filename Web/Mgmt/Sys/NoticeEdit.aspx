<%@ Page Title="通知编辑" ValidateRequest="false" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="NoticeEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.NoticeEdit" %>

<%@ Import Namespace="CourseMgmt.Web.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .ui-datepicker-title select {
            width: 70px !important;
        }
    </style>
    <!--ckeditor-->
    <script src="../../Support/ckeditor/ckeditor.js" type="text/javascript"></script>
    <!--ckfinder-->
    <script src="../../Support/ckfinder/ckfinder.js" type="text/javascript"></script>

    <script type="text/javascript">
        //ckfinder应用根目录
        var ckfinderAppPath = '<%= Request.ApplicationPath %>';

        $(function () {
            loadCKEDITOR();
        });

        function loadCKEDITOR() {
            //加载ckeditor
            CKEDITOR.replace('<%= tbxContent.ClientID %>', {
                height: 500,
                fullPage: false,
                allowedContent: true
            });

            CKEDITOR.on('instanceReady', function (e) {
                PageResize2();
            });
        }
    </script>
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
                        <th class="required" width="200">标题
                        </th>
                        <td>
                            <asp:TextBox ID="tbxTitle" runat="server" CssClass="TextBox04 validate[required] input-xxlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">内容
                        </th>
                        <td>
                            <asp:TextBox ID="tbxContent" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>附件
                        </th>
                        <td>
                            <asp:Repeater ID="rpAttachment" runat="server" OnItemCommand="rpAttachment_ItemCommand"
                                OnItemDataBound="rpAttachment_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" class="InfolistA2" width="100%" style="margin-bottom: 5px;">
                                        <tr>
                                            <th style="text-align: center">文件名</th>
                                            <th style="text-align: center" width="80">操作</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="align-left">
                                            <div>
                                                <a href='<%# ResolveUrl(SysConsts.FileUploadDirectory + Eval("FilePath")) %>' target="_blank"><%#Eval("FileName")%></a>
                                            </div>
                                        </td>
                                        <td class="align-center">
                                            <asp:LinkButton ID="btDelete" CommandName="Delete" CssClass="button_img" ToolTip="删除附件" Text="删除附件" CommandArgument='<%# Eval("ID") %>' runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:FileUpload ID="fuAttach" runat="server" CssClass="TextBox04 input-large" />&nbsp;
                            <asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="Button03 validate-skip" Style="width: 44px;"
                                OnClick="btnUpload_Click" />
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button Visible="False" runat="server" ID="btnSaveAdd" Text="保存新增" CssClass="Button04" OnClick="btnSaveAdd_Click" />
                <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04 dynatree-drop-reject" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'NoticeList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveAdd" />
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

