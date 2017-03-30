(function () {

    var pluginName = 'KD_selectImage',
        commandName = 'KD_selectImage',
        contextCommandName = 'selectImage',
        menuGroup = "selectImage_group",
        menuItem = "selectImage_item";

    CKEDITOR.plugins.add(pluginName, {
        init: function (editor) {
            editor.addCommand(contextCommandName,
                {
                    exec: function () {
                        if (editor.getSelection() && editor.getSelection().getSelectedElement()) {
                            var element = editor.getSelection().getSelectedElement();

                            if (element.is('img')) {
                                var imgSrc = element.getAttribute('src');
                                ckEditorImgSelected(imgSrc);
                            }
                        }
                    },
                    modes: { wysiwyg: 1, source: 1 },
                    readOnly: 1,
                    canUndo: false
                });

            if (editor.contextMenu) {

                editor.addMenuGroup(menuGroup);

                // Create a manu item
                editor.addMenuItem(menuItem, {
                    label: '选取图片',
                    command: contextCommandName,
                    group: menuGroup
                });

                editor.contextMenu.addListener(function (element, selection) {
                    if (!element || !element.is('img'))
                        return null;
                    return { selectImage_item: CKEDITOR.TRISTATE_ON };
                });
            }

        }
    });

})();