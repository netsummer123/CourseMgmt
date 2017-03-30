<%@ Page Title="角色编辑" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.RoleEdit" %>

<%@ Import Namespace="CourseMgmt.Web.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
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
                        <th class="required" width="200">名称
                        </th>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server" CssClass="TextBox04 validate[required]" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>描述
                        </th>
                        <td>
                            <asp:TextBox ID="tbxDescription" runat="server" CssClass="TextBox04 input-xxlarge" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="phMenu" Visible="False">
                        <tr>
                            <th>菜单
                            </th>
                            <td>
                                <div id="menuTree" class="tree" style="width: 500px;"></div>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button Visible="False" runat="server" ID="btnSaveAdd" Text="保存新增" CssClass="Button04" OnClick="btnSaveAdd_Click" />
                <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'RoleList.aspx';" value="取消" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
    <!--dynatree-->
    <link href="../../App_Content/Plugin/dynatree/skin-vista/ui.dynatree.css" rel="stylesheet" />
    <script src="../../App_Content/Plugin/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../App_Content/Plugin/dynatree/jquery.dynatree.min.js" type="text/javascript"></script>

    <script src="../../App_Content/module/menuTree.js" type="text/javascript"></script>
    <script type="text/javascript">
        //当前选择菜单Id
        var hdSelectedTreeItemId = '#<%=hdSelectedTreeItemId.ClientID%>';
        //当前选择的角色Id
        var hdSelectedRoleId = '#<%=hdSelectedRoleId.ClientID%>';
        //根菜单Id
        var treeRootId = '<%= SysConsts.RootMenuID %>';

        var cookieId = "dynatree-RoleEdit_" + Math.random();

        $(function () {

            var roleId = $(hdSelectedRoleId).val();
            if (!roleId)
                return;

            //加载菜单树
            initMenuTreeCheckBox(cookieId, function (flag, node) {

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
