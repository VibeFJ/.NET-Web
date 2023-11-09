<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Web.Vistas.Autentificacion.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="TemplateMo" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i&display=swap" rel="stylesheet" />

    <title>Principal</title>

    <!-- Bootstrap core CSS -->
    <link href="../../Content/StandBlog/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.11.5/css/dataTables.bootstrap4.min.css">

    <!-- Additional CSS Files -->
    <link rel="stylesheet" href="../../Content/StandBlog/assets/css/fontawesome.css" />
    <link rel="stylesheet" href="../../Content/StandBlog/assets/css/templatemo-stand-blog.css" />
    <link rel="stylesheet" href="../../Content/StandBlog/assets/css/owl.css" />
</head>
<body>
    <!-- ***** Preloader Start ***** -->
    <div id="preloader">
        <div class="jumper">
            <div></div>
            <div></div>
            <div></div>
        </div>
    </div>
    <!-- ***** Preloader End ***** -->

    <!-- Header -->
    <header class="" style="height: 80px">
        <nav class="navbar navbar-expand-lg">
            <div class="container" style="max-width: 1800px;">
                <a class="navbar-brand" href="index.html">
                    <h2>Tienda en Linea</h2>
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="index.html">Home
                                <span class="sr-only">(current)</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="about.html">Cerrar Sesión</a>
                        </li>
                        <li class="nav-item">
                            <button id="btnMostrarCarrito" type="button" class="btn btn-primary">
                                <i class="fa fa-shopping-cart"></i>
                            </button>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

    </header>

    <section class="grid-system blog-post" style="padding-top: 100px">
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <div class="card">
                        <div class="card-body">
                            <select class="form-control" id="cbxCategorias">
                                <option value="" disabled selected>Seleccione una categoria de Producto</option>
                            </select>
                            <br>
                            <table class="table table-striped table-bordered">
                                <thead class="table-dark">
                                    <tr>
                                        <th>#</th>
                                        <th>Nombre</th>
                                        <th>Precio</th>
                                        <th>Cantidad</th>
                                        <th>Accion</th>
                                    </tr>
                                </thead>
                                <tbody id="tblProductos">
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>#</th>
                                        <th>Nombre</th>
                                        <th>Precio</th>
                                        <th>Cantidad</th>
                                        <th>Accion</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="carrito-panel" id="pnlCarrito" style="padding-top: 80px">
                    <div class="cart-producto" id="contenidoCarrito">
                    </div>
                </div>
            </div>
        </div>
    </section>

    
    <!-- Modal Cliente -->
    <div class="modal fade" id="modalCliente" tabindex="-1" aria-labelledby="modalLabelCliente" aria-hidden="true"
        style="width: 900px; height: 450px; left: 14%; top: 20%; margin-left: 0px; margin-top: 0px;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="agregarClienteModalLabel">Datos Cliente</h5>
                </div>
                <div class="modal-body">
                    <div class="form-outline mb-4">
                        <input class="form-control" name="txtNombre" type="text" id="txtNombre" placeholder="Nombre(s)" required="" />
                    </div>
                    <div class="form-outline mb-4">
                        <input class="form-control" name="txtApellidoPaterno" type="text" id="txtApellidoPaterno" placeholder="Apellido Paterno" required="" />
                    </div>
                    <div class="form-outline mb-4">
                        <input class="form-control" name="txtApellidoMaterno" type="text" id="txtApellidoMaterno" placeholder="Apellido Materno" required="" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" id="form-submit" class="btn btn-primary" onclick="realizarPedido()">Realizar Pedido</button>
                    <button type="button" id="form-cerrar" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- #Modal Cliente -->

    <footer>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <ul class="social-icons">
                        <li><a href="#">Facebook</a></li>
                        <li><a href="#">WhatsApp</a></li>
                        <li><a href="#">Linkedin</a></li>
                    </ul>
                </div>
                <div class="col-lg-12">
                    <div class="copyright-text">
                        <p>
                            Copyright 2020 Stand Blog Co.
                    
                 | Design: <a rel="nofollow" href="https://templatemo.com" target="_parent">TemplateMo</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <!-- Bootstrap core JavaScript -->
    <script src="../../Content/StandBlog/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.11.5/js/dataTables.bootstrap4.min.js"></script>

    <!-- Additional Scripts -->
    <script src="../../Content/StandBlog/assets/js/custom.js"></script>
    <script src="../../Content/StandBlog/assets/js/owl.js"></script>
    <script src="../../Content/StandBlog/assets/js/slick.js"></script>
    <script src="../../Content/StandBlog/assets/js/isotope.js"></script>
    <script src="../../Content/StandBlog/assets/js/accordions.js"></script>

    <script src="../../Scripts/Vistas/Principal.js"></script>

    <script language="text/Javascript"> 
      cleared[0] = cleared[1] = cleared[2] = 0; //set a cleared flag for each field
      function clearField(t){                   //declaring the array outside of the
      if(! cleared[t.id]){                      // function makes it static and global
          cleared[t.id] = 1;  // you could use true and false, but that's more typing
          t.value='';         // with more chance of typos
          t.style.color='#fff';
          }
      }
    </script>
</body>
</html>
