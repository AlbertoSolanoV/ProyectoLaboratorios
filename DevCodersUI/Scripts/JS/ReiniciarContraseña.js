const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const idUsuario = urlParams.get('id')


function ModificarContraseña() {
    this.InitView = function () {

        $("#modificarContraseña").click(function () {
            var vista = new ModificarContraseña();
            vista.RealizarCambios();
        });
    }


    this.RealizarCambios = function () {

        var usuario = {};
        usuario.contraseñaUsuario = $("#password").val();
        var contraseñaUsuario2 = $("#password2").val();
        /*   usuario.idIsuario = localStorage.getItem('idUsuario');*/
        usuario.id = idUsuario;
        console.log(usuario);


        if (usuario.contraseñaUsuario == contraseñaUsuario2) {
            var urlApi = "http://localhost:44335/api/RegistroUsuario/ModificarUsuarioContrasena";
            $.ajax({
                headers: {
                    'Accept': "application/json",
                    'Content-Type': "application/json"
                },
                method: "POST",
                url: urlApi,
                contentType: "application/json",
                data: JSON.stringify(usuario),
                hasContent: true
            }).done(function (response) {
                console.log(response);
                Swal.fire({
                    icon: 'success',
                    title: 'Contraseña restablecida',
                    text: 'La contraseña se reinicio exitosamente, puede iniciar de sesión',
                    confirmButtonText: 'Aceptar'
                    /*location.href = "/Login/Login";*/
                }).then((result) => {
                    if (result.isConfirmed) {

                        location.href = "/Login/Login";
                    };

                });
            });
        } else {
            Swal.fire({
                icon: 'error',
                title: 'ERROR',
                text: "Las contraseñas no son iguales, por favor verifique de nuevo",
                confirmButtonText: 'Aceptar'
            });

        };

    };
};





$(document).ready(function () {

    var view = new ModificarContraseña();
    view.InitView();

})


