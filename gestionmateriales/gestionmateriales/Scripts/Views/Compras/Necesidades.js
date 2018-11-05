var fecha = new Date();
var timestamp = fecha.getDate() + "-" + fecha.getMonth() + "-" + fecha.getFullYear() + " " + fecha.getHours() + "." + fecha.getMinutes();
var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaCompras;

$(document).ready(function () {

    if (window.location.href.split(':').length == 2)
        baseURL = baseURL + appName + "/";

    $('#divgrdCompras').append('<table id="grdCompras" class="table table-bordered table-striped table-hover"> <thead> <tr> <th> Código </th> <th> Material </th> <th> Stock Actual </th> <th> Stock Mínimo </th> <th> Stock </th> <th> Proveedor </th> </tr> </thead> </table>');

    jQuery.fn.dataTable.Api.register('processing()', function (show) {
        return this.iterator('table', function (ctx) {
            ctx.oApi._fnProcessingDisplay(ctx, show);
        });
    });

    if (!$.fn.dataTable.isDataTable('#grdCompras')) {
        tablaCompras = $('#grdCompras').DataTable({
            //"dom": 'Bflrtip',
            "autoWidth": false,
            //"aaData": data.Response,
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
                        return '<span class="badge bgc-red-50 c-red-700 p-10 lh-0 tt-c badge-pill">Sin Stock</span>';
                    }
                    if (row.stockActual > row.stockMinimo) {
                        return '<span class="badge bgc-green-50 c-green-700 p-10 lh-0 tt-c badge-pill">Alto</span>';
                    }
                    else {
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
            "processing": true
        });
    }

    tablaCompras.processing(true);

    var request = $.ajax({
        url: baseURL + "Compras/GetCompras",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        tablaCompras.clear();
        tablaCompras.rows.add(data.Response);
        tablaCompras.draw();
        tablaCompras.processing(false);
        
    });

    request.fail(function (data) {
        alert(data.Response);
    });
});