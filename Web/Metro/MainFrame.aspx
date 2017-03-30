<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainFrame.aspx.cs" Inherits="CourseMgmt.Web.Metro.MainFrame" %>

<%@ Import Namespace="CourseMgmt.Web.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= SysConsts.SystemName %></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link href="<%= ResolveUrl("~/App_Themes/Default/yui3CssReset.css") %>" rel="stylesheet" />
    <script type="text/javascript" src="<%= ResolveUrl("~/App_Content/jquery-1.9.1.min.js") %>"></script>
    <script type="text/javascript">
        var theme_root = '<%= Request.ApplicationPath%>/App_Themes/Metro/';
        var cur_color = 11;
    </script>
    <script type="text/javascript" src="metro.js"></script>
</head>
<body scroll="no">
    <div class="portal">
        <div class="head">
            <div class="title">
                <div class="text">
                    <div class="icon" style="display: none;">
                    </div>
                    <%= SysConsts.SystemName %>
                </div>
                <div class="text" id="mainMenuName" style="display: none;">
                </div>
                <div class="menu" style="display: none;">
                    <button class="icon"></button>
                    <input type="text" class="menu_helper" />
                </div>
            </div>
            <div class="headline">
                <%= SysConsts.SystemName %>
            </div>
            <div class="action">
            </div>
            <div class="info">
                <div class="avatar">
                    <div style="line-height: 26px; height: 26px;">
                        <img src="../App_Themes/Metro/avatar01.jpg" />
                    </div>
                    <div class="dept">
                        <span><%= CurrentUser.DepartmentName %> </span><span><%= CurrentUser.RealName %> </span>
                    </div>
                    <ul class="avatar_detail">
                        <li class="left">
                            <a href="#">
                                <img src="../App_Themes/Metro/avatar01.jpg" />
                            </a>
                        </li>
                        <li class="right">
                            <ul>
                                <li><%= CurrentUser.BaseDeptName %>-<br />
                                    <%= CurrentUser.DepartmentName %>
                                </li>
                                <li style="line-height: 16px;">-----------------------</li>
                                <li class="action">编辑个人资料</li>
                                <li class="action">帐户设置</li>
                                <li class="action logout">注销</li>
                            </ul>
                            <input type="text" class="helper" />
                        </li>
                    </ul>
                </div>
                <div class="avatar_dept_index">
                    <div class="dept">
                        <span>@parentdept</span> <span>@maindept</span> <span>DisplayName</span>
                    </div>
                </div>
                <div class="avatar_index">
                    <a>
                        <img alt="个人设置" src="@avatar" />
                    </a>
                </div>
                <div class="button">
                    <div class="setting" style="display: block;">
                        <div class="icon">
                        </div>
                        <ul class="setting_detail">
                            <li class="clrpanel">
                                <div color="0">
                                </div>
                                <div color="1">
                                </div>
                                <div color="2">
                                </div>
                                <div color="3">
                                </div>
                                <div color="4">
                                </div>
                                <div color="5">
                                </div>
                                <div color="6">
                                </div>
                                <div color="7">
                                </div>
                                <div color="8">
                                </div>
                                <div color="9">
                                </div>
                                <div color="10">
                                </div>
                                <div color="11">
                                </div>
                                <input type="text" class="helper" />
                            </li>
                            <li class="split">
                                <div>
                                </div>
                            </li>
                            <li class="action">高级设置</li>
                            <li class="split">
                                <div>
                                </div>
                            </li>
                            <li class="action">关于</li>
                            <li class="action">联系我们</li>
                            <li class="action">帮助</li>
                        </ul>
                    </div>
                    <div class="logout">
                        <div class="icon">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="menu">
            <ul>
                <asp:Repeater runat="server" ID="rpLv1Menu">
                    <ItemTemplate>
                        <li class="icon basegbcolor" id="menu_<%# Eval("ID") %>" data-id="<%# Eval("ID") %>" data-link="<%# Eval("Link") %>" data-name="<%# Eval("DisplayName") %>"
                            onclick="initSubMenu(this,<%# HasChild(Eval("ID"))?"true":"false" %>)"><%# Eval("DisplayName") %></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="document" id="document">
            <div class="submenu" id="submenu">
            </div>
            <div id="spliter-wrap" class="spliter-wrap">
                <div id="spliter" class="spliter"></div>
            </div>
            <div class="content">
                <div style="height: 100%;">
                    <iframe id="iframe-main" name="iframe-main" class="iframe-main" frameborder="0"></iframe>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
