<%@ Page Title="作业打分" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="ViewTaskEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Teach.ViewTaskEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="<%= ResolveUrl("~/App_Themes/Default/Style/Css/InfoPrevView.css") %>" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker-title select {
            width: 70px !important;
        }
    </style>
    <script type="text/javascript">

        $(function () {

            var cateId = $('#<%= tbxCategoryID.ClientID %>').val();
            var maxScore = 0;
            switch (parseInt(cateId)) {
                case 10:
                case 20:
                case 30:
                    maxScore = 5;
                    break;
                case 70:
                    maxScore = 20;
                    break;
                default:
                    maxScore = 10;
                    break;
            }

            //alert(cateId + "," + maxScore);

            $('#<%= tbxScore.ClientID %>').addClass('validate[max[' + maxScore + ']]');
            $('#tip').html('最高' + maxScore + '分');
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
                        <th width="200">课程
                        </th>
                        <td>
                            <asp:TextBox ID="tbxCourseName" ReadOnly="True" runat="server" CssClass="TextboxRead input-xlarge"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>作业类型
                        </th>
                        <td>
                            <asp:TextBox ID="tbxCategory" ReadOnly="True" runat="server" CssClass="TextboxRead"></asp:TextBox>
                            <asp:TextBox ID="tbxCategoryID" ReadOnly="True" runat="server" Style="display: none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>标题
                        </th>
                        <td>
                            <asp:TextBox ID="tbxTitle" ReadOnly="True" runat="server" CssClass="TextboxRead input-xxlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>时间
                        </th>
                        <td>
                            <asp:TextBox ID="tbxFinishTime" ReadOnly="True" runat="server" CssClass="TextboxRead"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>参与成员
                        </th>
                        <td>
                            <asp:TextBox ID="tbxMember" ReadOnly="True" runat="server" CssClass="TextboxRead input-xxlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>统计字数
                        </th>
                        <td>大约
                            <asp:TextBox ID="tbxCounter" ReadOnly="True" runat="server" CssClass="TextboxRead input-mini"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>活动内容<br />
                            /<br />
                            心得体会<br />
                        </th>
                        <td>
                            <div class="article-content">
                                <asp:Literal ID="tbxContent" runat="server"></asp:Literal>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>得分
                        </th>
                        <td>
                            <asp:TextBox ID="tbxScore" runat="server" CssClass="TextBox04 validate[required,custom[integer]]"></asp:TextBox>
                            <span class="help" id="tip"></span>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button runat="server" ID="btnSave" Text="提交" CssClass="Button04" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'ViewTaskList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

