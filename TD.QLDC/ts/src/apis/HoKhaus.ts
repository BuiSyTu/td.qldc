import { DataService } from './DataService';
import { ServicesConfig } from './ServicesConfig';
import { urlCombine, HttpResponse } from '@tdcore/http';
import { DataQuery } from '@tdcore/api-client';

const gconf = ServicesConfig.globalConfig;
export class HoKhaus extends DataService {
	constructor(opts?: any) {
		if (typeof opts === 'string') {
			opts = { serverUrl: opts };
		}

		super(gconf.hoKhauPath, opts);
    }
    CheckMa() {
        return new DataQuery(
            this.http,
            this.processUrl(urlCombine(this.actionUrl, "CheckMa")));
    }
    GetSHKByID() {
        return new DataQuery(
            this.http,
            this.processUrl(urlCombine(this.actionUrl, "GetSHKByID")));
    }
}
