function ObtenerRol() {
    this.InitView = function () {
        this.CargarRol();
    }


    this.CargarRol = function () {
        var rol = sessionStorage.getItem('Rol');
        console.log(rol);
            return rol;

        
    };
};



$(document).ready(function () {

    var view = new HeaderItems();
    view.InitView();

});