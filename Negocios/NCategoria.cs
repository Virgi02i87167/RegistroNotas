﻿using CDatos;
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
     
            Categorias _categorias = new Categorias();

            public DataTable obtenerCategorias()
            {
                return _categorias.ObtenerCategoria();
            }
       }
    
}
