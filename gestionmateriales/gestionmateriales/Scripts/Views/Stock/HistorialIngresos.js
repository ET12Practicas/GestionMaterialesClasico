var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var tablaMateriales;

$('#divgrdIngresos').append('<table id="grdIngresos" class="table table-bordered table-striped table-hover"> <thead> <tr> <th> Nro Entrada. </th> <th> Cod. Material </th> <th> Material </th> <th> Cantidad </th> <th> Tipo de Entrada </th> <th> Nro. Documento </th> <th> Usuario </th> <th> Fecha </th> </tr> </thead> </table>');

jQuery.fn.dataTable.Api.register('processing()', function (show) {
    return this.iterator('table', function (ctx) {
        ctx.oApi._fnProcessingDisplay(ctx, show);
    });
});

if (!$.fn.dataTable.isDataTable('#grdIngresos')) {
    tablaMateriales = $('#grdIngresos').DataTable({
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
                "data": "tipoEntrada"
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
                "mRender": function (data, type, row) {
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

var requestMaterial = $.ajax({
    url: baseURL + "Stock/GetHistorialIngresos",
    type: 'GET',
    contentType: 'application/json; charset=utf-8'
});

requestMaterial.done(function (data) {
    tablaMateriales.clear();
    tablaMateriales.rows.add(data.Response);
    tablaMateriales.draw();
    tablaMateriales.processing(false);   
});

requestMaterial.fail(function (data) {
    alert(data.Response);
});