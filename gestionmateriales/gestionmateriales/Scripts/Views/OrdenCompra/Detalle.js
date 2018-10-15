var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";

$(document).ready(function () {

    if (appName == 'ottest')
        baseURL = baseURL + appName + "/";

    var request = $.ajax({
        url: baseURL + "OrdenCompra/Get_Detalle_ItemsOrdenCompra",
        type: 'GET',
        data: { id: $('#IdOC').val() },
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        //console.log(data.Response);
        tablaMateriales = $('#grdItemsOC').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [],
                "visible": false,
                "sType": "html",
                "aTargets": [3,4]
            }],
            "aoColumns": [
                {
                    "sWidth": "10%",
                    "data": "codigo"
                },
                {
                    "sWidth": "50%",
                    "data": "material"
                },
                {
                    "sWidth": "10%",
                    "data": "cantidad"
                },
                {
                    "sWidth": "10%",
                    "data": "precioUnitario",
                    "mRender": function (dato, type, raw) {                        
                        return '$ ' + raw.precioUnitario;
                    }
                },
                {
                    "sWidth": "10%",
                    "data": "subtotal",
                    "mRender": function (dato, type, raw) {
                        return '$ ' + raw.subtotal;
                    }
                }
            ],
            "order": [1, "asc"]
        });
    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar los items OC');
    });
});
