var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";


$(document).ready(function () {

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";

    var request = $.ajax({
        url: baseURL + "OrdenCompra/GetMateriales",
        type: 'GET',
        data: { id: $('#IdOc').val() },
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        tablaMateriales = $ ('#grdMateriales').DataTable({
            "aaData" : data.Response,
            "aoColumnDefs": [{
                "targets": [0, 1],
                "visible": false,
                "sType": "html",
                "aTargets": [3,4,6]
            }],
            "aoColumns": [
                {
                    "data" : "idOC"
                },
                {
                    "data" : "idMat"
                },
                {
                    "sWidth": "10%",
                    "data" : "codMat"
                },
                {
                    "sWidth": "50%",
                    "data" : "nomMat"
                },
                {
                    "sWidth": "10%",
                    "data" : "Cantidad",
                    "mRender": function (dato, type, raw) {
                        var editarCant = '<input id="iCant-' + raw.idOC + '-' + raw.idMat + '" type="number" min="0" class="form-control" />';
                        return editarCant;
                    }
                },
                {
                    "data" : "PrecioUnitario",
                    "mRender": function (dato, type, raw) {
                        var editarCant = '<input id="iPre-' + raw.idOC + '-' + raw.idMat + '" type="text" class="form-control" />';
                        return editarCant;
                    }

                },
                {
                    "data" : "SubTotal",   
                    "mRender" : function (dato, type, raw){
                        return '';
                    }
                },
                {
                    "sWidth": "10%",
                    "mRender": function (dato, type, raw) {

                        var btnAddItemOTA = '<button type="button" title="Detalle" class="btn btn-outline-primary btn-sm" href="" id="bCant-' + raw.idOT + '-' + raw.idMat + 
                            '" onclick="addItemOTA(this);"><i class="fas fa-plus"></i> Agregar</button> ';
                        return btnAddItemOTA;
                    }
                }],
            "order": [3, "asc"]
            });
    });                  
});