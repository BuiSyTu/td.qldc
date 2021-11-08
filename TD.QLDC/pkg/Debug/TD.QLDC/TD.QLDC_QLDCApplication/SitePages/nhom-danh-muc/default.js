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
                    new td.qldc.NhomDanhMucs().items
                )
            )
            .addCheckColumn()
            .addIndexColumn('STT')
            .addColumn(
            {
                title: "Tên danh mục",
                data: "Name"
            },
         //   {
         //       title: "Số điện thoại",
          //      data: "SoDienThoai",
           // },
           // {
           //     title: "Địa chỉ",
            //    data: "DiaChi",
          //  },
           // {
          //      title: "Người đại diện",
           //     data: "DaiDienPhapLuat",
           // },
            //{
                //title: "Trạng thái",
               // data: "TrangThai",
           // },
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
                    hdv.Edit(id);
                }).on('click','[delete]', function(){
                    var id = $(this).attr("data-id");
                    hdv.Delete(id);
                });
            },
        };
    }();

    jQuery(document).ready(function () {
        AreaRemoteAjax.init();
        $('[add]').click(function () {
            hdv.Add();
        });
        $('[delete]').click(function () {
            var id = $(this).attr("data-id");
            hdv.Delete(id);
        });

    });
    var hdv = {};
    hdv.Add = function () {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: "Thêm danh mục"
            })
            .iframe('modal/adddanhmuc.aspx')
            .size(500, 400)
            .OkCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var data = returnData.data;
                    // TODO: some thing with dialog result
                    var dt = data;
                    delete dt.ID;
                    debugger
                    var dtService = new td.qldc.NhomDanhMucs();
                    dtService.add(dt).then(function () {
                        toastr.success("Thực hiện thành công");
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };
    hdv.Edit = function (id) {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: "Sửa danh mục"
            })
            .iframe('modal/adddanhmuc.aspx?aid=' + id)
            .size(1200, 550).maximize()
            .OkCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var data = returnData.data;
                    // TODO: some thing with dialog result
                    var dt = data;
                    var dtService = new td.qldc.NhomDanhMucs();
                    dtService.update(dt.ID, dt).then(function () {
                        toastr.success("Thực hiện thành công");
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };
    hdv.Delete = function (id) {
        var dtApi = new td.qldc.NhomDanhMucs();
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
