(function () {

    var htmlFilter = function (html) {
        if (html == null || html == "")
            return "";
        html = html.replace(/<a((?!href).)*?name((?!href).)*?>(.*?)<\/a>/gi, '$3');
        html = html.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
        html = html.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
        return html;
    };

    var pluginName = 'KD_htmlFilter',
		commandName = 'KD_htmlFilter';

    CKEDITOR.plugins.add(pluginName,
	{
	    // List of available localizations.
	    availableLangs: { en: 1, he: 1 },

	    init: function (editor) {
	        editor.ui.addButton(pluginName,
				                    			{
				                    			    label: "过滤html",
				                    			    icon: this.path + 'images/filterhtml.gif',
				                    			    toolbar: 'KD_toolbar, 1',
				                    			    command: commandName
				                    			});
	        editor.addCommand(commandName,
				                    {
				                        exec: function () {
				                            var html = editor.getData();

				                            html = htmlFilter(html);
				                            editor.setData(html);
				                        },
				                        modes: { wysiwyg: 1, source: 1 },
				                        readOnly: 1,
				                        canUndo: false
				                    });
	    }
	});
})();
