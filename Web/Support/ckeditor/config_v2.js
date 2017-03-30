/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here.
    // For complete reference see:
    // http://docs.ckeditor.com/#!/api/CKEDITOR.config

    // The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: ['find', 'selection'] },
		{ name: 'insert' },
        { name: 'forms' },
		{ name: 'others' },
        { name: 'KD_toolbar' },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
		{ name: 'styles' },
		{ name: 'colors' },
        { name: 'links' }
    ];

    // Remove some buttons provided by the standard plugins, which are
    // not needed in the Standard(s) toolbar.
    config.removeButtons = 'Underline,Subscript,Superscript';

    // Set the most common block elements.
    config.format_tags = 'p;h1;h2;h3;pre';

    // Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced';



    //º”‘ÿckfinder≈‰÷√
    config.filebrowserBrowseUrl = ckfinderAppPath + '/Support/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = ckfinderAppPath + '/Support/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = ckfinderAppPath + '/Support/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = ckfinderAppPath + '/Support/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = ckfinderAppPath + '/Support/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = ckfinderAppPath + '/Support/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.language = "zh-cn";

    ////º”‘ÿ≤Âº˛
    config.extraPlugins += (config.extraPlugins ? ',KD_wordFilter' : 'KD_wordFilter');
    config.extraPlugins += (config.extraPlugins ? ',KD_htmlFilter' : 'KD_htmlFilter');
    config.extraPlugins += (config.extraPlugins ? ',KD_importWord' : 'KD_importWord');
    config.extraPlugins += (config.extraPlugins ? ',KD_compose' : 'KD_compose');
    config.extraPlugins += (config.extraPlugins ? ',KD_selectImage' : 'KD_selectImage');
    //config.extraPlugins += (config.extraPlugins ? ',KD_selectTitle' : 'KD_selectTitle');


};

