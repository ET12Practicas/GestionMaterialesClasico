var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

if (appName == 'ottest')
    baseURL = baseURL + appName + "/";

var request = $.ajax({
    url: baseURL + "Stock/GetHistorialEgresos",
    type: 'GET',
    contentType: 'application/json; charset=utf-8'
});

request.done(function (data) {
    //console.log(data.Response);
    tablaMateriales = $('#grdEgresos').DataTable({
        //"dom": "lfrtip",
        "autoWidth": false,
        "aaData": data.Response,
        "aoColumnDefs": [{
            "sType": "html",
            "aTargets": [7]
        }],
        "aoColumns": [
            {
                "sWidth": "5%",
                "data": "numero"
            },
            {
                "sWidth": "12%",
                "data": "codMaterial"
            },
            {
                "sWidth": "33%",
                "data": "material"
            },
            {
                "sWidth": "5%",
                "data": "cantidad"
            },
            {
                "sWidth": "15%",
                "data": "tipoSalida"
            },
            {
                "sWidth": "15%",
                "data": "codDocumento"
            },
            {
                "sWidth": "10%",
                "data": "usuario"
            },
            {
                "sWidth": "5%",
                "mRender": function (dato, type, row) {
                    var value = new Date(parseInt(row.timestamp.replace(/(^.*\()|([+-].*$)/g, '')));
                    //return value.toLocaleString().split(' ')[0];
                    return value.toLocaleString();
                }
            }
        ],
        "order": [7, "desc"],
        "language": {
            "decimal": "",
            "emptyTable": "No hay información disponible para mostrar",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
            "infoEmpty": "No hay Egresos para mostrar",
            "infoFiltered": "(filtrados de _MAX_ Egresos totales)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "_MENU_",
            "loadingRecords": "Cargando...",
            "processing": "En proceso...",
            "search": "Buscar",
            "zeroRecords": "No hay Egresos que coincidan con el filtro",
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
    alert('No se pueden cargar el historial de egresos');
    console.log(data.Response);
});