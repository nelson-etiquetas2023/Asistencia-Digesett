function saveAsFile(filename, bytesBase64)
{
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};

window.saveExcel = function (filename, data) {
    const blob = new Blob([data], { type: 'application/octet-stream' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    window.URL.revokeObjectURL(url);

};


function DataTableInitPonches(table, jsonData) {
    DataTableLoad(table)
}




function DataTableLoad(table) {
    $(function () {
        $(table).DataTable({
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_-_END_ (_TOTAL_ Filas)",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar Por:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
            pageLength: 10,
            destroy: true,
            lengthMenu: [5,10,20,30,40,50]
        });
    });
    
}
function DataTableUnload(table) {
    
    $(table).DataTable().destroy();
   
}

function DataTableRepaint(table,jsonData)
{ 
    $(table + '_wrapper').remove();
    DataTableLoad(table);
};  