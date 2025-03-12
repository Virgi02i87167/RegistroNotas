using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CDatos
{
    public class Cuentas
    {
        private readonly string _connectionString;

        public Cuentas()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public DataTable ObtenerTabla()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT cu.*, ca.nombre AS categoria" +
                    " FROM cuentas cu" +
                    " INNER JOIN categorias ca ON cu.idCategoria = ca.id", con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool Agregar(string nombre, string usuario, string password, int idcategoria)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO cuentas" +
                    " (nombre, usuario, password, idcategoria)" +
                    " VALUES (@nombre, @usuario, @password, @idcategoria)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@idcategoria", idcategoria);

                    int filesAffected = cmd.ExecuteNonQuery();
                    return filesAffected > 0;
                }
            }
        }

        public bool Modificar(int id, string nombre, string usuario, string password, int idcategoria)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE cuentas" +
                    " SET nombre = @nombre, usuario = @usuario, password = @password, idcategoria = @idcategoria" +
                    " WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@idcategoria", idcategoria);
                    int filesAffected = cmd.ExecuteNonQuery();
                    return filesAffected > 0;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM cuentas WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filesAffected = cmd.ExecuteNonQuery();
                    return filesAffected > 0;
                }
            }
        }
    }
}
