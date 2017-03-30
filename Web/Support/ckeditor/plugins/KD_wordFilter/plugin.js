(function () {

    var wordFilter = function (html) {
        if (html == null || html == "")
            return "";
        html = html.replace(/<a((?!href).)*?name((?!href).)*?>(.*?)<\/a>/gi, '$3');
        html = html.replace(/<\/?SPAN[^>]*>/gi, "");
        html = html.replace(/<(\w[^>]*) class=([^ |>]*)([^>]*)/gi, "<$1$3");
        html = html.replace(/<(\w[^>]*) style="([^"]*)"([^>]*)/gi, "<$1$3");
        html = html.replace(/<(\w[^>]*) lang=([^ |>]*)([^>]*)/gi, "<$1$3");
        html = html.replace(/<\\?\?xml[^>]*>/gi, "");
        html = html.replace(/<\/?\w+:[^>]*>/gi, "");
        html = html.replace(/&nbsp; /gi, '&nbsp;&nbsp;');
        html = html.replace(/<\s*[^>]*>(&nbsp;| )+<\s*[^>]*>/gi, '');
        html = html.replace(/<([^\s>]+)(\s[^>]*)?>\s*<\/\1>/g, '');
        html = html.replace(/<([^\s>]+)(\s[^>]*)?>\s*<\/\1>/g, '');
        html = html.replace(/<([^\s>]+)(\s[^>]*)?>\s*<\/\1>/g, '');
        return html;
    };

    var pluginName = 'KD_wordFilter',
		commandName = 'KD_wordFilter';

    CKEDITOR.plugins.add(pluginName,
	{
	    // List of available localizations.
	    availableLangs: { en: 1, he: 1 },

	    init: function (editor) {
	        editor.ui.addButton(pluginName,
				                    			{
				                    			    label: "过滤word",
				                    			    icon: this.path + 'images/filterword.gif',
				                    			    toolbar: 'KD_toolbar, 2',
				                    			    command: commandName
				                    			});
	        editor.addCommand(commandName,
				                    {
				                        exec: function () {
				                            var html = editor.getData();

				                            html = wordFilter(html);
				                            editor.setData(html);
				                        },
				                        modes: { wysiwyg: 1, source: 1 },
				                        readOnly: 1,
				                        canUndo: false
				                    });
	    }
	});
})();
