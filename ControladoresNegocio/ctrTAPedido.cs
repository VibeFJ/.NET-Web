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
    public class ctrTAPedido
    {
        private string administradorBD = ConfigurationManager.ConnectionStrings["NombreConexionBD"].ConnectionString;
        public List<TAPedido> Obtener()
        {
            var respuesta = new List<TAPedido>();
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRRTAPedido", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TAPedido()
                                {
                                    PedidoId = Convert.ToInt32(atributo["PedidoId"]),
                                    ClienteId = Convert.ToInt32(atributo["ClienteId"]),
                                    FechaPedido = (DateTime)atributo["FechaPedido"],
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

        public int Insertar(TAPedido objeto)
        {
            var respuesta = -1;
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRCTAPedido", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@ClienteId", objeto.ClienteId);
                        comando.Parameters.AddWithValue("@FechaPedido", objeto.FechaPedido);

                        var resultado = comando.ExecuteScalar();

                        respuesta = Convert.ToInt32(resultado);
                    }
                }
                return respuesta;
            }
            catch
            {
                return respuesta;
            }
        }

        public bool Actualizar(TAPedido objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRUTAPedido", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@PedidoId", objeto.PedidoId);
                        comando.Parameters.AddWithValue("@ClienteId", objeto.ClienteId);
                        comando.Parameters.AddWithValue("@FechaPedido", objeto.FechaPedido);
                        comando.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(TAPedido objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRDTAPedido", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@PedidoId", objeto.PedidoId);
                        comando.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
