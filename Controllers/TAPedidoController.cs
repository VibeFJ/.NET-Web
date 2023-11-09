using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TAPedidoController : ApiController
    {
        [HttpPost]
        [ActionName("Insertar")]
        public int Insertar(TAPedido objeto)
        {
            var controlador = new ctrTAPedido();
            var respuesta = controlador.Insertar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Obtener")]
        public List<TAPedido> Obtener()
        {
            var controlador = new ctrTAPedido();
            var respuesta = controlador.Obtener();
            return respuesta;
        }

        [HttpPost]
        [ActionName("Actualizar")]
        public bool Actualizar(TAPedido objeto)
        {
            var controlador = new ctrTAPedido();
            var respuesta = controlador.Actualizar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public bool Eliminar(TAPedido objeto)
        {
            var controlador = new ctrTAPedido();
            var respuesta = controlador.Eliminar(objeto);
            return respuesta;
        }
    }
}