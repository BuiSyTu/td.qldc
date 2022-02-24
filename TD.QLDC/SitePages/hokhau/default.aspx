<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/qldc/default.master"
	inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"
	meta:progid="SharePoint.WebPartPage.Document" %>
	<%@ Register Tagprefix="layout" Namespace="TD.Core.Layouts.Controls"
		Assembly="TD.Core.Layouts.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=fdcb66d7090aabcd" %>

		<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
			<div class="m-portlet mb-0">
				<div class="m-portlet__head">
					<div class="m-portlet__head-caption">
						<div class="m-portlet__head-title">
							<h3 class="m-portlet__head-text">
								Danh sách hộ khẩu
							</h3>
						</div>
					</div>
					<div class="m-portlet__head-tools" td-permission visible-only-permissions=QLDC-HK-Full
						td-pms-pri-siteadmin=false>
						<ul class="m-portlet__nav">
							<li class="m-portlet__nav-item">
								<a href="javascript:void(0)" add td-permission visible-only-permissions=QLDC-HK-Full
									class="m-portlet__nav-link btn btn-outline-success m-btn m-btn--icon m-btn--pill">
									<span>
										<i class="m-nav__link-icon flaticon-add"></i>
										<span class="m-nav__link-text">
											Thêm mới
										</span>
									</span>
								</a>
							</li>
							<li class="m-portlet__nav-item">
								<a href="javascript:void(0)" delete td-permission visible-only-permissions=QLDC-HK-Full
									class="m-portlet__nav-link btn btn-outline-danger m-btn m-btn--icon m-btn--pill">
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

				<!--begin: Datatable -->
				<table class="td-datatable table table-bordered m-table display" style="width:100%">
				</table>
				<script id="action-template" type="text/x-handlebars-template">
				<a href="javascript:void(0)" nhankhau sohokhau-id="{{SoHoKhau}}" hoKhauId="{{ID}}"
					class="m-portlet__nav-link btn m-btn m-btn--hover-info m-btn--icon m-btn--icon-only m-btn--pill"
					data-toggle="m-tooltip" title="Danh sách nhân khẩu">
					<i class="flaticon-users"></i>
				</a>
				<a href="javascript:void(0)" edit td-permission visible-only-permissions=QLDC-HK-Full data-id="{{ID}}" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="m-tooltip" title="Sửa">
					<i class="la la-edit"></i>
				</a>
				<a href="javascript:void(0)" delete td-permission visible-only-permissions=QLDC-HK-Full data-id="{{ID}}" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="m-tooltip" title="Xóa">
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
			<link type="text/css" rel="stylesheet"
				href="~/_layouts/15/tdcore/v3/assets/vendors/custom/datatables/datatables.bundle.css" />
			<link rel="stylesheet" href="../css/fix.css">
		</asp:Content>
		<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageVendorScripts">
			<script type="text/javascript"
				src="~/_layouts/15/tdcore/v3/assets/vendors/custom/datatables/datatables.bundle.js"></script>
		</asp:Content>
		<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageScripts">
			<script type="text/javascript" src="default.js"> </script>
		</asp:Content>