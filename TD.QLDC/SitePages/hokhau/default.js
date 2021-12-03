(function (factor) {
    factor(window, tdcore.views, jQuery);
})(function (exports, views, $) {
    "use strict";
    //== Class definition
    var AreaRemoteAjax = function () {
        //== Private functions
        var loadDatatable = function () {
            views.table('.td-datatable', {
                "serverSide": true,
                filter: false
            })
                .useDataLoader(
                    new views.TDApiDataLoader(
                        new td.qldc.HoKhaus().items
                        )
                  
                )
                .addCheckColumn()
                .addIndexColumn('STT')
                .addColumn(
                    {
                        title: "Số Hộ Khẩu",
                        data: "SoHoKhau"
                    },
                    {
                        title: "Số Nhà",
                        data: "SoNha"
                    },
                   
                    {
                        title: "Thôn",
                        data: "Thon",
                    },
                    {
                        title: "Xóm",
                        data: "Xom",
                    },

                    {
                        title: "Người Nhập",
                        data: "NguoiNhap",
                    },
                    {
                        title: "Ghi Chú",
                        data: "GhiChu",
                    },
                    {
                        title: "Thao tác",
                        render: function (data, type, row, meta) {
                            var source = $("#action-template").html();
                            var template = Handlebars.compile(source);
                            return template(row);
                        },
                        orderable: false,
                        searchable: false
                    })
                .build();
        };
        return {
            // public functions
            init: function () {
                loadDatatable();
                $('.td-datatable').on('click', '[edit]', function () {
                    var id = $(this).attr("data-id");
                    hokhau.Edit(id);
                }).on('click', '[delete]', function () {
                    var id = $(this).attr("data-id");
                    hokhau.Delete(id);
                }).on('click', '[nhankhau]', function () {
                    var shk = $(this).attr("sohokhau-id");
                    hokhau.NhanKhau(shk);
                });
            },
        };
    }();

    jQuery(document).ready(function () {
        AreaRemoteAjax.init();
        $('[tdf-type="sp-areaselect"],[tdf-type="select"],[tdf-type="combobox"]')
            .change(function () {
                $('.td-datatable').DataTable().ajax.reload();
            });
        $('[add]').click(function () {
            hokhau.Add();
        });
        $('[delete]').click(function () {
            var id = $(this).attr("data-id");
            hokhau.Delete(id);
        });

    });
    var hokhau = {};
    hokhau.Add = function () {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: "Thêm hộ khẩu"
            })
            .iframe('modal/add-ho-khau.aspx')
            .size(700, 500)
            .okCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var data = returnData.data;
                    // TODO: some thing with dialog result
                    var dt = data;
                    delete dt.ID;
                    var dtService = new td.qldc.HoKhaus();
                    dtService.add(dt).then(function () {
                        toastr.success("Thực hiện thành công");
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };
    hokhau.Edit = function (id) {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: "Sửa hộ khẩu"
            })
            .iframe('modal/add-ho-khau.aspx?aid=' + id)
            .size(700, 550)
            .okCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var data = returnData.data;
                    // TODO: some thing with dialog result
                    var dt = data;
                    var dtService = new td.qldc.HoKhaus();
                    dtService.update(dt.ID, dt).then(function () {
                        toastr.success("Thực hiện thành công");
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };
    hokhau.NhanKhau = function (shk) {
        var obj = new Object();
        obj.text = "Hủy bỏ";
        tdcore.modals
            .modal({
                headerTitle: "Danh sách nhân khẩu"
            })
            .iframe('modal/danh-sach-nhan-khau.aspx?shk=' + shk)
            .size(1200, 550).maximize()
            .btnCancel(obj, 1).show();
    };
    hokhau.Delete = function (id) {
        var dtApi = new td.qldc.HoKhaus();
        if (id) {
            if (confirm("Bạn thực sự muốn xóa mục này?")) {
                dtApi.delete(id).then(function (data) {
                    if (data.status == 200) {
                        toastr.success("Thực hiện thành công");
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    } else {
                        toastr.error("Thực hiện không thành công");
                    }
                });
            }
        } else {
            var table = $('.td-datatable').DataTable();
            var length = table.rows('.selected').data().length;
            var selected = table.rows('.selected').data();
            if (length <= 0) {
                toastr.warning("Bạn chưa chọn mục nào!");
            } else if (length > 0) {
                if (confirm("Bạn thực sự muốn xóa mục này?")) {
                    for (var i = 0; i < length; i++) {
                        dtApi.delete(selected[i].ID).then(function (data) {
                            if (data.status == 200) {
                                toastr.success("Thực hiện thành công");
                                var table = $('.td-datatable').DataTable();
                                table.ajax.reload();
                            } else {
                                toastr.error("Thực hiện không thành công");
                            }
                        });
                    }
                }
            }
        }
    };
});
