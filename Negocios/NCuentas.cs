using CDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NCuentas
    {
        Cuentas _cuentas = new Cuentas();

        public DataTable GetObtenerTabla()
        {
            return _cuentas.ObtenerTabla();
        }
        public bool AgregarCredencial(string nombre, string usuario, string password, int idcategoria)
        {
            return _cuentas.Agregar(nombre, usuario, password, idcategoria);
        }

        public bool EliminarCredencial(int id)
        {
            return _cuentas.Eliminar(id);
        }
    }
}
