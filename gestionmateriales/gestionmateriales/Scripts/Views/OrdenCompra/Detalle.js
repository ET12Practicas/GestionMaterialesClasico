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
            "aaData": data.Response,
            "aoColumnDefs": [{
                "targets": [],
                "visible": false,
                "sType": "html",
                "aTargets": [4,5]
            }],
            "aoColumns": [
                {
                    "sWidth": "5%",
                    "data": "nroItem"
                },
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
            "order": [0, "asc"],
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
    var columns = [
        { title: "N°", dataKey: "nroItem" },
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

    //doc.roundedRect(164, 18, 30, 22, 3, 3, 'S');
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
    doc.text(168, 36, 'N° ');
    doc.setFontSize(30);
    doc.text(176, 36, numeroInterno.toString());

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
    doc.text('IVA EXENTO', 110, 60);
    doc.text('Factura N° ' + numeroFactura, 161, 60);

    //separador
  //  doc.line(15, 65, 195, 65);

    doc.text('Proveedor: ' + proveedorNombre, margenDerecho, 72);
    doc.text('Telefóno: ' + proveedorTelefono, 110, 72);

    doc.text('Contacto: ' + proveedorContacto, margenDerecho, 80);
    doc.text('Dirección: ' + proveedorDireccion, 110, 80);

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

    doc.text('TOTAL: $' + total, 160, tablaPosY + 12);

    //separador
    doc.line(margenDerecho, tablaPosY + 17, 195, tablaPosY + 17);
    var fechaFormato = new Date(parseInt(fecha.replace(/(^.*\()|([+-].*$)/g, '')));
    doc.text('Fecha: ' + fechaFormato.toLocaleDateString(), margenDerecho, tablaPosY + 25);
    doc.text('Recursos Asignados: $' + total, 140, tablaPosY + 25);

    doc.text('Responsable: ' + responsable, margenDerecho, tablaPosY + 33);
    doc.text('Cheque N° ' + cheque, 140, tablaPosY + 33);

    //doc.roundedRect(15, 15, 180, 267, 3, 3, 'S');
    doc.line(margenDerecho, 65, 195, 65);
    doc.line(margenDerecho, 85, 195, 85);
    doc.line(margenDerecho, 45, 195, 45);

    //propiedades del archivo
    var value = Date.now();
    var fechaCreacion = new Date(value);
    doc.setCreationDate(value);

    doc.save('OC-' + numeroInterno.toString() + '-' + fechaCreacion.getDate() + '' + (fechaCreacion.getMonth() + 1).toString() + '' + fechaCreacion.getFullYear());  
}