(function (factor) {
    factor(window, tdcore.views, jQuery);
})(function (exports, views, $) {
    'use strict'
    //== Class definition
    var bhytStatus = null;

    var AreaRemoteAjax = function () {
        //== Private functions
        var query = new td.qldc.apis.NhanKhaus().items.query({
            includes: 'DMQuanHe,DMHonNhan,DMDoiTuong',
            dongBHYT: true,
            orderBy: 'HanSuDungBHYT',
            bhytStatus: null,
        })

        var loadDatatable = function () {
            views.table('.td-datatable', {
                'serverSide': true,
                filter: true
            })
                .useDataLoader(
                    new views.TDApiDataLoader(
                        query
                    )
                        .beforeLoad(function (items) {
                            items.query(query).count(true)
                        })
                )
                .addCheckColumn()
                .addIndexColumn('STT')
                .addColumn(
                    {
                        title: 'Họ Tên ',
                        data: 'HoTen'

                    },
                    {
                        title: 'Giới tính',
                        data: 'GioiTinh'

                    },
                    {
                        title: 'Ngày sinh',
                        data: null,
                        render: function (data, type, row) {
                            var date = new Date(data.NgaySinh)
                            return date.ddMMyyyy()
                        }
                    },
                    {
                        title: 'CMND/CCCD',
                        data: 'SoCCCD'
                    },
                    {
                        title: 'Thẻ BHYT',
                        data: 'SoBHYT'

                    },
                    {
                        title: 'Hạn BHYT',
                        data: null,
                        render: function (data, type, row) {
                            if (!data.HanSuDungBHYT) return '';

                            var date = new Date(data.HanSuDungBHYT)
                            return date.ddMMyyyy()
                        }
                    },
                    {
                        title: 'Nghề Nghiệp',
                        data: 'NgheNghiep'
                    })
                .build();
        };
        return {
            // public functions
            init: function () {
                loadDatatable();
                $('.td-datatable').on('click', '[edit]', function () {
                    var id = $(this).attr('data-id');
                    nk.Edit(id);
                }).on('click', '[delete]', function () {
                    var id = $(this).attr('data-id');
                    nk.Delete(id);
                }).on('click', '[view-nhankhau]', function () {
                    var id = $(this).attr('data-id');
                    nk.ViewNhanKhau(id);
                }).on('processing.dt', function (e, settings, processing) {

                    if (!processing) {
                        tdcore.permissions.updateUi('td')
                    }

                });
            },
            reload: function () {
                var bhytStatusCode = $('.bhyt-filter.active').attr('data-code');

                query.query({
                    includes: 'DMQuanHe,DMHonNhan,DMDoiTuong',
                    dongBHYT: true,
                    orderBy: 'HanSuDungBHYT',
                    bhytStatus: BHYTStatus[bhytStatusCode] || null,
                })

                $('.td-datatable').DataTable().ajax.reload();
            },
        };
    }();

    $(document).ready(function () {
        AreaRemoteAjax.init();
        $('[add]').click(function () {
            nk.Add();
        });
        $('[delete]').click(function () {
            var id = $(this).attr("data-id");
            nk.Delete(id);
        });

        $('.bhyt-filter').on('click', function() {
            $('.bhyt-filter').removeClass('active');
            $(this).addClass('active');
            AreaRemoteAjax.reload();
        })
    });

    const BHYTStatus = {
        SapDenHan: 1,
        QuaHan: 2,
        DuocMien: 3,
    }

    var nk = {};
    nk.Add = function () {
        var hoKhauId = Url.queryString('hoKhauId');
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: 'Thêm nhân khẩu'
            })
            .iframe('modal/add-nhan-khau.aspx?hoKhauId=' + hoKhauId)
            .maximize()
            .okCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    var dt = returnData.data;
                    delete dt.ID;
                    var api = new td.qldc.apis.NhanKhaus();
                    api.add(dt).then(function () {
                        toastr.success('Thực hiện thành công');
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    })
                }
            });
    };

    nk.Edit = function (id) {
        tdcore.modals // khởi tạo modal dialog
            .modal({
                headerTitle: 'Sửa thông tin nhân khẩu'
            })
            .iframe('modal/add-nhan-khau.aspx?aid=' + id)
            .size(1200, 550).maximize()
            .okCancel().show()
            .then(function (returnData) {
                if (returnData.result == 'OK') {
                    //try validate or getdata and close form
                    var dt = returnData.data;
                    var api = new td.qldc.apis.NhanKhaus();
                    api.update(dt.ID, dt).then(function () {
                        toastr.success('Thực hiện thành công');
                        var table = $('.td-datatable').DataTable();
                        table.ajax.reload();
                    });
                }
            });
    };

    nk.ViewNhanKhau = function (id) {
        var obj = new Object();
        obj.text = 'Hủy bỏ';
        tdcore.modals
            .modal({
                headerTitle: 'Xem thông tin nhân khẩu'
            })
            .iframe('modal/view-nhan-khau.aspx?aid=' + id)
            .size(1200, 550).maximize()
            .btnCancel(obj, 1).show();
    }

    nk.Delete = function (id) {
        var api = new td.qldc.apis.NhanKhaus();
        if (id) {
            if (confirm('Bạn thực sự muốn xóa mục này?')) {
                api.delete(id).then(function (data) {
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
                        api.delete(selected[i].ID).then(function (data) {
                            if (data.status == 204) {
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
