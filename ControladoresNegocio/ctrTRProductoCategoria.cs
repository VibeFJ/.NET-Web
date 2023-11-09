using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ControladoresNegocio
{
    public class ctrTRProductoCategoria
    {
        private string administradorBD = ConfigurationManager.ConnectionStrings["NombreConexionBD"].ConnectionString;
        public List<TCProducto> Obtener(TCCategoria objeto)
        {
            var respuesta = new List<TCProducto>();
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRRTRProductoCategoria", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@CategoriaId", objeto.CategoriaId);

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TCProducto
                                {
                                    ProductoId = Convert.ToInt32(atributo["ProductoId"]),
                                    Nombre = atributo["Nombre"].ToString(),
                                    Precio = Convert.ToDecimal(atributo["Precio"]),
                                };
                                respuesta.Add(datos);
                            }
                        }
                    }
                }
            }
            finally
            {

            }
            return respuesta;
        }
    }
}
