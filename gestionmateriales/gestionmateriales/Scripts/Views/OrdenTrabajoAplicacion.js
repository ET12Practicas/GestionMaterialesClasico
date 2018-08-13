var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";

    var request = $.ajax({
        url: baseURL + "OrdenTrabajoAplicacion/GetOTA",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        tablaMateriales = $('#grdOTA').DataTable({
            //"dom": "lfrtip",
            "autoWidth": false,
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
                        var editar = '<a title="Editar" class="btn btn-outline-dark btn-sm" href="' + baseURL + 'OrdenTrabajoAplicacion/Editar/' + row.id + '"><i class="fas fa-pencil-alt"></i> </a> ';
                        return editar;
                    }
                }                
            ],
            "order": [2, "asc"],
            "language": {
                "decimal": "",
                "emptyTable": "No hay información disponible para mostrar",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                "infoEmpty": "No hay entradas para mostrar",
                "infoFiltered": "(filtrados de _MAX_ materiales totales)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Ver _MENU_ entradas por página",
                "loadingRecords": "Cargando...",
                "processing": "En proceso...",
                "search": "Buscar",
                "zeroRecords": "No hay entradas que coincidan con el filtro",
                "paginate": {
                    "first": "Primera",
                    "last": "Última",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            }
        });
    });
});
