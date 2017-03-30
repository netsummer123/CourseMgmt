<%@ Page Title="菜单编辑" Language="C#" MasterPageFile="~/MasterPage/Edit.Master" AutoEventWireup="true" CodeBehind="MenuEdit.aspx.cs" Inherits="CourseMgmt.Web.Mgmt.Sys.MenuEdit" %>

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
                        <th class="required" width="200">显示名称
                        </th>
                        <td>
                            <asp:TextBox ID="tbxDisplayName" runat="server" CssClass="TextBox04 validate[required]" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>提示
                        </th>
                        <td>
                            <asp:TextBox ID="tbxToolTip" runat="server" CssClass="TextBox04" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">名称
                        </th>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server" CssClass="TextBox04 validate[required]" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="required">上级菜单
                        </th>
                        <td>
                            <asp:TextBox ID="tbxParentName" CssClass="readonly TextBox04 validate[required]" runat="server" MaxLength="200" />
                            <div class="btn-group">
                                <a id="openDropdown" class="dropdown-toggle" style="cursor: pointer;">选择</a>
                                <div id="dropdownMenu" style="position: absolute; top: 195px; left: 235px; border: 1px solid #ADD2FF;">
                                    <div id="menuTree" class="tree"></div>
                                </div>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <th>目标
                        </th>
                        <td>
                            <asp:TextBox ID="tbxTarget" runat="server" CssClass="TextBox04" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>链接地址
                        </th>
                        <td>
                            <asp:TextBox ID="tbxLink" runat="server" CssClass="TextBox04 input-xxlarge" MaxLength="150"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>是否显示
                        </th>
                        <td>
                            <asp:DropDownList ID="tbxVisible" runat="server" CssClass="TextBox04 input-mini">
                                <asp:ListItem Text="是" Value="True"></asp:ListItem>
                                <asp:ListItem Text="否" Value="False"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>图标地址
                        </th>
                        <td>
                            <asp:TextBox ID="tbxImageUrl" runat="server" CssClass="TextBox04 input-xxlarge" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>排序
                        </th>
                        <td>
                            <asp:TextBox ID="tbxOrderNum" runat="server" CssClass="TextBox04 input-mini validate[custom[integer]]"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>描述
                        </th>
                        <td>
                            <asp:TextBox ID="tbxDescription" runat="server" CssClass="TextBox04 input-xxlarge" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
            <div style="text-align: center; margin-top: 5px;">
                <asp:Button Visible="False" runat="server" ID="btnSaveAdd" Text="保存新增" CssClass="Button04" OnClick="btnSaveAdd_Click" />
                <asp:Button runat="server" ID="btnSave" Text="保存" CssClass="Button04" OnClick="btnSave_Click" />
                <input type="button" class="Button04" onclick="location.href = 'MenuList.aspx';" value="取消" />
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
        //当前选择栏目Id
        var hdSelectedTreeItemId = '#<%=hdSelectedTreeItemId.ClientID%>';
        //当前选择栏目名称，
        var SelectedTreeItemName = '#<%=tbxParentName.ClientID%>';
        //根菜单Id
        var treeRootId = '<%= SysConsts.RootMenuID%>';

        $ajaxload(function () {

            //下拉树初始化
            var clickCount = 0;
            $('.dropdown-toggle').click(function () {
                //第一次展现时进行初始化
                if (clickCount == 0) {
                    //初始化树
                    initDropdownMenuTree("dynatree-MenuEdit");
                }

                var dropdownMenu = $('#dropdownMenu');
                if (dropdownMenu.is(':hidden'))
                    dropdownMenu.show();
                else
                    dropdownMenu.hide();

            });
        });
    </script>
</asp:Content>
