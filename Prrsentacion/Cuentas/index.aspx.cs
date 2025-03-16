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

            DropDownList ddlCategoria = (DropDownList)gvCredenciales.Rows[e.NewEditIndex].FindControl("ddlCategoria");
            if (ddlCategoria != null)
            {
                ddlCategoria.DataSource = _nCategorias.obtenerCategorias();
                ddlCategoria.DataTextField = "nombre";
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataBind();
            }
        }

        protected void gvCredenciales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvCredenciales.DataKeys[e.RowIndex].Value);
            string nombre = ((TextBox)gvCredenciales.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string usuario = ((TextBox)gvCredenciales.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string password = ((TextBox)gvCredenciales.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            DropDownList ddlCategoria = (DropDownList)gvCredenciales.Rows[e.RowIndex].FindControl("ddlCategoria");
            int idcategoria = Convert.ToInt32(ddlCategoria.SelectedValue);
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