let tablaCita;
let tablaCitaLab;
let idFactura;
let idExamenOrden;
function CitasCliente() {
    let idUsuario = localStorage.getItem('idUsuario');
    this.InitView = function () {

        this.CargarInfoLab();
        this.CargarCitasRegistradas();
    }

    this.CargarInfoLab = function () {

        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'idFactura' };
        arrayColumnsData[1] = { 'data': 'nombreLab' };
        arrayColumnsData[2] = { 'data': 'nombreExamen' };
        arrayColumnsData[3] = { 'data': 'fechaEmision' };
        arrayColumnsData[4] = {
            "render": function (data, type, full) { return '<button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalCita" data-bs-whatever="Nuevo">Agendar</button>' }
        };

        var urlApi = "http://localhost:44335/api/ExamenSinFactura/DevolverDatos?idCliente=" + idUsuario;

        tablaCita = $('#tbFacturaCita').DataTable({
            ajax: {
                method: "GET",
                url: urlApi,
                contentType: "application/json;charset=uft-8",
                dataSrc: function (json) {
                    console.log(json);
                    var json = { 'data': json }

                    return json.data;
                }
            },
            columns: arrayColumnsData,
            retrieve: true,
            columnDefs: [
                {
                    targets: -1,
                    data: null,
                    defaultContent: '<button>Click!</button>',

                },
            ],

        });
        $('#tbFacturaCita').on('click', 'button', function () {
            var tr = $(this).closest('tr');
            var data = $('#tbFacturaCita').DataTable().row(tr).data();
            console.log(data);
            var vista = new CitasCliente();
            idFactura = data.idFactura;
            idExamenOrden = data.idExamenOrden;
            vista.CargarCitasLab(data.idLaboratorio);
        });
    }


    this.CargarCitasLab = function (idLab) {
        console.log("Entro a cargar citasLab");

        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'horario' };
        arrayColumnsData[1] = { "render": function (data, type, full) { return '<div class="btn-group"> <button type="button"  class="btn btn-light">Agendar cita</button></div>' } };

        var urlApi = "http://localhost:44335/api/CitasLab/DevolverCitasLab?pIdLab=" + idLab;

        tablaCitaLab = $('#tbHorarioLab').DataTable({
            ajax: {
                method: "GET",
                url: urlApi,
                contentType: "application/json;charset=uft-8",
                dataSrc: function (json) {
                    console.log(json);
                    var json = { 'data': json }

                    return json.data;
                }
            },
            columns: arrayColumnsData,
            retrieve: true,
            columnDefs: [
                {
                    targets: -1,
                    data: null,
                    defaultContent: '<button>Click!</button>',

                },
            ],

        });
        $('#tbHorarioLab tbody').on('click', 'button', function () {
            var tr = $(this).closest('tr');
            var data = $('#tbHorarioLab').DataTable().row(tr).data();
            console.log(data);
            var vista = new CitasCliente();
            vista.RegistrarCita(data);
        });
    }

    this.RegistrarCita = function (data) {

        var citaExamen = {};
        citaExamen.idCita = data.idCita;
        citaExamen.idFactura = idFactura;
        citaExamen.idExamenOrden = idExamenOrden;
        console.log(citaExamen);
        /*Se ejecuta la llamada*/
        var urlApi = "http://localhost:44335/api/ExamenSinFactura/CrearCitaClienteLab";

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: urlApi,
            contentType: "application/json",
            data: JSON.stringify(citaExamen),
            hasContent: true
        }).done(
            function (response) {
                console.log(response);
                if (response.includes("Exito")) {
                    Swal.fire({
                        title: 'EXITO',
                        text: response,
                        icon: 'success',
                        confirmButtonText: 'Aceptar'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var table = $('#tbCitasAgendadas').DataTable();
                            table.ajax.reload();
                            var table = $('#tbHorarioLab').DataTable();
                            table.ajax.reload();
                            var table = $('#tbFacturaCita').DataTable();
                            table.ajax.reload();
                        }
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'ERROR',
                        text: response
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

    this.CargarCitasRegistradas = function () {
        console.log("Entro a cargar citas cliente registradas");
 
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'idFactura' };
        arrayColumnsData[1] = { 'data': 'nombreLab' };
        arrayColumnsData[2] = { 'data': 'nombreExamen' };
        arrayColumnsData[3] = { 'data': 'fechaEmision' };
        arrayColumnsData[4] = { "render": function (data, type, full) { return '<div class="btn-group"> <button type="button"  class="btn btn-light">Cancelar cita</button></div>' } };

        var urlApi = "http://localhost:44335/api/ExamenSinFactura/DevolverCitasCliente?idCliente=" + idUsuario;

        tablaCitaLab = $('#tbCitasAgendadas').DataTable({
            ajax: {
                method: "GET",
                url: urlApi,
                contentType: "application/json;charset=uft-8",
                dataSrc: function (json) {
                    console.log(json);
                    var json = { 'data': json }

                    return json.data;
                }
            },
            columns: arrayColumnsData,
            retrieve: true,
            columnDefs: [
                {
                    targets: -1,
                    data: null,
                    defaultContent: '<button>Click!</button>',

                },
            ],

        });
        $('#tbCitasAgendadas tbody').on('click', 'button', function () {
            var tr = $(this).closest('tr');
            var data = $('#tbCitasAgendadas').DataTable().row(tr).data();
            console.log(data);
            var vista = new CitasCliente();
            vista.CancelarCita(data.idCita);
        });
    }

    this.CancelarCita = function (idCita) {

        var citaExamen = {};
        citaExamen.idCitas = idCita;

        console.log(citaExamen);
        /*Se ejecuta la llamada*/
        var urlApi = "http://localhost:44335/api/Citas/CancelarCita";

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: urlApi,
            contentType: "application/json",
            data: JSON.stringify(citaExamen),
            hasContent: true
        }).done(
            function (response) {
                console.log(response);
                if (response.includes("Exito")) {
                    Swal.fire({
                        title: 'EXITO',
                        text: response,
                        icon: 'success',
                        confirmButtonText: 'Aceptar'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var table = $('#tbCitasAgendadas').DataTable();
                            table.ajax.reload();
                            var table = $('#tbHorarioLab').DataTable();
                            table.ajax.reload();
                            var table = $('#tbFacturaCita').DataTable();
                            table.ajax.reload();
                            
                        }
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'ERROR',
                        text: response
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

}


$(document).ready(function () {

    var view = new CitasCliente();

    view.InitView();

});

