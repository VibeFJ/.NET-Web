using Web.Entidades;
using Newtonsoft.Json.Linq;
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
    public class ctrTAUsuario
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

                    using (var comando = new SqlCommand("PRRTAUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (var atributo = comando.ExecuteReader())
                        {
                            while (atributo.Read())
                            {
                                var datos = new TAUsuario()
                                {
                                    UsuarioId = Convert.ToInt32(atributo["UsuarioId"]),
                                    Nombre = atributo["Nombre"].ToString(),
                                    ApellidoPaterno = atributo["ApellidoPaterno"].ToString(),
                                    ApellidoMaterno = atributo["ApellidoMaterno"].ToString(),
                                    NombreUsuario = atributo["NombreUsuario"].ToString(),
                                    Contraseña = atributo["Contraseña"].ToString(),
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

                    using (var comando = new SqlCommand("PRCTAUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                        comando.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                        comando.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);
                        comando.Parameters.AddWithValue("@NombreUsuario", objeto.NombreUsuario);
                        comando.Parameters.AddWithValue("@Contraseña", objeto.Contraseña);

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

                    using (var comando = new SqlCommand("PRUTAUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@UsuarioId", objeto.UsuarioId);
                        comando.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                        comando.Parameters.AddWithValue("@ApellidoPaterno", objeto.ApellidoPaterno);
                        comando.Parameters.AddWithValue("@ApellidoMaterno", objeto.ApellidoMaterno);
                        comando.Parameters.AddWithValue("@NombreUsuario", objeto.NombreUsuario);
                        comando.Parameters.AddWithValue("@Contraseña", objeto.Contraseña);
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

                    using (var comando = new SqlCommand("PRDTAUsuario", conexion))
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
