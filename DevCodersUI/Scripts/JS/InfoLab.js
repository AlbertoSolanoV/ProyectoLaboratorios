const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const idLab = urlParams.get('id');

function InfoLab() {

    this.InitView = function () {
        this.CargarPantalla();
        this.CargarExamenes();
    }


    this.CargarPantalla = function () {
        console.log(idLab);
        var urlApi = "http://localhost:44335/api/InfoLab/LaboratorioInformacion?pidLaboratorio=" + idLab;
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


                        var seccionCarrousel = document.getElementById("carrousel");
                        seccionCarrousel.innerHTML += " <div class='carousel-item active'>" +
                            "<img src=" + response.imagen1 + " class='d-block w-100' style='max-height:500px' >" +
                            "</div>";
                        seccionCarrousel.innerHTML += " <div class='carousel-item'>" +
                            "<img src=" + response.imagen2 + " class='d-block w-100' style='max-height:500px' >" +
                            "</div>";
                        seccionCarrousel.innerHTML += " <div class='carousel-item'>" +
                            "<img src=" + response.imagen3 + " class='d-block w-100' style='max-height:500px' >" +
                            "</div>";
                        seccionCarrousel.innerHTML += " <div class='carousel-item'>" +
                            "<img src=" + response.imagen4 + " class='d-block w-100' style='max-height:500px' >" +
                            "</div>";
                        seccionCarrousel.innerHTML += " <div class='carousel-item'>" +
                            "<img src=" + response.imagen5 + " class='d-block w-100' style='max-height:500px' >" +
                            "</div>";

                        var seccionInfo = document.getElementById("seccionInfo");
                        seccionInfo.innerHTML += "<div class='card-header' >" + response.nombreComercial + "</div > " +
                            "<div class='card-body'>" +
                            "<h5 class='card-title'>Direccion</h5>" +
                            "<p class='card-text'>" + response.direccion + "</p>" +
                            "</div>";

                        var seccionComu = document.getElementById("seccionContacto");
                        seccionComu.innerHTML += "<div class='card-body'>" +
                            " <h5 class='card-title'> Correo</h5 >" +
                            " <p class='card-text'>" + response.email + "</p>  </div>" +
                            " <div class='card-body'>" +
                            "<h5 class='card-title'>Telefono</h5>" +
                            " <p class='card-text'>" + response.telefono + "</p></div>"

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
    this.CargarExamenes = function () {
        console.log(idLab);
        var urlApi = "http://localhost:44335/api/ExamenInfoLab/InformacionExamen?pIdExamen=" + idLab;
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
                    var seccionExamenes = document.getElementById("catalogo");
                    console.log(seccionExamenes)

                    for (let i = 0; i < response.length; i++) {
                        seccionExamenes.innerHTML += "<div class='col-sm-6  mb-3'>" +
                            "<div class='card'>" +
                            "<div class='card-body'>" +
                            "<h4 class='title is-4' id='txtNomExamen'>" + response[i].nombreExamen + "</h4>" +
                            "<p class='card-text' id='txtDescripcion'>" + response[i].tipoExamen + "</p>" +
                            "<p class='card-text' id='txtDescripcion'>" + response[i].descripcionExamen + "</p>" +
                            "<h4 class='subtitle is-4'>Precio: <strong>" + response[i].precioExamen + "</strong></h4>" +
                            "<div class='card-footer'>" +
                            "<a href='' class='card-footer-item' id='addItem' data-producto=' "+ response[i].idExamen+"'>Agregar al carrito</a>" +
                            "</div></div></div> </div>";
                    }
                    

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

//Validacion de campos
function ValidacionCamposVacios(...args) {

    for (let arg of args) {
        if (arg == "") {
            return false;
        }
    }
    return true;
}

$(document).ready(function () {

    var view = new InfoLab();
    view.InitView();

});

