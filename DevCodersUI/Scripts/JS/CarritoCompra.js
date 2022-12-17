let dataExamen;

(function () {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const idLab = urlParams.get('id')
    function $(selector) {
        return document.querySelector(selector);
    }
    function Carrito() {
        var urlApi = "http://localhost:44335/api/ExamenInfoLab/InformacionExamen?pIdExamen=" + idLab;
        fetch(urlApi)           //api for the get request
            .then(response => response.json())
            .then(data => this.catalogo = data);


        this.constructor = function () {
            if (!localStorage.getItem("carrito")) {
                localStorage.setItem('carrito', '[]');
            }
        }
        this.getCarrito = JSON.parse(localStorage.getItem("carrito"));
        this.agregarItem = function (item) {

            for (i of this.catalogo) {
                console.log(item);
                if (i.idExamen == item) {
                    var registro = i
                }
            }
            if (!registro) {
                return
            }
            if (carrito.getCarrito != null) {
                for (i of this.getCarrito) {
                    if (i.idExamen == item) {
                        i.cantidad++;
                        console.log(this.getCarrito);
                        localStorage.setItem("carrito", JSON.stringify(this.getCarrito))
                        return;
                    }
                }
            }
            
            registro.cantidad = 1;
            this.getCarrito.push(registro);
            console.log(this.getCarrito);
            localStorage.setItem("carrito", JSON.stringify(this.getCarrito));
        }

        this.getTotal = function () {
            var total = 0;
            for (i of this.getCarrito) {
                total += parseFloat(i.cantidad) * parseFloat(i.precioExamen);
            }
            return total;
        }
        this.eliminarItem = function (item) {
            console.log("Entra a eliminar")
            for (var i in this.getCarrito) {
                if (this.getCarrito[i].idExamen == item) {
                    this.getCarrito.splice(i, 1);
                }
            }
            localStorage.setItem("carrito", JSON.stringify(this.getCarrito));
        }
    }
    function Carrito_View() {

        this.showModal = function () {
            $("#modal").classList.toggle('is-active');
            this.renderCarrito();
        }
        this.hideModal = function (ev) {
            if (ev.target.classList.contains("toggle")) {
                this.showModal();
            }
        }
        this.renderCarrito = function () {
            if (carrito.getCarrito.length <= 0) {
                var template = `<div class="is-12"><p class="title is-1 has-text-centered">No haz agregado Productos</p></div><br>`;
                $("#productosCarrito").innerHTML = template;
            } else {
                $("#productosCarrito").innerHTML = "";
                var template = ``
                for (i of carrito.getCarrito) {
                    template += `
                    <div class="columns">
                    <div class="column is-3">${i.nombreExamen}</div>
                    <div class="column is-2 has-text-centered">$${i.precioExamen}</div>
                    <div class="column is-1 has-text-centered">${i.cantidad}</div>
                    <div class="column is-2 has-text-centered"><strong><i>${i.cantidad * i.precioExamen}</i></strong></div>
                    <div class="column is-1"><p class="field"><a href="#" class="button is-danger"><span class="icon"><i class="fa fa-trash-o" id="deleteProducto" data-producto="${i.idExamen}">-</i></span></a></p></div>
                    </div>
                    `;
                }
                $("#productosCarrito").innerHTML = template;
            }
            $("#totalCarrito > strong").innerHTML = "$" + carrito.getTotal();
        }
        this.totalProductos = function () {
            if (carrito.getCarrito != null) {
                var total = carrito.getCarrito.length;
                console.log(total);
                $("#totalProductos > strong").innerHTML = total
            }

        }
    }

    var carrito_view = new Carrito_View();
    var carrito = new Carrito();


    document.addEventListener('DOMContentLoaded', function () {
        carrito.constructor();

        carrito_view.totalProductos();
    });

    $("#btn_carrito").addEventListener("click", function () {
        carrito_view.showModal();
    });

    $("#modal").addEventListener("click", function (ev) {
        carrito_view.hideModal(ev);
    });

    $("#catalogo").addEventListener("click", function (ev) {
        ev.preventDefault();
        if (ev.target.id === "addItem") {
            var id = ev.target.dataset.producto;
            carrito.agregarItem(id);
        }

        //carrito_view.showModal();
        carrito_view.totalProductos();
    });


    $("#productosCarrito").addEventListener("click", function (ev) {
        ev.preventDefault();
        if (ev.target.id === "deleteProducto") {
            carrito.eliminarItem(ev.target.dataset.producto);
            carrito_view.renderCarrito();
            carrito_view.totalProductos();
        }
    });


    /*$("#btn-pagar-total").addEventListener("click", function (ev) {
        this.registrarOrden();
    });*/

    dataExamen = carrito.getCarrito;



})();


$("#btn-pagar-total").click(function () {
    var orden = {};

    orden.IdUsuario = localStorage.getItem("idUsuario");

    var urlAPI = "http://localhost:44335/api/OrdenDeCompra/ProcesarOrden";

    $.ajax({
        headers: {
            'Accept': "application/json",
            'Content-Type': "application/json"
        },
        method: "POST",
        url: urlAPI,
        contentType: "application/json",
        data: JSON.stringify(orden),
        hasContent: true
    }).done(function (response) {
        if (response.includes("Error")) {
            Swal.fire({
                icon: 'error',
                title: 'ERROR',
                text: response
            });
        } else {
            console.log(response);
            console.log(dataExamen);
            localStorage.setItem("idOrdenLocal", response);
            var ordenExamen = {};
            console.log(dataExamen);
            for (var i = 0; i < dataExamen.length; i++) {
                ordenExamen.IdExamen = dataExamen[i].idExamen;
                ordenExamen.IdOrdenCompra = response;

                var urlApi = "http://localhost:44335/api/OrdenDeCompra/ProcesarOrdenExamen";
                console.log(ordenExamen);
                $.ajax({
                    headers: {
                        'Accept': "application/json",
                        'Content-Type': "application/json"
                    },
                    method: "POST",
                    url: urlApi,
                    contentType: "application/json",
                    data: JSON.stringify(ordenExamen),
                    hasContent: true
                }).done(
                    function (response) {
                        Swal.fire({
                            title: 'EXITO',
                            text: response,
                            icon: 'success',
                            confirmButtonText: 'Aceptar'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                console.log(response);

                            }
                        })
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
            location.href = "/ProcesoDePago/OrdenDeCompra";
        }
    }).fail(
        function () {
            Swal.fire({
                icon: 'error',
                title: 'ERROR',
                text: "El servidor no esta activo, por favor espere."
            });
        });

});
