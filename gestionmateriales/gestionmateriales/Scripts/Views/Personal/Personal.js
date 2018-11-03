var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaPersonal;

$(document).ready(function () {
    
    if (location.pathname.split('/').length > 2)
        baseURL = baseURL + appName + "/";
    
    var requestFecha = $.ajax({
        url: baseURL + "Personal/GetLastUpdated",
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

    var requestPersonal = $.ajax({
        url: baseURL + "Personal/GetAll",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    requestPersonal.done(function (data) {
        tablaPersonal = $('#grdPersonal').DataTable({
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0],
                "visible": false,
                "sType": "html",
                "aTargets": [4]
            }],
            "aoColumns": [
                {
                    "data": "idPersonal"
                },
                {
                    "data": "nombre"
                },
                {
                    "sWidth": "20%",
                    "data": "dni"
                },
                {
                    "sWidth": "20%",
                    "data": "fichaCensal"
                },
                {
                    "sWidth": "10%",
                    "mRender": function (dato, type, row) {
                        var ini = '<div class="row">';

                        var cab = '<div class="col-6">';

                        var editarHtml = '<a title="Editar" href="' + baseURL + 'Personal/Editar/' + row.idPersonal + '"><i class="far fa-edit fa-2x"></i> </a> ';

                        var borrarHtml = '<a title="Borrar" href="" data-toggle="modal" data-target="#myModal-' + row.idPersonal + '"><i class="far fa-trash-alt fa-2x"></i> </a><div class="modal fade" id= "myModal-' + row.idPersonal + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >' +
                            '<div class="modal-dialog modal-dialog-centered" role="document">' +
                            '<div class="modal-content">' +
                            '<div class="modal-header"><h4 class="modal-title" id="myModalLabel">Borrar Personal</h4></div>' +
                            '<div class="modal-body">' +
                            '<p>¿Desea borrar la siguiente persona del sistema?</p>' +
                            '<p><strong>Nombre y Apellido:</strong> ' + row.nombre + '</p>' +
                            '<p><strong>Ficha Censal:</strong> ' + row.fichaCensal + '</p>' +
                            '<p><strong>DNI:</strong> ' + row.dni + '</p>' +
                            '</div>' +
                            '<div class="modal-footer">' +
                            '<a href="' + baseURL + 'Personal/Borrar/' + row.idPersonal + '" type="button" class="btn btn-danger">Aceptar</a>' +
                            '<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                            '</div></div></div></div></div>';

                        var end = '</div>';

                        return ini + cab + editarHtml + end + cab + borrarHtml + end + end;
                    }
                }],
        });
    });

    requestPersonal.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar el listado de personal');
    });
});
