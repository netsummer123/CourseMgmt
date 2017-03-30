<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CourseMgmt.Web.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <title></title>

    <script type="text/javascript">
        function redraw() {
            // force ie10 redraw
            var w = document.body.clientWidth;
            document.body.style.width = w + 1 + 'px';
            setTimeout(function () {
                document.body.style.width = w - 1 + 'px';
                document.body.style.width = 'auto';
            }, 100);  // 这个延时时间看情况可能需要适当调大
        }
    </script>
</head>
<frameset rows="78,*,0,0" border="0" frameborder="0" framespacing="0" framepadding="0">
    <frame name="head" scrolling="no" noresize target="main" src="Frame/Top20130608.aspx" frameborder="0">

    <frame id="main" name="main" src="Frame/MainFrame.aspx" frameborder="0" scrolling="no" />
    <frame name="bottom" target="main" src="Frame/Bottom.aspx" frameborder="0" scrolling="no" noresize />
    <frame name="hide" src="Frame/popup.aspx" target="main" scrolling="auto" noresize />
    <noframes>
        <body>

            <p>此网页使用了框架，但您的浏览器不支持框架。</p>

        </body>
    </noframes>
</frameset>

</html>
