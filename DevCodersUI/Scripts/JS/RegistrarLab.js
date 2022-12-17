
function RegistrarLab() {
    var total = 0;
    var IVA = 0;
    var subTotal = 0;

    this.InitView = function () {

        this.CargarCosto();
        this.validarData();
        paypal.Buttons({

            createOrder: function (data, actions) {
                // This function sets up the details of the transaction, including the amount and line item details.
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: (total / 600).toFixed(2), //total es el elemento donde tenemos el monto. El monto es numerico con solo dos decimales. Solo funciona en dolares (Por eso la division)
                            currency_code: "USD"
                        }
                    }]
                });
            },

            onApprove: function (dataPaypal, actions) {
                return actions.order.capture().then(function (details) {

                    RegistrarLaboratorio();

                });

            }

        }).render('#paypal-button-container');

    }



    this.CargarCosto = function () {

        document.querySelector('#paypal-button-container').style.display = 'none';

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
                    var seccionSub = document.getElementById("seccCostoSub");
                    seccionSub.innerHTML += "<input type='text' class='form-control' id='nombreSub' placeholder=" + response[1].porcentaje + " disabled>"
                    subTotal = response[1].porcentaje;
                    IVA = response[0].porcentaje;
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

    this.validarData = function () {
        $("#btnRegistro").click(function () {
            var laboratorio = {};

            laboratorio.nombre = $("#nombreLab").val();
            laboratorio.nombreComercial = $("#nombreComercialLab").val();
            laboratorio.cedulaJuridica = $("#cedulaJuridica").val();
            laboratorio.telefono = $("#telefonoLab").val();
            laboratorio.email = $("#correo").val();
            laboratorio.razonSocial = $("#razonSocial").val();
            laboratorio.direccion = $("#direccion").val();
            laboratorio.apartadoPostal = $("#codigoPostal").val();
            laboratorio.paginaWeb = $("#paginaWeb").val();
            laboratorio.idAdmin = localStorage.getItem('idUsuario');

            laboratorio.imagen1 = document.getElementById("primerImg").src;
            laboratorio.imagen2 = document.getElementById("segImg").src;
            laboratorio.imagen3 = document.getElementById("terImg").src;
            laboratorio.imagen4 = document.getElementById("cuarImg").src;
            laboratorio.imagen5 = document.getElementById("quintaImg").src;

            if (!ValidacionCamposVacios(laboratorio.nombreLab, laboratorio.nombreComercialLab, laboratorio.cedulaJuridica,
                laboratorio.telefonoLab, laboratorio.correo, laboratorio.razonSocial, laboratorio.direccion, laboratorio.codigoPostal, laboratorio.paginaWeb)) {
                Swal.fire({
                    icon: 'error',
                    title: 'Faltan campos.',
                    text: 'Todos los campos deben estar agregados.'
                });
            } else if (!ValidacionCorreo(laboratorio.email)) {

                Swal.fire({
                    icon: 'error',
                    title: 'Correo.',
                    text: 'El formato del correo no es valido.'
                });
            } else {
                GenerarFactura();
                document.querySelector('#validarCampos').style.display = 'none';
                document.querySelector('#paypal-button-container').style.display = 'inline';
            }
        });
    }

    function RegistrarLaboratorio() {

        var laboratorio = {};

        laboratorio.nombre = $("#nombreLab").val();
        laboratorio.nombreComercial = $("#nombreComercialLab").val();
        laboratorio.cedulaJuridica = $("#cedulaJuridica").val();
        laboratorio.telefono = $("#telefonoLab").val();
        laboratorio.email = $("#correo").val();
        laboratorio.razonSocial = $("#razonSocial").val();
        laboratorio.direccion = $("#direccion").val();
        laboratorio.apartadoPostal = $("#codigoPostal").val();
        laboratorio.paginaWeb = $("#paginaWeb").val();
        laboratorio.idAdmin = localStorage.getItem('idUsuario');

        laboratorio.imagen1 = document.getElementById("primerImg").src;
        laboratorio.imagen2 = document.getElementById("segImg").src;
        laboratorio.imagen3 = document.getElementById("terImg").src;
        laboratorio.imagen4 = document.getElementById("cuarImg").src;
        laboratorio.imagen5 = document.getElementById("quintaImg").src;

        var urlApi = "http://localhost:44335/api/Laboratorio/RegistrarLaboratorio";

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
                if (response == "Error") {
                    Swal.fire({
                        icon: 'error',
                        title: 'ERROR',
                        text: response
                    });
                } else {
                    var factura = {};

                    factura.idLaboratorio = response;
                    factura.total = total;
                    factura.subTotal = subTotal;
                    factura.IVA = IVA;

                    var urlApi = "http://localhost:44335/api/FacturaLaboratorio/RegistrarFacturaLaboratorio";
                    console.log(factura);
                    $.ajax({
                        headers: {
                            'Accept': "application/json",
                            'Content-Type': "application/json"
                        },
                        method: "POST",
                        url: urlApi,
                        contentType: "application/json",
                        data: JSON.stringify(factura),
                        hasContent: true
                    }).done(
                        function (response) {
                            localStorage.setItem('Rol', 'AdminLab')
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
        ).fail(
            function () {
                Swal.fire({
                    icon: 'error',
                    title: 'ERROR',
                    text: "El servidor no esta activo, por favor espere."
                });
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
    function ValidacionCorreo(email) {

        return email.includes("@");
    }

    function GenerarFactura() {

        IVA = subTotal * (IVA / 100);
        total = subTotal + IVA;
    }


}


$(document).ready(function () {

    var view = new RegistrarLab();
    view.InitView();

});

