import { DataQuery, DataServiceBase } from '@tdcore/api-client';
import { HttpResponse, urlCombine } from '@tdcore/http';

export class DataService extends DataServiceBase {
	constructor(url: any, opts?: any) {
		super(url, typeof opts === 'string' ? { serverUrl: opts } : opts);
	}

	/**
	 * add list item
	 * @param items list to add
	 * @returns 
	 */
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
}
