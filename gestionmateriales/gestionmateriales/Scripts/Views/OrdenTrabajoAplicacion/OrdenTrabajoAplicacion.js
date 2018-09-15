var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";

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
            "order": [2, "asc"]
        });
    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar el listado de orden de trabajo de aplicación');
    });
});
