var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var itemsOTA;

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
        itemsOTA = data.Response;
        tablaMateriales = $('#grdItemsOTA').DataTable({
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
                    "data": "nroItem"
                },
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
                }
            ],
            "order": [0, "asc"],
            "paging": false,
            "filter": false,
            "info": false
        });
    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar los items OTA');
    });
});

function descargarOrdenTrabajoAplicacion() {

    var columns = [
        { title: "N°", dataKey: "nroItem" },
        { title: "Cantidad", dataKey: "cant" },
        { title: "Descripción", dataKey: "mat" }
    ];

    var nombreInstiticion = 'Escuela Técnica N°12 DE 1 "Libertador General Jose de San Martin"';
    var nombreDocumento = 'ORDEN DE TRABAJO DE APLICACION';
    var logo = baseURL + 'Assets/logodoc.png';
    var margenDerecho = 15;

    var doc = new jsPDF();
    
    doc.setFont('times', 'normal');
    //doc.setFontType('normal');

    //nombre institucion
    doc.setFontSize(10);
    doc.text(46, 20, nombreInstiticion);

    //logo
    doc.addImage(logo, 'png', 17, 17, 26, 26);

    //nombre documento
    doc.setFontType('bold');
    doc.setFontSize(16);
    doc.text(52, 42, nombreDocumento);

    //leyenda oficina tecnica
    doc.setFontType('bolditalic');
    doc.setFontSize(8);

    //numero orden de compra
    doc.setFontSize(12);
    doc.text(172, 42, 'N° ');
    doc.setFontSize(30);
    doc.text(178, 42, numero.toString());


    doc.setFontType('bold');
    doc.setFontSize(16);
    doc.text(margenDerecho, 62, nombre);
    doc.text(156, 62, 'Turno: ' + turno);
    
    doc.setFontType('normal');
    doc.setFontSize(12);
    doc.text('Responsable: ', margenDerecho, 72);
    doc.text('Jefe de Sección: ', 110, 72);

    doc.setFontType('bold');
    doc.setFontSize(14);
    doc.text(responsable, 40, 72);
    doc.text(jefeSeccion, 140, 72);
    
    //doc.text('Dirección: ' + proveedorDireccion, 110, 80);

    //separador
    //doc.line(15, 85, 195, 85);

    //tabla de materiales
    doc.autoTable(columns, itemsOTA, {
        theme: 'grid',
        margin: {
            top: 90,
            left: margenDerecho,
            right: margenDerecho
        }
    });

    var tablaPosY = doc.autoTable.previous.finalY;

    //separador
    //doc.line(margenDerecho, tablaPosY + 5, 195, tablaPosY + 5);
    //doc.text('TOTAL: $' + total, 160, tablaPosY + 12);

    //separador
    //doc.line(margenDerecho, tablaPosY + 17, 195, tablaPosY + 17);
    //var fechaFormato = new Date(parseInt(fecha.replace(/(^.*\()|([+-].*$)/g, '')));
    //doc.text('Fecha: ' + fechaFormato.toLocaleDateString(), margenDerecho, tablaPosY + 25);
    //doc.text('Recursos Asignados: $' + total, 140, tablaPosY + 25);
    //doc.text('Responsable: ' + responsable, margenDerecho, tablaPosY + 33);
    //doc.text('Cheque N° ' + cheque, 140, tablaPosY + 33);

    //doc.roundedRect(15, 15, 180, 267, 3, 3, 'S');
    doc.line(margenDerecho, 65, 195, 65);
    doc.line(margenDerecho, 85, 195, 85);
    doc.line(margenDerecho, 45, 195, 45);

    //propiedades del archivo
    var value = Date.now();
    var fechaCreacion = new Date(value);
    doc.setCreationDate(value);

    doc.save('OTA-' + numero.toString() + '-' + fechaCreacion.getDate() + '' + (fechaCreacion.getMonth() + 1).toString() + '' + fechaCreacion.getFullYear());  
}