window.addEventListener('load', init);
function init() {
    document.getElementById("containRemove").classList.remove("container");
    cargarDatos();
}

function cargarDatos() {
    var urlApi = "https://localhost:44335//api/Examen/mostrarExamen?idCliente=" + 1;
    fetch(urlApi)
        .then(response => response.json())
        .then(repos => {
            mostrarDatos(repos);
        })
        .catch(err => console.log(err))
}