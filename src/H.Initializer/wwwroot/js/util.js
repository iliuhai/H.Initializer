// ajax post请求
function AjaxPostRequest(url, parameter, callback) {
    if (parameter == undefined)
        parameter = {};
    $.ajax({
        type: "POST",
        url: url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: parameter,
        success: function (result) {
            if (callback)
                callback(result);
        },
        failure: function (err) {
            if (callback)
                callback(err);
        }
    });
}