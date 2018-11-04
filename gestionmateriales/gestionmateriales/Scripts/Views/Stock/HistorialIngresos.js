var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

if (window.location.href.split(':').length == 2)
    baseURL = baseURL + appName + "/";

var requestMaterial = $.ajax({
    url: baseURL + "Stock/GetHistorialIngresos",
    type: 'GET',
    contentType: 'application/json; charset=utf-8'
});

requestMaterial.done(function (data) {
    //console.log(data.Response);
    tablaMateriales = $('#grdIngresos').DataTable({
        //"dom": "lfrtip",
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
        "order": [7, "desc"]
    });
});

requestMaterial.fail(function (data) {
    alert(data.Response);
});