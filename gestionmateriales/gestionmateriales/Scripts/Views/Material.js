var appName = location.pathname.split('/')[1]
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaMateriales;

$(document).ready(function () {
    loadMateriales(0, 200);
})


function loadMateriales(from, end) {
    $('#btn_agregarmaterial').tooltip();

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";

    var requestMaterial = $.ajax({
        url: baseURL + "Material/GetMateriales",
        type: 'GET',
        data: { desde: from, hasta: end },
        contentType: 'application/json; charset=utf-8'
    });

    requestMaterial.done(function (data) {
        //console.log(data.Response);
        tablaMateriales = $('#grdMateriales').DataTable({
            //"dom": "lfrtip",
            "autoWidth": false,
            "aaData": data.Response,
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
                            return 'SIN STOCK';
                        }
                        if (row.stockActual > row.stockMinimo) {
                            return 'ALTO';
                        }
                        else {
                            return 'BAJO';
                        }
                    }
                },
                {
                    "sWidth": "14%",
                    "mRender": function (dato, type, row) {

                      

                        var verDetalleHtml =
                            '<button type="button" title="Detalle" class="btn btn-outline-dark" href="" id="matDet-' + row.idMaterial + '" onclick="getMaterialDetalle(this);"><i class="fas fa-eye"></i></button> ';
                                //'<a title="Ver Detalle" class="btn btn-outline-dark" href="" data-toggle="modal" data-target="#myModal-ver-' + row.idMaterial + '"><i class="fas fa-eye"></i> </a>' +
                                //'<div class="modal fade" id="myModal-ver-' + row.idMaterial + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">' +
                                //'<div class="modal-dialog modal-dialog-centered" role="document">' +
                                //'<div class="modal-content">' +
                                //'<div class="modal-header">' +
                                //'<h4 class="modal-title" id="myModalLabel">Material</h4>' +
                                //'</div>' +
                                //'<div class="modal-body">' +
                                //'<div class="row">' +
                                //'<div class="col-md-6">' +
                                //'<p><strong>Código:</strong> ' + row.codigo + '</p>' +
                                //'<p><strong>Material:</strong> ' + row.nombre + '</p>' +
                                //'<p><strong>Tipo:</strong> ' + row.tipoMaterial + '</p>' +
                                //'<p><strong>Unidad:</strong> ' + row.unidad + '</p>' +
                                //'<p><strong>Proveedor:</strong> ' + row.proveedor + '</p>' +
                                //'</div>' +
                                //'<div class="col-md-6 ml-auto">' +
                                //'<p><strong>Stock Actual:</strong> ' + row.stockActual + '</p>' +
                                //'<p><strong>Stock Mínimo:</strong> ' + row.stockMinimo + '</p > ' +
                                //'<p><strong>Estado del Stock:</strong> ' + row.estado + '</p > ' +
                                //'<p><strong>Detalle:</strong> ' + row.detalle + '</p > ' +
                                //'</div>' +
                                //'</div>' +
                                //'<br />' +
                                //'</div>' +
                                //'<div class="modal-footer">' +
                                //'<button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>' +
                                //'</div></div></div></div></div> ';

                            var historialHtml = '<a title="Ver Historial" class="btn btn-outline-dark" href="' + baseURL + 'Material/Historial/' + row.idMaterial + '"><i class="far fa-clock"></i> </a> ';

                            var editarHtml = '<a title="Editar" class="btn btn-outline-dark" href="' + baseURL + 'Material/Editar/' + row.idMaterial + '"><i class="fas fa-pencil-alt"></i> </a> ';

                            var borrarHtml =
                                '<a title="Borrar" class="btn btn-outline-dark" href="" data-toggle="modal" data-target="#myModal-' + row.idMaterial + '"><i class="fas fa-trash-alt"></i></a><div class="modal fade" id="myModal-' + row.idMaterial + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >' +
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
                            return verDetalleHtml + historialHtml + editarHtml + borrarHtml;
                    }
                },
            ],
            "order": [2, "asc"],
            "language": {
                "decimal": "",
                "emptyTable": "No hay información disponible para mostrar",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                "infoEmpty": "No hay materiales para mostrar",
                "infoFiltered": "(filtrados de _MAX_ materiales totales)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Ver _MENU_ materiales por página",
                "loadingRecords": "Cargando...",
                "processing": "En proceso...",
                "search": "Buscar",
                "zeroRecords": "No hay materiales que coincidan con el filtro",
                "paginate": {
                    "first": "Primera",
                    "last": "Última",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            }
        });
    });

    requestMaterial.fail(function (data) {
        alert(data.Response);
    });
}

//$('button[id^=matDet]').click(function () {
function getMaterialDetalle(data) {

    var id = data.id.split('-')[1];

    var requestMaterial = $.ajax({
        url: baseURL + "Material/GetMaterial",
        type: 'GET',
        data: { idMaterial: id },
        contentType: 'application/json; charset=utf-8',
        failure: function () {
            alert('No se puede traer el detalle del material o harramienta.');
        }
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
            estado ='SIN STOCK';
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
}