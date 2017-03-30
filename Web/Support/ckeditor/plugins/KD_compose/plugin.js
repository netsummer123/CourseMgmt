(function () {
    //一键排版
    function onekey(html) {
        //首行缩进
        var pos1 = html.indexOf("<P>");
        if (pos1<0) {
            pos1 = html.indexOf("<p>");
        }
        if (pos1 < 0) {
            html = "<P>" + html + "</P>";
        }
        html = formatHtml(html);

        //过滤html
        html = html.replace(/&lt;.*?&gt;/g, "");
        return html;
    }


    //封装正则替换，以便打日志查看
    function htmlReplace(html, regExp, relplaceStr) {
        var newhtml = html.replace(regExp, relplaceStr);
//        if (html != newhtml) {
//            var msg = "正则表达式:\n" + regExp + "\n\n替换格式:\n" + relplaceStr + "\n\n原html：\n" + html + "\n\n替换后的html：\n" + newhtml;
//            alert(msg);
//        }
        return newhtml;
    }
    function formatHtml(html) {

        if (html == null || html == "")
            return "";
        var indentedText = "　";
        //indentedText = "&nbsp;&nbsp;";
        var re = new RegExp("(<P)([^>]*>&nbsp;<\/P>)", "gi"); // Different because of a IE 5.0 error
        html = htmlReplace(html, re, "");

        re = new RegExp(indentedText, "gi");
        html = htmlReplace(html, re, "");
        
        ///过滤DIV	
        re = new RegExp("div", "gi");
        html = htmlReplace(html, re, "P");

        re = new RegExp("(<P align=left>)", "gi");
        html = htmlReplace(html, re, "<P>");

        re = new RegExp("^(<P>(&nbsp;| |)</P>\r\n)", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("<P>" + indentedText + indentedText + "( ){0,}(&nbsp;){0,}( ){0,}", "gi");
        html = htmlReplace(html, re, "<P>");

        re = new RegExp("^(<p>){1,}", "gi");
        html = htmlReplace(html, re, "<p>");

        re = new RegExp("^(&nbsp;){1,}", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("^( ){1,}", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("<br>(&nbsp;){1,}", "gi");
        html = htmlReplace(html, re, "<br>");

        re = new RegExp("<br>( ){1,}", "gi");
        html = htmlReplace(html, re, "<br>");

        re = new RegExp("(vAlign=bottom)", "gi");
        html = htmlReplace(html, re, "");
        re = new RegExp("(vAlign=top)", "gi");
        html = htmlReplace(html, re, "");

        //替换<br>为</P><P>
        re = new RegExp("(</p><br>)", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("(<br>)", "gi");
        html = htmlReplace(html, re, "</P><P>");

        re = new RegExp("(<br/>)", "gi");
        html = htmlReplace(html, re, "</P><P>");

        re = new RegExp("(<br />)", "gi");
        html = htmlReplace(html, re, "</P><P>");

        re = new RegExp("<p>(&nbsp;){1,}", "gi");
        html = htmlReplace(html, re, "<p>");

        re = new RegExp("<p>( ){1,}", "gi");
        html = htmlReplace(html, re, "<p>");

        re = new RegExp("(<p><p>)", "gi");
        html = htmlReplace(html, re, "<P>");

        re = new RegExp("<p>(" + indentedText + "){1,}", "gi");
        html = htmlReplace(html, re, "<P>");

        //首行缩进
        re = new RegExp("(<p>)", "gi");
        html = htmlReplace(html, re, "<P>" + indentedText + indentedText);

        re = new RegExp("^(" + indentedText + "){1,}", "gi");
        html = htmlReplace(html, re, "");
        re = new RegExp("^( ){1,}", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("^( ){1,}", "gi");
        html = htmlReplace(html, re, "");
        re = new RegExp("^(" + indentedText + "){1,}", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("(<p>&nbsp;</p>)", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("(<p>" + indentedText + "</p>)", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("(<p></p>)", "gi");
        html = htmlReplace(html, re, "");

        re = new RegExp("(</P><P>)", "gi");
        html = htmlReplace(html, re, "<br />");
        
        return html;
    }

    //插件添加
    var pluginName = 'KD_compose',
		commandName = 'KD_compose';

    CKEDITOR.plugins.add(pluginName,
	{
	    init: function (editor) {
	        editor.addCommand(commandName,
				                    {
				                        exec: function () {
				                            var html = editor.getData();

				                            html = onekey(html);
				                            editor.setData(html);

				                        },
				                        modes: { wysiwyg: 1, source: 1 },
				                        readOnly: 1,
				                        canUndo: false
				                    });
	        editor.ui.addButton(pluginName,
			{
			    label: "一键排版",
			    icon: this.path + 'images/compose.gif',
			    toolbar: 'KD_toolbar, 0',
			    command: commandName
			});
	    }
	});
})();
