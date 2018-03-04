var baseURL = window.location.protocol + "//" + window.location.host + "/"
var tablaProveedores;

$(document).ready(function () {
    $('#btnCrearProveedor').tooltip();

    var request = $.ajax({
        url: baseURL + "Proveedor/GetProveedores",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        tablaProveedores = $('#grdProveedores').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0, 9, 10],
                "visible": false,
                "sType": "html",
                "aTargets": [8]
            }],
            "aoColumns": [
                {
                    "data": "idProveedor"
                },
                {
                    "data": "nombre"
                },
                {
                    "data": "cuit"
                },
                {
                    "data": "razonSocial"
                },
                {
                    "data": "zona"
                },
                {
                    "data": "direccion"
                },
                {
                    "data": "telefono"
                },
                {
                    "data": "email"
                },
                {
                    "mRender": function (dato, type, row) {
                        //console.log(row);

                        var verDetalleHtml = '<div class="row"><div title="Ver Detalle" class="col-2 offset-1>' +
                            '<a href="" data-toggle="modal" data-target="#myModal-ver-' + row.idProveedor + '"><i class="fas fa-eye"></i></a>' +
                            '<div class="modal fade" id="myModal-ver-' + row.idProveedor + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">' +
                            '<div class="modal-dialog modal-dialog-centered" role="document">' +
                            '<div class="modal-content">' +
                            '<div class="modal-header">' +
                            '<h4 class="modal-title" id="myModalLabel">Proveedor</h4>' +
                            '</div>' +
                            '<div class="modal-body">' +
                            '<div class="row">' +
                            '<div class="col-md-6">' +
                            '<p><strong>Proveedor:</strong> ' + row.nombre + '</p>' +
                            '<p><strong>Razón Social:</strong> ' + row.razonSocial + '</p>' +
                            '<p><strong>CUIT:</strong> ' + row.cuit + '</p>' +
                            '</div>' +
                            '<div class="col-md-6 ml-auto">' +
                            '<p><strong>Teléfono:</strong> ' + row.telefono + '</p>' +
                            '<p><strong>Correo:</strong> ' + row.email + '</p > ' +
                            '<p><strong>Dirección:</strong> ' + row.direccion + '</p > ' +
                            '<p><strong>Zona:</strong> ' + row.zona + '</p > ' +
                            '<p><strong>Horario:</strong> ' + row.horario + '</p > ' +
                            '<p><strong>Contacto:</strong> ' + row.nombreContacto + '</p > ' +
                            '</div>' +
                            '</div>' +
                            '<br />' +
                            '</div>' +
                            '<div class="modal-footer">' +
                            '<button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>' +
                            '</div></div></div></div></div>';

                        var editarHtml = '<div title="Editar" class="offset-1"><a href="/Proveedor/Editar/' + row.idProveedor + '"><i class="fas fa-pencil-alt"></i></a></div>';

                        var borrarHtml = '<div title="Borrar" class="offset-1">' +
                            '<a href="" data-toggle="modal" data-target="#myModal-' + row.idProveedor + '"><i class="fas fa-trash-alt"></i></a><div class="modal fade" id="myModal-' + row.idProveedor + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >' +
                            '<div class="modal-dialog modal-dialog-centered" role="document">' +
                            '<div class="modal-content">' +
                            '<div class="modal-header"><h4 class="modal-title" id="myModalLabel">Borrar Proveedor</h4></div>' +
                            '<div class="modal-body">' +
                            '<p>¿Desea borrar el siguiente proveedor del sistema?</p>' +
                            '<p><strong>Proveedor:</strong> ' + row.nombre + '</p>' +
                            '<p> <strong>Razón Social:</strong> ' + row.razonSocial + '</p > ' +
                            '<p> <strong>CUIT:</strong> ' + row.cuit + '</p > ' +
                            '<p> <strong>Teléfono:</strong> ' + row.telefono + '</p > ' +
                            '<p> <strong>Dirección:</strong> ' + row.direccion + '</p > ' +
                            '</div>' +
                            '<div class="modal-footer">' +
                            '<a href="/Proveedor/Borrar/' + row.idProveedor + '" type="button" class="btn btn-danger">Aceptar</a>' +
                            '<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                            '</div></div></div></div></div></div>';
                        return verDetalleHtml + editarHtml + borrarHtml;
                    }
                },
                {
                    "data": "horario"
                },
                {
                    "data": "nombreContacto"
                }],
            "language": {
                "decimal": "",
                "emptyTable": "No hay información disponible para mostrar",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                "infoEmpty": "No hay proveedores para mostrar",
                "infoFiltered": "(filtrados de _MAX_ proveedores totales)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Ver _MENU_ proveedores por página",
                "loadingRecords": "Cargando...",
                "processing": "En proceso...",
                "search": "Buscar",
                "zeroRecords": "No hay proveedores que coincidan con el filtro",
                "paginate": {
                    "first": "Primera",
                    "last": "Última",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            }
        });
    });

    request.fail(function (data) {
        alert(data.Response);
    });
})