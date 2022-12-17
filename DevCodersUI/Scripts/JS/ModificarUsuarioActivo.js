const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const idUsuario = urlParams.get('id')

function ModificarUsuarioContraseña() {

    this.InitView = function () {
        $("#btnReinicioContraseña").click(function () {
            var vista = new ModificarUsuarioContraseña();
            vista.ValidarCorreo();
        });

    }

    this.ValidarCorreo = function () {
        var usuario = {};
        usuario.emailUsuario = $("#txtemail").val();

        console.log(usuario);

        var urlApi = "http://localhost:44335/api/RegistroUsuario/ValidarCorreo";

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
                if (response.emailUsuario == usuario.emailUsuario) {
                    localStorage.setItem("emailUsuarioReinicioContrasena", response.emailUsuario);
                    sessionStorage.setItem("emailUsuarioReinicioContrasena", response.emailUsuario);
                    Swal.fire({
                        title: 'EXITO',
                        text: 'Si el correo esta registrado debera de llegar un enlace con el cual reiniciar su contrasena',
                        icon: 'success',
                        confirmButtonText: 'Aceptar'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var urlCorreo = "http://localhost:44335/api/Email/Execute?pCorreo=" + usuario.emailUsuario + "&pId=" + response.id;
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
                                location.href = "/Login/Login";
                            }).fail(function () {
                                console.log("correo fallo");
                                location.href = "/Login/Login";
                            });
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'ERROR',
                                text: "Correo electronico no existe."
                            });
                        };

                    });
                }

            });
    };
};


$(document).ready(function () {

    var view = new ModificarUsuarioContraseña();

    view.InitView();
});































//    this.InitView = function () {

//        var vista = new ModificarUsuarioActivoContraseña();
//        vista.ModificarRegistro();
//        this.RealizarCambios();
//    }

//    this.ModificarRegistro = function () {
//        $("#btnReinicioContraseña").click(function () {

//            var registro = {}
//            registro.emailUsuario = $("#txtemail").val();
//            var urlApi = "http://localhost:44335/api/RegistroUsuario/InformacionUsuarioPorCorreo?correo=" + registro.emailUsuario;

//            $.ajax({
//                headers: {
//                    'Accept': "application/json",
//                    'Content-Type': "application/json"
//                },
//                method: "GET",
//                url: urlApi,
//            }).done(
//                function (response) {
//                    console.log(response);
//                    if (response.contraseñaUsuario != "incorrect") {
//                        Swal.fire({
//                            icon: 'success',
//                            title: 'Completado',
//                            text: 'Se envio un correo a su bandeja de entrada con un enlace para poder restablecer su contraseña'

//                        }).then((result) => {
//                            if (result.isConfirmed) {
//                                location.href = "/Login/Login";
//                            };
//                        }).fail(
//                            function () {
//                                Swal.fire({
//                                    icon: 'error',
//                                    title: 'ERROR',
//                                    text: "El servidor no esta activo, por favor espere."
//                                });
//                            });
//                    });
//        }

//    this.RealizarCambios = function () {

//                $("#btnModificarDatos").click(function () {
//                    var idUser = localStorage.getItem('idUsuario');
//                    var usuario = {};
//                    usuario.idLaboratorio = idLaboratorio;
//                    usuario.nombre = $("#nombreLab").val();
//                    usuario.nombreComercial = $("#nombreComercialLab").val();
//                    usuario.cedulaJuridica = $("#cedulaJuridica").val();
//                    usuario.telefono = $("#telefonoLab").val();
//                    usuario.email = $("#correo").val();
//                    usuario.razonSocial = $("#razonSocial").val();
//                    usuario.direccion = $("#direccion").val();
//                    usuario.apartadoPostal = $("#codigoPostal").val();
//                    usuario.paginaWeb = $("#paginaWeb").val();

//                    laboratorio.idAdmin = localStorage.getItem('IdUsuario');
//                    laboratorio.idAdmin = 3;

//                    laboratorio.imagen1 = document.getElementById("primerImg").src;
//                    laboratorio.imagen2 = document.getElementById("segundaImg").src;
//                    laboratorio.imagen3 = document.getElementById("tercerImg").src;
//                    laboratorio.imagen4 = document.getElementById("cuartaImg").src;
//                    laboratorio.imagen5 = document.getElementById("quintaImg").src;

//                    if ($("#cbEstadoLaboratorio").is(':checked')) {
//                        laboratorio.estado = 1;
//                    }
//                    else {
//                        laboratorio.estado = 0;
//                    }

//                    if (!ValidacionCamposVacios(nombreLab, nombreComercialLab, cedulaJuridica,
//                        telefonoLab, correo, razonSocial, direccion, codigoPostal, paginaWeb)) {
//                        Swal.fire({
//                            icon: 'error',
//                            title: 'Faltan campos.',
//                            text: 'Todos los campos deben estar agregados.'
//                        });
//                    } else {
//                        /*Se ejecuta la llamada*/
//                        var urlApi = "https://localhost:44335/api/Laboratorio/ModificarLaboratorio";

//                        $.ajax({
//                            headers: {
//                                'Accept': "application/json",
//                                'Content-Type': "application/json"
//                            },
//                            method: "POST",
//                            url: urlApi,
//                            contentType: "application/json",
//                            data: JSON.stringify(laboratorio),
//                            hasContent: true
//                        }).done(
//                            function (response) {
//                                console.log(response);
//                                if (response.includes("exito")) {
//                                    Swal.fire({
//                                        title: 'EXITO',
//                                        text: response,
//                                        icon: 'success',
//                                        confirmButtonText: 'Aceptar'
//                                    }).then((result) => {
//                                        if (result.isConfirmed) {
//                                            location.href = "/ModificacionLab/ModificacionLab";
//                                        }
//                                    })
//                                } else {
//                                    Swal.fire({
//                                        icon: 'error',
//                                        title: 'ERROR',
//                                        text: response
//                                    });
//                                }

//                            }
//                        ).fail(
//                            function () {
//                                Swal.fire({
//                                    icon: 'error',
//                                    title: 'ERROR',
//                                    text: "El servidor no esta activo, por favor espere."
//                                });
//                            });
//                    }

//                });
//            }

//    //Validacion de campos
//    function ValidacionCamposVacios(...args) {

//                for (let arg of args) {
//                    if (arg == "") {
//                        return false;
//                    }
//                }
//                return true;
//            }

//}


//    $(document).ready(function () {

//        var view = new ModificarLab();
//        view.InitView();

//    });