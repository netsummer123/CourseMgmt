<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubMenu.ascx.cs" Inherits="CourseMgmt.Web.Metro.Control.SubMenu" %>

<ul id="ul-menu">
    <asp:Repeater runat="server" ID="rpLv2Menu" OnItemDataBound="rpLv2Menu_ItemDataBound">
        <ItemTemplate>
            <li id="menu_<%# Eval("ID") %>" class="<%# HasChild(Eval("ID"))?"tab":"" %>" data-link="<%# Eval("Link") %>"
                onclick="<%# HasChild(Eval("ID"))?"toggleMenu(this);":"clickMenu(this);" %>"><%# Eval("DisplayName") %></li>
            <asp:Repeater runat="server" ID="rpLv3Menu">
                <HeaderTemplate>
                    <li class="sub">
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li id="menu_<%# Eval("ID") %>" style="padding: 3px 10px 3px 25px; background-position: 12px 5px;"
                        data-link="<%# Eval("Link") %>" onclick="clickMenu(this);"><%# Eval("DisplayName") %></li>
                </ItemTemplate>
                <FooterTemplate></ul></li></FooterTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
</ul>

<script type="text/javascript">
    $(function () {
        $('#ul-menu li:not(.sub)').on("mouseenter mouseleave", function () { $(this).toggleClass("hover"); });
        setTimeout(function () {
            $('#ul-menu li:first').get(0).click();
        }, 300);
    })
</script>
