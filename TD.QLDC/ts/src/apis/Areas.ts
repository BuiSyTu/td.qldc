import { DataService } from './DataService';
import { ServicesConfig } from './ServicesConfig';

const gconf = ServicesConfig.globalConfig;
export class Areas extends DataService {
	constructor(opts?: any) {
		if (typeof opts === 'string') {
			opts = { serverUrl: opts };
		}

		super(gconf.areaPath, opts);
	}
}
