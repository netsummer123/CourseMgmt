/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    CKEDITOR.config.toolbar_Full =
[
//	{ name: 'document', items: ['Source', '-', "KD_selectTitle"] }, //,'Save', 'NewPage', 'DocProps', 'Preview', 'Print', '-', 'Templates'
    { name: 'KD', items: ["KD_compose", '-', "KD_wordFilter", '-', "KD_htmlFilter", '-', "KD_importWord", '-', "KD_importExcel"] },
    '/',
//	{ name: 'editing', items: ['Copy', 'Paste', 'Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'] },
//  { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
//	{ name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
	'/',
	{ name: 'basicstyles', items: ['Source', 'Maximize', 'Image', '-', 'Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', 'RemoveFormat', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', "KD_selectTitle"] },
//  { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
//	{ name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
	'/',
	{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
	{ name: 'colors', items: ['TextColor', 'BGColor'] },
//	{ name: 'tools', items: ['Maximize', 'ShowBlocks', '-', 'About'] }
];

    //模版在线编辑对应的插件
    config.toolbar_KDTemplateTool = [
    { name: 'document', items: ['Source'] },

    { name: 'KD', items: ["KD_compose", '-', "KD_wordFilter", '-', "KD_htmlFilter", '-', "KD_selectTitle", '-', "KD_importWord", '-', "KD_importExcel", '-'] }
    ];

    //加载插件
    config.extraPlugins += (config.extraPlugins ? ',KD_wordFilter' : 'KD_wordFilter');
    config.extraPlugins += (config.extraPlugins ? ',KD_htmlFilter' : 'KD_htmlFilter');
    config.extraPlugins += (config.extraPlugins ? ',KD_importWord' : 'KD_importWord');
    config.extraPlugins += (config.extraPlugins ? ',KD_selectTitle' : 'KD_selectTitle');
    config.extraPlugins += (config.extraPlugins ? ',KD_compose' : 'KD_compose');
    config.extraPlugins += (config.extraPlugins ? ',KD_selectImage' : 'KD_selectImage');



    //config.toolbar = "KDTool";

    config.forcePasteAsPlainText = false;
    config.pasteFromWordNumberedHeadingToList = true;
    config.pasteFromWordPromptCleanup = false;
    config.pasteFromWordRemoveFontStyles = true;
    config.pasteFromWordRemoveStyles = false;

};
