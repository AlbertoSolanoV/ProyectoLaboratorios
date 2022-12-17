function Paypal() {
    this.appApiURL = "http://localhost:44335";
    this.appApiURL_Azure = "";

    this.InitView = function () {
        $("#btnPayPagar").click(function () {
            var vista = new Paypal();
            vista.PagarPaypal();
        });      
    }


    this.GetUrlApiService = function (service) {
        var hostname = $(location).attr('hostname');
        if (hostname === "localhost")
            return this.appApiURL + service;
        else
            return this.appApiURL_Azure + service;
    }

    this.PagarPaypal = function () {

        var orden = {}

        orden.NombreLab = $("#txtPayLab").val();
        orden.NombreCliente = $("#txtPayUsuario").val();
        orden.Total = $("#txtPayTotal").val();
        console.log(orden);
        var urlAPI = this.GetUrlApiService("/api/Paypal/CreatePaypalOrder");

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: urlAPI,
            contentType: "application/json",
            data: JSON.stringify(orden),
            hasContent: true
        }).done(function (response) {
            if (response.Result === "OK") {
                //Si se crea el Order, se redirecciona al link de Paypal para el check
                location.href = response.Data;
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
    var view = new Paypal();
    view.InitView();
})