function EnvioCorreo() {

    this.InitView = function () {
        $("#btnReinicioContraseña").click(function () {
            var vista = new EnvioCorreo();
            vista.EnvioCorreo();

        });
    }

    this.EnvioCorreo = function (pDestinatario) {
        var urlSMS = "http://localhost:44335/api/Email/sendEmail?to=" + pDestinatario;
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
            console.log("correo enviado con exito");
        }).fail(function () {
            console.log("correo fallo");
        });
    };
}

$(document).ready(function () {

    var view = new CrearRegistro();
    view.InitView();


})