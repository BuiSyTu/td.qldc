import resolve from 'rollup-plugin-node-resolve';
import commonjs from 'rollup-plugin-commonjs';
import babel from 'rollup-plugin-babel';
import pkg from './package.json';
import typescript from 'rollup-plugin-typescript';
import { uglify } from 'rollup-plugin-uglify';
import license from'rollup-plugin-license';
import moment from "moment";
import sass from 'rollup-plugin-sass';
import string from 'rollup-plugin-string';

const IS_PROD = process.env.NODE_ENV === 'production'

const banner = 
`/*! ****************************************************************************
* ${ pkg.title || pkg.name } - ${ pkg.description }
*
* v${ pkg.version } - ${ moment().format("YYYY-MM-DD") }
*
* Copyright (c) ${ moment().format("YYYY") } ${ pkg.copyright }
* ${ pkg.website }
* License: ${ pkg.license }
* Author: ${ (typeof pkg.author === "string") ? pkg.author : (pkg.author.name + " <" + pkg.author.email + ">") }
***************************************************************************** */\n`;

const createMinFileName = (fileName) => {
	const dotInx = fileName.lastIndexOf('.');
	let slashInx = fileName.lastIndexOf('/');
	const bslashInx = fileName.lastIndexOf('\\');

	slashInx = Math.max(slashInx, bslashInx);

	if(dotInx > slashInx){
		return fileName.substring(0, dotInx) + 
			'.min' + fileName.substring(dotInx);
	}

	return fileName + '.min';
};

const changeExt = (fileName, ext) => {
	const dotInx = fileName.lastIndexOf('.');
	let slashInx = fileName.lastIndexOf('/');
	const bslashInx = fileName.lastIndexOf('\\');

	slashInx = Math.max(slashInx, bslashInx);

	let name;

	if(dotInx > slashInx){
		name = fileName.substring(0, dotInx);
	} else {
		name = fileName;
	}

	return name + ext;
};

export default [
	// browser-friendly UMD build
	{
		input: 'src/main.ts',
		output: {
			name: pkg.browserModuleName,
			file: pkg.browser,
			sourcemap: true,
			format: 'umd',
			globals: {
				'jquery': 'jQuery',
				'moment': 'moment',
				'toastr': 'toastr',
				'split.js': 'Split',
				'handlebars': 'Handlebars',
				'handsontable': 'Handsontable',
				'sortablejs': 'Sortable',
				'codemirror': 'CodeMirror',
				'@tdcore/http': 'tdcore.http',
				"@tdcore/api-client": "tdcore.apis",
				"@tdcore/forms": "tdcore.forms",
				'@tdcore/forms-sp': 'tdcore.forms.sp',
				"@tdcore/views": 'tdcore.views',
				"@tdcore/modals": 'tdcore.modals',
				'@tdcore/permissions':'tdcore.permissions',
				"amcharts3":"AmCharts",
			},
		},
		plugins: [
			sass({ 
				output: pkg.style
			}),
			// importAlias({
			// 	Paths: {
			// 		"@shared": '../../../Shared/ts'
			// 	},
			// 	Extensions: ['ts']
			// }),
			// rollupPluginTypescriptPathMapping({ tsconfig: true }),
			typescript({
				typescript: require('typescript')
			}),
			string({
				// Required to be specified
				include: ['**/*.html', '**/*.svg'],
	 
				// Undefined by default
				exclude: ['**/index.html']
			}),
			resolve({
				extensions: [ '.mjs', '.js', '.json', '.node', '.ts' ],
				include: 'node_modules/**'
			}),
			commonjs(),
			babel({
				exclude: 'node_modules/**, **/*.ts'
			}),
			license({
				banner: banner
			})
		],
		external: [
			'jquery',
			'moment',
			'toastr',
			'split.js',
			'urijs',
			'handlebars',
			'handsontable',
			'sortablejs',
			'codemirror',
			'@tdcore/http',
			"@tdcore/api-client",
			"@tdcore/forms",
			'@tdcore/forms-sp',
			"@tdcore/views",
			"@tdcore/modals",
			'@tdcore/permissions',
			"amcharts3",
		]
	},
	
	// minify browser js
	//{
	//	input: pkg.browser,
	//	output: {
	//		file: createMinFileName(pkg.browser),
	//		format: "cjs"
	//	},
	//	context: "this",
	//	plugins: [
	//		uglify(),
	//		license({
	//			banner: banner
	//		})
	//	]
	//},
];