$(document).ready(function () {
    $('#btn_limpiar').tooltip();
    $('#btn_aceptar').tooltip();
    $('#btn_cancelar').tooltip();

    var appName = location.pathname.split('/')[1];
    var baseURL = window.location.protocol + "//" + window.location.host + "/";

    if (appName == 'ottest')
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
    //console.log($('#codigoMaterial').text());
    $('#codMaterial').val($('#codigoMaterial').text());
})