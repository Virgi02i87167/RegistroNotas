using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos
{
    public class Nota
    {
        private readonly string _connectionString;
        public Nota()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public DataTable ObtenerNotas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, titulo, descripcion, fecha, hora FROM Notas", con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AgregarNota(string titulo, string descripcion, DateTime fecha, DateTime hora)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Notas (titulo, descripcion, fecha, Hora) " +
                    "VALUES (@titulo, @descripcion, @fecha, @hora)", con))
                {
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);
                    cmd.Parameters.AddWithValue("@hora", fechaHora);

                    int filesAffected = cmd.ExecuteNonQuery();
                    return filesAffected > 0;
                }
            }
        }

        public bool ActualizarNota(int id, string tituloNota, string descripcionNota, DateTime fecha, DateTime hora)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Notas SET titulo = @titulo, descripcion = @descripcion, fecha = @fecha, hora = @hora WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@titulo", tituloNota);
                    cmd.Parameters.AddWithValue("@descripcion", descripcionNota);
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);
                    cmd.Parameters.AddWithValue("@hora", fechaHora);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }


        public bool EliminarNota(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Notas WHERE id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filesAffected = cmd.ExecuteNonQuery();
                    return filesAffected > 0;
                }
            }
        }
    }
}
