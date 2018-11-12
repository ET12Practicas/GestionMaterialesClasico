var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaMateriales;

if (window.location.href.split(':').length == 2)
    baseURL = baseURL + appName + "/";

$('#divgrdEgresos').append('<table id="grdEgresos" class="table table-bordered table-striped table-hover"> <thead> <tr> <th> Nro. Salida </th> <th> Cod. Material </th> <th> Material </th> <th> Cantidad </th> <th> Tipo de Salida </th> <th> Nro. Documento </th> <th> Usuario </th> <th> Fecha </th> </tr> </thead> </table>');

jQuery.fn.dataTable.Api.register('processing()', function (show) {
    return this.iterator('table', function (ctx) {
        ctx.oApi._fnProcessingDisplay(ctx, show);
    });
});

if (!$.fn.dataTable.isDataTable('#grdEgresos')) {
    tablaMateriales = $('#grdEgresos').DataTable({
        //"dom": "lfrtip",
        //"aaData": data.Response,
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
                "sWidth": "5%",
                "data": "codMaterial"
            },
            {
                "sWidth": "20%",
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
                "sWidth": "5%",
                "data": "codDocumento"
            },
            {
                "sWidth": "10%",
                "data": "usuario"
            },
            {
                "sWidth": "10%",
                "mRender": function (dato, type, row) {
                    var value = new Date(parseInt(row.timestamp.replace(/(^.*\()|([+-].*$)/g, '')));
                    return value.toLocaleString();
                }
            }
        ],
        "order": [0, "desc"],
        "processing": true
    });   
}

tablaMateriales.processing(true);

var request = $.ajax({
    url: baseURL + "Stock/GetHistorialEgresos",
    type: 'GET',
    contentType: 'application/json; charset=utf-8'
});

request.done(function (data) {
    tablaMateriales.clear();
    tablaMateriales.rows.add(data.Response);
    tablaMateriales.draw();
    tablaMateriales.processing(false);
});
    
request.fail(function (data) {
    alert('No se pueden cargar el historial de egresos');
    console.log(data.Response);
});

