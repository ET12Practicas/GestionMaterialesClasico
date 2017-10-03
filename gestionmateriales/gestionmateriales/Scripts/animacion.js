window.setTimeout(function () {
    $("#alert_message").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 750);

//function ClearFields() {

//    document.getElementById("nom").value = "";
//    document.getElementById("fc").value = "";
//    document.getElementById("dni").value = "";
//}