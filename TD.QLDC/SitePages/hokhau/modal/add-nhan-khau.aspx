<%@ Page Language="C#" MasterPageFile="~sitecollection/_catalogs/masterpage/qldc/dialog-form.master"
    inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"
    meta:progid="SharePoint.WebPartPage.Document" %>
    <asp:Content runat="server" ContentPlaceHolderID="PlaceHolderMain">
        <!--begin::Form quản lý thẻ-->
        <div id="form" tdf-type="form" class="m-form m-form--fit m-form--label-align-right">
            <input type="hidden" name="ID" />
            <input type="hidden" name="HoKhauID" />

            <div class="mt-4 header-control">
                <h5>Thông tin cơ bản</h5>
            </div>
            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label">Họ và Tên</label>
                    <input type="text" name="HoTen" class="form-control" placeholder="">

                    <label class="col-form-label">Ngày sinh</label>
                    <input type="hidden" id="NgaySinh" name="NgaySinh" tdf-type="datepicker"
                        data-ui-element="+div>input" data-output-format="YYYY-MM-DDTHH:mm:ssZ"
                        data-input-format="DD/MM/YYYY" data-autoclose="true" data-autocomplete="true" />
                    <div class="m-input-icon m-input-icon--left">
                        <span class="m-input-icon__icon m-input-icon__icon--left">
                            <span><i class="la la-calendar-check-o"></i></span>
                        </span>
                        <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                    </div>
                </div>

                <div class="col-4">
                    <label class="col-form-label">Tên gọi khác</label>
                    <input type="text" name="TenGoiKhac" class="form-control" placeholder="">

                    <label class="col-form-label">Giới tính</label>
                    <select tdf-type="combobox" class="form-control" name="GioiTinh">
                        <option value="Nam">Nam</option>
                        <option value="Nữ">Nữ</option>
                    </select>
                </div>

                <div class="col-4 file">
                    <label class="col-form-label">Ảnh</label>
                    <div class="m-dropzone m-dropzone--primary dz-icon-compact" tdf-type="dropzone"
                        data-field="AnhDaiDien" data-plugins="spdoclibupload" data-sp-list-title="Documents"
                        data-sp-web-url="/sites/qldc" data-folder="{Year}/{Month}/{Day}/{Random}"
                        data-parallel-uploads="1" data-add-remove-links="true">
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
                <div class="col-4">
                    <label class="col-form-label">Tình trạng hôn nhân <b class="text-danger">*</b></label>

                    <select name="DMHonNhanID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn tình trạng" data-ajax-url="/qldcapi/categories?active=true&nhomid=7"
                        data-ajax-page-size=-1 data-result-field="result" data-value-field="ID" data-text-field="Name"
                        data-val="true" data-allow-clear="true"></select>
                    <div class="form-control-feedback" data-valmsg-for="DMHonNhanID" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label">Mã Số Thuế</label>
                    <input type="text" name="MaSoThue" class="form-control" placeholder="">
                </div>

                <div class="col-4">
                    <label class="col-form-label">Số điện thoại</label>
                    <input type="text" name="SoDienThoai" class="form-control" placeholder="">
                </div>
            </div>

            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label required">Dân tộc</label>
                    <select name="DMDanTocID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn dân tộc" data-ajax-url="/qldcapi/categories?active=true&nhomid=1"
                        data-ajax-page-size=-1 data-result-field="result" data-value-field="ID" data-text-field="Name"
                        data-val-required="Chọn dân tộc là bắt buộc!" data-add-remove-links="true"></select>
                    <div class="form-control-feedback" data-valmsg-for="DMDanTocID" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label required">Quốc tịch</label>
                    <select name="DMQuocTichID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn quốc tịch" data-ajax-url="/qldcapi/categories?active=true&nhomid=2"
                        data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                        data-val-required="Chọn quốc tịch là bắt buộc!" data-add-remove-links="true"></select>
                    <div class="form-control-feedback" data-valmsg-for="DMQuocTichID" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label required">Tôn giáo</label>
                    <select name="DMTonGiaoID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn tôn giáo" data-ajax-url="/qldcapi/categories?active=true&nhomid=3"
                        data-ajax-page-size=-1 data-result-field=result data-value-field="ID" data-text-field="Name"
                        data-val-required="Chọn tôn giáo là bắt buộc!" data-add-remove-links="true"></select>
                    <div class="form-control-feedback" data-valmsg-for="DMTonGiaoID" data-valmsg-replace="true"></div>
                </div>
            </div>

            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label required">Quan hệ với chủ hộ</label>
                    <select name="DMQuanHeID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn quan hệ" data-ajax-url="/qldcapi/categories?active=true&nhomid=8"
                        data-ajax-page-size=-1 data-result-field="result" data-value-field="ID" data-text-field="Name"
                        data-val-required="Quan hệ với chủ hộ là bắt buộc!" data-add-remove-links="true"></select>
                    <div class="form-control-feedback" data-valmsg-for="DMQuanHeID" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label required">Đối tượng</label>
                    <select name="DMDoiTuongID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn đối tượng" data-ajax-url="/qldcapi/categories?nhomid=4"
                        data-ajax-page-size=-1 data-result-field="result" data-value-field="ID" data-text-field="Name"
                        data-val-required="Chọn đối tượng là bắt buộc!" data-add-remove-links="true">
                    </select>
                    <div class="form-control-feedback" data-valmsg-for="DMDoiTuongID" data-valmsg-replace="true"></div>
                </div>
            </div>

            <div class="form-group m-form__group row">
                <div class="col-8">
                    <label class="col-form-label"> Ghi chú </label>
                    <textarea type="text" tdf-type="textarea" data-maxlength-threshold="10" maxlength="1000"
                        name="GhiChu"
                        data-maxlength-warning-class="m-badge m-badge--primary m-badge--rounded m-badge--wide"
                        data-maxlength-separator=" of " data-maxlength-pre-text="You have "
                        data-maxlength-post-text=" chars remaining."
                        data-maxlength-limit-reached-class="m-badge m-badge--brand m-badge--rounded m-badge--wide"
                        data-autosize="true" class="form-control" placeholder="Ghi chú "></textarea>
                </div>
            </div>

            <div class="mt-4 header-control">
                <h5>Học vấn, nghề nghiệp</h5>
            </div>

            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label">Trình độ văn hóa <b class="text-danger">*</b></label>
                    <select name="DMVanHoaID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn trình độ" data-ajax-url="/qldcapi/categories?active=true&nhomid=9"
                        data-ajax-page-size=-1 data-result-field="result" data-value-field="ID" data-text-field="Name"
                        data-val="true" data-allow-clear="true">
                    </select>
                    <div class="form-control-feedback" data-valmsg-for="DMVanHoaID" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label">Trình độ chuyên môn <b class="text-danger">*</b></label>
                    <select name="DMChuyenMonID" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn trình độ" data-ajax-url="/qldcapi/categories?nhomid=10"
                        data-ajax-page-size=-1 data-result-field="result" data-value-field="ID" data-text-field="Name"
                        data-val="true" data-allow-clear="true">
                    </select>
                    <div class="form-control-feedback" data-valmsg-for="DMChuyenMonID" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label">Nghề Nghiệp</label>
                    <input type="text" name="NgheNghiep" class="form-control" placeholder="">
                </div>
            </div>

            <div class="form-group m-form__group row">
                <div class="col-8">
                    <label class="col-form-label">Nơi Làm Việc</label>
                    <input type="text" name="NoiLamViec" class="form-control" placeholder="">
                </div>
            </div>

            <div class="mt-4 header-control">
                <h5>Nơi ở hiện tại (Tạm trú)</h5>
            </div>

            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label">Tỉnh thành</label>

                    <select name="MaTinhThanhTamTru" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn tỉnh thành" data-ajax-url="/qldcapi/areas?parentCode=00"
                        data-ajax-page-size=-1 data-result-field=result data-value-field="Code" data-text-field="Name"
                        data-val="true" data-val="true" onchange="ChooseArea('MaTinhThanhTamTru','MaQuanHuyenTamTru')"
                        data-allow-clear="true" data-item-url="/qldcapi/areas/code/{id}"
                        data-item-result-field="result">
                        <option value=""></option>
                    </select>
                    <div class="form-control-feedback" data-valmsg-for="Tinh" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label">Quận, huyện</label>

                    <select name="MaQuanHuyenTamTru" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn quận huyện" data-ajax-url="       " data-ajax-page-size=-1
                        data-result-field=result data-value-field="Code" data-text-field="Name" data-val="true"
                        onchange="ChooseArea('MaQuanHuyenTamTru','MaXaPhuongTamTru')" data-allow-clear="true">
                        <option value=""></option>
                    </select>
                    <div class="form-control-feedback" data-valmsg-for="Huyen" data-valmsg-replace="true"></div>
                </div>

                <div class="col-4">
                    <label class="col-form-label">Phường, xã</label>
                    <select name="Xa" class="form-control m-select2" tdf-type="select" data-width="100%"
                        data-placeholder="Chọn xã" data-ajax-url="    " data-ajax-page-size=-1 data-result-field=result
                        data-value-field="Code" data-text-field="Name" data-val="true" data-allow-clear="true">
                    </select>
                    <div class="form-control-feedback" data-valmsg-for="Xa" data-valmsg-replace="true">
                    </div>
                </div>
            </div>

            <div class="form-group m-form__group row">
                <div class="col-8">
                    <label class="col-form-label">Địa chỉ tạm trú</label>
                    <input type="text" name="DiaChiTamTru" class="form-control" placeholder="">
                </div>
            </div>

            <div class="mt-4 header-control">
                <h5>CMND/CCCD</h5>
            </div>
            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label">Số thẻ</label>
                    <input type="text" name="SoCCCD" class="form-control" placeholder="">
                </div>
                <div class="col-4">
                    <label class="col-form-label">Ngày cấp</label>

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
                <div class="col-4">
                    <label class="col-form-label">Hạn sử dụng</label>
                    <input type="hidden" id="HanSuDungCCCD" name="HanSuDungCCCD" tdf-type="datepicker"
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
                <div class="col-8">
                    <label class="col-form-label">Nơi Cấp</label>
                    <input type="text" name="NoiCapCCCD" class="form-control" placeholder="">
                </div>
            </div>

            <div class="mt-4 header-control">
                <h5>Thẻ bảo hiểm y tế</h5>
            </div>
            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label">Số thẻ</label>
                    <input type="text" name="SoBHYT" class="form-control" placeholder="">
                </div>

                <!-- <div class="col-4">
                    <label class="col-form-label">Ngày cấp</label>
                    <input
                        type="hidden"
                        name="NgayCapBHYT"
                        tdf-type="datepicker"
                        data-ui-element="+div>input"
                        data-output-format="YYYY-MM-DDTHH:mm:ssZ"
                        data-input-format="DD/MM/YYYY"
                        data-autoclose="true"
                        data-autocomplete="true" />
                    <div class="m-input-icon m-input-icon--left">
                        <span class="m-input-icon__icon m-input-icon__icon--left">
                            <span><i class="la la-calendar-check-o"></i></span>
                        </span>
                        <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                    </div>
                </div> -->
                <div class="col-4">
                    <label class="col-form-label">Hạn sử dụng</label>
                    <input type="hidden" name="HanSuDungBHYT" tdf-type="datepicker" data-ui-element="+div>input"
                        data-output-format="YYYY-MM-DDTHH:mm:ssZ" data-input-format="DD/MM/YYYY" data-autoclose="true"
                        data-autocomplete="true" />
                    <div class="m-input-icon m-input-icon--left">
                        <span class="m-input-icon__icon m-input-icon__icon--left">
                            <span><i class="la la-calendar-check-o"></i></span>
                        </span>
                        <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                    </div>
                </div>
            </div>
            <!-- <div class="form-group m-form__group row">
                <div class="col-8">
                    <label class="col-form-label">Nơi Cấp</label>
                    <input type="text" name="NoiCapBHYT" class="form-control" placeholder="">
                </div>
            </div> -->

            <div class="mt-4 header-control">
                <h5>Hộ chiếu</h5>
            </div>
            <div class="form-group m-form__group row">
                <div class="col-4">
                    <label class="col-form-label">Số hộ chiếu</label>
                    <input type="text" name="SoHC" class="form-control" placeholder="">
                </div>

                <div class="col-4">
                    <label class="col-form-label">Ngày cấp</label>
                    <input type="hidden" id="NgayCapHC" name="NgayCapHC" tdf-type="datepicker"
                        data-ui-element="+div>input" data-output-format="YYYY-MM-DDTHH:mm:ssZ"
                        data-input-format="DD/MM/YYYY" data-autoclose="true" data-autocomplete="true" />
                    <div class="m-input-icon m-input-icon--left">
                        <span class="m-input-icon__icon m-input-icon__icon--left">
                            <span><i class="la la-calendar-check-o"></i></span>
                        </span>
                        <input type="text" class="form-control m-input" placeholder="Chọn ngày" />
                    </div>
                </div>

                <div class="col-4">
                    <label class="col-form-label">Nơi Cấp</label>
                    <input type="text" name="NoiCapHC" class="form-control" placeholder="">
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

                        var hoKhauId = Url.queryString("hoKhauId");
                        if (!IsNullOrUndefined(Url.queryString("hoKhauId"))) {
                            $("[name=HoKhauID]").val(hoKhauId);
                        }

                        if (id) loadData(id);
                        var dlg = modals.getCurrentDialog();
                        dlg.addCmd('OK', function (dlg, prevResult) {
                            return UploadFile(".file").then(() => {
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
                    });

                    var loadData = function (id) {
                        var item;
                        var form;
                        $('[name=ID]').val(id);
                        var unitService = new td.qldc.apis.NhanKhaus();
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

                    var UploadFile = async function (div) {
                        var frm = $("form");
                        if (frm.find(".dz-preview").length > 0) {
                            var rptItems = $("form").find(div).toArray().filter(ele => { if ($(ele).find(".dz-preview").length > 0) return $(ele); });
                            //rptItems.forEach(async function (item) {
                            for (let index = 0; index < rptItems.length; index++) {
                                const item = rptItems[index];
                                let id = $(item).find('[tdf-type="dropzone"]').attr("data-field");
                                let up = tdcore.forms.findWidgets(item, true, tdcore.forms.Dropzone)[0]
                                if (!up) break;
                                let pms = [];
                                if (up.queuedFiles.length || up.removedFiles.length) {
                                    toastr.info("Đang tải lên tệp đính kèm");
                                }
                                // update attachment
                                if (up.queuedFiles.length) {
                                    pms.push(up.uploadQueue());
                                }
                                // deleted files
                                if (up.removedFiles.length) {
                                    let deleted = $.map(up.removedFiles, f => f.url);
                                    let listApi = new tdcore.apis.ListsService();
                                    for (let i = 0; i < deleted.length; i++) {
                                        if (deleted[i]) {
                                            try {
                                                pms.push(
                                                    listApi.deleteFile(deleted[i])
                                                        .then(function () {
                                                            up.resetDeleted();
                                                        })
                                                );
                                            } catch { }
                                        }
                                    }
                                }
                                await Promise.all(pms).then(function () {
                                    let uploaded = $.map(up.uploadedFiles, f => f.url);
                                    let a = uploaded.join('\n');
                                    $(item).find("#" + id).val(a);
                                    $(item).find("#" + id).attr("value", a);
                                });
                            }
                            //});
                        }
                    }
                });
        </script>
    </asp:Content>