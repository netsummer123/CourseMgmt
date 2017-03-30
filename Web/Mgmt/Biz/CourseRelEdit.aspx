<%@ Page Title="老师设定编辑" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="CourseRelEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Biz.CourseRelEdit" %>

<%@ Import Namespace="CourseMgmt.Web.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <input id="hdSelectedTreeItemId" type="hidden" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:PlaceHolder runat="server" ID="phData">
                <table cellpadding="5" border="0" class="TableFormB" valign="top" width="100%">
                    <tr>
                        <th class="required" width="200">老师
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxTeacher" runat="server" CssClass="TextBox04 validate[required]" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">年份
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxRegYear" runat="server" CssClass="TextBox04 validate[required] validate-skip" AutoPostBack="True"
                                OnSelectedIndexChanged="tbxRegYear_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>班级
                        </th>
                        <td>
                            <div id="deptTree" class="tree" style="width: 500px;">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button Visible="False" runat="server" ID="btnSaveAdd" Text="保存新增" CssClass="Button04" OnClick="btnSaveAdd_Click" />
                <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'CourseRelList.aspx?CourseID=<%= CourseID%>    ';" value="取消" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="tbxRegYear" />
            <asp:PostBackTrigger ControlID="tbxTeacher" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
    <!--dynatree-->
    <link href="../../App_Content/Plugin/dynatree/skin-vista/ui.dynatree.css" rel="stylesheet" />
    <script src="../../App_Content/Plugin/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../App_Content/Plugin/dynatree/jquery.dynatree.min.js" type="text/javascript"></script>

    <script src="../../App_Content/module/deptTree.js" type="text/javascript"></script>

    <script type="text/javascript">
        //当前选择栏目Id
        var hdSelectedTreeItemId = '#<%= hdSelectedTreeItemId.ClientID %>';
        //当前选择的角色Id
        var year = $('#<%= tbxRegYear.ClientID %>').val();
        var teacherId = $('#<%= tbxTeacher.ClientID %>').val();
        var courseId = '<%= Request["CourseID"] %>';
        //根菜单Id
        var treeRootId = '<%= SysConsts.RootDeptID %>';

        var cookieId = "dynatree-CourseRelEdit-Course_" + courseId + '_'+ Math.random();

        $load(function () {
            if (!teacherId) {
                return;
            }

            //加载菜单树
            initDeptTreeCheckBox(cookieId, function (flag, node) {

                var selectedNodes = node.tree.getSelectedNodes();
                var selectedKeys = $.map(selectedNodes, function (node) {
                    return node.data.key;
                });

                //存储
                $(hdSelectedTreeItemId).val(selectedKeys.join(','));
            });
        });
    </script>
</asp:Content>
