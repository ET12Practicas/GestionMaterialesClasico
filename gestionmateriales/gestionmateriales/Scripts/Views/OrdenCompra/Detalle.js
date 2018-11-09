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
    var doc = new jsPDF();
    doc.setFontSize(20);
    doc.text('Orden de Compra', 15, 20);
    doc.setFontSize(10);

    doc.text('Proveedor: ASDASDAD', 15, 40);
    doc.text('Número Interno: 1342', 80, 40);
    doc.text('Número Factura: 1247', 150, 40);

    doc.text('Responsable: Juan Perez', 15, 50);
    doc.text('Fecha: 12/10/2018', 80, 50);
    doc.text('Cheque: 10000', 150, 50);
    doc.line(15, 55, 195, 55);

    var columns = [
        { title: "Material", dataKey: "material" },
        { title: "Cantidad", dataKey: "cantidad" },
        { title: "Precio Unitario", dataKey: "precioUnitario" },
        { title: "Subtotal", dataKey: "subtotal" }
    ];

    doc.autoTable(columns, itemsOC, {
        margin: { top: 70 },
        addPageContent: function (data) {
            doc.text("Materiales", 15, 65);
        }
    });

    doc.text('Total: $ 100000');
    doc.roundedRect(10, 10, 190, 275, 5, 5, 'S');
    doc.save('OC');
  
}