const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const idLab = urlParams.get('idLab')
function CrearRegistro() {

    this.InitView = function () {

        var vista = new CrearRegistro();
        vista.CrearRegistro();


    }

    this.CrearRegistro = function () {
      
        $("#btnRegistrar").click(function () {
            console.log(idLab);
            if (idLab == null) {
                var registro = {}
                var OTP = OTPGen(1000, 9999);
                var urlAPI = "http://localhost:44335/api/RegistroUsuario/RegistrarUsuario";

            registro.nombreUsuario = $("#txtnombre").val();
            registro.primerApellido = $("#txtprimerApellido").val();
            registro.segundoApellido = $("#txtsegundoApellido").val();
            registro.identificacionUsuario = $("#txtidentificacion").val();
            registro.emailUsuario = $("#txtemail").val();
            registro.telefonoUsuario = $("#txttelefono").val();
            registro.contraseñaUsuario = $("#txtpassword").val();
            registro.confirmarContraseñaUsuario = $("#txtconfirmarpassword").val();
            registro.fotoPerfilUsuario = document.getElementById("perfilImg").src;
            registro.idRolUsuario = '1';
            var idRol = 'Cliente';
            registro.usuarioActivo = 'NO';
            registro.otpUsuario = OTP;

                if (!ValidacionCamposVacios(registro.nombreUsuario, registro.primerApellido, registro.segundoApellido, registro.identificacionUsuario, registro.emailUsuario,
                    registro.telefonoUsuario, registro.contraseñaUsuario, registro.fotoPerfilUsuario, registro.idRolUsuario, registro.usuarioActivo, registro.OTP)) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Faltan campos por completar.',
                        text: 'Todos los campos deben estar llenos.'
                    });

                } else if (!ValidacionCorreo(registro.emailUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Correo invalido.',
                        text: 'El formato del correo no es válido.'
                    });
                } else if (!ValidarContraseña(registro.contraseñaUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Contraseña invalida.',
                        text: 'Contraseña debe contener mayúsculas, minúsculas, números, carácter especial, mayor a 8 caracteres, menor de 16 caracteres.'
                    })

                } else if (!ValidarConfirmarContraseña(registro.contraseñaUsuario, registro.confirmarContraseñaUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Contraseñas no son iguales',
                        text: 'Verifique que la confirmación de contraseña sea igual.'
                    })
                } else if (!ValidarImagen(registro.fotoPerfilUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Imagen de perfil no cargada',
                        text: 'Debe de cargar una imagen de perfil'
                    })
                } else {

                    var urlApi = urlAPI;

                $.ajax({
                    headers: {
                        'Accept': "application/json",
                        'Content-Type': "application/json"
                    },
                    method: "POST",
                    url: urlApi,
                    contentType: "application/json",
                    data: JSON.stringify(registro),
                    hasContent: true
                }).done(
                    function (response) {
                        var id = response;
                        console.log(response);
                        if (response == null) {
                            Swal.fire({
                                icon: 'error',
                                title: 'ERROR',
                                text: response
                            });
                        } else {
                          var urlCorreo = "http://localhost:44335/api/EmailOTP/Execute?pCorreo=" + registro.emailUsuario + "&pOTP=" + registro.otpUsuario;
                            $.ajax({

                                Headers: {
                                    'Accept': "application/json",
                                    'Content-Type': "application/json"
                                },
                                method: "POST",
                                url: urlCorreo,
                                contentType: "application/json",
                                hasContent: true
                            }).done(function (response) {
                                console.log(response);
                                Swal.fire({
                                    title: 'Registro Completo',
                                    text: 'Para activar su cuenta, por favor confirme su código enviado a su número de teléfono',
                                    icon: 'success',
                                    confirmButtonText: 'Aceptar'
                                }).then((result) => {
                                    if (result.isConfirmed) {
                                        localStorage.setItem("idUsuario", id);
                                        localStorage.setItem("OTPRegistroNuevo", OTP);
                                        localStorage.setItem("Rol", registro.idRolUsuario);
                                        localStorage.setItem("emailUsuario", registro.emailUsuario);
                                        sessionStorage.setItem("Rol", registro.idRolUsuario);
                                        sessionStorage.setItem("OTPRegistroNuevo", OTP);
                                        sessionStorage.setItem("emailUsuario", registro.emailUsuario);
                                       
                                        Redireccion(OTP, idRol, registro.telefonoUsuario);
                                        location.href = "/OTP/OTP";
                                    }
                                })
                            })
                        }
                    }
                ).fail(
                    function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'ERROR',
                            text: "El servidor no está activo, por favor espere."
                        });
                    });


            }
                    $.ajax({
                        headers: {
                            'Accept': "application/json",
                            'Content-Type': "application/json"
                        },
                        method: "POST",
                        url: urlApi,
                        contentType: "application/json",
                        data: JSON.stringify(registro),
                        hasContent: true
                    }).done(
                        function (response) {
                            console.log(response);
                            if (response.includes("exito")) {
                                Swal.fire({
                                    title: 'Registro Completo',
                                    text: 'Para activar su cuenta, por favor confirme su código enviado a su número de teléfono',
                                    icon: 'success',
                                    confirmButtonText: 'Aceptar'
                                }).then((result) => {
                                    if (result.isConfirmed) {
                                        Redireccion(OTP, idRol, registro.telefonoUsuario);
                                        localStorage.setItem("ROL", JSON.stringify(pIdRolUsuario));
                                        localStorage.setItem("OTPRegistroNuevo", JSON.stringify(OTP));
                                        location.href = "/OTP/OTP";
                                    }
                                })
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'ERROR',
                                    text: response
                                });
                            }

                        }
                    ).fail(
                        function () {
                            Swal.fire({
                                icon: 'error',
                                title: 'ERROR',
                                text: "El servidor no está activo, por favor espere."
                            });
                        });
                
            } else {
                console.log("Entro a registroUsuario lab");
                var registro = {}
                var urlAPI = "http://localhost:44335/api/RegistroUsuarioLab/ReegistrarUsuarioLab";

                registro.nombreUsuario = $("#txtnombre").val();
                registro.primerApellido = $("#txtprimerApellido").val();
                registro.segundoApellido = $("#txtsegundoApellido").val();
                registro.identificacionUsuario = $("#txtidentificacion").val();
                registro.emailUsuario = $("#txtemail").val();
                registro.telefonoUsuario = $("#txttelefono").val();
                registro.contraseñaUsuario = $("#txtpassword").val();
                registro.confirmarContraseñaUsuario = $("#txtconfirmarpassword").val();
                registro.fotoPerfilUsuario = document.getElementById("perfilImg").src;
                registro.idRolUsuario = '4';
                var idRol = 'TecnicLab';
                registro.usuarioActivo = 'YES';
                registro.otpUsuario = 'Si';
                registro.idLab = idLab;

                if (!ValidacionCamposVacios(registro.nombreUsuario, registro.primerApellido, registro.segundoApellido, registro.identificacionUsuario, registro.emailUsuario,
                    registro.telefonoUsuario, registro.contraseñaUsuario, registro.fotoPerfilUsuario, registro.idRolUsuario, registro.usuarioActivo, registro.OTP)) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Faltan campos por completar.',
                        text: 'Todos los campos deben estar llenos.'
                    });

                } else if (!ValidacionCorreo(registro.emailUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Correo invalido.',
                        text: 'El formato del correo no es válido.'
                    });
                } else if (!ValidarContraseña(registro.contraseñaUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Contraseña invalida.',
                        text: 'Contraseña debe contener mayúsculas, minúsculas, números, carácter especial, mayor a 8 caracteres, menor de 16 caracteres.'
                    })

                } else if (!ValidarConfirmarContraseña(registro.contraseñaUsuario, registro.confirmarContraseñaUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Contraseñas no son iguales',
                        text: 'Verifique que la confirmación de contraseña sea igual.'
                    })
                } else if (!ValidarImagen(registro.fotoPerfilUsuario)) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Imagen de perfil no cargada',
                        text: 'Debe de cargar una imagen de perfil'
                    })
                } else {

                    var urlApi = urlAPI;

                    $.ajax({
                        headers: {
                            'Accept': "application/json",
                            'Content-Type': "application/json"
                        },
                        method: "POST",
                        url: urlApi,
                        contentType: "application/json",
                        data: JSON.stringify(registro),
                        hasContent: true
                    }).done(
                        function (response) {
                            console.log(response);
                            if (response.includes("Exito")) {
                                Swal.fire({
                                    title: 'Registro Completo',
                                    text: 'Exito, usuario de laboratorio creado',
                                    icon: 'success',
                                    confirmButtonText: 'Aceptar'
                                }).then((result) => {
                                    if (result.isConfirmed) {
                                        location.href = "/DashBoardLaboratorio/DashBoardLaboratorio";
                                    }
                                })
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'ERROR',
                                    text: response
                                });
                            }

                        }
                    ).fail(
                        function () {
                            Swal.fire({
                                icon: 'error',
                                title: 'ERROR',
                                text: "El servidor no está activo, por favor espere."
                            });
                        });
                }
            }
           



        });
    }

    //OTG GENERATOR
    function OTPGen(min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1) + min);
    }



    /// Inicio Validaciones de form


    //campos vacios
    function ValidacionCamposVacios(...args) {
        for (let arg of args) {
            if (arg == "") {
                return false;
            }
        }
        return true;
    }

    //validacion formato de correo

    function ValidacionCorreo(pCorreolUsuario) {
        var field = pCorreolUsuario;
        let fieldLenght = field.trim().length;
        const regex = new RegExp(/^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/);

        if (fieldLenght > 5 && regex.test(pCorreolUsuario)) {
            return pCorreolUsuario.includes("@");

        }
        return false

    }


    //validacion formato de contraseña
    function ValidarContraseña(pContraseñaUsuario) {
        var field = pContraseñaUsuario;

        let fieldLenght = field.trim().length;
        const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])([A-Za-z\d$@$!%*?&]|[^ ]){7,16}$/;


        if (fieldLenght > 5 && regex.test(pContraseñaUsuario) && fieldLenght < 16) {
            return pContraseñaUsuario;

        } else if (fieldLenght < 5 || !regex.test(pContraseñaUsuario) || fieldLenght > 16) {
            return false;
        }
    };

    //validacion confirmar contraseña
    function ValidarConfirmarContraseña(pContraseñaUsuario, pConfirmarContraseña) {

        var field1 = pConfirmarContraseña;
        var field2 = pContraseñaUsuario;

        if (field1 === field2) {
            return field2;
        }
        return false;
    };


    //validacion caerga de imagen
    function ValidarImagen(pImagen) {

        if (pImagen == 'https://localhost:44360/Content/Imagenes/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg') {

            return false;
        }
        return pImagen;


    }

    /// Cierre Validaciones de form


    //SMS SENDER
    function Redireccion(pOTPRegistroNuevo, pIdRolUsuario, pTelefonoUsuario, pCorreoUsuario) {
        var OTP = pOTPRegistroNuevo;
        var telefonoUser = pTelefonoUsuario;
        var urlSMS = "http://localhost:44335/api/SMS/sendSMS?pTelefono=" + telefonoUser + "&pOTP=" + OTP;
        $.ajax({

            Headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: urlSMS,
            contentType: "application/json",
            hasContent: true
        }).done(function () {
            console.log("sms enviado");
            localStorage.setItem("Rol", JSON.stringify(pIdRolUsuario));
            sessionStorage.setItem("Rol", JSON.stringify(pIdRolUsuario));
            localStorage.setItem("OTPRegistroNuevo", JSON.stringify(OTP));
            sessionStorage.setItem("OTPRegistroNuevo", JSON.stringify(OTP));
            envioEmail(pCorreoUsuario, OTP)
            window.location.href = "/OTP/OTP";
        }).fail(function () {
            console.log("sms fallo");
        });
    };



    //EMAIL SENDER
    function envioEmail(pOTPRegistroNuevo, pCorreo) {
        var OTP = pOTPRegistroNuevo;
        var correoUsuario = pCorreo;
        var urlSMS = "https://localhost:44335/api/EmailOTP/Execute?pCorreo=" + correoUsuario + OTP;
        $.ajax({

            Headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: urlSMS,
            contentType: "application/json",
            hasContent: true
        }).done(function () {
            console.log("emailOTP enviado");
            sessionStorage.setItem("CorreoUsuario", JSON.stringify(correoUsuario));
            localStorage.setItem("CorreoUsuario", JSON.stringify(correoUsuario));
        }).fail(function () {
            console.log("emailOTP fallo");
        });
    };


}




$(document).ready(function () {

    var view = new CrearRegistro();
    view.InitView();


})
