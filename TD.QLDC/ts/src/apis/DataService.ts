import { DataServiceBase, DataQuery } from '@tdcore/api-client';
import { urlCombine, HttpResponse } from '@tdcore/http';

export class DataService extends DataServiceBase {
	constructor(url: any, opts?: any) {
		super(url, typeof opts === 'string' ? { serverUrl: opts } : opts);
	}

	// post:bcttapi/data/list
	addRange(items: any): Promise<HttpResponse> {
		return this.http.post(urlCombine(this.actionUrl, 'list'), JSON.stringify(items));
	}

	/**
	 * items query
	 */
	itemsByActive(active: boolean) {
		const url = this.processUrl(urlCombine(this.actionUrl, 'active', active ? 'true' : 'false'));
		return new DataQuery(this.http, url);
	}

	// TODO: Implement Areas Api Extend
}
