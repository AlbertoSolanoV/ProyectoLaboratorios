function ModificarUsuario() {


    this.InitView = function () {
        this.CargarPantalla();

        $("#btnCrear").click(function () {
            var vista = new ModificarUsuario();
            // vista.CrearOferta();
        });
        this.RealizarCambios();
    }

    this.CargarPantalla = function () {

        var idUsuario = localStorage.getItem("idUsuario");

        var urlApi = "http://localhost:44335/api/RegistroUsuario/InformacionUsuario?pIdUsuario=" + idUsuario;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "GET",
            url: urlApi,
        }).done(
            function (response) {
                console.log(response);
                if (response === null) {
                    Swal.fire({
                        icon: 'error',
                        title: 'ERROR',
                        text: 'No se pudo cargar su información de usuario, recargue la página.'
                    });
                } else {
                    //Nombre
                    var idSeccion = document.getElementById("secNombreUsuario");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='nombreUser' value=" + response.nombreUsuario + ">";
                    //Apellido 1
                    idSeccion = document.getElementById("secPrimerApeUsuario");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='PrimerApeUsuario' value=" + response.primerApellido + ">";
                    //Apellido 2 
                    idSeccion = document.getElementById("secSegundoApeUsuario");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='SegundoApeUsuario' value=" + response.segundoApellido + ">";
                    //Cedula
                    idSeccion = document.getElementById("secIdentificacionUsuario");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='IdentificacionUsuario' value=" + response.identificacionUsuario + ">";
                    //correo
                    idSeccion = document.getElementById("secEmailUsuario");
                    idSeccion.innerHTML += "<input type='email' class='form-control' id='EmailUsuario' value=" + response.emailUsuario + ">";
                    //Telefono
                    idSeccion = document.getElementById("secTelefonoUsuario");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='TelefonoUsuario' value=" + response.telefonoUsuario + ">";


                   //  idSeccion = document.getElementById("secHabilitado");
                   //  if (response.estado == 1) {
                      //  idSeccion.innerHTML += "<input class='form-check-input' type='checkbox' id='cbEstadoUsuario' value='estado' checked>";
                     //   idSeccion.innerHTML += "<label class='form-check-label' for= 'flexSwitchCheckDefault' > Habilitar Usuario</label>"
                   // } else {
                       // idSeccion.innerHTML += "<input class='form-check-input' type='checkbox' id='cbEstadoUsuario' value='estado' >";
                       // idSeccion.innerHTML += "<label class='form-check-label' for= 'flexSwitchCheckDefault' > Habilitar Usuario</label>"
                   // }

                    idSeccion = document.getElementById("secCambioContra");
                    idSeccion.innerHTML += "<a href='/ModificarContraseña/ModificarContraseña?pidUsuario=" + idUsuario + "' class='btn btn-primary profile-button' > Cambiar Contraseña</a>"


                    //Para las imagenes
                  $("#fotoPerfil").attr("src", response.fotoPerfilUsuario);  
                    idUsuario = response.idUsuario;
                }
            }   
        ).fail(
            function () {
                Swal.fire({
                    icon: 'error',
                    title: 'ERROR',
                    text: "El servidor no está  activo, por favor espere."
                });
            });



    }


    this.RealizarCambios = function () {

        $("#btnModificarDatos").click(function () {

            var idUsuario = localStorage.getItem('idUsuario');

            var usuario = {};


            usuario.nombreUsuario = $("#nombreUser").val();
            usuario.primerApellido = $("#PrimerApeUsuario").val();
            usuario.segundoApellido = $("#SegundoApeUsuario").val();
            usuario.identificacionUsuario = $("#IdentificacionUsuario").val();
            usuario.emailUsuario = $("#EmailUsuario").val();
            usuario.telefonoUsuario = $("#TelefonoUsuario").val();
            

            usuario.Id = localStorage.getItem('idUsuario');

            usuario.fotoPerfilUsuario = document.getElementById("fotoPerfil").src;

             console.log(usuario);
                       


           /// if ($("#cbEstadoUsuario").is(':checked')) {
               /// usuario.estado = 1;

           /// }
           //// else {
              ///  usuario.estado = 0;
            ///}


            if (!ValidacionCamposVacios(nombreUser, PrimerApeUsuario, SegundoApeUsuario,
                IdentificacionUsuario, EmailUsuario, TelefonoUsuario)) {

                Swal.fire({
                    icon: 'error',
                    title: 'Faltan campos.',
                    text: 'Todos los campos deben estar agregados.'
                });
            } else {

                var urlApi = "http://localhost:44335/api/RegistroUsuario/ModificarUsuario";


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
                        if (response.includes("exito")) {
                            Swal.fire({
                                title: 'ÉXITO',
                                text: response,
                                icon: 'success',
                                confirmButtonText: 'Aceptar'
                            }).then((result) => {
                                if (result.isConfirmed) {
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
                            text: "El servidor no está  activo, por favor espere."
                        });
                    });
            }

        });

    }

    //Validacion de campos
    function ValidacionCamposVacios(...args) {

        for (let arg of args) {
            if (arg == "") {
                return false;
            }
        }
        return true;
    }
}

$(document).ready(function () {

    var view = new ModificarUsuario();
    view.InitView();

});