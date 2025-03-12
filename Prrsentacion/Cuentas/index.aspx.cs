using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prrsentacion.Cuentas
{
    public partial class index : System.Web.UI.Page
    {
        NCuentas nCuentas = new NCuentas();
        NCategoria _nCategorias = new NCategoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCredenciales();
                CargarCategorias();
            }
        }

        protected void CargarCredenciales()
        {
            gvCredenciales.DataSource = nCuentas.GetObtenerTabla();
            gvCredenciales.DataBind();
        }

        protected void CargarCategorias()
        {
            DataTable dt = _nCategorias.obtenerCategorias();
            dropCategorias.DataSource = dt;
            dropCategorias.DataTextField = "nombre";
            dropCategorias.DataValueField = "id";
            dropCategorias.DataBind();

            dropCategorias.Items.Insert(0, new ListItem("Seleccione una opción", "0"));
        }

        protected void gvCredenciales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                bool eliminado = nCuentas.EliminarCredencial(id);
                if (eliminado)
                {
                    CargarCredenciales();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo eliminar el registro');", true);
                }
            }
        }
    }
}