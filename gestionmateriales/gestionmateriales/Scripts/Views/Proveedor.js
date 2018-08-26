var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaProveedores;

$(document).ready(function () {
    //$('#btnCrearProveedor').tooltip();

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";


    var requestFecha = $.ajax({
        url: baseURL + "Proveedor/GetLastUpdated",
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var value = new Date(parseInt(data.Response[0].LAST_UPDATED_DATE.replace(/(^.*\()|([+-].*$)/g, '')));
            var fecha = value.toLocaleString();//.split(' ')[0];
            //console.log(fecha);
            $('#lastUpdated').text('Última modificación ' + fecha);
        }
    });

    var request = $.ajax({
        url: baseURL + "Proveedor/GetAll",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        tablaProveedores = $('#grdProveedores').DataTable({
            //"dom": "lfrtip",
            "autoWidth": false,
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0],
                "visible": false,
                "sType": "html",
                "aTargets": [5]
            }],
            "aoColumns": [
                {
                    "data": "idProveedor"
                },
                {
                    "sWidth": "25%",
                    "data": "nombre"
                },
                {
                    "sWidth": "10%",
                    "data": "cuit"
                },
                {
                    "sWidth": "10%",
                    "data": "telefono"
                },
                {
                    "sWidth": "20%",
                    "data": "email"
                },
                {
                    "sWidth": "10%",
                    "mRender": function (dato, type, row) {

                        var ini = '<div class="row">';

                        var cab = '<div class="col-4">';

                        var verDetalleHtml =
                            '<a title="Detalle" href="#" id="matDet-' + row.idProveedor + '" onclick="getProveedorDetalle(this);"><i class="fal fa-eye fa-2x"></i></a>';

                        var editarHtml = '<a title="Editar" href="' + baseURL + 'Proveedor/Editar/' + row.idProveedor + '"><i class="fal fa-pencil-alt fa-2x"></i> </a>';

                        var borrarHtml =
                            '<a title="Borrar" href="" data-toggle="modal" data-target="#myModal-' + row.idProveedor + '"><i class="fal fa-trash-alt fa-2x"></i> </a><div class="modal fade" id="myModal-' + row.idProveedor + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >' +
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
                            '<a href="' + baseURL + 'Proveedor/Borrar/' + row.idProveedor + '" type="button" class="btn btn-danger">Aceptar</a>' +
                            '<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                            '</div></div></div></div></div></div>';

                        var end = '</div>';
                        return ini + cab + verDetalleHtml + end + cab + editarHtml + end + cab + borrarHtml + end + end;
                    }
                }],
            "order": [1, "asc"],
            "language": {
                "decimal": "",
                "emptyTable": "No hay información disponible para mostrar",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                "infoEmpty": "No hay proveedores para mostrar",
                "infoFiltered": "(filtrados de _MAX_ proveedores totales)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "_MENU_",
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
        console.log(data.Response);
        alert('No se pueden cargar el listado de proveedores');
    });
});

function getProveedorDetalle(data) {

    var id = data.id.split('-')[1];

    var requestProveedor = $.ajax({
        url: baseURL + "Proveedor/GetById",
        type: 'GET',
        data: { idProveedor: id },
        contentType: 'application/json; charset=utf-8',
        failure: function () {
            alert('No se puede traer el detalle del material o harramienta.');
        }
    });

    requestProveedor.done(function (data) {
        $('#proNombre').html(data.Response[0].nombre);
        $('#proRazonSocial').html(data.Response[0].razonSocial);
        $('#proCuit').html(data.Response[0].cuit);
        $('#proTelefono').html(data.Response[0].telefono);
        $('#proCorreo').html(data.Response[0].correo);

        $('#proDireccion').html(data.Response[0].direccion);
        $('#proZona').html(data.Response[0].zona);
        $('#proHorario').html(data.Response[0].horario);
        $('#proContacto').html(data.Response[0].contacto);

        $('#modalDetalle').modal("show");
    });
}