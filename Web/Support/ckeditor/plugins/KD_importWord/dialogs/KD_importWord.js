(function () {

    var exampleDialog = function (editor) {
        var uploadFilepath = CKEDITOR.basePath + 'plugins/KD_importWord/aspx/UploadWordFile.aspx?t=' + new Date();
        return {
            title: "导入Word或Excel",
            minWidth: 400,
            minHeight: 220,
            buttons: [CKEDITOR.dialog.okButton, CKEDITOR.dialog.cancelButton],
            onOk: function () {
                var frame = window.frames["upload-frame"];
                var html = frame.$(".htmlTextBox").val();
                editor.setData(html);
            },
            onLoad: function () {
            },
            onShow: function () {
            },
            onHide: function () {
            },
            onCancel: function () {
            },
            resizable: CKEDITOR.DIALOG_RESIZE_NONE,
            contents: [{
                id: 'page1',  /* not CSS ID attribute! */
                label: 'Page1',
                accessKey: 'P',
                elements: [{
                    type: 'hbox',
                    widths: ['100%'],
                    children:
                        [{
                            type: 'html',
                            html: ' <iframe id="upload-frame" style="width:400px;height:200px;" src="' + uploadFilepath + '" frameBorder="0" name="upload-frame" scrolling="no"></iframe>'
                        }]
                }]
            }]
        }
    }

    CKEDITOR.dialog.add('KD_importWord', function (editor) {
        return exampleDialog(editor);
    });

})();