var fecha = new Date();
var timestamp = fecha.getDate() + "-" + fecha.getMonth() + "-" + fecha.getFullYear() + " " + fecha.getHours() + "." + fecha.getMinutes();
var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

if (appName == 'ottest')
    baseURL = baseURL + appName + "/";

//console.log(appName);
$(document).ready(function () {
    var request = $.ajax({
        url: baseURL + "Compras/GetCompras",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        $('#grdCompras').DataTable({
            //"dom": 'Bflrtip',
            "autoWidth": false,
            "aaData": data.Response,
            "aoColumnDefs": [{
                "aTargets": [4]
            }],
            "aoColumns": [{
                "data": "codigo"
            },
            {
                "data": "nombre"
            },
            {
                "data": "stockActual"
            },
            {
                "data": "stockMinimo"
            },
            {
                "mRender": function (dato, type, row) {
                    if (row.stockActual == 0) {
                        //return 'SIN STOCK';
                        //return '<span class="badge badge-danger">Sin Stock</span>';
                        return '<span class="badge bgc-red-50 c-red-700 p-10 lh-0 tt-c badge-pill">Sin stock</span>';
                    }
                    if (row.stockActual > row.stockMinimo) {
                        //return 'ALTO';
                        //return '<span class="badge badge-success">Alto</span>';
                        return '<span class="badge bgc-green-50 c-green-700 p-10 lh-0 tt-c badge-pill">Alto</span>';
                    }
                    else {
                        //return 'BAJO';
                        //return '<span class="badge badge-warning">Bajo</span>';
                        return '<span class="badge bgc-yellow-50 c-yellow-700 p-10 lh-0 tt-c badge-pill">Bajo</span>';
                    }
                }
            },
            {
                "data": "proveedor"
            }],
            "buttons": [
                {
                    extend: 'pdf',
                    text: 'Exportar a PDF',
                    filename: 'listadoCompras-' + timestamp
                },
                {
                    extend: 'excel',
                    text: 'Exportar a Excel',
                    filename: 'listadoCompras-' + timestamp
                }
            ],
            "language": {
                "decimal": "",
                "emptyTable": "No hay información disponible para mostrar",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                "infoEmpty": "No hay compras para mostrar",
                "infoFiltered": "(filtrados de _MAX_ compras totales)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "_MENU_",
                "loadingRecords": "Cargando...",
                "processing": "En proceso...",
                "search": "Buscar",
                "zeroRecords": "No hay compras que coincidan con el filtro",
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
});