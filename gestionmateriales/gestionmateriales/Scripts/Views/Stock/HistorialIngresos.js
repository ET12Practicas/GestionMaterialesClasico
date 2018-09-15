﻿var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

if (appName == 'ottest')
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
                "data": "tipoEntrada"
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
                "mRender": function (data, type, row) {
                    var value = new Date(parseInt(row.timestamp.replace(/(^.*\()|([+-].*$)/g, '')));
                    return value.toLocaleString().split(' ')[0];
                }
            }
        ],
        "order": [7, "desc"]
    });
});

requestMaterial.fail(function (data) {
    alert(data.Response);
});