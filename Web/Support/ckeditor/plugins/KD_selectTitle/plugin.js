(function () {

    var selectTitle = function (text) {
        if (text == null || text == "")
            return;

        if ($(window.frames['aspnetForm'].document)) {
            $(window.frames['aspnetForm'].document).find('.fcTitle').val(text);
        }
        else if (parent.$) {
            parent.$('.fcTitle').val(text);
        }
    };

    var pluginName = 'KD_selectTitle',
		commandName = 'KD_selectTitle';

    CKEDITOR.plugins.add(pluginName,
	{
	    availableLangs: { en: 1, he: 1 },

	    init: function (editor) {
	        editor.ui.addButton(pluginName,
				                    			{
				                    			    label: "选取标题",
				                    			    icon: this.path + 'images/selectTitle.gif',
				                    			    toolbar: 'KD_toolbar, 3',
				                    			    command: commandName
				                    			});
	        editor.addCommand(commandName,
				                    {
				                        exec: function () {

				                            var thisSelect = editor.getSelection();
				                            var nativeSel = thisSelect.getNative();
				                            var text = CKEDITOR.env.ie ? nativeSel.createRange().text : nativeSel.toString();
				                            selectTitle(text);

				                        },
				                        modes: { wysiwyg: 1, source: 1 },
				                        readOnly: 1,
				                        canUndo: false
				                    });
	    }
	});
})();
