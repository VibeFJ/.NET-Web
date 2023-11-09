
//Desabilitar boton
function envio() {
    $('#btnIniciarSesion').prop('disabled', true);
    $.ajax({
        url: "/api/TAUsuario/Verificar",
        type: "POST",
        data: {
            _token: "{{ csrf_token() }}",
            NombreUsuario: $('#txtUsuario').val(),
            Contraseña: $('#txtContraseña').val(),
        },
        success: function (respuesta) {
            console.log(respuesta);

            if (!respuesta) {
                Swal.fire({
                    icon: 'error',
                    type: 'error',
                    title: 'Oops...',
                    text: 'Usuario y/o contraseña Incorrectos, intente de nuevo',
                }).then((result) => {
                    if (result.value) {
                        document.getElementById("btnIniciarSesion").disabled = false;
                    }
                })
            }
            else if (respuesta) {
                console.log("Si entro en true");
                //enviar a Principal
                Swal.fire({
                    icon: 'success',
                    title: 'Bienvenido a Tienda en Linea',
                    showConfirmButton: false,
                    timer: 2000
                }).then((result) => {
                    window.location.href = "Principal.aspx";
                })
            }
            else {
                Swal.fire({
                    icon: 'error',
                    type: 'error',
                    title: 'Oops...',
                    text: 'Error al iniciar sesión, intente de nuevo',
                }).then((result) => {
                    if (result.value) {
                        document.getElementById("btnIniciarSesion").disabled = false;
                    }
                })
            }
        }
    });
}

//Mostrar contraseña
$(document).ready(function () {

    if (($('#txtContraseña').val() != "") & ($('#txtUsuario').val() != "")) {
        $('#btnIniciarSesion').prop('disabled', false);
    }
    else {
        $('#btnIniciarSesion').prop('disabled', true);
    }

    $('#txtUsuario').on('input change', function () {
        if (($(this).val() != "") & ($('#txtContraseña').val() != "")) {
            $('#btnIniciarSesion').prop('disabled', false);
        }
        else {
            $('#btnIniciarSesion').prop('disabled', true);
        }
    });
    $('#txtContraseña').on('input change', function () {
        if (($(this).val() != "") & ($('#txtUsuario').val() != "")) {
            $('#btnIniciarSesion').prop('disabled', false);
        }
        else {
            $('#btnIniciarSesion').prop('disabled', true);
        }
    });
});