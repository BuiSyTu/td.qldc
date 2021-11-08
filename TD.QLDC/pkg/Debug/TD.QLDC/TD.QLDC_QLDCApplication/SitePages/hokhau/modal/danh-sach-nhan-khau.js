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
                    new td.qldc.NhanKhaus().items.query({
                        shk : parseInt(Url.queryString("shk"))
                    })
                )
            )
            .addCheckColumn()
            .addIndexColumn('STT')           
            .addColumn(
              
            {
                title: "Họ Tên ",
                data: "HoTen"
              
            },
            {
                title: "Quan Hệ",
                data: "DMQuanHe",
                render: function (data, type, row) {
                    if (data!=null) {
                        return data.Name;
                    }
                    return "";
                },
            },
           
            {
                title: "Ngày sinh",
                data: "NgaySinh",
                type: "date",
                render: function (data, type, row) {
                    if (data && (type === 'display' || type === 'filter')) {
                        var d = new Date(data);
                        return d.format("dd/MM/yyyy");
                    }
                    return data;
                },
            },
            {
                title: "Hôn Nhân",
                data: "DMHonNhan",
                render: function (data, type, row) {
                    if (data!=null) {
                        return data.Name;
                    }
                    return "";
                },
            },
            {
                title: "Quê Quán",
                data: "QueQuan"
            },
            {
                title: "Số CMT",
                data: "SoCMT"
            },
            {
                title: "Nghề Nghiệp",
                data: "NgheNghiep"
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
                $('.td-datatable').on('click','[edit]', function(){
                    var id = $(this).attr("data-id");
                    nk.Edit(id);
                }).on('click','[delete]', function(){
                    var id = $(this).attr("data-id");
                    nk.Delete(id);
                }).on('click', '[view-nhankhau]', function () {
                    var id = $(this).attr("data-id");
                    nk.ViewNhanKhau(id);
                });
            },
        };
    }();

    jQuery(document).ready(function () {
        AreaRemoteAjax.init();
        $('[add]').click(function () {
            nk.Add();
        });
        $('[delete]').click(function () {
            var id = $(this).attr("data-id");
            nk.Delete(id);
        });

    });
    var nk = {};
    nk.Add = function () {
        var shk = Url.queryString("shk");
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: "Thêm nhân khẩu"
            })
            .iframe('modal/add-nhan-khau.aspx?shk='+shk)
            .size(1200, 550).maximize()
            .OkCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var dt = returnData.data;
                    delete dt.ID;
                    var api = new td.qldc.NhanKhaus();
                    api.add(dt).then(function () {
                        toastr.success("Thực hiện thành công");
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    })
                }
            });
    };
    nk.Edit = function (id) {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: "Sửa thông tin nhân khẩu"
            })
            .iframe('modal/add-nhan-khau.aspx?aid=' + id)
            .size(1200, 550).maximize()
            .OkCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var dt = returnData.data;
                    var api = new td.qldc.NhanKhaus();
                    api.update(dt.ID, dt).then(function () {
                        toastr.success("Thực hiện thành công");
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };
    nk.ViewNhanKhau=function(id){
        var obj = new Object();
        obj.text = "Hủy bỏ";
        tdcore.modals
            .modal({
                headerTitle: "Xem thông tin nhân khẩu"
            })
            .iframe('modal/view-nhan-khau.aspx?aid=' + id)
            .size(1200, 550).maximize()
            .btnCancel(obj, 1).show();
    }
    nk.Delete = function (id) {
        var api = new td.qldc.NhanKhaus();
        if (id) {
            if (confirm("Bạn thực sự muốn xóa mục này?")) {
                api.delete(id).then(function (data) {
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
                        api.delete(selected[i].ID).then(function (data) {
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
