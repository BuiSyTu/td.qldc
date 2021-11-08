module.exports = function (grunt) {

	grunt.initConfig({
		concat:{
			css: {
				src: [
					'vendors/handsontable/handsontable.full.min.css',
					// 'node_modules/chosen-js/chosen.min.css',
					'node_modules/codemirror/lib/codemirror.css',
				],
				dest: '../Layouts/TD.QLDC/assets/css/vendors.css'
			},
			js: {
				src: [
					// 'node_modules/chosen-js/chosen.jquery.min.js',
					'vendors/handsontable/numbro/numbro.js',
					'vendors/handsontable/hot-formula-parser/formula-parser.js',
					'vendors/handsontable/handsontable.js',
					'vendors/amcharts3/amcharts/amcharts.js',
					'vendors/amcharts3/amcharts/serial.js',
					'vendors/amcharts3/amcharts/pie.js',
					'vendors/amcharts3/amcharts/plugins/animate/animate.min.js',
					'vendors/amcharts3/amcharts/themes/light.js',
					// 'vendors/handsontable-chosen-editor/handsontable-chosen-editor.js',
					//'node_modules/codemirror/lib/codemirror.js',
					//'node_modules/codemirror/addon/edit/matchbrackets.js',
					//'node_modules/codemirror/mode/mathematica/mathematica.js',
					//'node_modules/file-saver/dist/FileSaver.min.js',
					//'node_modules/@tdcore/ckeditor5-build-decoupled-document/build/ckeditor.js',
					//'node_modules/@tdcore/ckeditor5-build-decoupled-document/build/translations/vi.js',
				],
				dest: '../Layouts/TD.QLDC/assets/js/vendors.js'
			}
		},
		uglify: {
			main: {
				files: {
				    '../Layouts/TD.QLDC/assets/js/vendors.min.js': '../Layouts/TD.QLDC/assets/js/vendors.js'
				}
			}
		},
		cssmin: {
			main: {
				files: {
				    '../Layouts/TD.QLDC/assets/css/vendors.min.css': '../Layouts/TD.QLDC/assets/css/vendors.css'
				}
			}
		}
	});

	grunt.loadNpmTasks('grunt-contrib-concat');
	grunt.loadNpmTasks('grunt-contrib-uglify');
	grunt.loadNpmTasks('grunt-contrib-cssmin');

	grunt.registerTask('default', ['concat', 'uglify', 'cssmin']);
};