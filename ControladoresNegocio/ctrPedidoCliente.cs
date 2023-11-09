using Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ControladoresNegocio
{
    public class ctrPedidoCliente
    {
        private string administradorBD = ConfigurationManager.ConnectionStrings["NombreConexionBD"].ConnectionString;
        public List<TAPedido> Obtener(int ClienteId)
        {
            var respuesta = new List<TAPedido>();
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRREPedidoCliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@ClienteId", ClienteId);

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TAPedido()
                                {
                                    PedidoId = Convert.ToInt32(atributo["PedidoId"]),
                                    FechaPedido = (DateTime)atributo["FechaPedido"],
                                    Total = (decimal)atributo["Total"]
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
