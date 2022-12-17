function CierreSesion() {

    this.InitView = function () {

        var vista = new CierreSesion();
        vista.CerrarSesion();


    }
    this.CerrarSesion = function () {
        $("#btnCerrarSesion").on("click", function () {
            localStorage.clear();
            sessionStorage.clear();
        });
    };
}



$(document).ready(function () {

    var view = new CierreSesion();
    view.InitView();

})






