(function (factor) {
    factor(window, tdcore.views, jQuery);
})(function (exports, views, $) {
    'use strict'    
    //== Class definition
    var AreaRemoteAjax = function () {
        //== Private functions
        var loadDatatable = function () {
                views.table('.td-datatable', {
                    'serverSide': true,
                    filter: true,
                })
                    .useDataLoader(
                        new views.TDApiDataLoader(new td.qldc.apis.HoKhaus().items.query({
                            includes: 'DMLoaiHo'
                        }))
                    )
                    .addCheckColumn()
                    .addIndexColumn('STT')
                    .addColumn(
                        {
                            title: 'Thôn',
                            data: 'TenThon',
                        },
                        {
                            title: 'Xóm',
                            data: 'TenXom',
                        },
                        {
                            title: 'Tên chủ hộ',
                            data: 'TenChuHo',
                        },
                        {
                            title: 'CCCD chủ hộ',
                            data: 'CCCDCHuHo',
                        },
                        {
                            title: 'Loại hộ',
                            data: 'DMLoaiHo.Name',
                        },
                        {
                            title: 'Hộ kinh doanh',
                            data: 'HoKinhDoanh',
                        }
                    )
                    .addTemplateColumn({
                        title: 'Thao tác',
                        template: $('#action-template').html()
                    })
                    .build();
        };
        return {
            // public functions
            init: function () {
                
                loadDatatable();
                
                $('.td-datatable').on('click', '[edit]', function () {
                    var id = $(this).attr('data-id');
                    hokhau.Edit(id);
                }).on('click', '[delete]', function () {
                    var id = $(this).attr('data-id');
                    hokhau.Delete(id);
                }).on('click', '[nhankhau]', function () {
                    var shk = $(this).attr('sohokhau-id');
                    var hoKhauId = $(this).attr('hoKhauId');
                    hokhau.NhanKhau(shk, hoKhauId);
                }).on('processing.dt', function (e, settings, processing) {

                        if (!processing) {
                            tdcore.permissions.updateUi('td')
                        }

                    });
            },
        };
    }();

    $(document).ready(function () {
        AreaRemoteAjax.init();
        $('[tdf-type="sp-areaselect"],[tdf-type="select"],[tdf-type="combobox"]')
            .change(function () {
                $('.td-datatable').DataTable().ajax.reload();
            });
        $('[add]').click(function () {
            hokhau.Add();
        });
        $('[delete]').click(function () {
            var id = $(this).attr('data-id');
            hokhau.Delete(id);
        });

    });

    var hokhau = {};

    hokhau.Add = function () {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: 'Thêm hộ khẩu'
            })
            .iframe('modal/add-ho-khau.aspx')
            .size(700, 650)
            .okCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var data = returnData.data;
                    // TODO: some thing with dialog result
                    var dt = data;
                    delete dt.ID;
                    var dtService = new td.qldc.apis.HoKhaus();
                    dtService.add(dt).then(function () {
                        toastr.success('Thực hiện thành công');
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };

    hokhau.Edit = function (id) {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: 'Sửa hộ khẩu'
            })
            .iframe('modal/add-ho-khau.aspx?aid=' + id)
            .size(700, 550)
            .okCancel()
            .show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var data = returnData.data;
                    // TODO: some thing with dialog result
                    var dt = data;
                    var dtService = new td.qldc.apis.HoKhaus();
                    dtService.update(dt.ID, dt).then(function () {
                        toastr.success('Thực hiện thành công');
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };

    hokhau.NhanKhau = function (shk, hoKhauId) {
        var obj = new Object();
        obj.text = 'Hủy bỏ';
        tdcore.modals
            .modal({
                headerTitle: 'Danh sách nhân khẩu'
            })
            .iframe(`modal/danh-sach-nhan-khau.aspx?shk=${shk}&hoKhauId=${hoKhauId}`)
            .maximize()
            .btnCancel(obj, 1).show();
    };

    hokhau.Delete = function (id) {
        var dtApi = new td.qldc.apis.HoKhaus();
        if (id) {
            if (confirm('Bạn thực sự muốn xóa mục này?')) {
                dtApi.delete(id).then(function (data) {
                    if (data.status === 204) {
                        toastr.success('Thực hiện thành công');
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    } else {
                        toastr.error('Thực hiện không thành công');
                    }
                });
            }
        } else {
            var table = $('.td-datatable').DataTable();
            var length = table.rows('.selected').data().length;
            var selected = table.rows('.selected').data();
            if (length <= 0) {
                toastr.warning('Bạn chưa chọn mục nào!');
            } else if (length > 0) {
                if (confirm('Bạn thực sự muốn xóa mục này?')) {
                    for (var i = 0; i < length; i++) {
                        dtApi.delete(selected[i].ID).then(function (data) {
                            if (data.status === 204) {
                                toastr.success('Thực hiện thành công');
                                var table = $('.td-datatable').DataTable();
                                table.ajax.reload();
                            } else {
                                toastr.error('Thực hiện không thành công');
                            }
                        });
                    }
                }
            }
        }
    };
   
});
