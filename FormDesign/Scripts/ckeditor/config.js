/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

//CKEDITOR.editorConfig = function (config) {
//    config.extraPlugins = "myplug";   //增加了我们的自定义插件
//    config.toolbar = 'Full';
//    config.toolbar_Full =
//        [{ name: 'document', items: ['Source'] },
//        { name: 'custome_plugin', items: ['myplug'] }, //将自定义插件加入toolbar
//        { name: 'insert', items: ['upload', 'album', '-', 'Table'] },
//        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
//        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'] },
//        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', '-', 'Blockquote', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
//        { name: 'colors', items: ['TextColor', 'BGColor'] },

//        ];
//};

CKEDITOR.editorConfig = function (config) {
    config.toolbarGroups = [
        '/',
        '/',
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        { name: 'links', groups: ['links'] },
        { name: 'insert', groups: ['insert'] },
        { name: 'styles', groups: ['styles'] },
        { name: 'colors', groups: ['colors'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'others', groups: ['others'] },
        { name: 'about', groups: ['about'] },
        { name: 'forms', groups: ['forms'] }
    ];

    config.removeButtons = 'Save,NewPage,Preview,Print,PasteFromWord,Replace,Scayt,Image,Flash,Smiley,PageBreak,Anchor,Language,BidiRtl,BidiLtr,BulletedList,NumberedList,Blockquote,About';
};