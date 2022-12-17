function Login() {

    this.InitView = function () {
        $("#btnInicioSesion").click(function () {
            var vista = new Login();
            vista.ValidarLogin();
        });

    }

    this.ValidarLogin = function () {
        var usuario = {};
        usuario.contraseñaUsuario = $("#campoContraseña").val();
        usuario.emailUsuario = $("#campoCorreo").val();
        
        console.log(usuario);

        var urlApi = "http://localhost:44335/api/Login/ValidarLogin";

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
        }).done(
            function (response) {
                console.log(response);
                if (response.contraseñaUsuario != "incorrect") {
                    localStorage.setItem("idUsuario", response.id);
                    localStorage.setItem("Rol", response.nombreRol);
                    sessionStorage.setItem("Rol", response.nombreRol);
                    sessionStorage.setItem("idUsuario", response.id);
                    var prueba = localStorage.getItem("idUsuario");
                    console.log(prueba);
                    Swal.fire({
                        title: 'EXITO',
                        text: 'Logeado con exito',
                        icon: 'success',
                        confirmButtonText: 'Aceptar'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.href = "/Home/PaginaMain";
                        }
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Correo o contraseña incorrecto.',
                        text: 'Correo o contraseña incorrecto.'
                    });
                }

            }
        ).fail(
            function () {
                Swal.fire({
                    icon: 'error',
                    title: 'ERROR',
                    text: "El servidor no esta activo, por favor espere."
                });
            });


    }

}

$(document).ready(function () {

    var view = new Login();

    view.InitView();
});