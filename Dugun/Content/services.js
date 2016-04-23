var ui = {
    ServiceUrl: window.location.protocol + "//" + window.location.host + "/" + "Controllers/MainController.cs/",
}

var Services = {
    GetUser: function (userId, fn) {
        $.ajax({
            type: "GET",
            url: ui.ServiceUrl + "GetUser/" + userId,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                fn(data);
            },
            error: function () {
                ui.ShowError();
            }
        });
    },
    SetUser: function (dto, fn) {
        $.ajax({
            type: "POST",
            url: ui.ServiceUrl + "SetUser",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(dto),
            success: function (data) {
                fn(data);
            },
            error: function () {
                ui.ShowError();
            }
        });
    },
};

$(document).ajaxStart(function (e) {
    ui.StartAjaxRequest();
});

$(document).ajaxStop(function (e) {
    ui.FinishAjaxRequest();
});