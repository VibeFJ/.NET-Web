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
    public class ctrTACliente
    {
        private string administradorBD = ConfigurationManager.ConnectionStrings["NombreConexionBD"].ConnectionString;
        public List<TACliente> Obtener()
        {
            var respuesta = new List<TACliente>();
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRRTACliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TACliente()
                                {
                                    ClienteId = Convert.ToInt32(atributo["ClienteId"]),
                                    Nombre = atributo["Nombre"].ToString(),
                                    ApellidoPaterno = atributo["ApellidoPaterno"].ToString(),
                                    ApellidoMaterno = atributo["ApellidoMaterno"].ToString()
                                };

                                respuesta.Add(datos);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Add(new TACliente { Nombre = "Error: " + ex.ToString() });
            }
            return respuesta;
        }

        public int Insertar(TACliente objeto)
        {
            var respuesta = -1;
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRCTACliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                        comando.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                        comando.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);

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

        public bool Actualizar(TACliente objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRUTACliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@ClienteId", objeto.ClienteId);
                        comando.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                        comando.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                        comando.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);
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

        public bool Eliminar(int clienteId)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRDTACliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@ClienteId", clienteId);
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
