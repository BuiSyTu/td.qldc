<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/qldc/default.master" inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document"%>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageHeaderTitle">
	Danh mục tình trạng hôn nhân
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
    <!--begin:: Widgets/Input methods-->
	<div class="m-portlet mb-0">
		<div class="m-portlet__head">
			<div class="m-portlet__head-caption">
				<div class="m-portlet__head-title">
					<h3 class="m-portlet__head-text">
						Danh mục Tình trạng hôn nhân
					</h3>
				</div>
			</div>
			<div class="m-portlet__head-tools">
				<ul class="m-portlet__nav">
					<li class="m-portlet__nav-item">
						<a href="javascript:void(0)" add class="m-portlet__nav-link btn btn-outline-success m-btn m-btn--icon m-btn--pill">
							<span>
								<i class="m-nav__link-icon flaticon-add"></i>
								<span class="m-nav__link-text">
									Thêm mới 
								</span>
							</span>
						</a>
					</li>
					<li class="m-portlet__nav-item">
						<a href="javascript:void(0)" delete class="m-portlet__nav-link btn btn-outline-danger m-btn m-btn--icon m-btn--pill">
							<span>
								<i class="m-nav__link-icon flaticon-close"></i>
								<span class="m-nav__link-text">
									Xóa 
								</span>
							</span>
						</a>
					</li>
				</ul>
			</div>
		</div>
		<!--begin::Form-->
		<div class="m-portlet__body">
			<!--begin: Datatable -->
			<table class="td-datatable table table-bordered m-table display" style="width:100%">
			</table>
			<script id="action-template" type="text/x-handlebars-template">
				<a href="javascript:void(0)" edit data-id="{{ID}}"
					class="btn btn-light-success m-btn m-btn--icon btn-sm m-btn--icon-only" data-toggle="m-tooltip" title="Sửa danh mục">
					<i class="la la-edit"></i>
				</a>
				<a href="javascript:void(0)" delete data-id="{{ID}}"
					class="btn btn-light-danger m-btn m-btn--icon btn-sm m-btn--icon-only" data-toggle="m-tooltip" title="Xóa danh mục">
					<i class="la la-trash"></i>
				</a>
			</script>
			<!--end: Datatable -->
		</div>
		<!--end::Form-->
	</div>
	<!--end:: Widgets/Input methods-->
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageVendorStyles">
	<link type="text/css" rel="stylesheet" href="~/_layouts/15/tdcore/v3/assets/vendors/custom/datatables/datatables.bundle.css"/>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageVendorScripts">
	<script type="text/javascript" src="~/_layouts/15/tdcore/v3/assets/vendors/custom/datatables/datatables.bundle.js"></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageScripts">
	<!--<script type="text/javascript" src="common.js"> </script>-->
	<script type="text/javascript" src="hon-nhan.js"> </script>
</asp:Content>
