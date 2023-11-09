using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Web.ControladoresNegocio
{
    public class ctrTCGenero
    {
        private string administradorBD = ConfigurationManager.ConnectionStrings["NombreConexionBD"].ConnectionString;
        public List<TCGenero> Obtener()
        {
            var respuesta = new List<TCGenero>();
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRRTCGenero", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TCGenero()
                                {
                                    GeneroId = Convert.ToInt32(atributo["GeneroId"]),
                                    Descripcion = atributo["Descripcion"].ToString(),
                                };

                                respuesta.Add(datos);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Add(new TCGenero { Descripcion = "Error: " + ex.ToString() });
            }
            return respuesta;
        }
    }
}
