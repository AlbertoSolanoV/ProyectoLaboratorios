function Dashboard() {
    let tablaCita;
    let idUsuario = localStorage.getItem('idUsuario');


    this.InitView = function () {
        this.CargarNombreLaboratorio();
        $('#tbCitas tbody').on('click', 'button', function () {
            const row = tablaCita.row().data();
            alert(row.idCitas)
        });
    }
    this.CargarNombreLaboratorio = function () {
        var urlApi = "http://localhost:44335/api/Laboratorio/LaboratorioInformacionAdmin?pIdAdmin=" + idUsuario;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "GET",
            url: urlApi,
        }).done(
            function (response) {
                console.log(response);
                if (response === null) {
                    Swal.fire({
                        icon: 'error',
                        title: 'ERROR',
                        text: 'No se pudo cargar su información de laboratorio, recargue la página.'
                    });
                } else {
                    //Nombre
                    console.log(response)
                    //Nombre comercial
                    $('#tituloLab').append("Inicio administrador de " + response.nombreComercial);
                    idLaboratorio = response.idLaboratorio;
                    var dash = new Dashboard();
                    var seccionbtnEmple = document.getElementById("seccionBtnEmpleado");
                    seccionbtnEmple.innerHTML += " <a id='btnInicioSesion' href='/RegistroForm/RegistroForm?idLab=" + response.idLaboratorio +"'  class='btn btn-success'>Registrar Empleado</a>"
                    dash.CargarCitasExamen(response.idLaboratorio);
                    dash.CargarTablaEmpleados(response.idLaboratorio);
                    dash.CargarTablaBitacora(response.idLaboratorio);
                    dash.CargarGanancias(response.idLaboratorio);
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

    this.CargarGanancias = function (id) {

        var urlApi = "http://localhost:44335/api/Ganancia/DevolverGanancia?pId=" + id;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "GET",
            url: urlApi,
        }).done(
            function (response) {
                console.log(response);
                if (response === null) {
                    Swal.fire({
                        icon: 'error',
                        title: 'ERROR',
                        text: 'No se pudo cargar su información de laboratorio, recargue la página.'
                    });
                } else {
                    const ctx = document.getElementById('myChart');
                    const meses = [];
                    const ganancias = [];
                    const cantidad = [];
                    for (let i = 0; i < response.length; i++) {
                        meses.push(response[i].mes);
                        ganancias.push(response[i].total);
                        cantidad.push(response[i].cantidad);
                    }
                    console.log(meses);


                    new Chart(ctx, {
                        type: 'bar',
                        data: {
                            labels: meses,
                            datasets: [{
                                label: 'Ganancias por meses',
                                data: ganancias,
                                borderWidth: 1
                            },
                            {
                                type: 'line',
                                label: 'Cantidad de citas',
                                data: cantidad,
                            }],
                        },
                        options: {
                            scales: {
                                y: {
                                    beginAtZero: true
                                }
                            }
                        }
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


    this.CargarCitasExamen = function (id) {

        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'usuario' };
        arrayColumnsData[1] = { 'data': 'email' };
        arrayColumnsData[2] = { 'data': 'telefono' };
        arrayColumnsData[3] = { 'data': 'horario' };
        arrayColumnsData[4] = { 'data': 'nombreExamen' };

        var urlApi = "http://localhost:44335/api/Citas/DevolverCitasLab?pId=" + id;

       tablaCita= $('#tbCitas').DataTable({
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
    }


    this.CargarTablaEmpleados = function (id) {

        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'identificacionUsuario' };
        arrayColumnsData[1] = { 'data': 'nombreUsuario' };
        arrayColumnsData[2] = { 'data': 'emailUsuario' };
        arrayColumnsData[3] = { 'data': 'telefonoUsuario' };
        

    

        var urlApi = "http://localhost:44335/api/Empleado/DevolverEmpleados?pIdLab=" + id;

         $('#tbEmpleadosCreados').DataTable({
            ajax: {
                method: "GET",
                url: urlApi,
                contentType: "application/json;charset=uft-8",
                dataSrc: function (json) {
                    var json = { 'data': json }

                    return json.data;
                }
            },
            columns: arrayColumnsData
        });
    }

    this.CargarTablaBitacora = function (id) {

        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'nombreUsuario' };
        arrayColumnsData[1] = { 'data': 'emailUsuario' };
        arrayColumnsData[2] = { 'data': 'telefonoUsuario' };

        var urlApi = "http://localhost:44335/api/Cliente/DevolverClientes?pIdLab=" + id;

        $('#tbBitacora').DataTable({
            ajax: {
                method: "GET",
                url: urlApi,
                contentType: "application/json;charset=uft-8",
                dataSrc: function (json) {
                    var json = { 'data': json }

                    return json.data;
                }
            },
            columns: arrayColumnsData
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

}


$(document).ready(function () {

    var view = new Dashboard();
    view.InitView();

});

