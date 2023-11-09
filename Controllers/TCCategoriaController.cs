using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TCCategoriaController : ApiController
    {
        [HttpPost]
        [ActionName("Obtener")]
        public List<TCCategoria> Obtener()
        {
            var controlador = new ctrTCCategoria();
            var respuesta = controlador.Obtener();
            return respuesta;
        }
    }
}