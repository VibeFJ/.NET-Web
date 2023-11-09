using Web.ControladoresNegocio;
using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class TAClienteController : ApiController
    {
        [HttpPost]
        [ActionName("Insertar")]
        public int Insertar(TACliente objeto)
        {
            var controlador = new ctrTACliente();
            var respuesta = controlador.Insertar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Obtener")]
        public List<TACliente> Obtener()
        {
            var controlador = new ctrTACliente();
            var respuesta = controlador.Obtener();
            return respuesta;
        }

        [HttpPost]
        [ActionName("Actualizar")]
        public bool Actualizar(TACliente objeto)
        {
            var controlador = new ctrTACliente();
            var respuesta = controlador.Actualizar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public bool Eliminar(int objeto)
        {
            var controlador = new ctrTACliente();
            var respuesta = controlador.Eliminar(objeto);
            return respuesta;
        }
    }
}