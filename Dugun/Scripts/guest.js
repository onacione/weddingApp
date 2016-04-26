var guestFunctions = {

 SetGuest: function () {
      var dto = {
          Name: "Sami",
          Surname: "Yılmaz"

      };
      Services.SetGuest(dto, function (data) {
          if (data.ErrorObject != null) {
              console.log("success");
          }
          else {
              console.log("error");
          }
      });
    },   

};



$(document).ready(function () {
    guestFunctions.SetGuest();
});