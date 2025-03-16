using CDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NNotas
    {
        Nota _notas = new Nota();

        public DataTable GetObtenerTabla()
        {
            return _notas.ObtenerNotas();
        }
        public bool AgregarNotas(string titulo, string descripcion, DateTime fecha, DateTime hora)
        {
            return _notas.AgregarNota(titulo, descripcion, fecha, hora);
        }

        public bool ModificarNotas(int id, string titulo, string descripcion, DateTime fecha, DateTime hora)
        {
            return _notas.ActualizarNota(id, titulo, descripcion, fecha, hora);
        }

        public bool EliminarNotas(int id)
        {
            return _notas.EliminarNota(id);
        }
    }
}
