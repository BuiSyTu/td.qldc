// tslint:disable-next-line:variable-name
let _globalConf: ServicesConfig;

export class ServicesConfig {
	public server = '/QLDCapi/';
    public categoryPath = 'QLDCapi/Categories';
    public hoKhauPath = 'QLDCapi/HoKhaus';
    public nhanKhauPath = 'QLDCapi/NhanKhaus';
		public nhomDanhMucPath = 'QLDCapi/NhomDanhMucs';
		public areaPath = 'QLDCapi/areas';


	static get globalConfig(): ServicesConfig {
		if (!_globalConf) {
			_globalConf = new ServicesConfig();
		}

		return _globalConf;
	}

	static set globalConfig(val) {
		_globalConf = val;
	}
}
