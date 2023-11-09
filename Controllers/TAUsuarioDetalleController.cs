using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TAUsuarioDetalleController : ApiController
    {
        [HttpPost]
        [ActionName("Insertar")]
        public int Insertar(TAUsuario objeto)
        {
            var controlador = new ctrTAUsuarioDetalle();
            var respuesta = controlador.Insertar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Obtener")]
        public List<TAUsuario> Obtener()
        {
            var controlador = new ctrTAUsuarioDetalle();
            var respuesta = controlador.Obtener();
            return respuesta;
        }

        [HttpPost]
        [ActionName("Actualizar")]
        public bool Actualizar(TAUsuario objeto)
        {
            var controlador = new ctrTAUsuarioDetalle();
            var respuesta = controlador.Actualizar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public bool Eliminar(TAUsuario objeto)
        {
            var controlador = new ctrTAUsuarioDetalle();
            var respuesta = controlador.Eliminar(objeto);
            return respuesta;
        }
    }
}