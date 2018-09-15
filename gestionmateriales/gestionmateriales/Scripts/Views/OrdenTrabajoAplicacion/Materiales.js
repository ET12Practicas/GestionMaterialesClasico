var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";

    var requestMaterial = $.ajax({
        url: baseURL + "OrdenTrabajoAplicacion/GetMateriales",
        type: 'GET',
        data: { id: $('#IdOT').val() },
        contentType: 'application/json; charset=utf-8'
    });

    requestMaterial.done(function (data) {
        //console.log(data.Response);
        tablaMateriales = $('#grdMateriales').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0, 1],
                "visible": false,
                "sType": "html",
                "aTargets": [5,6]
            }],
            "aoColumns": [
                {
                    "data": "idOT"
                },
                {
                    "data": "idMat"
                },
                {
                    "sWidth": "10%",
                    "data": "codMat"
                },
                {
                    "sWidth": "50%",
                    "data": "nomMat"
                },
                {
                    "sWidth": "10%",
                    "data": "stkMat"
                },
                {
                    "sWidth": "10%",
                    //"data": "cant"
                    "mRender": function (dato, type, raw) {
                        var editarCant = '<input id="iCant-' + raw.idOT + '-' + raw.idMat + '" type="number" min="0" max="'
                            + raw.stkMat + '" class="form-control" value="' + raw.cant + '" />';
                        return editarCant;
                    }
                },
                {
                    "sWidth": "10%",
                    "mRender": function (dato, type, raw) {

                        var btnAddItemOTA = '<button type="button" title="Detalle" class="btn btn-outline-primary btn-sm" href="" id="bCant-' + raw.idOT + '-' + raw.idMat + 
                            '" onclick="addItemOTA(this);"><i class="fas fa-plus"></i> Agregar</button> ';
                        return btnAddItemOTA;
                    }
                },
            ],
            "order": [2, "asc"]
        });
    });

    requestMaterial.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar el listado de materiales');
    });
});

function addItemOTA(data) {
    var idOT = data.id.split('-')[1];
    var idMaterial = data.id.split('-')[2];
    var cant = $('#iCant-' + idOT + '-' + idMaterial).val();

    var request = $.ajax({
        url: baseURL + "OrdenTrabajoAplicacion/AddItemMaterial",
        type: 'POST',
        data: "{ 'id': '" + idOT + "', 'idMaterial':'" + idMaterial + "', 'cant':'" + cant + "' }",
        dataType: 'json',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function () {

        $.notify(
            {
                message: 'Los datos se guardaron con éxito'
            },
            {
                type: 'success',
                animate: {
                    enter: 'animated bounceInDown',
                    exit: 'animated bounceOutUp'
                },
                placement: {
                    from: 'top',
                    align: 'right'
                },
                offset: {
                    x: 25,
                    y: 75
                },
                delay: 500
            }
        );
    });

    request.fail(function () {
        console.log(data.Response);
        alert('No se pueden cargar el listado de items OTA');
    });
}