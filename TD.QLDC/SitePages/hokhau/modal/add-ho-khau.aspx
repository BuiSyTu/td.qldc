<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/qldc/dialog-form.master"
	inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"
	meta:progid="SharePoint.WebPartPage.Document" %>
	<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
		<!--begin::Form quản lý thẻ-->
		<div id="form" tdf-type="form" class="m-form m-form--fit">
			<input type="hidden" name="ID" />
			<!-- <div class="form-group m-form__group row">
				<label class="col-form-label">Sổ Hộ Khẩu</label>
				<input type="text" name="SoHoKhau" class="form-control" placeholder="">
			</div> -->
			<div class="form-group m-form__group row">
				<label class="col-form-label">Loại hộ gia đình</label>
				<select name="DMLoaiHoID" class="form-control m-select2" tdf-type="select" data-width="100%"
					data-placeholder="Chọn loại hộ gia đình" data-ajax-url="/qldcapi/categories?nhomid=11&active=true" data-ajax-page-size=-1
					data-result-field=result data-value-field="ID" data-text-field="Name" data-val="true" data-allow-clear="true">
					<option value=""></option>
				</select>
				<div class="form-control-feedback" data-valmsg-for="DMLoaiHoID" data-valmsg-replace="true"></div>
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Số Nhà</label>
				<input type="text" name="SoNha" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Thôn</label>
				<select name="MaThon" class="form-control m-select2" tdf-type="select" data-width="100%"
					data-placeholder="Chọn thôn" data-ajax-url="/qldcapi/areas?type=7" data-item-url="/qldcapi/areas/code/{id}"
					data-item-result-field="result" data-ajax-page-size=-1 data-result-field=result data-value-field="Code"
					data-text-field="Name" data-val="true" data-allow-clear="true" onchange="ChooseArea('MaThon', 'MaXom')">
					<option value=""></option>
				</select>
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Xóm</label>
				<select name="MaXom" class="form-control m-select2" tdf-type="select" data-width="100%"
					data-placeholder="Chọn xóm" data-ajax-url="/qldcapi/areas?type=9" data-ajax-page-size=-1
					data-item-url="/qldcapi/areas/code/{id}" data-item-result-field="result" data-result-field=result
					data-value-field="Code" data-text-field="Name" data-val="true" data-allow-clear="true">
					<option value=""></option>
				</select>
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Tên chủ hộ</label>
				<input type="text" name="TenChuHo" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">CCCD chủ hộ</label>
				<input type="text" name="CCCDCHuHo" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Loại nhà ở</label>
				<input type="text" name="LoaiNhaO" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Đất ở</label>
				<input type="text" name="DatO" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Đất SXNN</label>
				<input type="text" name="DatSXNN" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Đất chuyển đổi</label>
				<input type="text" name="DatChuyenDoi" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label">Hộ kinh doanh</label>
				<input type="text" name="HoKinhDoanh" class="form-control" placeholder="">
			</div>
			<div class="form-group m-form__group row">
				<label class="col-form-label"> Ghi chú </label>
				<textarea type="text" tdf-type="textarea" rows="3" data-maxlength-threshold="10" maxlength="1000" name="GhiChu"
					data-maxlength-warning-class="m-badge m-badge--primary m-badge--rounded m-badge--wide"
					data-maxlength-separator=" of " data-maxlength-pre-text="You have "
					data-maxlength-post-text=" chars remaining."
					data-maxlength-limit-reached-class="m-badge m-badge--brand m-badge--rounded m-badge--wide"
					data-autosize="true" class="form-control" placeholder="Ghi chú "></textarea>
			</div>
		</div>
	</asp:Content>
	<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderPageScripts">
		<script type="text/javascript">
			(function (factor) {
				var mtoastr;
				try {
					mtoastr = window.top.toastr || window.toastr;
				} catch (e) {
					mtoastr = window.toastr;
				}

				factor(jQuery, tdcore.modals, tdcore.forms, mtoastr);
			})
				(function ($, modals, forms, toastr) {
					// $.ajax({
					// 	method: 'GET',
					// 	url: '/qldcapi/areas/currentuser',
					// 	success: function(res) {
					// 		const { result } = res
					// 		$('input[name=MaThon]').val(result?.VillageCode ?? '');
					// 		$('input[name=MaXom]').val(result?.HamletCode ?? '');
					// 		$('input[name=TenThon]').val(result?.VillageName ?? '');
					// 		$('input[name=TenXom]').val(result?.HamletName ?? '');
					// 	}
					// })

					var id = Url.queryString('aid');
					if (id) loadData(id);

					// lấy dialog
					var dlg = modals.getCurrentDialog();
					// xử lý sự kiện click nút OK
					dlg.addCmd('OK', function (dlg, prevResult) {
						// get form control
						var val = forms.Widget.ofElement($('#form')[0]).getData();

						val.TenThon = $('[name=MaThon] option:selected').text();
						val.TenXom = $('[name=MaXom] option:selected').text();

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

					function loadData(id) {
						var item;
						var form;
						// set id cho input#ID
						$('[name=ID]').val(id);
						var hoKhauService = new td.qldc.apis.HoKhaus();
						return hoKhauService.getSingle(id)
							.then((data) => {
								var temp = data.json();
								item = temp.result;
								// Đợi form khởi tạo
								return forms.Widget.waitForWidgetInit(document.getElementById('form'));
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