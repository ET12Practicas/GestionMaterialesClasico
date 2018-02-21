var baseURL = window.location.protocol + "//" + window.location.host + "/"
var tablaPersonal;

$(document).ready(function () {
    $('#btn_crearPersonal').tooltip();

    var requestPersonal = $.ajax({
        url: baseURL + "/Personal/GetPersonal",
        type: 'GET',
        contentType: 'application/json; charset=utf-8'
    });

    requestPersonal.done(function (data) {
        //console.log(data.Response);
        //tablaPersonal = $('#tablePersonal').DataTable({
        //    "dom": 'lrtip',
        //    "aaData": data.Response,
        //    "aoColumnDefs": [{
        //        "targets": [0, 4],
        //        "visible": true,
        //        "sType": "html",
        //    }],
        //    "aoColumns": [
        //        {
        //            "data": "idPersonal"
        //        },
        //        {
        //            "data": "nombre"
        //        },
        //        {
        //            "data": "dni"
        //        },
        //        {
        //            "data": "fichaCensal"
        //        },
        //        {
        //            "data": "hab"
        //        }
        //    ],
        //    "language": {
        //        "decimal": "",
        //        "emptyTable": "No hay información disponible para mostrar",
        //        "info": " _TOTAL_",
        //        "infoEmpty": "No hay reservas para mostrar",
        //        "infoFiltered": "(filtrados de _MAX_ reservas totales)",
        //        "infoPostFix": "",
        //        "thousands": ",",
        //        "lengthMenu": "Ver _MENU_ reservas por página de ",
        //        "loadingRecords": "Cargando...",
        //        "processing": "En proceso...",
        //        "search": "Buscar",
        //        "zeroRecords": "No hay reservas que coincidan con el filtro",
        //        "paginate": {
        //            "first": "Primera",
        //            "last": "Última",
        //            "next": "Siguiente",
        //            "previous": "Anterior"
        //        }
        //    }
        //});
        tablaPersonal = $('#grdPersonal').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [0],
                "visible": false,
                "sType": "html",
                "aTargets": [4]
            }],
            "aoColumns": [
                {
                    "data": "idPersonal"
                },
                {
                    "data": "nombre"
                },
                {
                    "data": "dni"
                },
                {
                    "data": "fichaCensal"
                },
                {
                    "mRender": function (dato, type, row) {
                        //console.log(row);

                        var editarHtml = '<div title="Editar Personal" class="col-xs-offset-3 col-xs-4"><a href="/Personal/Editar/' + row.idPersonal + '"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></a></div>';

                        var borrarHtml = '<div title="Borrar Personal" class="col-xs-4"><a href="" data-toggle="modal" data-target="#myModal-' + row.idPersonal + '"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></a><div class="modal fade" id= "myModal-' + row.idPersonal + '" tabindex= "-1" role= "dialog" aria- labelledby="myModalLabel" >' +
                            '<div class="modal-dialog modal-sm" role="document">'+
                                    '<div class="modal-content">'+
                                        '<div class="modal-header"><h4 class="modal-title" id="myModalLabel">Borrar Personal</h4></div>'+
                                            '<div class="modal-body">' +
                                        '<p>¿Desea borrar la siguiente persona del sistema?</p>' +
                                            '<p><strong>Nombre y Apellido:</strong> ' + row.nombre + '</p>' +
                                            '<p><strong>Ficha Censal:</strong> ' + row.fichaCensal + '</p>' +
                                            '<p><strong>DNI:</strong> ' + row.dni + '</p>' +
                                            '</div>' +
                                        '<div class="modal-footer">' +
                                        '<a href="/Personal/Borrar/'+ row.idPersonal + '" type="button" class="btn btn-danger">Aceptar</a>' +
                                        '<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                        '</div></div></div></div></div>';
                        return editarHtml + borrarHtml;
                    }
                }
            ]
        });
    });

    requestPersonal.fail(function (data) {
        alert(data.Response);
    });
})
