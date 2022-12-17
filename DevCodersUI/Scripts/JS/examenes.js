window.addEventListener('load', init);
function init() {
    document.getElementById("containRemove").classList.remove("container");
    mostrarExamenes();
    //prepararExamen();
}



function prepararExamen() {
    var urlApi = "http://localhost:44335//api/TipoExamen/DevolverTExamen?idTExamen=" + 254;
    fetch(urlApi)
        .then(response => response.json())
        .then(repo => {
            envioExamen(repo);
        });
}

function envioExamen(lista) {
    var urlApi = "http://localhost:44335/api/Examen/RegistrarExamen";
    var examen = {};
    examen.idExamen = 0;
    examen.idlaboratorio = 1;
    examen.idTipoExamen = lista.idTipoExamen;
    examen.nombreExamen = lista.nombreTipoExamen;
    examen.estadoExamen = 0;
    examen.descripcionExamen = "descripcion de test";
    examen.precioExamen = lista.precio;
    examen.parametros = lista.parametros;
    examen.valores = "";
    $.ajax({
        headers: {
            'Accept': "application/json",
            'Content-Type': "application/json"
        },
        method: "POST",
        url: urlApi,
        contentType: "application/json",
        data: JSON.stringify(examen),
        hasContent: true
    });
}

function mostrarExamenes() {
    var urlApi = "http://localhost:44335//api/Examen/mostrarExamenLaboratorio?idCliente=" + localStorage.getItem("idLaboratorio");
    fetch(urlApi)
        .then(response => response.json())
        .then(repo => {
            generarLista(repo);
        });
}

var valores = [];

function generarLista(json) {
    var contenido = document.getElementById("contenido");
    var list = 0;
    var count = 0;
    for (var i = 0; i < json.length;i++) {
        var parametro = cParametro(json[i].parametros);
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
        if (json[i].estadoExamen == false) {
            estadoExa = '<button class="btn btn-danger" disabled><h1>Pendidente</h1></button>';
        } else {
            estadoExa = '<button class="btn btn-success" disabled><h1>Listo</h1></button>';
        }
        console.log(json[i]);
        var temp = document.getElementById(("lista" + String(list - 1)));
        temp.innerHTML += '<section class="examenes d-flex flex-column justify-content-center">' +
            '<section class="estado text-center">'+estadoExa+'</section>'+
            '<section class="text-center"><h2>' + json[i].nombreExamen + '</h2></section>' +
            '<p><b>Precio: </b>' + json[i].precioExamen + '</p>' +
            '<p><b>Descripci&oacute;n del examen: </b>' + json[i].descripcionExamen + '</p>' +
            '<p><b>Nombre del cliente: </b>' + json[i].nombreUsuario + '</p>' +
            '<p><b>Fecha de la cita: </b>' + json[i].horario + '</p>' +
            '<p><b>P&aacute;rametros: </b>' + parametro + '</p><div class="text-center">' +
            '<button onclick="modificar(' + json[i].idCita + ')" class="modificaBtn"><p>Revisar</p></button>' +
            '</div></section> ';
    };
}

function cParametro(dato) {
    var temp = "";
    for (var i = 0; i < (dato.length) - 1; i++) {
        temp += dato[i];
    }
    return temp;
}

function modificar(id) {
    params = [];
    var urlApi = "http://localhost:44335/api/Examen/mostrarUnExamen?idCita=" + id;
    fetch(urlApi)
        .then(response => response.json())
        .then(repo => {
            var textparam = crearParams(repo.parametros, repo.valores);
            Swal.fire({
                title: '<strong>Modificar Examen</strong>',
                html: '<div> <section class="input-group mb-3">' +
                    '<span class="input-group-text w-50">Nombre del examen</span>' +
                    '<input class="form-control type="text" id="mNExa" placeholder="' + repo.nombreExamen + '">' +
                    '</section><section class="input-group mb-3">' +
                    '<span class="input-group-text w-50">descripci&oacute;n del examen</span>' +
                    '<textarea class="form-control" id="mDescExa" placeholder="' + repo.descripcionExamen + '"></textarea>' +
                    '</section><section class="input-group mb-3">' +
                    '<span class="input-group-text w-50">Precio del examen</span>' +
                    '<input disabled class="form-control type="text" id="mPExa" placeholder="' + repo.precioExamen + '">' +
                    '</section><section class="input-group mb-3">' +
                    textparam +
                    '</section></div>',
                showCloseButton: true,
                showCancelButton: true,
                confirmButtonText: 'Modificar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    var nombre = document.getElementById("mNExa");
                    var desc = document.getElementById("mDescExa");
                    var precio = document.getElementById("mPExa");
                    var nombreParams = document.querySelectorAll('[name="valoresP"]');
                    var temp = "";
                    for (var i = 0; i < nombreParams.length; i++) {
                        if (nombreParams[i].value == "") {
                            temp += nombreParams[i].placeholder + ",";
                        } else {
                            temp += nombreParams[i].value + ",";
                        }
                    }

                    if (nombre.value == "") {
                        nombre = nombre.placeholder;
                    } else {
                        nombre = nombre.value;
                    }
                    if (desc.value == "") {
                        desc = desc.placeholder;
                    } else {
                        desc = desc.value;
                    }
                    if (precio.value == "") {
                        precio = precio.placeholder;
                    } else {
                        precio = precio.value;
                    }
                    urlApi = "http://localhost:44335//api/Examen/ModificarExamen";
                    var examen = {};
                    examen.nombreExamen = nombre;
                    examen.descripcionExamen = desc;
                    examen.valores = temp;
                    examen.idExamen = repo.idExamen;

                    $.ajax({
                        headers: {
                            'Accept': "application/json",
                            'Content-Type': "application/json"
                        },
                        method: "POST",
                        url: urlApi,
                        contentType: "application/json",
                        data: JSON.stringify(examen),
                        hasContent: true
                    }
                    )
                    window.location.reload();
                } else {

                }
                
            });
        })
        .catch(err => console.log(err));
}

function crearParams(data, valor) {
    var text = "";
    var params = [];
    for (var i = 0; i < data.length; i++) {
        if (data[i] == ",") {
            params.push(text);
            text = "";
        } else {
            text += data[i];
        }
    }
    if (valor != "") {
        text = "";
        for (var i = 0; i < valor.length; i++) {
            if (valor[i] == ",") {
                if (text == "undefined") {
                    text = "";
                }
                valores.push(text);
                text = "";
            } else {
                text += valor[i];
            }
        }
        var temp = '<table id="tablaP"><tr><th>P&aacute;rametro</th><th>Resultado</th></tr>';
        for (var i = 0; i < params.length; i++) {
            temp += '<tr id="para' + i + '">' +
                '<td>' +
                '<p class="input-group-text">' + params[i] + '</p>' +
                '</td>' +
                '<td>' +
                '<input name="valoresP" type="text" class="form-control" placeholder="' + valores[i] + '"></td></tr>';
        }
        temp += '</table>';
    } else {
        var temp = '<table id="tablaP"><tr><th>Parametro</th><th>Resultado</th></tr>';
        for (var i = 0; i < params.length; i++) {
            temp += '<tr id="para' + i + '">' +
                '<td>' +
                '<p class="input-group-text">' + params[i] + '</p>' +
                '</td>' +
                '<td>' +
                '<input name="valoresP" type="text" class="form-control" placeholder=" "></td></tr>';
        }
        temp += '</table>';
    }
    
    return temp;
}

