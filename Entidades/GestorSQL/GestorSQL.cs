using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using Entidades.Exceptions;

namespace Entidades.GestorSQL
{
    public class GestorSQL
    {
        #region Atributos
        private static string cadenaConexion;
        #endregion

        #region Constructor
        static GestorSQL()
        {
            GestorSQL.cadenaConexion = "Server =.; Database = SOCIOS_TEST_DB; Trusted_Connection = True";
        }
        #endregion
                
        #region Metodos
        /// <summary>
        /// Metodo para leer la lista de socios de la base SQL, la devuelve en una lista de socios
        /// </summary>
        /// <returns>List<Socio></returns>
        public static List<Socio> LeerDatosSocio()
        {
            List<Socio> listaSocios = new List<Socio>();
            string query = "select * from socios";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int dni = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        DateTime fechaNacimiento = reader.GetDateTime(3);
                        int actividad = reader.GetInt32(4);
                        int categoria = reader.GetInt32(5);

                        Socio socio = new Socio(nombre, apellido, dni, fechaNacimiento, (Socio.EActividad)actividad, (Socio.ECategoria)categoria);
                        listaSocios.Add(socio);
                    }
                }
                return listaSocios;
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al leer los socios de la base de datos", ex);
            }
        }
        /// <summary>
        /// Usando los metodos para traer socios y cuotas de la base de datos, los carga en un club
        /// </summary>
        /// <param name="club"></param>
        public static void LeerDatosClub(Club club)
        {
            club.ListaSocios = LeerDatosSocio();
            foreach (Socio socio in club.ListaSocios)
            {
                socio.HistorialDePagos = LeerCuotasDeSocio(socio);
            }
        }
        /// <summary>
        /// Carga un socio en la tabla socios de la base de datos
        /// </summary>
        /// <param name="s"></param>
        /// <exception cref="ExceptionSQL"></exception>
        public static void AltaSocio(Socio s)
        {
            string query = "insert into socios (nombre, apellido, dni, fecha_nacimiento, actividad, categoria) values (@nombre, @apellido, @dni, @fecha_nacimiento, @actividad, @categoria)";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(GestorSQL.cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", s.Nombre);
                cmd.Parameters.AddWithValue("apellido", s.Apellido);
                cmd.Parameters.AddWithValue("dni", s.Dni);
                cmd.Parameters.AddWithValue("fecha_nacimiento", s.FechaNacimiento);
                cmd.Parameters.AddWithValue("actividad", (int)s.Actividad);
                cmd.Parameters.AddWithValue("categoria", (int)s.Categoria);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al dar de alta en la base de datos", ex);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// Actualiza los datos de un socios en la base de datos, el socio es identificado por su dni 
        /// </summary>
        /// <param name="s">El socio que será actualizado</param>
        /// <param name="dni">El numero del socio a actualizar en la base</param>
        public static void ModificarSocio(Socio s, int dni)
        {
            string query = "update socios set nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fecha_nacimiento, actividad = @actividad, categoria = @categoria where dni = @dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", dni);
                    cmd.Parameters.AddWithValue("nombre", s.Nombre);
                    cmd.Parameters.AddWithValue("apellido", s.Apellido);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", s.FechaNacimiento);
                    cmd.Parameters.AddWithValue("actividad", s.Actividad);
                    cmd.Parameters.AddWithValue("categoria", s.Categoria);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al modificar el socio en la base de datos", ex);
            }
        }
        /// <summary>
        /// Elimina un socio de la base de datos
        /// </summary>
        /// <param name="dni">El numero de dni del socio a eliminar</param>
        public static void Borrar(int dni)
        {
            string query = "delete from socios where dni = @dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", dni);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al eliminar el socio en la base de datos", ex);
            }
        }
        /// <summary>
        /// Agrega una cuota en la tabla de cuotas de la base
        /// </summary>
        /// <param name="s">El socio del cual se toma el dato DNI para registrarlo en la cuota</param>
        /// <param name="c">La cuota que se guardara en la base</param>
        public static void AltaCuota(Socio s, Cuota c)
        {
            string query = "insert into cuotas (metodo_de_pago, actividad, importe, fecha_cuota, dni) values (@metodo_de_pago, @actividad, @importe, @fecha_cuota, @dni)";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("metodo_de_pago", (int)c.MetodoDePago);
                cmd.Parameters.AddWithValue("actividad", (int)c.Actividad);
                cmd.Parameters.AddWithValue("importe", c.Importe);
                cmd.Parameters.AddWithValue("fecha_cuota", c.FechaCuota);
                cmd.Parameters.AddWithValue("dni", c.DniSocio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al dar de alta la cuota en la base de datos", ex);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// Trae de la base las cuotas de un socio determinado
        /// </summary>
        /// <param name="socio">El socio del cual se traeran las cuotas</param>
        /// <returns>Una lista de cuotas</returns>
        public static List<Cuota> LeerCuotasDeSocio(Socio socio)
        {
            List<Cuota> listaDeCuotas = new List<Cuota>();
            string datos = string.Empty;

            string query = $"select cuotas.metodo_de_pago, cuotas.importe, cuotas.actividad, cuotas.fecha_cuota, cuotas.dni from socios join cuotas on socios.dni = cuotas.dni where socios.dni = {socio.Dni};";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int metodoDePago = reader.GetInt32(0);
                        int importe = reader.GetInt32(1);
                        int actividad = reader.GetInt32(2);
                        DateTime fechaCuota = reader.GetDateTime(3);
                        int dni = reader.GetInt32(4);
                        Cuota cuota = new Cuota((Cuota.EMetodoDePago)metodoDePago, importe, (Socio.EActividad)actividad, fechaCuota, dni);

                        listaDeCuotas.Add(cuota);
                    }
                }
                return listaDeCuotas;
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al leer las cuotas", ex);
            }
        }
        #endregion
    }
}
