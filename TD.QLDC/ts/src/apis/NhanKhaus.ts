import { DataService } from './DataService';
import { ServicesConfig } from './ServicesConfig';
import { urlCombine, HttpResponse } from '@tdcore/http';
import { DataQuery } from '@tdcore/api-client';

const gconf = ServicesConfig.globalConfig;
export class NhanKhaus extends DataService {
	constructor(opts?: any) {
		if (typeof opts === 'string') {
			opts = { serverUrl: opts };
		}

		super(gconf.nhanKhauPath, opts);
    }
    UpdateTheoSHK() {
        return new DataQuery(
            this.http,
            this.processUrl(urlCombine(this.actionUrl, "UpdateTheoSHK")));
    }
}
