using CDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NCategoria
    {
        public class NCategorias
        {
            Categorias _categorias = new Categorias();

            public DataTable getCategorias()
            {
                return _categorias.Get();
            }
        }
    }
}
