let cont = 1;
function VerificarOTP() {

    this.InitView = function () {

        var vista = new VerificarOTP();
        vista.ValidarOTP();


    }


    this.ValidarOTP = function () {
        $("#btnValidarOTP").click(function () {
            var usuario = {};
            var activarUsuario = {}
            usuario.OTPUsuario = $("#userOTP").val();
            activarUsuario.id = localStorage.getItem("idUsuario");
            usuario.emailUsuario = localStorage.getItem("emailUsuario");
            activarUsuario.usuarioActivo = "YES";
            console.log(usuario);
            console.log(activarUsuario);
            var urlApi = "http://localhost:44335/api/ValidarOTP/ValidarOTP";
            console.log(activarUsuario);
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
                if (response.OTPUsuario == usuario.OTPUsuario) {
                    var urlApi = "http://localhost:44335/api/RegistroUsuario/ModificarUsuarioActivo";
                    console.log(activarUsuario);
                    $.ajax({
                        headers: {
                            'Accept': "application/json",
                            'Content-Type': "application/json"
                        },
                        method: "POST",
                        url: urlApi,
                        contentType: "application/json",
                        data: JSON.stringify(activarUsuario),
                        hasContent: true
                    }).done(function (response) {
                        console.log(response);
                        Swal.fire({
                            icon: 'success',
                            title: 'Usuario confirmado',
                            text: 'El usuario se confirmó exitosamente, puede iniciar de sesión',
                            confirmButtonText: 'Aceptar'
                        }).then((result) => {
                            if (result.isConfirmed) {
                               
                                location.href = "/Login/Login";
                            };
                        });
                    });

                } else if (response.OTPUsuario != usuario.OTPUsuario) {
                    if (cont <= 3) {
                        var contmostrador = cont;
                        cont++;
                        Swal.fire({
                            icon: 'error',
                            title: 'Codigo OTP Incorrecto.',
                            text: 'Codigo OTP Incorrecto. Intento ' + (contmostrador) + ' de 3.)',

                        })
                    } else if (cont >= 3) {
                        Swal.fire({
                            icon: 'error',
                            title: 'ERROR',
                            text: "La cuenta no pudo ser verificada, por favor realice el proceso de nuevo",
                            confirmButtonText: 'Aceptar'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                location.href = "/Login/Login";
                            }
                        })

                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'ERROR',
                            text: "El servidor no esta activo, por favor espere.",
                            confirmButtonText: 'Aceptar'
                        });
                    };
                };
            });

        });
    };

    //Validacion de campos
    function ValidacionCamposVacios(...args) {

        for (let arg of args) {
            if (arg == "") {
                return false;
            }
        }
        return true;
    };
};



$(document).ready(function () {

    var view = new VerificarOTP();
    view.InitView();

})





    //this.ValidarLogin = function () {
    //    var usuario = {};
    //    usuario.OTPUsuario = $("#userOTP").val();
    //    console.log(usuario);

    //    var urlApi = "https://localhost:44335/api/Login/ValidarLogin";

    //    $.ajax({
    //        headers: {
    //            'Accept': "application/json",
    //            'Content-Type': "application/json"
    //        },
    //        method: "POST",
    //        url: urlApi,
    //        contentType: "application/json",
    //        data: JSON.stringify(usuario),
    //        hasContent: true
    //    }).done(
    //        function (response) {
    //            console.log(response);
    //            if (response.OTPUsuario != "incorrect") {
    //                Swal.fire({
    //                    title: 'EXITO',
    //                    text: 'Logeado con exito',
    //                    icon: 'success',
    //                    confirmButtonText: 'Aceptar'
    //                }).then((result) => {
    //                    if (result.isConfirmed) {
    //                        location.href = "/Home/PaginaMain";
    //                    }
    //                })
    //            } else {
    //                Swal.fire({
    //                    icon: 'error',
    //                    title: 'Correo o contraseña incorrecto.',
    //                    text: 'Correo o contraseña incorrecto.'
    //                });
    //            }

    //        }
    //    ).fail(
    //        function () {
    //            Swal.fire({
    //                icon: 'error',
    //                title: 'ERROR',
    //                text: "El servidor no esta activo, por favor espere."
    //            });
    //        });


    //}









    //                function (response) {
    //                    console.log(response);
    //                    if (response.OTPUsuario == usuario.OTPUsuario) {
    //                        Swal.fire({
    //                            icon: 'Success',
    //                            title: 'Usuario confirmado',
    //                            text: 'El usuario se confirmó de exitosamente, en unos segundos será redirigido a la página de inicio de sesión',
    //                            confirmButtonText: 'Aceptar'
    //                        });
    //                        setTimeout(function () {
    //                            localStorage.setItem("Rol", response.nombreRol);
    //                            sessionStorage.setItem("Rol", response.nombreRol);
    //                            location.href = "/Login/Login";
    //                        }, 4000);

    //                    } else {
    //                        var intentos
    //                        for (intentos == 0; intentos < 3; intentos++) {
    //                            Swal.fire({
    //                                icon: 'Error',
    //                                title: 'Error de Confirmacion',
    //                                text: 'No se pudo cargar o confirmar su cuenta, intento de verificacion: ' + intentos + '.(tres intentos).'


    //                            })
    //                            Swal.fire({
    //                                icon: 'Error',
    //                                title: 'Error de Confirmacion',
    //                                text: 'No se pudo cargar o confirmar su cuenta, por favor realice el proceso de registro nuevamente'



    //                            });
    //                        }
    //                    };

    //                });
    //    });

    //}

