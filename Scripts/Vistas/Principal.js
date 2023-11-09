var productosCarrito = "";
var total = 0.00;
var cantidadProductos = 0;

var productosPedido = [];

$(document).ready(function () {
    obtenerCategoria();

    var selectCategorias = document.getElementById("cbxCategorias");

    selectCategorias.addEventListener("change", function () {
        obtenerProductos($('#cbxCategorias').val());
    });

    var btnMostrarCarrito = document.getElementById('btnMostrarCarrito');
    var carritoPanel = document.getElementById('pnlCarrito');

    btnMostrarCarrito.addEventListener('click', () => {
        if (carritoPanel.style.right === '0px') {
            carritoPanel.style.right = '-350px';
        } else {
            carritoPanel.style.right = '0px';
        }
    });
});

function obtenerCategoria() {
    $.ajax({
        url: "/api/TCCategoria/Obtener",
        type: "POST",
        data: {
            _token: "{{ csrf_token() }}",
        },
        success: function (respuesta) {
            var selectCategorias = document.getElementById("cbxCategorias");
            respuesta.forEach(function (categoria) {
                var opcion = document.createElement("option");
                opcion.id = categoria.CategoriaId;
                opcion.value = categoria.CategoriaId;
                opcion.text = categoria.Descripcion;
                selectCategorias.add(opcion);
            });
        }
    });
}

function aumentar(productoId) {
    var cantidad = parseInt($('#txtCantidad' + productoId).val());
    $('#btnProducto' + productoId).prop('disabled', false);
    if (cantidad < 10) {
        cantidad = cantidad + 1;
        $('#txtCantidad' + productoId).val(cantidad);
    }
}

function disminuir(productoId) {
    var cantidad = parseInt($('#txtCantidad' + productoId).val());
    if (cantidad > 0) {
        cantidad = cantidad - 1;
        $('#txtCantidad' + productoId).val(cantidad);
        if (cantidad == 0) {
            $('#btnProducto' + productoId).prop('disabled', true);
        }
    }
}

function limpiarTabla(tabla) {
    var rowCount = tabla.rows.length;
    for (var i = rowCount-1; i > -1; i--) {
        tabla.deleteRow(i);
    }
} 

function agregarCarrito(productoId) {
    $.ajax({
        url: "/api/TCProducto/Obtener",
        type: "POST",
        data: {
            _token: "{{ csrf_token() }}",
        },
        success: function (respuesta) {
            respuesta.forEach(function (producto) {
                if (producto.ProductoId == productoId) {
                    var cantidad = $('#txtCantidad' + productoId).val();
                    var precio = parseFloat(producto.Precio)
                    var semitotal = parseFloat(cantidad) * precio;
                    var carrito = `
                    <div class="product">
                        <img src="../Content/StandBlog/assets/images/banner-item-01.jpg">
                        <div class="product-info">
                            <h3>${producto.Nombre}</h3>
                            <p>Precio: ${producto.Precio}</p>
                            <p>Cantidad: ${cantidad}</p>
                            <p>Total: ${semitotal}</p>
                        </div>
                    </div>`;

                    var pedido = [productoId, cantidad];

                    productosPedido.push(pedido);

                    productosCarrito = productosCarrito + carrito;
                    total = total + (cantidad * precio);
                    cantidadProductos = cantidadProductos + parseInt(cantidad);

                    var divCarrito = document.getElementById('contenidoCarrito');

                    divCarrito.innerHTML = productosCarrito + `

                    <div class="cart-producto-summary">
                        <h2>Resumen del Carrito</h2>
                        <p>Total de Productos: ${cantidadProductos}</p>
                        <p>Total a Pagar: ${total.toFixed(2)}</p>
                    </div>

                    <div class="col" style="padding-top:10px;">
                        <button data-toggle="modal" data-target="#modalCliente" type="button" class="btn btn-success">
                            <i class="fa fa-arrow-circle-o-right"></i> Continuar Pedido
                        </button>
                    </div>
                    `;
                }
            });
        }
    });
}

