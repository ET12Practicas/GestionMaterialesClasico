var appName = location.pathname.split('/')[1];
var baseURL = window.location.protocol + "//" + window.location.host + "/";
var itemsOC;

$(document).ready(function () {

    if (window.location.href.split(':').length == 2)
        baseURL = baseURL + appName + "/";

    var request = $.ajax({
        url: baseURL + "OrdenCompra/Get_Detalle_ItemsOrdenCompra",
        type: 'GET',
        data: { id: $('#IdOC').val() },
        contentType: 'application/json; charset=utf-8'
    });

    request.done(function (data) {
        itemsOC = data.Response;
        tablaMateriales = $('#grdItemsOC').DataTable({
            //"dom": "lfrtip",
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [],
                "visible": false,
                "sType": "html",
                "aTargets": [3, 4]
            }],
            "aoColumns": [
                {
                    "sWidth": "30%",
                    "data": "material"
                },
                {
                    "sWidth": "30%",
                    "data": "dest"
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
            "order": [1, "asc"],
            "paging": false,
            "filter": false,
            "info": false
        });
    });

    request.fail(function (data) {
        console.log(data.Response);
        alert('No se pueden cargar los items OC');
    });
});


function descargarOrdenCompra() {
    console.log(itemsOC);

    var columns = [
        { title: "Detalle", dataKey: "material" },
        { title: "Destino", dataKey: "dest" },
        { title: "Cantidad", dataKey: "cantidad" },
        { title: "P. Unit.", dataKey: "precioUnitario" },
        { title: "Subtotal", dataKey: "subtotal" }
    ];

    var nombreInstiticion = 'Escuela Técnica N°12 DE 1 "Libertador General Jose de San Martin"';
    var nombreDocumento = 'ORDEN DE COMPRA';
    var logo = baseURL + 'Assets/logodoc.png';
    var margenDerecho = 15;

    var doc = new jsPDF();

    doc.roundedRect(164, 18, 30, 22, 3, 3, 'S');
    //doc.rect(15, 15, 180, 267, 'S');
    doc.setFont('helvetica');
    doc.setFontType('normal');

    //nombre institucion
    // doc.setFontSize(12);
    // doc.text(20, 24, nombreInstiticion);

    //logo
    doc.addImage(logo, 'png', 17, 17, 26, 26);

    //nombre documento
    doc.setFontType('bold');
    doc.setFontSize(18);
    doc.text(75, 34, nombreDocumento);

    //leyenda oficina tecnica
    doc.setFontType('bolditalic');
    doc.setFontSize(8);
    doc.text(168, 24, 'Oficina Técnica');

    //numero orden de compra
    doc.setFontSize(12);
    doc.text(166, 36, 'N° ');
    doc.setFontSize(30);
    doc.text(174, 36, '100');

    //separador
    //doc.line(15, 45, 195, 45);

    doc.setFont('helvetica');
    doc.setFontType('bolditalic');
    doc.setFontSize(10);
    doc.text('Asociación Cooperadora María L. Prat de Louit', margenDerecho, 52);
    doc.setFontType('bold');
    doc.text('CUIT: 30-68246181-7', 110, 52);
    doc.text('Factura tipo B o C', 161, 52);

    doc.setFontType('normal');
    doc.text('Av. Del Libertador 238 CABA Tel. 4328-4433/9421', margenDerecho, 60);
    doc.setFontType('bold');
    doc.text('IVA EXENTO', 170, 60);

    //separador
  //  doc.line(15, 65, 195, 65);

    doc.text('Proveedor: ', margenDerecho, 72);
    doc.text('Telefóno: ', 120, 72);

    doc.text('Contacto: ', margenDerecho, 80);
    doc.text('Dirección: ', 90, 80);

    //separador
    //doc.line(15, 85, 195, 85);

    //tabla de materiales
    doc.autoTable(columns, itemsOC, {
        theme: 'grid',
        margin: {
            top: 90,
            left: margenDerecho,
            right: margenDerecho
        }
    });

    var tablaPosY = doc.autoTable.previous.finalY;

    //separador
    doc.line(margenDerecho, tablaPosY + 5, 195, tablaPosY + 5);

    doc.text('TOTAL: $ 100000', 160, tablaPosY + 12);

    //separador
    doc.line(margenDerecho, tablaPosY + 17, 195, tablaPosY + 17);

    doc.text('Fecha: ', margenDerecho, tablaPosY + 25);
    doc.text('Recursos Asignados: ', 135, tablaPosY + 25);

    doc.text('Responsable: ', margenDerecho, tablaPosY + 33);
    doc.text('Cheque N° ', 153, tablaPosY + 33);

    //doc.roundedRect(15, 15, 180, 267, 3, 3, 'S');
    doc.line(margenDerecho, 65, 195, 65);
    doc.line(margenDerecho, 85, 195, 85);
    doc.line(margenDerecho, 45, 195, 45);

    //propiedades del archivo
    var fecha = Date.now();

    doc.setCreationDate(fecha);

    doc.save('OC-' + '100');  
}