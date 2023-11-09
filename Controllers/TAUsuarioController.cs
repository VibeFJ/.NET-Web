using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web.ControladoresNegocio;
using Web.Entidades;

namespace Web.Controllers
{
    public class TAUsuarioController : ApiController
    {
        [HttpPost]
        [ActionName("Insertar")]
        public int Insertar(TAUsuario objeto)
        {
            var controlador = new ctrTAUsuario();
            var respuesta = controlador.Insertar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Obtener")]
        public List<TAUsuario> Obtener()
        {
            var controlador = new ctrTAUsuario();
            var respuesta = controlador.Obtener();
            return respuesta;
        }

        [HttpPut]
        [ActionName("Actualizar")]
        public bool Actualizar(TAUsuario objeto)
        {
            var controlador = new ctrTAUsuario();
            var respuesta = controlador.Actualizar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public bool Eliminar(TAUsuario objeto)
        {
            var controlador = new ctrTAUsuario();
            var respuesta = controlador.Eliminar(objeto);
            return respuesta;
        }

        [HttpPost]
        [ActionName("Verificar")]
        public bool Verificar(TAUsuario objeto)
        {
            var controlador = new ctrTAUsuario();
            var datos = controlador.Obtener();

            bool respuesta = false;
            foreach (var item in datos) 
            {
                if(objeto.NombreUsuario == item.NombreUsuario && objeto.Contraseña == item.Contraseña)
                {
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }
    }
}