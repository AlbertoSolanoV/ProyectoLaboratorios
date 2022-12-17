window.addEventListener('load', init, false);
var count = 0;
var cParametros = [];

document.getElementById("containRemove").classList.remove("container");
document.getElementById("containRemove").classList.remove("body-content");

function init() {
    var inputs = document.querySelectorAll('input');
    var textArea = document.getElementById('descExamen');

    for (var i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener('click', removeClass);
    }
    textArea.addEventListener('click', removeClass);
}


function removeClass(event) {
    var clases = event.currentTarget.classList;
    if (clases.contains('error')) {
        clases.remove('error');
    }
}


function registrar(event) {
    event.preventDefault();
    if (esVacio() == false) {
        envio();
        Swal.fire({
            title: 'Examen registrado',
            icon: 'success',
            text: 'Se realizo el registro con éxito',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                location.href = "/Home/mostrarTExamenes";
            }
        });

    } else {
        Swal.fire({
            title: 'Hay campos vacíos',
            icon: 'error',
            text: 'Porfavor rellene los campos marcados',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        })
    }
}

function envio() {
    var idLaboratorio;

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
                var urlApi = "http://localhost:44335/api/TipoExamen/RegistrarTipoExamen";

                var examen = {};
                examen.idTipoExamen = "";
                examen.idLaboratorio = idLaboratorio;
                examen.nombreTipoExamen = document.getElementById("tExamen").value;
                examen.descripcionTipoExamen = document.getElementById("descExamen").value;
                examen.precio = document.getElementById("pExamen").value;
                var parametros = "";
                cParametros.forEach(element => {
                    parametros += element + ",";
                });
                console.log(examen);
                examen.parametros = parametros
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


function esVacio() {
    var list = document.querySelectorAll("input");
    var textArea = document.getElementById("descExamen");
    var alerta = false;
    for (var i = 0; i < list.length; i++) {
        if (list[i].value == "" && list[i].id != "paramExamen") {
            list[i].classList.add("error");
            alerta = true;
        }
    }
    if (textArea.value == "") {
        textArea.classList.add("error");
        alerta = true;
    }
    return alerta;
}


function agregarParam() {
    var tabla = document.getElementById("tablaP");
    var dato = document.getElementById("paramExamen");
    if (dato.value == "") {
        Swal.fire({
            title: 'El campo esta vacío',
            icon: 'error',
            text: 'Por favor no deje el campo vacío',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        })
    } else {
        if (tabla.classList.contains("d-none") == true) {
            tabla.classList.remove("d-none");
        }
        cParametros.push(dato.value);
        var param = '<tr id=' + count + '><td>' + dato.value + '</td><td><button id="' + dato.value + '" class="borrar" onclick="borrar(event,' + count + ')">Borrar</button></td></tr>';
        tabla.innerHTML += param;
        dato.value = "";
        count++;
    }
}


function borrar(event, id) {
    event.preventDefault();
    var item = event.target.id;
    var borrado = document.getElementById(id);
    borrado.innerHTML = "";
    var temp = [];
    cParametros.forEach(dato => {
        if (dato != item) {
            temp.push(dato);
        }
    });
    cParametros = temp;
}

document.getElementById("pExamen").addEventListener("input", (e) => {
    let value = e.target.value;
    e.target.value = value.replace(/[^A-Z\d-]/g, "");
});