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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            int idcategoria = Convert.ToInt32(dropCategorias.SelectedValue);

            bool agregado = nCuentas.AgregarCredencial(nombre, usuario, password, idcategoria);
            if (agregado)
            {
                CargarCredenciales();
            }
            else
            {
                Response.Write("<script>alert('Error al agregar credencial');</script>");
            }
        }

        protected void gvCredenciales_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvCredenciales.EditIndex = e.NewEditIndex;
            CargarCredenciales();
        }

        protected void gvCredenciales_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvCredenciales.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvCredenciales.Rows[e.RowIndex];

            string nombre = (row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            string usuario = (row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text; 
            string password = (row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            int idcategoria = int.Parse((row.Cells[5].Controls[0] as System.Web.UI.WebControls.TextBox).Text); 

            if (nCuentas.ActualizarCredencial(id, nombre, usuario, password, idcategoria))  
            {
                gvCredenciales.EditIndex = -1;
                CargarCredenciales();
            }
        }

        protected void gvCredenciales_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvCredenciales.EditIndex = -1;
            CargarCredenciales();
        }

        protected void gvCredenciales_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCredenciales.DataKeys[e.RowIndex].Value);

            if (nCuentas.EliminarCredencial(id))
            {
                CargarCredenciales();
            }
        }
    }
}