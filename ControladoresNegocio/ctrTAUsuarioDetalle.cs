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
    public class ctrTAUsuarioDetalle
    {
        private string administradorBD = ConfigurationManager.ConnectionStrings["NombreConexionBD"].ConnectionString;
        public List<TAUsuario> Obtener()
        {
            var respuesta = new List<TAUsuario>();
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRRTAUsuarioDetalle", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TAUsuario()
                                {
                                    UsuarioId = Convert.ToInt32(atributo["UsuarioId"]),
                                    Direccion = atributo["Direccion"].ToString(),
                                    Telefono = atributo["Telefono"].ToString(),
                                    GeneroId = Convert.ToInt32(atributo["GeneroId"]),
                                };

                                respuesta.Add(datos);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Add(new TAUsuario { Nombre = "Error: " + ex.ToString() });
            }
            return respuesta;
        }

        public int Insertar(TAUsuario objeto)
        {
            var respuesta = -1;
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRCTAUsuarioDetalle", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                        comando.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                        comando.Parameters.AddWithValue("@GeneroId", objeto.GeneroId);

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

        public bool Actualizar(TAUsuario objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRUTAUsuarioDetalle", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@UsuarioId", objeto.UsuarioId);
                        comando.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                        comando.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                        comando.Parameters.AddWithValue("@GeneroId", objeto.GeneroId);
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

        public bool Eliminar(TAUsuario objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(administradorBD))
                {
                    conexion.Open();

                    using (var comando = new SqlCommand("PRDTAUsuarioDetalle", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@UsuarioId", objeto.UsuarioId);
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
