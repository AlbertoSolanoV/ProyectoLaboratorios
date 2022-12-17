function PaginaMain() {

    this.InitView = function () {
        var prueba = localStorage.getItem("idUsuario");
        console.log(prueba);
        this.CargarPantalla();
    }


    this.CargarPantalla = function () {

        var urlApi = "http://localhost:44335/api/Laboratorio/LaboratoriosInformacion";

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
                var prueba = localStorage.getItem("idUsuario");
                console.log(prueba);
                if (response === null) {
                    Swal.fire({
                        icon: 'error',
                        title: 'ERROR',
                        text: 'No se pudo cargar su información de laboratorio, recargue la página.'
                    });
                } else {
                    var lab = document.getElementById("seccionLaboratorios");

                    for (let i = 0; i < response.length; i++) {
                        lab.innerHTML += " <div class='col-sm-6 mb-3'><div class='card' ><div class='card-body'> <img src=" + response[i].imagen1 + " class='card-img-top mt-2' > <h5 class='card-title'>" + response[i].nombreComercial + "</h5> <p class='card-text'>" + response[i].direccion + "</p> <a href=/InformacionLabs/InformacionLabs?id=" + response[i].idLaboratorio +" class='btn btn-primary'>Ver laboratorio</a></div></div></div>";


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

    var view = new PaginaMain();
    view.InitView();

});

