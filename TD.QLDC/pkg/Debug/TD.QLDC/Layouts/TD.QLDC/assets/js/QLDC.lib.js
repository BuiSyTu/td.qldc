/*! ****************************************************************************
* @td/QLDC - Hệ thông quản lý thông tin dân cư
*
* v0.0.0-alpha.0 - 2020-03-27
*
* Copyright (c) 2020 Tandan JSC
* tandan.com.vn
* License: UNLICENSED
* Author: Team 3 SharePoint
***************************************************************************** */

(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@tdcore/api-client'), require('@tdcore/http')) :
    typeof define === 'function' && define.amd ? define(['exports', '@tdcore/api-client', '@tdcore/http'], factory) :
    (factory((global.td = global.td || {}, global.td.qldc = {}),global.tdcore.apis,global.tdcore.http));
}(this, (function (exports,apiClient,http) { 'use strict';

    function __extends(d, b) {
        for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    }

    var DataService = /** @class */function (_super) {
        __extends(DataService, _super);
        function DataService(url, opts) {
            return _super.call(this, url, typeof opts === 'string' ? { serverUrl: opts } : opts) || this;
        }
        // post:bcttapi/data/list
        DataService.prototype.addRange = function (items) {
            return this.http.post(http.urlCombine(this.actionUrl, 'list'), JSON.stringify(items));
        };
        /**
         * items query
         */
        DataService.prototype.itemsByActive = function (active) {
            var url = this.processUrl(http.urlCombine(this.actionUrl, 'active', active ? 'true' : 'false'));
            return new apiClient.DataQuery(this.http, url);
        };
        return DataService;
    }(apiClient.DataServiceBase);

    // tslint:disable-next-line:variable-name
    var _globalConf;
    var ServicesConfig = /** @class */function () {
        function ServicesConfig() {
            this.server = '/QLDCapi/';
            this.categoryPath = 'QLDCapi/Categories';
            this.hoKhauPath = 'QLDCapi/HoKhaus';
            this.nhanKhauPath = 'QLDCapi/NhanKhaus';
            this.nhomDanhMucPath = 'QLDCapi/NhomDanhMucs';
        }
        Object.defineProperty(ServicesConfig, "globalConfig", {
            get: function get() {
                if (!_globalConf) {
                    _globalConf = new ServicesConfig();
                }
                return _globalConf;
            },
            set: function set(val) {
                _globalConf = val;
            },
            enumerable: true,
            configurable: true
        });
        return ServicesConfig;
    }();

    var gconf = ServicesConfig.globalConfig;
    var Categories = /** @class */function (_super) {
        __extends(Categories, _super);
        function Categories(opts) {
            var _this = this;
            if (typeof opts === 'string') {
                opts = { serverUrl: opts };
            }
            _this = _super.call(this, gconf.categoryPath, opts) || this;
            return _this;
        }
        return Categories;
    }(DataService);

    var gconf$1 = ServicesConfig.globalConfig;
    var HoKhaus = /** @class */function (_super) {
        __extends(HoKhaus, _super);
        function HoKhaus(opts) {
            var _this = this;
            if (typeof opts === 'string') {
                opts = { serverUrl: opts };
            }
            _this = _super.call(this, gconf$1.hoKhauPath, opts) || this;
            return _this;
        }
        HoKhaus.prototype.CheckMa = function () {
            return new apiClient.DataQuery(this.http, this.processUrl(http.urlCombine(this.actionUrl, "CheckMa")));
        };
        HoKhaus.prototype.GetSHKByID = function () {
            return new apiClient.DataQuery(this.http, this.processUrl(http.urlCombine(this.actionUrl, "GetSHKByID")));
        };
        return HoKhaus;
    }(DataService);

    var gconf$2 = ServicesConfig.globalConfig;
    var NhanKhaus = /** @class */function (_super) {
        __extends(NhanKhaus, _super);
        function NhanKhaus(opts) {
            var _this = this;
            if (typeof opts === 'string') {
                opts = { serverUrl: opts };
            }
            _this = _super.call(this, gconf$2.nhanKhauPath, opts) || this;
            return _this;
        }
        NhanKhaus.prototype.UpdateTheoSHK = function () {
            return new apiClient.DataQuery(this.http, this.processUrl(http.urlCombine(this.actionUrl, "UpdateTheoSHK")));
        };
        return NhanKhaus;
    }(DataService);

    var gconf$3 = ServicesConfig.globalConfig;
    var NhomDanhMucs = /** @class */function (_super) {
        __extends(NhomDanhMucs, _super);
        function NhomDanhMucs(opts) {
            var _this = this;
            if (typeof opts === 'string') {
                opts = { serverUrl: opts };
            }
            _this = _super.call(this, gconf$3.nhomDanhMucPath, opts) || this;
            return _this;
        }
        return NhomDanhMucs;
    }(DataService);

    exports.Categories = Categories;
    exports.HoKhaus = HoKhaus;
    exports.NhanKhaus = NhanKhaus;
    exports.NhomDanhMucs = NhomDanhMucs;

    Object.defineProperty(exports, '__esModule', { value: true });

})));
//# sourceMappingURL=QLDC.lib.js.map
