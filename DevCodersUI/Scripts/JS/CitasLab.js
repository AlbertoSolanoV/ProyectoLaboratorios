let tablaCita;
let tablaCitaLab;
function CitasLab() {

    let idUsuario = localStorage.getItem('idUsuario');
    let idLaboratorio = 0;
    this.InitView = function () {

        this.CargarInfoLab();
        this.RegistrarCita();

        var today = new Date();
        var dd = today.getDate();

        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }
        today = mm + '/' + dd + '/' + yyyy;
        console.log(today)
        $('#horarioCitaCrea').daterangepicker({
            "singleDatePicker": true,
            "timePicker": true,
            "timePicker24Hour": true,
            "startDate": today,
            "minDate": today,
            locale: {
                format: 'MM/DD/YYYY hh:mm A'
            }
        }, function (start, end, label) {
            console.log(start.format('MM/DD/YYYY hh:mm A'));
        });

    }
    this.CargarInfoLab = function () {
        var rol = localStorage.getItem('Rol');
        if (rol == "AdminLab") {
            var urlApi = "http://localhost:44335/api/Laboratorio/LaboratorioInformacionAdmin?pIdAdmin=" + idUsuario;
            console.log("admin");
        } else if (rol == "TecnicoLab") {
            var urlApi = "http://localhost:44335/api/Empleado/DevolverLabEmpleado?pIdEmpleado=" + idUsuario;
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
                    console.log(idLaboratorio);
                    var cita = new CitasLab();
                    cita.CargarCitasExamen(response.idLaboratorio);
                    cita.CargarCitasLab(response.idLaboratorio);
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

    this.CargarCitasExamen = function (idLab) {
        console.log("Entro a cargar citas");

        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'usuario' };
        arrayColumnsData[1] = { 'data': 'email' };
        arrayColumnsData[2] = { 'data': 'telefono' };
        arrayColumnsData[3] = { 'data': 'horario' };
        arrayColumnsData[4] = { 'data': 'nombreExamen' };
        arrayColumnsData[5] = { "render": function (data, type, full) { return '<div class="btn-group"> <button type="button"  class="btn btn-light" >Agregar resultado</button></div>' } };

        var urlApi = "http://localhost:44335/api/Citas/DevolverCitasLab?pId=" + idLab;

        tablaCita = $('#tbCitasCreadas').DataTable({
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
            columnDefs: [
                {
                    targets: -1,
                    data: null,
                    defaultContent: '<button>Click!</button>',

                },
            ],

        });

        $('#tbCitasCreadas').on('click', 'button', function () {
            var tr = $(this).closest('tr');
            var data = $('#tbCitasCreadas').DataTable().row(tr).data();
            console.log(data);
            var cita = new CitasLab();
            cita.CargarExamenCliente(data.idCitas);
        });

    }

    this.CargarCitasLab = function (idLab) {
        console.log("Entro a cargar citasLab");

        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'horario' };
        arrayColumnsData[1] = { "render": function (data, type, full) { return '<div class="btn-group"> <button type="button"  class="btn btn-light">Eliminar cita</button></div>' } };

        var urlApi = "http://localhost:44335/api/CitasLab/DevolverCitasLab?pIdLab=" + idLab;

        tablaCitaLab = $('#tbCitasHabilitadas').DataTable({
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
            columnDefs: [
                {
                    targets: -1,
                    data: null,
                    defaultContent: '<button>Click!</button>',

                },
            ],

        });

        $('#tbCitasHabilitadas').on('click', 'button', function () {
            var tr = $(this).closest('tr');
            var data = $('#tbCitasHabilitadas').DataTable().row(tr).data();
            console.log(data);
            var cita = new CitasLab();
            cita.EliminarCita(data.idCita);
        });

  
    }

    this.RegistrarCita = function () {

        $("#btnCrearHorarioCita").click(function () {
            var nuevoCita = $("#horarioCitaCrea").val();

            var Cita = {};
            Cita.idLaboratorio = idLaboratorio;
            Cita.horario = nuevoCita;

            if (!ValidacionCamposVacios(nuevoCita.horario)) {
                Swal.fire({
                    icon: 'error',
                    title: 'Faltan campos.',
                    text: 'Todos los campos deben estar agregados.'
                });
            } else {

                /*Se ejecuta la llamada*/
                var urlApi = "http://localhost:44335/api/CitasLab/RegistrarCitaLab";

                $.ajax({
                    headers: {
                        'Accept': "application/json",
                        'Content-Type': "application/json"
                    },
                    method: "POST",
                    url: urlApi,
                    contentType: "application/json",
                    data: JSON.stringify(Cita),
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
                                    var table = $('#tbCitasHabilitadas').DataTable();
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

        });
    }

    function ValidacionCamposVacios(...args) {

        for (let arg of args) {
            if (arg == "") {
                return false;
            }
        }
        return true;
    }

    this.EliminarCita = function (idCita) {

            /*Se ejecuta la llamada*/
        var urlApi = "http://localhost:44335/api/CitasLab/EliminarCitaLab?pIdCita=" + idCita;

            $.ajax({
                headers: {
                    'Accept': "application/json",
                    'Content-Type': "application/json"
                },
                method: "POST",
                url: urlApi,
                contentType: "application/json",
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
                                var table = $('#tbCitasHabilitadas').DataTable();
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

    this.CargarExamenCliente = function (idCita){

        params = [];
        var urlApi = "http://localhost:44335/api/Examen/mostrarUnExamen?idCita=" + idCita;
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
}


$(document).ready(function () {

    var view = new CitasLab();

    view.InitView();

});

