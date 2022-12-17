window.addEventListener('load', init);
function init() {
    document.getElementById("containRemove").classList.remove("container");
    cargarDatos();
    var btn = document.querySelectorAll("button");
    for (var i = 0; i < btn.length; i++) {
        btn[i].addEventListener("click", modificar);
    }
}

var params = [];

function cargarDatos() {
    var urlApi = "http://localhost:44335//api/Examen/MostrarExamenUsuario?idUsuario=" + localStorage.getItem("idUsuario");
    fetch(urlApi)
        .then(response => response.json())
        .then(repos => {
            generarLista(repos);
        })
        .catch(err => console.log(err))

}

function generarLista(json) {
    var contenido = document.getElementById("contenido");
    var list = 0;
    var count = 0;
    json.forEach(element => {
        var parametro = cParametro(element.parametros);
        if (count == 0) {
            contenido.innerHTML += '<div id="lista' + list + '" class="d-flex flex-row justify-content-center"></div>';
            list++;
        } else if (count == 3) {
            contenido.innerHTML += '<div id="lista' + list + '" class="d-flex flex-row justify-content-center"></div>';
            list++;
            count = 0;
        }
        count++;
        var estadoExa = ""
        if (element.estadoExamen == false) {
            estadoExa = '<button class="btn btn-danger" disabled><h1>Pendidente</h1></button>';
        } else {
            estadoExa = '<button class="btn btn-success" disabled><h1>Listo</h1></button>';
        }
        var temp = document.getElementById(("lista" + String(list - 1)));
        temp.innerHTML += '<section class="examenes d-flex flex-column justify-content-center">' +
            '<section class="estado text-center">' + estadoExa + '</section>' +
            ' <section class="text-center"><h2>' + element.nombreExamen + '</h2>' +
            '</section><p><b>Precio: </b>' + element.precioExamen + '</p>' +
            '<p><b>Laboratorio: </b>' + element.nombreComercial + '</p>' +
            '<p><b>Descripci&oacute;n del examen: </b>' + element.descripcionExamen + '</p>' +
            '<p><b>P&aacute;rametros: </b>' + parametro + '</p>' +
            '<p><b>Valores: </b>' + element.valores + '</p><div class="text-center">' +
            '<p><b>Fecha del examen: </b>' + element.horario + '</p>' +

            '</div></section> ';
    });
}

function cParametro(dato) {
    var temp = "";
    for (var i = 0; i < (dato.length) - 1; i++) {
        temp += dato[i];
    }
    return temp;
}