(function () {
    //todo: 导入word文件
    var wordFilter = function (html) {
        alert("导入word");
        return html;
    };

    var pluginName = 'KD_importWord',
		commandName = 'KD_importWord';

    CKEDITOR.plugins.add(pluginName,
	{
	    // List of available localizations.
	    availableLangs: { en: 1, he: 1 },

	    init: function (editor) {
	        editor.ui.addButton(pluginName,
				                    			{
				                    			    label: "导入word",
				                    			    icon: this.path + 'images/importWord.gif',
				                    			    toolbar: 'KD_toolbar, 4',
				                    			    command: commandName
				                    			});
	        editor.ui.addButton("KD_importExcel",
				                    			{
				                    			    label: "导入Excel",
				                    			    icon: this.path + 'images/importExcel.gif',
				                    			    toolbar: 'KD_toolbar, 5',
				                    			    command: commandName
				                    			});
	        editor.addCommand(commandName, new CKEDITOR.dialogCommand(pluginName));
	        CKEDITOR.dialog.add(pluginName, this.path + 'dialogs/KD_importWord.js');
	    }

	});

})();
