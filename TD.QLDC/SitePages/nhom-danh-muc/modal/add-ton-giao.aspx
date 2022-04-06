<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/qldc/dialog-form.master" inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document"%>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
	<!--begin::Form-->
	<div id="form" tdf-type="form" class="m-form m-form--fit m-form--label-align-right">
		<input type="hidden" id="ID" name="ID" />
		<input type="hidden" id="nhomid" name="nhomid" value="3"/>

		<!--<div class="form-group m-form__group row">
			<label class="col-form-label col-sm-4">Thuộc nhóm</label>
			<div class="col-sm-8 col-md-6 col-lg-5">
				<input type="text" name="NhomID" class="form-control " placeholder="Nhóm">
			</div>
		</div>-->
		<div class="form-group m-form__group row">
			<label class="col-form-label col-sm-4">Tên tôn giáo</label>
			<div class="col-sm-8 col-md-6 col-lg-5">
				<input type="text" name="Name" class="form-control " placeholder="">
			</div>
		</div>
		<div class="form-group m-form__group row">
			<label class="col-form-label col-sm-4">Thứ tự</label>
			<div class="col-sm-8 col-md-6 col-lg-5">
				<input type="text" name="Order" class="form-control " placeholder="Thứ tự">
			</div>
		</div>
		<div class="form-group m-form__group row">
			<label class="col-form-label col-sm-4">Sử dụng</label>
			<div class="col-sm-8 col-md-6 col-lg-5">
				<label class="m-checkbox m-checkbox--state-success">
					<input type="checkbox" name="Active" value="true" checked>
					<span></span>
				</label>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
		</div>

	</div>
	<!--end::Form-->
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageScripts">
	<script type="text/javascript">
		(function (factor) {
			var mtoastr;
			try {
				mtoastr = window.top.toastr || window.toastr;
			} catch(e) {
				mtoastr = window.toastr;
			}

			factor(jQuery, tdcore.modals, tdcore.forms, mtoastr);
		})
			(function ($, modals, forms, toastr) {
				$(document).ready(function () {

					var id = Url.queryString("aid");
					if (id) loadData(id);
					// lấy dialog
					var dlg = modals.getCurrentDialog();
					// xử lý sự kiện click nút OK
					dlg.addCmd('OK', function (dlg, prevResult) {
						// get form control
						var val = forms.Widget.ofElement($("#form")[0]).getData();
						if (val) {
							dlg.data = val;
						} else {
							toastr.warning('Chưa nhập giá trị');
							// không đóng modal
							return false;
						}
						// trả lại kết quả của lần xử lý trước
						return prevResult;

					});
				});

				var loadData = function (id) {
					var item;
					var form;
					// set id cho input #ID
					$('#ID').val(id);
					var unitService = new td.qldc.apis.Categories();
					return unitService.getSingle(id)
						.then((data) => {
							var temp = data.json();
							item = temp.result;
							// Đợi form khởi tạo
							return forms.Widget.waitForWidgetInit(
								document.getElementById('form'));
						})
						// Form khởi tạo xong => set dữ liệu vào form
						.then(function (wg) {
							form = wg;
							// set data to form
							form.setData(item);
						});
				};

			});

	</script>
</asp:Content>
