import { DataQuery } from '@tdcore/api-client';
import { DataService } from './DataService';
import { ServicesConfig } from './ServicesConfig';
import { urlCombine } from '@tdcore/http';

const gconf = ServicesConfig.globalConfig;
export class HoKhaus extends DataService {
	constructor(opts?: any) {
		if (typeof opts === 'string') {
			opts = { serverUrl: opts };
		}

		super(gconf.hoKhauPath, opts);
    }
    //checkCode() {
    //    return new DataQuery(
    //        this.http,
    //        this.processUrl(urlCombine(this.actionUrl, "checkCode")));
    //}
}
