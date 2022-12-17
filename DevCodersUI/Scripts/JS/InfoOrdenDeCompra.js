function OrdenDeCompra() {

    this.InitView = function () {
        this.listOrders();
        //this.PagarOrden();
        /*$("#btnPago").click(function () {
            console.log("Cargando");
            var vista = new OrdenDeCompra();
            vista.PagarOrden();
        });*/
    }

    this.listOrders = function () {
        var id = localStorage.getItem("idOrdenLocal");
        var urlApi = "http://localhost:44335/api/OrdenDeCompra/DevolverInfoOrdenDeCompra?pIdAdmin="+id;
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: 'GET',
            url: urlApi,
            async: true,
        }).done(function (response) {
            console.log("Resultado ", response);
            if (response === null) {
                Swal.fire({
                    icon: 'error',
                    title: 'ERROR',
                    text: 'No se pudo cargar la información.',
                });
            } else {
                var idSeccion = document.getElementById("idDatosOrden");
                idSeccion.innerHTML += `<div class="container rounded bg-white mt-5 mb-5">
                                             <div class="row">
                                                <div class="col-md-5 border-right">
                                                    <div class="p-3 py-5">
                                                        <div class="d-flex justify-content-between align-items-center mb-3">
                                                            <h4 class="text-right">Orden de Compra</h4>
                                                        </div>
                                                        <div class="row mt-3">
                                                            <div class="col-md-12"><label class="labels">Número de Orden de Compra</label><p id="idNumOrden">`+ response.NumeroConsecutivo +`</p></div>
                                                            <div class="col-md-12"><label class="labels">Laboratorio</label><p id="idNomLab">`+ response.NombreLab +`</p></div>
                                                            <div class="col-md-12"><label class="labels">Cédula Jurídica</label><p id="idCeduju">`+ response.CedulaJuridica +`</p></div>
                                                            <div class="col-md-12"><label class="labels">Nombre del Cliente</label><p id="idNomUsuario">`+ response.NombreCliente +` `+response.Apillido1+` `+response.Apellido2+`</p></div>
                                                            <div class="col-md-12"><label class="labels">Su-Total</label><p id="idSubTotal">`+ response.SubTotal +`</p></div>
                                                            <div class="col-md-12"><label class="labels">Descuento</label><p id="idDescuento">`+ response.Descuento +`</p></div>
                                                            <div class="col-md-12"><label class="labels">IVA</label><p id="idIVA">`+ (response.SubTotal * 0.13) +`</p></div>                                                          
                                                            <div class="col-md-12"><label class="labels">Total</label><h5 id="idTotalOrden">`+ (response.SubTotal*1.13) +`</h5></div>                                                  
                                                        </div>
                                                        <div class="form-group">
                                                            <button class="btn btn-block btn-primary" type="button" id="btnPago" onclick="PagarOrden()">Pagar</button>
                                                        </div>
                                                    <div>
                                                </div>
                                             </div>
                                        </div>`
            }
        }).fail(
            function () {
                Swal.fire({
                    icon: 'error',
                    title: 'ERROR',
                    text: "El servidor no esta activo, por favor espere."
                });
        })
    };
}

$(document).ready(function () {
    var view = new OrdenDeCompra();
    view.InitView();
});

function PagarOrden() {

    var orden = {}

    orden.IdOrden = document.getElementById("idNumOrden").textContent;
    orden.NombreLab = document.getElementById("idNomLab").textContent
    orden.NombreCliente = document.getElementById("idNomUsuario").textContent;
    orden.Total = document.getElementById("idTotalOrden").textContent;
    orden.SubTotal = document.getElementById("idSubTotal").textContent;
    orden.Descuento = document.getElementById("idDescuento").textContent;
    orden.IVA = document.getElementById("idIVA").textContent;
    //Se llama un controller y se le envían los parametros como parte del Query String
    location.href = "/ProcesoDePago/Paypal?IdOrden=" + orden.IdOrden + "&NombreCliente=" + orden.NombreCliente + "&NombreLab=" + orden.NombreLab + "&Total=" + orden.Total + "&SubTotal=" + orden.SubTotal + "&Descuento=" + orden.Descuento + "&IVA=" + orden.IVA;
}