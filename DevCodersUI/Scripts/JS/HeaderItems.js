function HeaderItems() {
    this.InitView = function () {
        this.CargarHeader();
        $("#btnCerrarSesion").click(function () {
            localStorage.clear();
            location.href = "/Home/PaginaMain";
        });
    }


    this.CargarHeader = function () {
        var rol = sessionStorage.getItem('Rol');

        /*rol = "AdminLab";*/
        var header = document.getElementById("headerItems");
        if (rol == "Cliente") {
            header.innerHTML += " <li class='nav - link px - 2 link - secondary'> <a href = '/Home/PaginaMain' class='nav-link px-2 link-secondary' >Inicio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/UserProfile/UserProfile' class='nav-link px-2 link-dark' >Mi perfil</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Home/CitasCliente' class='nav-link px-2 link-dark'>Mis citas</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Home/mostrarHistorialExamenes' class='nav-link px-2 link-dark'>Mi historial</a></li";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Home/RegistroLaboratorio' class='nav-link px-2 link-dark'>Registrar laboratorio</a></li";

            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '' class='nav-link px-2 link-dark' id='btnCerrarSesion'>Cerrar sesión</a></li>";

        } else if (rol == "AdminPag") {
            header.innerHTML += " <li class='nav - link px - 2 link - secondary'> <a href = '/Home/PaginaMain'  class='nav-link px-2 link-secondary' >Inicio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/UserProfile/UserProfile' class='nav-link px-2 link-dark' >Mi perfil</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/AdministradorPagina/DashBoardPagina' class='nav-link px-2 link-dark'>Dashboard de la página</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Login/Login' class='nav-link px-2 link-secondary' id='btnCerrarSesion'>Cerrar sesión</a></li>";
        } else if (rol == "AdminLab") {
            header.innerHTML += " <li class='nav - link px - 2 link - secondary'> <a href = '/Home/PaginaMain'  class='nav-link px-2 link-secondary' >Inicio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/UserProfile/UserProfile' class='nav-link px-2 link-dark' >Mi perfil</a></li>";

            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/DashBoardLaboratorio/DashBoardLaboratorio' class='nav-link px-2 link-dark'>Dashboard Laboratorio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/DashBoardLaboratorio/CitasLaboratorio' class='nav-link px-2 link-dark'>Citas laboratorio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Home/registrarTExamenes' class='nav-link px-2 link-dark'>Registro Examenes laboratorio</a></li>"; 
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Home/mostrarTExamenes' class='nav-link px-2 link-dark'> Examenes laboratorio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/ModificacionLab/ModificacionLab' class='nav-link px-2 link-dark'>Modificar laboratorio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Login/Login' class='nav-link px-2 link-secondary' id='btnCerrarSesion' >Cerrar sesión</a></li>";
        } else if (rol == "TecnicoLab") {
            header.innerHTML += " <li class='nav - link px - 2 link - secondary'> <a href = '/Home/PaginaMain'  class='nav-link px-2 link-secondary' >Inicio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/UserProfile/UserProfile' class='nav-link px-2 link-dark' >Mi perfil</a></li>";

            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/DashBoardLaboratorio/CitasLaboratorio' class='nav-link px-2 link-dark'>Citas laboratorio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Home/registrarTExamenes' class='nav-link px-2 link-dark'>Registro Examenes laboratorio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Home/mostrarTExamenes' class='nav-link px-2 link-dark'> Examenes laboratorio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - dark'><a href = '/Login/Login' class='nav-link px-2 link-secondary' id='btnCerrarSesion'>Cerrar sesión</a></li>";
        } else {
            header.innerHTML += " <li class='nav - link px - 2 link - secondary'> <a href = '/Home/PaginaMain'  class='nav-link px-2 link-secondary' >Inicio</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - secondary'> <a href = '/Login/Login'  class='nav-link px-2 link-secondary' >Inicio de sesión</a></li>";
            header.innerHTML += " <li class='nav - link px - 2 link - secondary'> <a href = '/RegistroForm/RegistroForm'  class='nav-link px-2 link-secondary' >Registrarse</a></li>";
        }

    }



}


$(document).ready(function () {

    var view = new HeaderItems();
    view.InitView();

});

