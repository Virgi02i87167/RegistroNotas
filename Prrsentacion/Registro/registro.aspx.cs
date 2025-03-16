using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prrsentacion
{
    public partial class registro : System.Web.UI.Page
    {
        NNotas _notas = new NNotas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNotas();
            }
        }

        protected void CargarNotas()
        {
            gvRegistro.DataSource = _notas.GetObtenerTabla();
            gvRegistro.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string descripcion = txtDescripcion.Text;

            DateTime fecha;
            DateTime hora;

            bool fechaValida = DateTime.TryParse(txtFecha.Text, out fecha);
            bool horaValida = DateTime.TryParseExact(txtHora.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out hora);

            if (!fechaValida || !horaValida)
            {
                Response.Write("<script>alert('Formato de fecha u hora incorrecto');</script>");
                return;
            }

            DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, 0);

            bool agregado = _notas.AgregarNotas(titulo, descripcion, fecha, hora);
            if (agregado)
            {
                CargarNotas();
            }
            else
            {
                Response.Write("<script>alert('Error al agregar credencial');</script>");
            }
        }

        protected void gvRegistro_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvRegistro.EditIndex = e.NewEditIndex;
            CargarNotas();
        }

        protected void gvRegistro_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvRegistro.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvRegistro.DataKeys[e.RowIndex].Values[0]);
            string titulo = ((TextBox)row.Cells[1].Controls[0]).Text;
            string descripcion = ((TextBox)row.Cells[2].Controls[0]).Text;
            DateTime fecha = Convert.ToDateTime(((TextBox)row.Cells[3].Controls[0]).Text);
            DateTime hora = Convert.ToDateTime(((TextBox)row.Cells[4].Controls[0]).Text);
            bool actualizado = _notas.ModificarNotas(id, titulo, descripcion, fecha, hora);
            if (actualizado)
            {
                gvRegistro.EditIndex = -1;
                CargarNotas();
            }
            else
            {
                Response.Write("<script>alert('Error al actualizar credencial');</script>");
            }
        }

        protected void gvRegistro_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvRegistro.EditIndex = -1;
            CargarNotas();
        }

        protected void gvRegistro_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvRegistro.DataKeys[e.RowIndex].Value);
            bool eliminado = _notas.EliminarNotas(id);
            if (eliminado)
            {
                CargarNotas();
            }
            else
            {
                Response.Write("<script>alert('Error al eliminar credencial');</script>");
            }
        }
    }
}