using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TCProductoController : ApiController
    {
        [HttpPost]
        [ActionName("Obtener")]
        public List<TCProducto> Obtener()
        {
            var controlador = new ctrTCProducto();
            var respuesta = controlador.Obtener();
            return respuesta;
        }
    }
}