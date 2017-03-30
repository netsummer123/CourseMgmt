<%@ Page Title="提交作业" ValidateRequest="false" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="TaskEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Stu.TaskEdit" %>


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
            //加载ckeditor
            CKEDITOR.replace('<%= tbxContent.ClientID %>', {
                height: 500,
                fullPage: false,
                allowedContent: true
            });

            CKEDITOR.on('instanceReady', function (e) {
                PageResize2();
            });
        });
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
                        <th class="required" width="200">课程
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxCourseID" runat="server" CssClass="TextBox04 validate[required]"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">作业类型
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxCategoryID" runat="server" CssClass="TextBox04 validate[required]"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">标题
                        </th>
                        <td>
                            <asp:TextBox ID="tbxTitle" runat="server" CssClass="TextBox04 validate[required] input-xxlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>参与成员
                        </th>
                        <td>
                            <asp:TextBox ID="tbxMember" runat="server" CssClass="TextBox04 input-xxlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">活动内容<br />
                            /<br />
                            心得体会<br />
                        </th>
                        <td>
                            <asp:TextBox ID="tbxContent" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button Visible="False" runat="server" ID="btnSaveAdd" Text="保存新增" CssClass="Button04" OnClick="btnSaveAdd_Click" />
                <asp:Button runat="server" ID="btnSave" Text="提交" CssClass="Button04" OnClick="btnSave_Click" />
                <input style="display: none;" type="button" class="Button04" onclick="location.href = 'TaskList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveAdd" />
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

