$.extend(true, $.fn.dataTable.defaults, {
    "autoWidth": false,
    "searching": true,
    "ordering": true,    
    "language": {
        "decimal": "",
        "emptyTable": "No hay información disponible para mostrar",
        "info": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
        "infoEmpty": "No hay entradas para mostrar",
        "infoFiltered": "(filtrados de _MAX_ entradas totales)",
        "infoPostFix": "",
        "thousands": ",",
        "lengthMenu": "Visualizar _MENU_ entradas   ",
        "loadingRecords": "Cargando...",
        "processing": "En proceso...",
        "search": "Buscar",
        "zeroRecords": "No hay entradas que coincidan con el criterio de busqueda",
        "paginate": {
            "first": "Primera",
            "last": "Última",
            "next": "Siguiente",
            "previous": "Anterior"
        }
    }
});
