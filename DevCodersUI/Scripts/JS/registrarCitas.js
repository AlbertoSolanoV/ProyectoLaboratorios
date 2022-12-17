function registrar(event) {
    event.preventDefault();
    if (esVacio() == false) {
        Swal.fire({
            title: 'Cita registrada',
            icon: 'success',
            text: 'Se realizo el registro con exito',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        })
    }
}

function esVacio() {
    var list = document.querySelectorAll("input");
    var select = document.getElementById("TExamen");
    var alerta = false;
    for (var i = 0; i < list.length; i++) {
        if (list[i].value == "") {
            list[i].classList.add("error");
            alerta = true;
        }
    }
    if (select.value == 0) {
        select.classList.add("error");
        alerta = true;
    }
    if (alerta == true) {
        Swal.fire({
            title: 'No se puedo realizar el registro',
            icon: 'error',
            text: 'No puede dejar campos vacios',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        })
    }
    return alerta;
}

window.addEventListener('load', init, false);

function init() {
    document.getElementById("containRemove").classList.remove("container");
    var inputs = document.querySelectorAll('input');
    var selects = document.getElementById('TExamen');

    for (var i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener('click', removeClass);
    }
    selects.addEventListener('click', removeClass);
    selects.addEventListener('click', descExamen);
}

function descExamen() {
    var select = document.getElementById('TExamen');
    if (select.value == 1) {
        document.getElementById("descEx").innerHTML = "Nombre y descripción del primer examen";
        document.getElementById("precio").innerHTML = "3000";
    } else if (select.value == 2) {
        document.getElementById("descEx").innerHTML = "Nombre y descripción del segundo examen";
        document.getElementById("precio").innerHTML = "8000";
    }
}

function removeClass(event) {
    var clases = event.currentTarget.classList;
    if (clases.contains('error')) {
        clases.remove('error');
    }
}