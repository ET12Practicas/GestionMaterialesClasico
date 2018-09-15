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
    tablaMateriales = $('#grdEgresos').DataTable({
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
                "sWidth": "12%",
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
        "order": [7, "desc"]       
    });   
});
    
request.fail(function (data) {
    alert('No se pueden cargar el historial de egresos');
    console.log(data.Response);
});

