/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	config.language = 'fa';
	config.filebrowserImageUploadUrl = "/file-upload";
	config.filebrowserUploadUrl = "/file-upload";
	config.extraPlugins = 'html5video,widget,widgetselection,clipboard,lineutils';
	config.allowedContent = true;
	config.removeFormatAttributes = '';

	//config.extraAllowedContent = '*(*)';
	config.extraAllowedContent = '*(*);*{*}';
	config.protectedSource.push(/<span[^>]*><\/span>/g);
};
