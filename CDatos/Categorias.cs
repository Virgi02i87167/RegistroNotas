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
    public class Categorias
    {
        private readonly string _connectionString;

        public Categorias()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public DataTable ObtenerCategoria()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, nombre FROM categorias", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
