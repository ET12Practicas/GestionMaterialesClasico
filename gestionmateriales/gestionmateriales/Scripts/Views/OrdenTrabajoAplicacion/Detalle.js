var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";

    var request = $.ajax({
        url: baseURL + "OrdenTrabajoAplicacion/GetItemsOTA",
        type: 'GET',
        data: { id: $('#IdOTA').val() },
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        tablaMateriales = $('#grdItemsOTA').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [],
                "visible": false,
                "sType": "html",
                "aTargets": [2]
            }],
            "aoColumns": [
                {
                    "sWidth": "5%",
                    "data": "cant"
                },
                {
                    "sWidth": "60%",
                    "data": "mat"
                },
                {
                    "sWidth": "5%",
                    "data": "cantRet"
                },
                {
                    "sWidth": "5%",
                    "mRender": function (data, type, row) {
                        //console.log(row.fecha);
                        if (row.fecha != '') {
                            var value = new Date(parseInt(row.fecha.replace(/(^.*\()|([+-].*$)/g, '')));
                            return value.toLocaleString().split(' ')[0];
                        }
                        return '';
                    }
                }
            ],
            "order": [1, "asc"]            
        });
    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar los items OTA');
    });
});
