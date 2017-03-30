<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadWordFile.aspx.cs" Inherits="KDSoft.ckeditor.plugins.KD_importWord.aspx.UploadWordFile"   ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        div
        {
            line-height: 25px;
        }
    </style>
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".upLoadBt").click(function () {
                $(".htmlTextBox").val("");
            });

        });

    </script>
</head>
<body style="font-size: 12px;">
    <form id="form1" runat="server">
    <div>
        请选择文件:
        <asp:FileUpload ID="FileUploadWord" runat="server" />
        <asp:Button ID="UpLoadBt" runat="server" Text="转换" CssClass="upLoadBt" OnClick="UpLoadBt_Click" />
    </div>
    <div>
        转换后的html：</div>
    <div>
        <asp:TextBox ID="HtmlTextBox" CssClass="htmlTextBox" Style="width: 400px; height: 100px;"
            TextMode="MultiLine" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" CssClass="msg" ID="Msg"></asp:Label>
    </div>
    </form>
</body>
</html>
