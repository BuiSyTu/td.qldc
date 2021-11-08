$(document).ready(async function () {
    try {
        $.fn.dataTable.ext.errMode = 'none';
    } catch (e) { }
});
// lấy text của combobox
function GetComboxTextByName(name){
    return $("[name='" + name + "']").parent().find(".select2-selection__rendered").attr("title");
}
// tạo GUID 16 có -
function GUIDString() {
    return S4() + "-" + S4() + "-" + S4() + "-" + S4();
}
function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}
// set cookie
function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}
// get cookie
function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}
function eraseCookie(name) {
    document.cookie = name + '=; Max-Age=-99999999;';
}
//
function createFileData(file) {
    var arr = [file.url];
    if (file.name) {
        arr.push(file.name);
    }

    return arr.join(',');
}
// chỉ cho nhập số
$('.number-field').keypress(function (event) {
    var keycode = event.which;

    if (!(event.shiftKey == false && (keycode == 44 || keycode == 8 || keycode == 109 || (keycode >= 48 && keycode <= 57)))) {
        event.preventDefault();
    }
});

$('.number-field').change(function () {
    var value = $(this).val();
    value = formatMoney(value, 2, ",", ".");
    $(this).val(value);
});
// định dạng tiền tệ
function formatMoney(amount, decimalCount = 2, decimal = ".", thousands = ",") {
    try {
        amount = amount.replace(",", ".");
        decimalCount = Math.abs(decimalCount);
        decimalCount = isNaN(decimalCount) ? 2 : decimalCount;
        const negativeSign = amount < 0 ? "-" : "";
        let i = parseInt(amount = Math.abs(Number(amount) || 0).toFixed(decimalCount)).toString();
        let j = (i.length > 3) ? i.length % 3 : 0;

        return negativeSign + (j ? i.substr(0, j) + thousands : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousands) + (decimalCount ? decimal + Math.abs(amount - i).toFixed(decimalCount).slice(2) : "");
    } catch (e) {
        console.log(e)
    }
};
//Get trạng thái của 1 promise
function promiseState(p) {
    const t = {};
    return Promise.race([p, t])
        .then(v => (v === t) ? "pending" : "fulfilled", () => "rejected");
}
// hàm upload file chung
var UploadFile = function (id) {
    //var allpms = [];
    var tb = $("table[tdf-type=repeater]");
    if (tb.find(".dz-preview").length > 0) {
        var rptItems = $("table[tdf-type=repeater]").find("tr[data-repeater-item]").toArray();
        rptItems.reduce(function (chain, item) {
            return chain.then(function () {
                var up = tdcore.forms.findWidgets(item, true, tdcore.forms.Dropzone)[0]
                if (!up) return;
                var pms = [];
                if (up.queuedFiles.length || up.removedFiles.length) {
                    toastr.info("Đang tải lên tệp đính kèm");
                }
                // update attachment
                if (up.queuedFiles.length) {
                    pms.push(up.uploadQueue());
                }
                // deleted files
                if (up.removedFiles.length) {
                    var deleted = $.map(up.removedFiles, f => f.url);
                    var listApi = new tdcore.apis.ListsService();
                    for (var i = 0; i < deleted.length; i++) {
                        if (deleted[i]) {
                            pms.push(
                                listApi.deleteFile(deleted[i])
                                    .then(function () {
                                        up.resetDeleted();
                                    })
                            );
                        }
                    }
                }
                //allpms.push(Promise.all(pms));
                return Promise.all(pms)
                    .then(function () {
                        var uploaded = $.map(up.uploadedFiles, f => createFileData(f));
                        var a = uploaded.join('\n');
                        $(item).find("#" + id).val(a);
                        $(item).find("#" + id).attr("value", a);
                    });
            });
        }, Promise.resolve());
        //return Promise.resolve();
    }
    //return Promise.all(allpms)
    //.then(function(){
    //	return Promise.resolve();
    //})
    return Promise.resolve();
}
//Chọn tỉnh huyện xã set lại url cho cấp dưới
function ChooseArea(name,childName){
    var code = $("[name=" + name+"]").val();
    var wgs = tdcore.forms.findFormWidgets($('[name="' + childName + '"]').parent()[0], true, tdcore.forms.Select);
    if (wgs && wgs.length > 0) {
        var wgUsingOffice = wgs[0];
        if (code) {
            wgUsingOffice.setOptions({ 'ajax': {"url": "/_vti_bin/tdcore/areas.svc/areas/code/" + code + "/children" }});
        }
        else {
            wgUsingOffice.setOptions({ 'ajax': { "url": '' } });
        }
        $('[name = "' + childName + '"]').empty();
    }
}