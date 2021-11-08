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
                    new td.qldc.Categories().items.query({
                     
                      nhomid: 7
                    })
                )
            )
            .addCheckColumn()
            .addIndexColumn('STT')
            .addColumn(
            {
                title: "Thứ tự",
                data: "Order"
            },            
            {
                title: "Hôn nhân",
                data: "Name"
            },
            {
                title: "Sử dụng",
                data: "Active",
                searchable: false,
                orderable: false,
                className: "text-center",
                render: function (data, type, row) {
                    var checked = null;
                    if (data)
                        checked = "checked";
                    return '<label class="m-checkbox m-checkbox--single  m-checkbox--success m-checkbox--disabled">' +
                        '<input type="checkbox" name="checkbox" ' + checked + ' value="true" disabled>' +
                        '<span></span>' +
                        '</label>';
                }
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
                    hn.Edit(id,"Sửa tình trạng hôn nhân",'modal/add-hon-nhan.aspx');
                }).on('click','[delete]', function(){
                    var id = $(this).attr("data-id");
                    hn.Delete(id);
                });
            },
        };
    }();

    jQuery(document).ready(function () {
        AreaRemoteAjax.init();
        $('[add]').click(function () {
            hn.Add("Thêm tính trạng hôn nhân",'modal/add-hon-nhan.aspx');
        });
        $('[delete]').click(function () {
            var id = $(this).attr("data-id");
            hn.Delete(id);
        });

    });
    var hn = {};
    hn.Add = function (name,url) {
    tdcore.modals // khá»Ÿi táº¡o modal dialog
        .modal({
            headerTitle: name
        })
        .iframe(url)
        .size(450, 350)
        .OkCancel().show()
        .then(function (returnData) {
            if (returnData.result == 'OK') {
                var data = returnData.data;
                // TODO: some thing with dialog result
                var dm = data;
                dm.Active = data.Active[0]||false;
                delete dm.ID;
                var dmService = new td.qldc.Categories();
                dmService.add(dm).then(function () {
                    toastr.success("Thá»±c hiá»‡n thÃ nh cÃ´ng");
                    var table = $('.td-datatable').DataTable();
                    table.ajax.reload();
                });
            }
        });
};
hn.Edit = function (id,name,url) {
    tdcore.modals // khá»Ÿi táº¡o modal dialog
        .modal({
            headerTitle: name
        })
        .iframe(url+'?aid=' + id)
        .size(450, 350)
        .OkCancel().show()
        .then(function (returnData) {
            if (returnData.result == 'OK') {
                var data = returnData.data;
                // TODO: some thing with dialog result
                var dm = data;
                dm.Active = data.Active[0]||false;
                var dmService = new td.qldc.Categories();
                dmService.update(dm.ID, dm).then(function () {
                    toastr.success("Thá»±c hiá»‡n thÃ nh cÃ´ng");
                    var table = $('.td-datatable').DataTable();
                    table.ajax.reload();
                });
            }
        });
};
    hn.Delete = function (id) {
    var danhmucApi = new td.qldc.Categories();
    if (id) {
        if (confirm("Báº¡n thá»±c sá»± muá»‘n xÃ³a má»¥c nÃ y?")) {
            danhmucApi.delete(id).then(function (data) {
                if (data.status == 200) {
                    toastr.success("Thá»±c hiá»‡n thÃ nh cÃ´ng");
                    var table = $('.td-datatable').DataTable();
                    table.ajax.reload();
                } else {
                    toastr.error("Thá»±c hiá»‡n khÃ´ng thÃ nh cÃ´ng");
                }
            });
        }
    } else {
        var table = $('.td-datatable').DataTable();
        var length = table.rows('.selected').data().length;
        var selected = table.rows('.selected').data();
        if (length <= 0) {
            toastr.warning("Báº¡n chÆ°a chá»n má»¥c nÃ o!");
        } else if (length > 0) {
            if (confirm("Báº¡n thá»±c sá»± muá»‘n xÃ³a má»¥c nÃ y?")) {
                for (var i = 0; i < length; i++) {
                    danhmucApi.delete(selected[i].ID).then(function (data) {
                        if (data.status == 200) {
                            toastr.success("Thá»±c hiá»‡n thÃ nh cÃ´ng");
                            var table = $('.td-datatable').DataTable();
                            table.ajax.reload();
                        } else {
                            toastr.error("Thá»±c hiá»‡n khÃ´ng thÃ nh cÃ´ng");
                        }
                    });
                }
            }
        }
    }
  };
});
