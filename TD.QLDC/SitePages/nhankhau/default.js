(function (factor) {
    factor(window, tdcore.views, jQuery);
})(function (exports, views, $) {
    'use strict'
    //== Class definition
    var dmDoiTuongId = null;
    var dmVanHoaId = null;
    var dmQuanHeId = null;
    var gioiTinh = null;
    var tuTuoi = null;
    var denTuoi = null;

    var AreaRemoteAjax = function () {
        //== Private functions
        var query = new td.qldc.apis.NhanKhaus().items.query({
            dmDoiTuongId,
            dmVanHoaId,
            dmQuanHeId,
            gioiTinh,
            tuTuoi,
            denTuoi,
            includes: 'DMQuanHe,DMHonNhan,DMDoiTuong',
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
                    // {
                    //     title: 'Quan Hệ',
                    //     data: 'DMQuanHe.Name',
                    // },
                    {
                        title: 'Đối tượng chính sách',
                        data: 'DMDoiTuong.Name',
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
                    },
                    {
                        title: 'Thao tác',
                        render: function (data, type, row, meta) {
                            var source = $('#action-template').html();
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
            reload: function() {
                query.query({
                    dmDoiTuongId,
                    dmVanHoaId,
                    dmQuanHeId,
                    gioiTinh,
                    tuTuoi,
                    denTuoi,
                    includes: 'DMQuanHe,DMHonNhan,DMDoiTuong',
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

        fillSelect({
            selector: '.select-dmdoituongid.filter',
            dataProvider: new td.qldc.apis.Categories().items.query({
                nhomid: 4,
                orderBy: 'Order',
                active: true,
            }),
            dataValueField: 'ID',
            dataTextField: 'Name',
            placeholder: 'Tất cả',
            allowClear: true,
        });

        $('.select-dmdoituongid.filter').on('change', function() {
            dmDoiTuongId = $(this).val();
            AreaRemoteAjax.reload();
        })

        fillSelect({
            selector: '.select-dmvanhoaid.filter',
            dataProvider: new td.qldc.apis.Categories().items.query({
                nhomid: 9,
                orderBy: 'Order',
                active: true,
            }),
            dataValueField: 'ID',
            dataTextField: 'Name',
            placeholder: 'Tất cả',
            allowClear: true,
        });

        $('.select-dmvanhoaid.filter').on('change', function() {
            dmVanHoaId = $(this).val();
            AreaRemoteAjax.reload();
        })

        fillSelect({
            selector: '.select-dmquanheid.filter',
            dataProvider: new td.qldc.apis.Categories().items.query({
                nhomid: 8,
                orderBy: 'Order',
                active: true,
            }),
            dataValueField: 'ID',
            dataTextField: 'Name',
            placeholder: 'Tất cả',
            allowClear: true,
        });

        $('.select-dmquanheid.filter').on('change', function() {
            dmQuanHeId = $(this).val();
            AreaRemoteAjax.reload();
        })

        fillSelect({
            selector: '.select-gioitinh.filter',
            placeholder: 'Tất cả',
            allowClear: true,
        });

        $('.select-gioitinh.filter').on('change', function() {
            gioiTinh = $(this).val();
            AreaRemoteAjax.reload();
        })

        fillSelect({
            selector: '.select-tutuoi.filter',
            placeholder: 'Tất cả',
            data: tuoi1Den100(),
            dataTextField: 'text',
            dataValueField: 'value',
            allowClear: true,
        })

        $('.select-tutuoi.filter').on('change', function() {
            tuTuoi = $(this).val();
            AreaRemoteAjax.reload();
        })

        fillSelect({
            selector: '.select-dentuoi.filter',
            placeholder: 'Tất cả',
            data: tuoi1Den100(),
            dataTextField: 'text',
            dataValueField: 'value',
            allowClear: true,
        })

        $('.select-dentuoi.filter').on('change', function() {
            denTuoi = $(this).val();
            AreaRemoteAjax.reload();
        })
    });

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

    function tuoi1Den100() {
        var items = []
    
        for (var i = 1; i <= 100; i++) {
            items.push({
                text: i,
                value: i,
            })
        }
    
        return items
    }
});
