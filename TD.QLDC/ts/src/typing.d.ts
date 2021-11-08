interface TDCorePageContextInfo {
	appId: number;
	isSiteAdmin: boolean;
	isSystemUser: boolean;
	moduleId: number;
	moduleSiteId: string;
	rootUrl: string;
	userGroupCode: string;
	userOfficeCode: string;
	userGroupId: number;
	userPositionId: string;
}

interface JQuery{
	inputVal(data?): any;
	selectpicker(opts?): JQuery;
	datepicker(...opts: any[]): JQuery;
	select2(...opts: any[]): JQuery;
	// bootstrap tabs
	tab(...opts: any[]): JQuery;
}

declare const _tdCorePageContextInfo: TDCorePageContextInfo;
