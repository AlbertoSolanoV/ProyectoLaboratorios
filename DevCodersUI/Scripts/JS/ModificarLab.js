function ModificarLab() {
    var idLaboratorio = 1;
    this.InitView = function () {

        this.CargarPantalla();

        $("#btnCrear").click(function () {
            var vista = new ModificarLab();
            // vista.CrearOferta();
        });
        this.RealizarCambios();
    }


    this.CargarPantalla = function () {
        var idAdmin = localStorage.getItem('idUsuario');
        var urlApi = "http://localhost:44335/api/Laboratorio/LaboratorioInformacionAdmin?pIdAdmin=" + idAdmin;

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
                        text: 'No se pudo cargar su información de laboratorio, recargue la página.'
                    });
                } else {
                    //Nombre
                    var idSeccion = document.getElementById("secNombreLaboratorio");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='nombreLab' value=" + response.nombre + ">";
                    //Nombre comercial
                    idSeccion = document.getElementById("secNombreComercial");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='nombreComercialLab' value=" + response.nombreComercial + ">";
                    //Nombre comercial
                    idSeccion = document.getElementById("secCedulaJuridica");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='cedulaJuridica' value=" + response.cedulaJuridica + ">";
                    //telefono
                    idSeccion = document.getElementById("secTelefono");
                    idSeccion.innerHTML += "<input type='number' class='form-control' id='telefonoLab' value=" + response.telefono + ">";
                    //correo
                    idSeccion = document.getElementById("secCorreo");
                    idSeccion.innerHTML += "<input type='email' class='form-control' id='correo' value=" + response.email + ">";
                    //razonSocial
                    idSeccion = document.getElementById("secRazonSocial");
                    idSeccion.innerHTML += "<textarea class='form-control' id='razonSocial'>" + response.razonSocial + "</textarea>";
                    //direccion
                    idSeccion = document.getElementById("secDireccionLab");
                    idSeccion.innerHTML += "<textarea class='form-control' id='direccion'>" + response.direccion + "</textarea>";
                    //CodigoPostal
                    idSeccion = document.getElementById("secCodigoPostal");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='codigoPostal' value=" + response.apartadoPostal + ">";
                    //PaginaWeb
                    idSeccion = document.getElementById("secPaginaWeb");
                    idSeccion.innerHTML += "<input type='text' class='form-control' id='paginaWeb' value=" + response.paginaWeb + ">";
                    //PaginaWeb
                    idSeccion = document.getElementById("secHabilitado");
                    if (response.estado == 1) {
                        idSeccion.innerHTML += "<input class='form-check-input' type='checkbox' id='cbEstadoLaboratorio' value='estado' checked>";
                        idSeccion.innerHTML += "<label class='form-check-label' for= 'flexSwitchCheckDefault' > Habilitar laboratorio</label>"
                    } else {
                        idSeccion.innerHTML += "<input class='form-check-input' type='checkbox' id='cbEstadoLaboratorio' value='estado' >";
                        idSeccion.innerHTML += "<label class='form-check-label' for= 'flexSwitchCheckDefault' > Habilitar laboratorio</label>"

                    }
                    //Para las imagenes
                    $("#primerImg").attr("src", response.imagen1);
                    $("#segundaImg").attr("src", response.imagen2);
                    $("#tercerImg").attr("src", response.imagen3);
                    $("#cuartaImg").attr("src", response.imagen4);
                    $("#quintaImg").attr("src", response.imagen5);
                    idLaboratorio = response.idLaboratorio;
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

    this.RealizarCambios = function () {

        $("#btnModificarDatos").click(function () {
            var idAdmin = localStorage.getItem('idUsuario');
            var laboratorio = {};
            laboratorio.idLaboratorio = idLaboratorio;
            laboratorio.nombre = $("#nombreLab").val();
            laboratorio.nombreComercial = $("#nombreComercialLab").val();
            laboratorio.cedulaJuridica = $("#cedulaJuridica").val();
            laboratorio.telefono = $("#telefonoLab").val();
            laboratorio.email = $("#correo").val();
            laboratorio.razonSocial = $("#razonSocial").val();
            laboratorio.direccion = $("#direccion").val();
            laboratorio.apartadoPostal = $("#codigoPostal").val();
            laboratorio.paginaWeb = $("#paginaWeb").val();
            laboratorio.idAdmin = idAdmin;
            laboratorio.imagen1 = document.getElementById("primerImg").src;
            laboratorio.imagen2 = document.getElementById("segundaImg").src;
            laboratorio.imagen3 = document.getElementById("tercerImg").src;
            laboratorio.imagen4 = document.getElementById("cuartaImg").src;
            laboratorio.imagen5 = document.getElementById("quintaImg").src;

            if ($("#cbEstadoLaboratorio").is(':checked')) {
                laboratorio.estado = 1;
            }
            else {
                laboratorio.estado = 0;
            }

            if (!ValidacionCamposVacios(nombreLab, nombreComercialLab, cedulaJuridica,
                telefonoLab, correo, razonSocial, direccion, codigoPostal, paginaWeb)) {
                Swal.fire({
                    icon: 'error',
                    title: 'Faltan campos.',
                    text: 'Todos los campos deben estar agregados.'
                });
            } else {
                /*Se ejecuta la llamada*/
                var urlApi = "http://localhost:44335/api/Laboratorio/ModificarLaboratorio";

                $.ajax({
                    headers: {
                        'Accept': "application/json",
                        'Content-Type': "application/json"
                    },
                    method: "POST",
                    url: urlApi,
                    contentType: "application/json",
                    data: JSON.stringify(laboratorio),
                    hasContent: true
                }).done(
                    function (response) {
                        console.log(response);
                        if (response.includes("exito")) {
                            Swal.fire({
                                title: 'EXITO',
                                text: response,
                                icon: 'success',
                                confirmButtonText: 'Aceptar'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    location.href = "/ModificacionLab/ModificacionLab";
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
                            text: "El servidor no esta activo, por favor espere."
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

    var view = new ModificarLab();
    view.InitView();

});

