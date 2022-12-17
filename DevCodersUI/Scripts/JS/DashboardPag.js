function Dashboard() {
    this.InitView = function () {
        this.CargarLaboratorios();
        this.CambioSubscripcion();
        this.CambioIVA();
        this.CargarDatosFinan();
        this.CargarDatosBitacora();
    }



    this.CargarLaboratorios = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'nombreComercial' };
        arrayColumnsData[1] = { 'data': 'telefono' };
        arrayColumnsData[2] = { 'data': 'email' };
        arrayColumnsData[3] = { 'data': 'paginaWeb' };
        arrayColumnsData[4] = { 'data': 'idAdmin' };
        arrayColumnsData[5] = { 'data': 'estado' };

        var urlApi = "http://localhost:44335/api/Laboratorio/LaboratoriosInformacion";

        $('#tbLabSubs').DataTable({
            ajax: {
                method: "GET",
                url: urlApi,
                contentType: "application/json;charset=uft-8",
                dataSrc: function (json) {
                    var json = { 'data': json }

                    return json.data;
                }
            },
            columns: arrayColumnsData
        });

    }


    this.CambioSubscripcion = function () {

        $("#btnCambiarPrecioSub").click(function () {
            var nuevoPrecioSubs = $("#cantidadDescuento").val();

            var porcentaje = {};
            porcentaje.id = 2;
            porcentaje.porcentaje = nuevoPrecioSubs;


            if (!ValidacionCamposVacios(nuevoPrecioSubs)) {
                Swal.fire({
                    icon: 'error',
                    title: 'Faltan campos.',
                    text: 'Todos los campos deben estar agregados.'
                });
            } else {

                /*Se ejecuta la llamada*/
                var urlApi = "http://localhost:44335/api/Porcentaje/ModificarPorcentaje";

                $.ajax({
                    headers: {
                        'Accept': "application/json",
                        'Content-Type': "application/json"
                    },
                    method: "POST",
                    url: urlApi,
                    contentType: "application/json",
                    data: JSON.stringify(porcentaje),
                    hasContent: true
                }).done(
                    function (response) {
                        console.log(response);
                        if (response.includes("Exito")) {
                            Swal.fire({
                                title: 'EXITO',
                                text: response,
                                icon: 'success',
                                confirmButtonText: 'Aceptar'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    $("#nombreSub").attr("placeholder", "₡" + nuevoPrecioSubs);
                                    $("#cantidadDescuento").text("");
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

    this.CambioIVA = function () {

        $("#btnCambiarPrecioIVA").click(function () {
            var nuevoPrecioSubs = $("#cantidadIVA").val();

            var porcentaje = {};
            porcentaje.id = 1;
            porcentaje.porcentaje = nuevoPrecioSubs;


            if (!ValidacionCamposVacios(nuevoPrecioSubs)) {
                Swal.fire({
                    icon: 'error',
                    title: 'Faltan campos.',
                    text: 'Todos los campos deben estar agregados.'
                });
            } else {

                /*Se ejecuta la llamada*/
                var urlApi = "http://localhost:44335/api/Porcentaje/ModificarPorcentaje";

                $.ajax({
                    headers: {
                        'Accept': "application/json",
                        'Content-Type': "application/json"
                    },
                    method: "POST",
                    url: urlApi,
                    contentType: "application/json",
                    data: JSON.stringify(porcentaje),
                    hasContent: true
                }).done(
                    function (response) {
                        console.log(response);
                        if (response.includes("Exito")) {
                            Swal.fire({
                                title: 'EXITO',
                                text: response,
                                icon: 'success',
                                confirmButtonText: 'Aceptar'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    $("#nombreIVA").attr("placeholder", nuevoPrecioSubs + "%");
                                    $("#cantidadIVA").text("");
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


    this.CargarDatosFinan = function () {
        var urlApi = "http://localhost:44335/api/Porcentaje/DevolverPorcentajes";

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
                    var seccionSub = document.getElementById("seccionSub");
                    seccionSub.innerHTML += "<input type='text' class='form-control' id='nombreSub' placeholder=" + response[1].porcentaje + " disabled>"
                    var seccionSub = document.getElementById("seccionIVA");
                    seccionSub.innerHTML += "<input type='text' class='form-control' id='nombreIVA' placeholder=" + response[0].porcentaje + " disabled>"
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


        var urlApi = "http://localhost:44335/api/FacturaLaboratorio/FacturasLaboratoriosInfo";

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
                    const ctx = document.getElementById('myChart');
                    const meses = [];
                    const ganancias = [];
                    const cantidad = [];
                    for (let i = 0; i < response.length; i++) {
                        meses.push(response[i].mes);
                        ganancias.push(response[i].total);
                        cantidad.push(response[i].id);
                    }
                    console.log(meses);


                    new Chart(ctx, {
                        type: 'bar',
                        data: {
                            labels: meses,
                            datasets: [{
                                label: 'Ganancias por meses',
                                data: ganancias,
                                borderWidth: 1
                            },
                            {
                                type: 'line',
                                label: 'Cantidad de subscripciones',
                                data: cantidad,
                            }],
                        },
                        options: {
                            scales: {
                                y: {
                                    beginAtZero: true
                                }
                            }
                        }
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

    this.SeleccionarMes = function () {

        document.getElementById("favourite").value;


    }

    this.CargarDatosBitacora = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'accion' };
        arrayColumnsData[1] = { 'data': 'fecha' };
        arrayColumnsData[2] = { 'data': 'nombreRol' };
        arrayColumnsData[3] = { 'data': 'nombreUsuario' };

        var urlApi = "http://localhost:44335/api/Bitacora/DevolverBitacora";

        $('#tbUsuarios').DataTable({
            ajax: {
                method: "GET",
                url: urlApi,
                contentType: "application/json;charset=uft-8",
                dataSrc: function (json) {
                    var json = { 'data': json }

                    return json.data;
                }
            },
            columns: arrayColumnsData
        });


    }

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

    var view = new Dashboard();
    view.InitView();
});

function MesSeleccionar() {
    var mylist = document.getElementById("myList");
    document.getElementById("mesSeleccioando").value = mylist.options[mylist.selectedIndex].text;
}