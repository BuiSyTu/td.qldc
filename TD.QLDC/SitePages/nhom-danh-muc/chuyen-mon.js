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
                    new td.qldc.apis.Categories().items.query({
                      nhomid: 10
                    })
                )
            )
            .addCheckColumn()
            .addColumn(
            {
                title: "Thứ tự",
                data: "Order"
            },            
            {
                title: "Trình độ chuyên môn ",
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
                    danhmuc.Edit(id,"Sửa trình độ chuyên môn",'modal/add-chuyen-mon.aspx');
                }).on('click','[delete]', function(){
                    var id = $(this).attr("data-id");
                    danhmuc.Delete(id);
                });
            },
        };
    }();

    $(document).ready(function () {
        AreaRemoteAjax.init();
        $('[add]').click(function () {
            danhmuc.Add("Thêm trình độ chuyên môn",'modal/add-chuyen-mon.aspx');
        });
        $('[delete]').click(function () {
            var id = $(this).attr("data-id");
            danhmuc.Delete(id);
        });
    });
});
