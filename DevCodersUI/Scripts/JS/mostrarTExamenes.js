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
var countador = null;

function cargarDatos() {
    console.log("Cargar");
    var rol = localStorage.getItem('Rol');
    if (rol == "AdminLab") {
        var urlApi = "http://localhost:44335/api/Laboratorio/LaboratorioInformacionAdmin?pIdAdmin=" + localStorage.getItem("idUsuario");
        console.log("admin");
    } else if (rol == "TecnicoLab") {
        var urlApi = "http://localhost:44335/api/Empleado/DevolverLabEmpleado?pIdEmpleado=" + localStorage.getItem("idUsuario");
        console.log("Tec");
    }

    $.ajax({
        headers: {
            'Accept': "application/json",
            'Content-Type': "application/json"
        },
        method: "GET",
        url: urlApi,
    }).done(
        function (response) {

            if (response === null) {
                Swal.fire({
                    icon: 'error',
                    title: 'ERROR',
                    text: 'No se pudo cargar su información de laboratorio, recargue la página.'
                });
            } else {
                console.log(response);
                idLaboratorio = response.idLaboratorio;
                var urlApi = "http://localhost:44335/api/TipoExamen/MostrarTodosTExamen?idCliente="+idLaboratorio;
                fetch(urlApi)
                    .then(response => response.json())
                    .then(repos => {
                        generarLista(repos);
                    })
                    .catch(err => console.log(err))
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
        count ++;
        var temp = document.getElementById(("lista" + String(list - 1)));
        temp.innerHTML += '<section class="examenes d-flex flex-column justify-content-center"><section class="text-center"><h2>' + element.nombreTipoExamen + '</h2></section><p><b>Precio: </b>' + element.precio + '</p><p><b>Descripci&oacute;n del examen: </b>' + element.descripcionTipoExamen + '</p><p><b>P&aacute;rametros: </b>' + parametro + '</p><div class="text-center"><button onclick="modificar(' + element.idTipoExamen + ')" class="modificaBtn"><p>Modificar</p></button></div></section> ';
    });
}

function cParametro(dato) {
    var temp = "";
    for (var i = 0; i < (dato.length)-1; i++) {
        temp += dato[i];
    }
    return temp;
}


function modificar(id) {
    params = [];
    var urlApi = "http://localhost:44335//api/TipoExamen/devolverTExamen?idTExamen=" + id;
    fetch(urlApi)
        .then(response => response.json())
        .then(repo => {
            var textparam = crearParams(repo.parametros);
            Swal.fire({
                title: '<strong>Modificar Examen</strong>',
                html: '<div> <section class="input-group mb-3">' +
                    '<span class="input-group-text w-50">Nombre del examen</span>' +
                    '<input class="form-control type="text" id="mNTExa" placeholder="'+repo.nombreTipoExamen+'">' +
                    '</section><section class="input-group mb-3">' +
                    '<span class="input-group-text w-50">Descripci&oacute;n del examen</span>' +
                    '<textarea class="form-control" id="mDescTExa" placeholder="'+repo.descripcionTipoExamen+'"></textarea>' +
                    '</section><section class="input-group mb-3">' +
                    '<span class="input-group-text w-50">Precio del examen</span>' +
                    '<input class="form-control type="text" id="mPTExa" placeholder="' + repo.precio + '">' +
                    '</section><section class="input-group mb-3">' +
                    '<span class="input-group-text w-50">Agregar p&aacute;rametros</span>' +
                    '<input type="text" class="form-control" id="agregaPara" placeholder="P&aacute;rametro">' +
                    '<input onclick="agregarP()" type="button" value="Agregar">' +
                    textparam +
                    '</section></div>',
                showCloseButton: true,
                showCancelButton: true,
                confirmButtonText: 'Modificar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    var nombre = document.getElementById("mNTExa");
                    var desc = document.getElementById("mDescTExa");
                    var precio = document.getElementById("mPTExa");
                    var nombreParams = document.querySelectorAll('[name="parametrosM"]');
                    var temp = "";
                    for (var i = 0; i < nombreParams.length; i++) {
                        if (nombreParams[i].classList.contains("d-none")) {
                        } else {
                            if (nombreParams[i].value == "") {
                                temp += nombreParams[i].placeholder + ",";
                            } else {
                                temp += nombreParams[i].value + ",";
                            }
                        }
                    }
                    console.log(temp);
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
                    urlApi = "http://localhost:44335//api/TipoExamen/ModificarTipoExamen";
                    var examen = {};
                    examen.nombreTipoExamen = nombre;
                    examen.descripcionTipoExamen = desc;
                    examen.precio = precio;
                    examen.parametros = temp;
                    examen.idTipoExamen = repo.idTipoExamen;

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
                    window.location.reload();
                }
            });
        })
        .catch(err => console.log(err))
}


function agregarP() {
    var dato = document.getElementById("agregaPara").value;
    params.push(dato);
    document.getElementById("tablaP").innerHTML += '<tr id="para'+(params.length+1)+'"><td><input type="text" class="form-control" name="parametrosM" placeholder="'+dato+'"></td><td><input type="button" onclick="borrar(para'+(params.length+1)+')" class="borrar" value="Borrar"></td></tr>';
}

function crearParams(data) {
    var text = "";
    for (var i = 0; i < data.length; i++) {
        if (data[i] == ",") {
            params.push(text);
            text = "";
        } else {
            text += data[i];
        }
    }
    var temp = '<table id="tablaP"><tr><th>Parametro</th><th>Borrar</th></tr>';
    for (var i = 0; i < params.length; i++) {
        temp += '<tr id="para'+i+'"><td><input type="text" class="form-control" name="parametrosM" placeholder="'+params[i]+'"></td><td><input onclick="borrar(para'+i+')" type="button" class="borrar" value="Borrar"></td></tr>';
    }
    temp += '</table>';
    return temp;
}


function borrar(dato) {
    var temp = dato.placeholder;
    contador = dato[4];
    console.log(contador);
    var listTemp = [];
    dato.classList.add("d-none");
    params.forEach(dato => {
        if (dato != temp) {
            listTemp.push(dato);
        }
    });
    params = temp;
}
