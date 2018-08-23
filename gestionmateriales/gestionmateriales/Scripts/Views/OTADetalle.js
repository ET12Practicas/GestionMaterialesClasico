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
            "autoWidth": false,
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
            "order": [1, "asc"],
            "searching": false,
            "info": false,
            "paging": false,
            "language": {
                "decimal": "",
                "emptyTable": "No hay información disponible para mostrar",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                "infoEmpty": "No hay entradas para mostrar",
                "infoFiltered": "(filtrados de _MAX_ materiales totales)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Ver _MENU_ entradas por página",
                "loadingRecords": "Cargando...",
                "processing": "En proceso...",
                "search": "Buscar",
                "zeroRecords": "No hay entradas que coincidan con el filtro",
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
        console.log(data.Response);
        alert('No se pueden cargar los items OTA');
    });
});


//var doc = new jsPDF();

//var specialElementHandlers = {
//    '#editor': function (element, renderer) {
//        return true;
//    },
//    '.controls': function (element, renderer) {
//        return true;
//    }
//};


//$('#cmd').click(function () {
//    doc.fromHTML($('#content').get(0), 15, 15, {
//        'width': 170,
//        'elementHandlers': specialElementHandlers
//    });
//    doc.save('sample-file.pdf');
//});