function ShowNotificationSuccess(nombrePantalla, mensaje = 'Los datos se guardaron con éxito') {
    $.notify(
        {
            icon: "fas fa-check-circle",
            title: '<b>' + nombrePantalla + '</b><br/>',
            message: mensaje
        },
        {
            type: 'success',
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
            placement: {
                from: 'top',
                align: 'right'
            },
            offset: {
                x: 20,
                y: 80
            },
            delay: 1000,
            allow_dismiss: true
        }
    );
}

function ShowNotificationDanger(nombrePantalla, mensaje) {
    $.notify(
        {
            icon: "fas fa-exclamation-circle",
            title: '<b>' + nombrePantalla + '</b><br/>',
            message: mensaje
        },
        {
            type: 'danger',
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
            placement: {
                from: 'top',
                align: 'right'
            },
            offset: {
                x: 20,
                y: 80
            },
            delay: 1000,
            allow_dismiss: true
        }
    );
}

