var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {

    if (location.pathname.split('/').length > 2)
        baseURL = baseURL + appName + "/";

    var requestFecha = $.ajax({
        url: baseURL + "OrdenTrabajoAplicacion/GetLastUpdated",
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

    var request = $.ajax({
        url: baseURL + "OrdenTrabajoAplicacion/GetAll",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        tablaMateriales = $('#grdOTA').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0],
                "visible": false,
                "sType": "html",
                "aTargets": [2, 9]
            }],
            "aoColumns": [
                {
                    "data": "id"
                },
                {
                    "sWidth": "5%",
                    "data": "num"
                },
                {
                    "sWidth": "5%",
                    "mRender": function (data, type, row) {
                        var value = new Date(parseInt(row.fecha.replace(/(^.*\()|([+-].*$)/g, '')));
                        return value.toLocaleString().split(' ')[0];
                    }
                },
                {
                    "sWidth": "5%",
                    "data": "turno"
                },
                {
                    "sWidth": "40%",
                    "data": "nombre"
                },
                {
                    "sWidth": "15%",
                    "data": "res"
                },
                {
                    "sWidth": "15%",
                    "data": "jds"
                },
                {
                    "sWidth": "5%",
                    "data": "cant"
                },
                {
                    "sWidth": "10%",
                    "mRender": function (dato, type, row) {

                        var ini = '<div class="row">';

                        var cab = '<div class="col-6">';

                        var editar = '<a title="Editar" href="' + baseURL + 'OrdenTrabajoAplicacion/Editar/' + row.id + '"><i class="far fa-edit fa-2x"></i> </a> ';

                        var detalle = '<a title="Ver Detalle" href="' + baseURL + 'OrdenTrabajoAplicacion/Detalle/' + row.id + '"><i class="far fa-info-circle fa-2x"></i> </a> ';

                        var end = '</div>';

                        return ini + cab + detalle + end + cab + editar + end + end;
                    }
                }                
            ],
            "order": [1, "desc"]
        });
    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar el listado de orden de trabajo de aplicación');
    });
});
