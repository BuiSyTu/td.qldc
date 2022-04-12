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
								Danh sách người đóng bảo hiểm y tế
							</h3>
						</div>
					</div>
					<div class="m-portlet__head-tools">
					</div>
				</div>

				<div class="m-portlet__head">
					<div class="row py-2 align-items-center justify-content-between">
						<div class="col-md">
								<ul class="nav nav-pills mb-0">
										<li class="nav-item">
												<a class="bhyt-filter nav-link btn btn-outline-primary active" data-code="TatCa">
														Tất cả
												</a>
										</li>
										<li class="nav-item">
												<a class="bhyt-filter nav-link btn btn-outline-warning" data-code="SapDenHan">
														Sắp đến hạn
												</a>
										</li>
										<li class="nav-item">
												<a class="bhyt-filter nav-link btn btn-outline-danger" data-code="QuaHan">
														Quá hạn
												</a>
										</li>
										<li class="nav-item">
											<a class="bhyt-filter nav-link btn btn-outline-success" data-code="DuocMien">
													Đối tượng được miễn
											</a>
									</li>
								</ul>
						</div>
					</div>
				</div>
				<!--begin::Form-->
			<div class="m-portlet__body">
				<!--begin: Datatable -->
				<table class="td-datatable table table-bordered m-table display" style="width:100%">
				</table>
				<script id="action-template" type="text/x-handlebars-template">
					<a href="javascript:void(0)" edit
						data-id="{{ID}}" class="btn btn-light-success m-btn m-btn--icon btn-sm m-btn--icon-only" data-toggle="m-tooltip" title="Sửa">
						<i class="la la-edit"></i>
					</a>
					<a href="javascript:void(0)" delete data-id="{{ID}}"
						class="btn btn-light-danger m-btn m-btn--icon btn-sm m-btn--icon-only" data-toggle="m-tooltip" title="Xóa">
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
      <script type="text/javascript" src="../js/common.js"> </script>	
      <script type="text/javascript" src="default.js"> </script>
		</asp:Content>