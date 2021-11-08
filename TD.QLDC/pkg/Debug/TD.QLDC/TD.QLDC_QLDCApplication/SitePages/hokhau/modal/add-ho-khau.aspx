<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/qldc/dialog-form.master" inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document"%>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
    <!--begin::Form quản lý thẻ-->
    <div id="form" tdf-type="form" class="m-form m-form--fit m-form--label-align-right">
        <input type="hidden" id="ID" name="ID" />
        
        <!--<input type="hidden" id="HuongDanVien_ID" name="HuongDanVien_ID" />-->
        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-2">Sổ Hộ Khẩu</label>
            <div class="col-sm-4 col-lg-3">
                <input type="text" name="SoHoKhau" class="form-control" placeholder="">
            </div>          
        </div>
        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-2">Số Nhà</label>
            <div class="col-sm-4 col-lg-3">
                <input type="text" name="SoNha" class="form-control" placeholder="">
            </div>          
        </div>
        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-2">Thôn</label>
            <div class="col-sm-4 col-lg-3">
                <input type="text" name="Thon" class="form-control" placeholder="">
            </div>          
        </div>
        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-2">Xóm</label>
            <div class="col-sm-4 col-lg-3">
                <input type="text" name="Xom" class="form-control" placeholder="">
            </div>          
        </div>
        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-2">Người Nhập</label>
            <div class="col-sm-4 col-lg-3">
                <input type="text" name="NguoiNhap" class="form-control" placeholder="">
            </div>          
        </div>
        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-2">Ghi Chú</label>
            <div class="col-sm-4 col-lg-3">
                <input type="text" name="GhiChu" class="form-control" placeholder="">
            </div>          
        </div>      
    </div>
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
					// set id cho input#ID
					$('#ID').val(id);
					var unitService = new td.qldc.HoKhaus();
					return unitService.getSingle(id)
						.then((data) => {
							var temp = data.json();
                            item = temp.result;
                           // item.LoaiHinh = {Name:item.LoaiHinh};   
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
