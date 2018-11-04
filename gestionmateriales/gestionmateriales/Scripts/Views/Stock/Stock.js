var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {
   
    if (window.location.href.split(':').length == 2)
        baseURL = baseURL + appName + "/";

    var request = $.ajax({
        url: baseURL + "Material/GetMaterialesShort",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        var fuseOptions = { keys: ["nombre", "codigo"] };
        var options = { display: "nombre", key: "codigo", resultsLimit: 7, fuseOptions: fuseOptions };
        $("#materialPicker").fuzzyComplete(data.Response, options);
        
        //Visualiza el detalle del material seleccionado
        $('input').on('keyup blur', function () {
            $(this).parent().find(".output").html($(this).parent().find("select").val());
        });

    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar el stock de materiales');
    });
});

$('.output').on('DOMSubtreeModified', function () {
    $('#codMaterial').val($('#codigoMaterial').text());
});