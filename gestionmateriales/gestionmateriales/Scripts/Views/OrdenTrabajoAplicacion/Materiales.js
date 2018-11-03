var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {

    if (location.pathname.split('/').length > 2)
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

                        var btnAgregarItemOTA = '<button type="button" title="Detalle" class="btn btn-outline-primary btn-sm" href="" id="bCant-' + raw.idOT + '-' + raw.idMat + 
                            '" onclick="AgregarItemOTA(this);"><i class="fas fa-plus"></i> Agregar</button> ';
                        return btnAgregarItemOTA;
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

function AgregarItemOTA(data) {
    var idOT = data.id.split('-')[1];
    var idMaterial = data.id.split('-')[2];
    var cant = $('#iCant-' + idOT + '-' + idMaterial).val();
    if (cant <= 0) {
        ShowNotificationDanger('Orden de Trabajo de Aplicación', 'El campo cantidad debe ser un valor entero y positivo');
    }
    else {
        var request = $.ajax({
            url: baseURL + "OrdenTrabajoAplicacion/AddItemMaterial",
            type: 'POST',
            data: "{ 'id': '" + idOT + "', 'idMaterial':'" + idMaterial + "', 'cant':'" + cant + "' }",
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        });

        request.done(function () {
            ShowNotificationSuccess('Order de Trabajo de Aplicación');
        });

        request.fail(function () {
            //console.log(data.Response);
            ShowNotificationDanger('Orden de Trabajo de Aplicación', 'Los datos no se pueden guardar');           
        });
    }
}