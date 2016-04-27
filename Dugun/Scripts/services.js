var ui = {
    BaseUrl: window.location.protocol + "//" + window.location.host,
    ServiceUrl: window.location.protocol + "//" + window.location.host + "/" + "Models/DataService/WinService.svc/",
}

var Services = {

    SetGuest: function (dto, fn) {
        debugger;
        $.ajax({
            type: "POST",
            url: ui.ServiceUrl + "SetGuest",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(dto),
            success: function (data) {
                console.log("success");
            },
            error: function () {
                console.log("error");
            }
        });
    },
};
