using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TRProductoCategoriaController : ApiController
    {
        [HttpPost]
        [ActionName("Obtener")]
        public List<TCProducto> Obtener(TCCategoria objeto)
        {
            var controlador = new ctrTRProductoCategoria();
            var respuesta = controlador.Obtener(objeto);
            return respuesta;
        }
    }
}