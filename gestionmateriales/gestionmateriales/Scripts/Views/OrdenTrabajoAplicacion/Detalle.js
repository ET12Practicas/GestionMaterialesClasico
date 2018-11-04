var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {
    
    if (window.location.href.split(':').length == 2)
        baseURL = baseURL + appName + "/";
    
    var idOTA = $('#IdOTA').val();
    
    var request = $.ajax({
        url: baseURL + "OrdenTrabajoAplicacion/GetItemsOTA",
        type: 'GET',
        data: { id: idOTA },
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
                "aTargets": []
            }],
            "aoColumns": [
                {
                    "sWidth": "5%",
                    "data": "cant"
                },
                {
                    "sWidth": "10%",
                    "data": "codMat"
                },
                {
                    "sWidth": "60%",
                    "data": "mat"
                },
                {
                    "sWidth": "5%",
                    "data": "cantRet"
                }
                //{
                //    "sWidth": "5%",
                //    "mRender": function (data, type, row) {
                //        //console.log(row.fecha);
                //        if (row.fecha != '') {
                //            var value = new Date(parseInt(row.fecha.replace(/(^.*\()|([+-].*$)/g, '')));
                //            return value.toLocaleString().split(' ')[0];
                //        }
                //        return '';
                //    }
                //}
            ],
            "order": [1, "asc"]            
        });
    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar los items OTA');
    });
});
