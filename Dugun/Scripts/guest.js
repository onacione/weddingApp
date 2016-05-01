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
 OpenEditModal: function (e) {
     $('#setguestInfoModal').modal("show");
 },

};



$(document).ready(function () {
    
});