function realizarPedido() {
    var pedidoCorrecto = 0;
    $.ajax({
        url: "/api/TACliente/Insertar",
        type: "POST",
        data: {
            _token: "{{ csrf_token() }}",
            Nombre: $('#txtNombre').val(),
            ApellidoPaterno: $('#txtApellidoPaterno').val(),
            ApellidoMaterno: $('#txtApellidoMaterno').val(),
        },
        success: function (clienteId) {
            if (clienteId > 0) {
                var fecha = new Date();

                var horas = fecha.getHours();
                var minutos = fecha.getMinutes();
                var segundos = fecha.getSeconds();

                var horaActual = horas + ':' + (minutos < 10 ? '0' : '') + minutos + ':' + (segundos < 10 ? '0' : '') + segundos;

                $.ajax({
                    url: "/api/TAPedido/Insertar",
                    type: "POST",
                    data: {
                        _token: "{{ csrf_token() }}",
                        ClienteId: clienteId,
                        FechaPedido: horaActual,
                    },
                    success: function (pedidoId) {
                        if (pedidoId > 0) {
                            console.log(productosPedido)
                            productosPedido.forEach(function (producto) {
                                $.ajax({
                                    url: "/api/TAPedidoDetalle/Insertar",
                                    type: "POST",
                                    data: {
                                        _token: "{{ csrf_token() }}",
                                        PedidoId: pedidoId,
                                        ProductoId: producto[0],
                                        Cantidad: producto[1],
                                    },
                                    success: function (detalleId) {
                                        if (detalleId > 0) {
                                            $.ajax({
                                                url: "/api/TAPedidoDetalle/Actualizar",
                                                type: "POST",
                                                data: {
                                                    _token: "{{ csrf_token() }}",
                                                    DetalleId: detalleId,
                                                    PedidoId: pedidoId,
                                                    ProductoId: producto[0],
                                                    Cantidad: producto[1],
                                                },
                                                success: function (respuesta) {
                                                    if (respuesta) {
                                                        $.ajax({
                                                            url: "/api/TAPedido/Actualizar",
                                                            type: "POST",
                                                            data: {
                                                                _token: "{{ csrf_token() }}",
                                                                PedidoId: pedidoId,
                                                                ClienteId: clienteId,
                                                                FechaPedido: horaActual,
                                                            },
                                                            success: function (respuesta) {
                                                                if (respuesta) {
                                                                    Swal.fire({
                                                                        icon: 'success',
                                                                        title: 'Pedido Correcto',
                                                                        showConfirmButton: false,
                                                                        timer: 2000
                                                                    })
                                                                }
                                                                else {
                                                                    pedidoCorrecto = 2;
                                                                }
                                                            }
                                                        });
                                                    }
                                                    else {
                                                        pedidoCorrecto = 2;
                                                    }
                                                }
                                            });
                                        }
                                        else {
                                            pedidoCorrecto = 2;
                                        }
                                    }
                                });
                            });
                        }
                        else {
                            pedidoCorrecto = 2;
                        }
                    }
                });
            }
            else {
                pedidoCorrecto = 2;
            }
            if (pedidoCorrecto>1) {
                Swal.fire({
                    icon: 'error',
                    type: 'error',
                    title: 'Oops...',
                    text: 'Hubo un problema con su pedido',
                })
            }
        }
    });
}

function obtenerProductos(ID) {
    $.ajax({
        url: "/api/TRProductoCategoria/Obtener",
        type: "POST",
        data: {
            _token: "{{ csrf_token() }}",
            CategoriaId: ID,
        },
        success: function (productos) {
            var tablaProductos = document.getElementById("tblProductos");

            limpiarTabla(tablaProductos);

            var contador = 1;
            productos.forEach(function (producto) {
                var fila = tablaProductos.insertRow();
                var celdaNumero = fila.insertCell(0);
                var celdaNombre = fila.insertCell(1);
                var celdaPrecio = fila.insertCell(2);
                var celdaCantidad = fila.insertCell(3);
                var celdaAccion = fila.insertCell(4);

                celdaNumero.className = "col-lg-1";
                celdaNombre.className = "col-lg-3";
                celdaPrecio.className = "col-lg-2";
                celdaCantidad.className = "col-lg-2";
                celdaAccion.className = "col-lg-1";

                celdaNumero.innerHTML = contador++;
                celdaNombre.innerHTML = producto.Nombre;
                celdaPrecio.innerHTML = producto.Precio;

                celdaCantidad.innerHTML = `
                <div class="input-group mb-1">
                    <div class="input-group-prepend">
                        <button onclick="disminuir(${producto.ProductoId})" id="btnDisminuirCantidad" class="btn btn-outline-secondary" type="button"><</button>
                    </div>
                    <input id="txtCantidad${producto.ProductoId}" type="text" style="text-align: center;" class="form-control" aria-label="Text input with segmented dropdown button" value="0" disabled>
                    <div class="input-group-append">
                        <button onclick="aumentar(${producto.ProductoId})" id="btnAumentarCantidad" class="btn btn-outline-secondary" type="button">></button>
                    </div>
                </div>`;

                celdaAccion.innerHTML = `
                <button onclick="agregarCarrito(${producto.ProductoId})" id="btnProducto${producto.ProductoId}" type="button" class="btn btn-success" disabled>
                    <i class="fa fa-plus"></i> Agregar
                </button>`;
            });
        }
    });
}