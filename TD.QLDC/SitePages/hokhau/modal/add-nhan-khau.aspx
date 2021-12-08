<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/qldc/dialog-form.master" inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document"%>
<asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
    <!--begin::Form quản lý thẻ-->
    <div id="form" tdf-type="form" class="m-form m-form--fit m-form--label-align-right">
        <input type="hidden" id="ID" name="ID" />

       <input type="hidden" id="SoHoKhau" name="SoHoKhau" />

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Họ và Tên</label>
            <div class="col-sm-3">
                <input type="text" name="HoTen" class="form-control" placeholder="">
            </div>

            <label class="col-form-label col-sm-1">Tên gọi khác</label>
            <div class="col-sm-3">
                <input type="text" name="TenGoiKhac" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Ảnh</label>
            <div class="col-sm-3">
                <div class="m-dropzone m-dropzone--primary dz-icon-compact" tdf-type="dropzone" data-field="AnhDaiDien"
                    data-plugins="spdoclibupload" data-sp-list-title="HinhAnh"
                    data-folder="{UnitCode}/{Year}/{Month}/{Day}/{Random}" data-parallel-uploads="1"
                    data-add-remove-links="true">
                    <div class="m-dropzone__msg dz-message needsclick">
                        <h3 class="m-dropzone__msg-title">
                            Thả tệp tin hoặc nhấp chuột để tải lên.
                        </h3>
                        <span class="m-dropzone__msg-desc">
                            ảnh.
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Ngày sinh</label>
            <div class="col-sm-5">
                <input type="hidden" id="NgaySinh" name="NgaySinh" tdf-type="datepicker" data-ui-element="+div>input"
                    data-output-format="YYYY-MM-DDTHH:mm:ssZ" data-input-format="DD/MM/YYYY" data-autoclose="true"
                    data-autocomplete="true" />
                <div class="m-input-icon m-input-icon--left">
                    <span class="m-input-icon__icon m-input-icon__icon--left">
                        <span><i class="la la-calendar-check-o"></i></span>
                    </span>
                    <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                </div>
            </div>
            <label class="col-form-label col-sm-1">Giới tính</label>
            <select tdf-type="combobox" class="form-control col-sm-5" name="GioiTinh">
                <option value="Nam">Nam</option>
                <option value="Nữ">Nữ</option>
            </select>

        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Email</label>
            <div class="col-sm-5">
                <input type="text" name="Email" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Số điện thoại</label>
            <div class="col-sm-5">
                <input type="text" name="SoDienThoai" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Tình trạng hôn nhân <b class="text-danger">*</b></label>
            <div class="col-sm-5">
                <select name="DMHonNhanID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn tình trạng" data-ajax-url="/qldcapi/categories?active=true&nhomid=7"
                    data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val="true" data-allow-clear="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMHonNhanID" data-valmsg-replace="true"></div>
            </div>
            <label class="col-form-label col-sm-1">Mã Số Thuế</label>
            <div class="col-sm-5">
                <input type="text" name="MaSoThue" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Trình độ văn hóa <b class="text-danger">*</b></label>
            <div class="col-sm-5">
                <select name="DMVanHoaID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn trình độ" data-ajax-url="/qldcapi/categories?active=true&nhomid=9"
                    data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val="true" data-allow-clear="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMVanHoaID" data-valmsg-replace="true"></div>
            </div>
            <label class="col-form-label col-sm-1">Trình độ chuyên môn <b class="text-danger">*</b></label>
            <div class="col-sm-5">
                <select name="DMChuyenMonID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn trình độ" data-ajax-url="/qldcapi/categories?active=true&nhomid=10"
                    data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val="true" data-allow-clear="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMChuyenMonID" data-valmsg-replace="true"></div>
            </div>
        </div>
         <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Nơi Sinh</label>
            <div class="col-sm-3 col-md-3">
                <select name="TinhThanh" class="form-control m-select2" tdf-type="select" data-width="100%" data-placeholder="Chọn tỉnh"
                    data-ajax-url="/_vti_bin/tdcore/areas.svc/areas/codes/36" data-ajax-page-size=10 data-result-field=result
                    data-value-field="WardCode" data-text-field="AreaName" data-val="true" data-val="true" 
                    onchange="ChooseArea('TinhThanh','HuyenThiXa')" data-allow-clear="true"
                    data-item-url="/_vti_bin/tdcore/areas.svc/areas/codes/{id}" data-item-result-field="result" ></select>
                <div class="form-control-feedback" data-valmsg-for="Tinh" data-valmsg-replace="true">
                </div>
            </div>
            <div class="col-sm-3 col-md-4">
                <select name="HuyenThiXa" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn huyện" data-ajax-url="       " data-ajax-page-size=10 data-result-field=result
                    data-value-field="WardCode" data-text-field="AreaName" data-val="true" onchange="ChooseArea('HuyenThiXa','XaPhuong')"
                    data-allow-clear="true"></select>
                <div class="form-control-feedback" data-valmsg-for="Huyen" data-valmsg-replace="true">
                </div>
            </div>
            <div class="col-sm-3 col-md-4">
                <select name="XaPhuong" class="form-control m-select2" tdf-type="select" data-width="100%" data-placeholder="Chọn xã"
                    data-ajax-url="    " data-ajax-page-size=10 data-result-field=result data-value-field="WardCode"
                    data-text-field="AreaName" data-val="true" data-allow-clear="true"></select>
                <div class="form-control-feedback" data-valmsg-for="Xa" data-valmsg-replace="true">
                </div>
            </div>           
        </div>

        <div class="form-group m-form__group row">  
            <label class="col-form-label col-sm-1">Quê Quán</label>
            <div class="col-sm-2 col-md-3">
                <select name="TinhThanh" class="form-control m-select2" 
                    tdf-type="sp-areaselect" 
                    data-width="100%"
                    data-placeholder="Chọn Tỉnh Thành" 
                    data-allow-clear="true">
                </select>
            </div>
            <div class="col-sm-2 col-md-4">
                <select name="HuyenThiXa" class="form-control m-select2" 
                    tdf-type="sp-areaselect" 
                    data-width="100%"
                    data-placeholder="Chọn Huyện Thị xã" 
                    data-allow-clear="true">
                </select>
            </div>
            <div class="col-sm-2 col-md-4">
                <select name="XaPhuong" class="form-control m-select2" 
                    tdf-type="sp-areaselect" 
                    data-width="100%"
                    data-placeholder="Chọn Xã Phường" 
                    data-allow-clear="true">
                </select>
            </div> 
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Quan hệ với chủ hộ <b class="text-danger">*</b></label>
            <div class="col-sm-3 col-md-3">
                <select name="DMQuanHeID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn quan hệ" data-ajax-url="/qldcapi/categories?active=true&nhomid=8"
                    data-ajax-page-size=10 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val-required="Quan hệ với chủ hộ là bắt buộc!" data-add-remove-links="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMQuanHeID" data-valmsg-replace="true"></div>
            </div>
            <label class="col-form-label col-sm-1">Đối tượng <b class="text-danger">*</b></label>
            <div class="col-sm-3 col-md-3">
                <select name="DMDoiTuongID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn đối tượng" data-ajax-url="/qldcapi/categories?active=true&nhomid=4"
                    data-ajax-page-size=10 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val-required="Chọn đối tượng là bắt buộc!" data-add-remove-links="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMDoiTuongID" data-valmsg-replace="true"></div>
            </div>
            <label class="col-form-label col-sm-1">Loại Đối tượng <b class="text-danger">*</b></label>
            <div class="col-sm-3 col-md-3">
                <select name="DMLoaiDoiTuongID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn loại đối tượng" data-ajax-url="/qldcapi/categories?active=true&nhomid=5"
                    data-ajax-page-size=10 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val-required="Chọn loại đối tượng là bắt buộc!" data-add-remove-links="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMLoaiDoiTuongID" data-valmsg-replace="true"></div>
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Dân tộc <b class="text-danger">*</b></label>
            <div class="col-sm-3 col-md-3">
                <select name="DMDanTocID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn dân tộc" data-ajax-url="/qldcapi/categories?active=true&nhomid=1"
                    data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val-required="Chọn dân tộc là bắt buộc!" data-add-remove-links="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMDanTocID" data-valmsg-replace="true"></div>
            </div>
            <label class="col-form-label col-sm-1">Quốc tịch <b class="text-danger">*</b></label>
            <div class="col-sm-3 col-md-3">
                <select name="DMQuocTichID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn quốc tịch" data-ajax-url="/qldcapi/categories?active=true&nhomid=2"
                    data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val-required="Chọn quốc tịch là bắt buộc!" data-add-remove-links="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMQuocTichID" data-valmsg-replace="true"></div>
            </div>
            <label class="col-form-label col-sm-1">Tôn giáo <b class="text-danger">*</b></label>
            <div class="col-sm-3 col-md-3">
                <select name="DMTonGiaoID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn tôn giáo" data-ajax-url="/qldcapi/categories?active=true&nhomid=3"
                    data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val-required="Chọn tôn giáo là bắt buộc!" data-add-remove-links="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMTonGiaoID" data-valmsg-replace="true"></div>
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Số CMT</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="SoCMT" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Ngày cấp CMT</label>
            <div class="col-sm-3 col-md-3">
                <input type="hidden" id="NgayCapCMT" name="NgayCapCMT" tdf-type="datepicker"
                    data-ui-element="+div>input" data-output-format="YYYY-MM-DDTHH:mm:ssZ"
                    data-input-format="DD/MM/YYYY" data-autoclose="true" data-autocomplete="true" />
                <div class="m-input-icon m-input-icon--left">
                    <span class="m-input-icon__icon m-input-icon__icon--left">
                        <span><i class="la la-calendar-check-o"></i></span>
                    </span>
                    <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                </div>
            </div>
            <label class="col-form-label col-sm-1">Nơi Cấp CMT</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="NoiCapCMT" class="form-control" placeholder="">
            </div>
        </div>


        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Số CCCD</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="SoCCCD" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Ngày cấp CCCD</label>
            <div class="col-sm-3 col-md-3">
                <input type="hidden" id="NgayCapCCCD" name="NgayCapCCCD" tdf-type="datepicker"
                    data-ui-element="+div>input" data-output-format="YYYY-MM-DDTHH:mm:ssZ"
                    data-input-format="DD/MM/YYYY" data-autoclose="true" data-autocomplete="true" />
                <div class="m-input-icon m-input-icon--left">
                    <span class="m-input-icon__icon m-input-icon__icon--left">
                        <span><i class="la la-calendar-check-o"></i></span>
                    </span>
                    <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                </div>
            </div>
            <label class="col-form-label col-sm-1">Nơi Cấp CCCD</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="NoiCapCCCD" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Số BHYT</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="SoBHYT" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Ngày cấp BHYT</label>
            <div class="col-sm-3 col-md-3">
                <input type="hidden" id="NgayCapBHYT" name="NgayCapBHYT" tdf-type="datepicker"
                    data-ui-element="+div>input" data-output-format="YYYY-MM-DDTHH:mm:ssZ"
                    data-input-format="DD/MM/YYYY" data-autoclose="true" data-autocomplete="true" />
                <div class="m-input-icon m-input-icon--left">
                    <span class="m-input-icon__icon m-input-icon__icon--left">
                        <span><i class="la la-calendar-check-o"></i></span>
                    </span>
                    <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                </div>
            </div>
            <label class="col-form-label col-sm-1">Nơi Cấp BHYT</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="NoiCapBHYT" class="form-control" placeholder="">
            </div>
        </div>
        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Số HC</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="SoHC" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Ngày cấp HC</label>
            <div class="col-sm-3 col-md-3">
                <input type="hidden" id="NgayCapHC" name="NgayCapHC" tdf-type="datepicker" data-ui-element="+div>input"
                    data-output-format="YYYY-MM-DDTHH:mm:ssZ" data-input-format="DD/MM/YYYY" data-autoclose="true"
                    data-autocomplete="true" />
                <div class="m-input-icon m-input-icon--left">
                    <span class="m-input-icon__icon m-input-icon__icon--left">
                        <span><i class="la la-calendar-check-o"></i></span>
                    </span>
                    <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                </div>
            </div>
            <label class="col-form-label col-sm-1">Nơi Cấp HC</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="NoiCapHC" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Tên Cha</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="TenCha" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Tên Mẹ</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="TenMe" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Tên Thân Nhân</label>
            <div class="col-sm-3 col-md-3">
                <input type="text" name="ThanNhan" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Nghề Nghiệp</label>
            <div class="col-sm-5">
                <input type="text" name="NgheNghiep" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Nơi Làm Việc</label>
            <div class="col-sm-5">
                <input type="text" name="NoiLamViec" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Nơi Thường Trú</label>
            <div class="col-sm-5">
                <input type="text" name="NoiThuongTru" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Nơi Ở Hiện Tại</label>
            <div class="col-sm-5">
                <input type="text" name="NoiOHienTai" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Tình trạng cư trú<b class="text-danger">*</b></label>
            <div class="col-sm-5">
                <select name="DMTinhTrangCuTruID" class="form-control m-select2" tdf-type="select" data-width="100%"
                    data-placeholder="Chọn tình trạng " data-ajax-url="/qldcapi/categories?active=true&nhomid=6"
                    data-ajax-page-size=10 data-result-field=result data-value-field="ID" data-text-field="Name"
                    data-val-required="Chọn tình trạng cư trú là bắt buộc!" data-add-remove-links="true"></select>
                <div class="form-control-feedback" data-valmsg-for="DMTinhTrangID" data-valmsg-replace="true"></div>
            </div>
            <label class="col-form-label col-sm-1">Chuyển đến ngày</label>
            <div class="col-sm-5">
                <input type="hidden" id="ChuyenDenNgay" name="ChuyenDenNgay" tdf-type="datepicker"
                    data-ui-element="+div>input" data-output-format="YYYY-MM-DDTHH:mm:ssZ"
                    data-input-format="DD/MM/YYYY" data-autoclose="true" data-autocomplete="true" />
                <div class="m-input-icon m-input-icon--left">
                    <span class="m-input-icon__icon m-input-icon__icon--left">
                        <span><i class="la la-calendar-check-o"></i></span>
                    </span>
                    <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                </div>
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1">Nơi Thường Trú trước</label>
            <div class="col-sm-5">
                <input type="text" name="NoiTTTruoc" class="form-control" placeholder="">
            </div>
            <label class="col-form-label col-sm-1">Lí do chuyển</label>
            <div class="col-sm-5">
                <input type="text" name="LyDoChuyen" class="form-control" placeholder="">
            </div>
        </div>

        <div class="form-group m-form__group row">
            <label class="col-form-label col-sm-1"> Ghi chú </label>
            <div class="col-sm-4 col-lg-8">
                <textarea type="text" tdf-type="textarea" data-maxlength-threshold="10" maxlength="1000" name="GhiChu"
                    data-maxlength-warning-class="m-badge m-badge--primary m-badge--rounded m-badge--wide"
                    data-maxlength-separator=" of " data-maxlength-pre-text="You have "
                    data-maxlength-post-text=" chars remaining."
                    data-maxlength-limit-reached-class="m-badge m-badge--brand m-badge--rounded m-badge--wide"
                    data-autosize="true" class="form-control" placeholder="Ghi chú "></textarea>
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
            } catch (e) {
                mtoastr = window.toastr;
            }

            factor(jQuery, tdcore.modals, tdcore.forms, mtoastr);
        })
            (function ($, modals, forms, toastr) {
                $(document).ready(function () {


                    var id = Url.queryString("aid");
                    var shk = Url.queryString("shk");
                    if (!IsNullOrUndefined(Url.queryString("shk")))
                        $("#SoHoKhau").val(shk);
                    if (id) loadData(id);
                    var dlg = modals.getCurrentDialog();
                    dlg.addCmd('OK', function (dlg, prevResult) {
                        var form = forms.Widget.ofElement($("#form")[0]);
                        return form.tryValidate().then(function () {
                            var val = form.getData();
                            if (val) {
                                dlg.data = val;
                            } else {
                                toastr.warning('Chưa nhập giá trị');
                                return false;
                            }
                            return prevResult;
                        });
                        return false;
                    });
                });

                var loadData = function (id) {
                    var item;
                    var form;
                    $('#ID').val(id);
                    var unitService = new td.qldc.NhanKhaus();
                    return unitService.getSingle(id)
                        .then((data) => {

                            var temp = data.json();
                            item = temp.result;
                            
                            return forms.Widget.waitForWidgetInit(
                                document.getElementById('form'));
                        })
                        .then(function (wg) {
                            form = wg;
                            form.setData(item);
                        });
                };

            });

    </script>
</asp:Content>
