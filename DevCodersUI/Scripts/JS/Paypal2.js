function Paypal2() {
    var total = 0;
    this.InitView = function () {
       total = $("#txtPayTotal").val();
        console.log(total);
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
                    
                    var crear = new Paypal2();
                    crear.CrearFactura();
                });

            }

        }).render('#paypal-button-container');

    }
    this.CrearFactura = function () {
        let rnd = Math.floor(Math.random() * 1001);
        factura = {}

        factura.total = $("#txtPayTotal").val();
        factura.subTotal = $("#txtPaySubTotal").val();
        factura.IVA = $("#txtPayIVA").val();
        factura.descuentos = $("#txtPayDescuento").val();
        factura.clave = rnd;
        factura.idOrdenCompra = $("#txtPayOrden").val();
        console.log(factura);

        var urlApi = "http://localhost:44335/api/Factura/RegistrarFactura";
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
        }).done(function (response) {
            if (response === "Exito") {
                //Si se crea el Order, se redirecciona al link de Paypal para el check
                Swal.fire({
                    title: 'EXITO',
                    text: response,
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        localStorage.removeItem("idOrdenLocal");
                        localStorage.removeItem("carrito");

                        
                        location.href = "/Home/CitasCLiente";
                    }
                })
            }
            else {
                var mens = "Hubo un error " + response.Message;
                alert(mens);
            }
        }
        ).fail(function () {
            alert('Hubo un problema al hacer el pago');

        });
    }
}

$(document).ready(function () {
    var view = new Paypal2();
    view.InitView();
})