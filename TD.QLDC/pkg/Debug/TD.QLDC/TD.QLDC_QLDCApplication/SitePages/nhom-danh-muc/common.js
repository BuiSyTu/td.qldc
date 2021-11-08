var danhmuc = {};
danhmuc.Add = function (name,url) {
    tdcore.modals // khởi tạo modal dialog
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
                    toastr.success("Thực hiện thành công");
                    var table = $('.td-datatable').DataTable();
                    table.ajax.reload();
                });
            }
        });
};
danhmuc.Edit = function (id,name,url) {
    tdcore.modals // khởi tạo modal dialog
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
                    toastr.success("Thực hiện thành công");
                    var table = $('.td-datatable').DataTable();
                    table.ajax.reload();
                });
            }
        });
};
danhmuc.Delete = function (id) {
    var danhmucApi = new td.qldc.Categories();
    if (id) {
        if (confirm("Bạn thực sự muốn xóa mục này?")) {
            danhmucApi.delete(id).then(function (data) {
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
                    danhmucApi.delete(selected[i].ID).then(function (data) {
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