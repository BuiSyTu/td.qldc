import { DataService } from './DataService';
import { ServicesConfig } from './ServicesConfig';

const gconf = ServicesConfig.globalConfig;
export class NhomDanhMucs extends DataService {
	constructor(opts?: any) {
		if (typeof opts === 'string') {
			opts = { serverUrl: opts };
		}

		super(gconf.nhomDanhMucPath, opts);
	}
}
