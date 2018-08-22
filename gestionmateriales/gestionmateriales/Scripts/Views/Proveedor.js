var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaProveedores;

$(document).ready(function () {
    $('#btnCrearProveedor').tooltip();

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
        url: baseURL + "Proveedor/GetProveedores",
        type: 'GET',
        data: { desde: 0, hasta : 200 },
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
                    "sWidth": "15%",
                    "mRender": function (dato, type, row) {

                        var verDetalleHtml = 
                            '<button type="button" title="Detalle" class="btn btn-outline-dark" href="" id="matDet-' + row.idProveedor + '" onclick="getProveedorDetalle(this);"><i class="fas fa-eye"></i></button> ';

                        var editarHtml = '<a title="Editar" class="btn btn-outline-dark" href="' + baseURL + 'Proveedor/Editar/' + row.idProveedor + '"><i class="fas fa-pencil-alt"></i> </a></div> ';

                        var borrarHtml = 
                            '<a title="Borrar" class="btn btn-outline-dark" href="" data-toggle="modal" data-target="#myModal-' + row.idProveedor + '"><i class="fas fa-trash-alt"></i> </a><div class="modal fade" id="myModal-' + row.idProveedor + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >' +
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
                        return verDetalleHtml + editarHtml + borrarHtml;
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
        alert(data.Response);
    });
})

function getProveedorDetalle(data) {

    var id = data.id.split('-')[1];

    var requestProveedor = $.ajax({
        url: baseURL + "Proveedor/GetProveedor",
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