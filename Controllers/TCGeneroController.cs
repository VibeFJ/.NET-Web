using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TCGeneroController : ApiController
    {
        [HttpPost]
        [ActionName("Obtener")]
        public List<TCGenero> Obtener()
        {
            var controlador = new ctrTCGenero();
            var respuesta = controlador.Obtener();
            return respuesta;
        }
    }
}