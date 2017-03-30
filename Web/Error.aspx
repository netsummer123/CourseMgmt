<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CourseMgmt.Web.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统异常</title>
    <style>
        body
        {
            margin: 0px;
            background-color: #EEEEEE;
        }
        p, div
        {
            font-family: Arial, Helvetica;
            font-size: 8pt;
            color: #333333;
        }
        h1
        {
            font-family: Arial, Helvetica;
            font-size: 12pt;
            font-weight: bold;
            background-color: #EEEEEE;
            width: 100%;
            border-bottom: solid 1px #CCCCCC;
            padding: 1px;
        }
        #errorbox
        {
            padding: 10px;
            margin: 30px;
            background-color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="errorbox">
        <h1>
            <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label></p>
    </div>
    </form>
</body>
</html>
