var appName = location.pathname.split('/')[1]
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaMateriales;

$(document).ready(function () {

    if (window.location.href.split(':').length == 2)
        baseURL = baseURL + appName + "/";

    $('#divgrdMateriales').append('<table id="grdMateriales" class="table table-bordered table-striped table-hover"> <thead> <tr> <th></th> <th> Código </th> <th> Material </th> <th> Stock Actual </th> <th> Stock Mínimo </th> <th> Stock </th> <th> Opciones </th> </tr> </thead> </table>');

    jQuery.fn.dataTable.Api.register('processing()', function (show) {
        return this.iterator('table', function (ctx) {
            ctx.oApi._fnProcessingDisplay(ctx, show);
        });
    });


    loadMateriales();
});


function loadMateriales() {

    var requestFecha = $.ajax({
        url: baseURL + "Material/GetLastUpdated",
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var fecha = '';
            if (data.Response.length > 0) {
                var value = new Date(parseInt(data.Response[0].LAST_UPDATED_DATE.replace(/(^.*\()|([+-].*$)/g, '')));
                fecha = value.toLocaleString();
            }
            else {
                fecha = new Date().toLocaleString();
            }

            $('#lastUpdated').text('Última modificación ' + fecha);
        }
    });

    if (!$.fn.dataTable.isDataTable('#grdMateriales')) {
        tablaMateriales = $('#grdMateriales').DataTable({
            //"aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0],
                "visible": false,
                "sType": "html",
                "aTargets": [6, 7]
            }],
            "aoColumns": [
                {
                    "data": "idMaterial"
                },
                {
                    "sWidth": "7%",
                    "data": "codigo"
                },
                {
                    "sWidth": "20%",
                    "data": "nombre"
                },
                {
                    "sWidth": "10%",
                    "data": "stockActual"
                },
                {
                    "sWidth": "10%",
                    "data": "stockMinimo"
                },
                {
                    "sWidth": "7%",
                    "mRender": function (dato, type, row) {
                        if (row.stockActual == 0) {
                            return '<span class="badge bgc-red-50 c-red-700 p-10 lh-0 tt-c badge-pill">Sin stock</span>';
                        }
                        if (row.stockActual > row.stockMinimo) {
                            return '<span class="badge bgc-green-50 c-green-700 p-10 lh-0 tt-c badge-pill">Alto</span>';
                        }
                        else {
                            return '<span class="badge bgc-yellow-50 c-yellow-700 p-10 lh-0 tt-c badge-pill">Bajo</span>';
                        }
                    }
                },
                {
                    "sWidth": "10%",
                    "mRender": function (dato, type, row) {
                        var cab = '<div class="row">';

                        var head = '<div class="col-3">';

                        var verDetalleHtml =
                            '<a title="Detalle" href="#" id="matDet-' + row.idMaterial + '" onclick="getMaterialDetalle(this);"><i class="far fa-info-circle fa-2x"></i></a> ';

                        var historialHtml = '<a title="Historial" href="' + baseURL + 'Material/Historial/' + row.idMaterial + '"><i class="far fa-clock fa-2x"></i> </a> ';

                        var editarHtml = '<a title="Editar" href="' + baseURL + 'Material/Editar/' + row.idMaterial + '"><i class="far fa-edit fa-2x"></i></a> ';

                        var borrarHtml =
                            '<a title="Borrar" href="" data-toggle="modal" data-target="#myModal-' + row.idMaterial + '"><i class="far fa-trash-alt fa-2x"></i></a><div class="modal fade" id="myModal-' + row.idMaterial + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >' +
                            '<div class="modal-dialog modal-dialog-centered" role="document">' +
                            '<div class="modal-content">' +
                            '<div class="modal-header"><h4 class="modal-title" id="myModalLabel">Borrar Material</h4></div>' +
                            '<div class="modal-body">' +
                            '<p>¿Desea borrar el siguiente material del sistema?</p>' +
                            '<p><strong>Código:</strong> ' + row.codigo + '</p>' +
                            '<p> <strong>Material:</strong> ' + row.nombre + '</p > ' +
                            '<p> <strong>Stock Actual:</strong> ' + row.stockActual + '</p > ' +
                            '</div>' +
                            '<div class="modal-footer">' +
                            '<a href="' + baseURL + 'Material/Borrar/' + row.idMaterial + '" type="button" class="btn btn-danger">Aceptar</a>' +
                            '<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                            '</div></div></div></div></div>';
                        var cola = '</div>';

                        return cab + head + verDetalleHtml + cola + head + historialHtml + cola + head + editarHtml + cola + head + borrarHtml + cola;
                    }
                }
            ],
            "order": [2, "asc"],
            "processing": true
        });
    }

    tablaMateriales.processing(true);

    var requestMaterial = $.ajax({
        url: baseURL + "Material/GetAll",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    requestMaterial.done(function (data) {
        //console.log(data.Response);
        tablaMateriales.clear();
        tablaMateriales.rows.add(data.Response);
        tablaMateriales.draw();
        tablaMateriales.processing(false);
        
    });

    requestMaterial.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar el listado de materiales');
    });
}

function getMaterialDetalle(data) {

    var idMaterial = data.id.split('-')[1];

    var requestMaterial = $.ajax({
        url: baseURL + "Material/GetById",
        type: 'GET',
        data: { id: idMaterial },
        contentType: 'application/json; charset=utf-8',
    });

    requestMaterial.done(function (data) {
        //console.log(data.Response[0]);
        $('#matCodigo').html(data.Response[0].codigo);
        $('#matNombre').html(data.Response[0].nombre);
        $('#matTipo').html(data.Response[0].tipoMaterial);
        $('#matUnidad').html(data.Response[0].unidad);
        $('#matProveedor').html(data.Response[0].proveedor);

        $('#matStockActual').html(data.Response[0].stockActual);
        $('#matStockMinimo').html(data.Response[0].stockMinimo);
        $('#matDetalle').html(data.Response[0].detalle);

        var estado = '';

        if (parseInt(data.Response[0].stockActual) <= "0") {
            estado = 'SIN STOCK';
        }
        if (parseInt(data.Response[0].stockActual) > parseInt(data.Response[0].stockMinimo)) {
            estado = 'ALTO';
        }
        else {
            estado = 'BAJO';
        }

        $('#matStockEstado').html(estado);
        $('#modalDetalle').modal("show");
    });

    requestMaterial.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar el material');
    });
}