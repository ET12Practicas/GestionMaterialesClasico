$(document).ready(function () {
    $('#btn_limpiar').tooltip();
    $('#btn_aceptar').tooltip();
    $('#btn_cancelar').tooltip();

    var baseURL = window.location.protocol + "//" + window.location.host + "/"
    var request = $.ajax({
        url: baseURL + "Material/GetMaterialesShort",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        //if (data.Response != '') {
        //    $('#verMaterial').html('<p><strong>Código: </strong>' + data.Response[0].codigo + '<br /><strong>Material: </strong>' + data.Response[0].nombre + '</p>');
        //}
        //else {
        //    $('#verMaterial').html('<p>No existe el material con el código del material ingresado.</p>');
        //}
        var fuseOptions = { keys: ["nombre", "codigo"] };
        var options = { display: "nombre", key: "codigo", resultsLimit: 10, fuseOptions: fuseOptions };
        $("#materialPicker").fuzzyComplete(data.Response, options);
        
        //Visualiza el detalle del material seleccionado
        $('input').on('keyup blur', function () {
            $(this).parent().find(".output").html($(this).parent().find("select").val());
        });

    });

    request.fail(function (data) {
        alert(data.Response);
    });
});

$('.output').on('DOMSubtreeModified', function () {
    console.log($('#codigoMaterial').text());
    $('#codMaterial').val($('#codigoMaterial').text());
})