using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TAPedidoDetalleController : ApiController
    {
        [HttpPost]
        [ActionName("Insertar")]
        public int Insertar(TAPedidoDetalle objeto)
        {
            var controlador = new ctrTAPedidoDetalle();
            var respuesta = controlador.Insertar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Obtener")]
        public List<TAPedidoDetalle> Obtener()
        {
            var controlador = new ctrTAPedidoDetalle();
            var respuesta = controlador.Obtener();
            return respuesta;
        }

        [HttpPost]
        [ActionName("Actualizar")]
        public bool Actualizar(TAPedidoDetalle objeto)
        {
            var controlador = new ctrTAPedidoDetalle();
            var respuesta = controlador.Actualizar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public bool Eliminar(TAPedidoDetalle objeto)
        {
            var controlador = new ctrTAPedidoDetalle();
            var respuesta = controlador.Eliminar(objeto);
            return respuesta;
        }
    }
}