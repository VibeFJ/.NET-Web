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
    public class ctrTAPedidoDetalle
    {
        private string administradorBD = ConfigurationManager.ConnectionStrings["NombreConexionBD"].ConnectionString;
        public List<TAPedidoDetalle> Obtener()
        {
            var respuesta = new List<TAPedidoDetalle>();
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRRTAPedidoDetalle", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TAPedidoDetalle()
                                {
                                    PedidoId = Convert.ToInt32(atributo["PedidoId"]),
                                    ProductoId = Convert.ToInt32(atributo["ProductoId"]),
                                    Cantidad = Convert.ToInt32(atributo["Cantidad"]),
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

        public int Insertar(TAPedidoDetalle objeto)
        {
            var respuesta = -1;
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRCTAPedidoDetalle", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@PedidoId", objeto.PedidoId);
                        comando.Parameters.AddWithValue("@ProductoId", objeto.ProductoId);
                        comando.Parameters.AddWithValue("@Cantidad", objeto.Cantidad);

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

        public bool Actualizar(TAPedidoDetalle objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRUTAPedidoDetalle", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@DetalleId", objeto.DetalleId);
                        comando.Parameters.AddWithValue("@PedidoId", objeto.PedidoId);
                        comando.Parameters.AddWithValue("@ProductoId", objeto.ProductoId);
                        comando.Parameters.AddWithValue("@Cantidad", objeto.Cantidad);
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

        public bool Eliminar(TAPedidoDetalle objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRDTAPedidoDetalle", conexion))
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
