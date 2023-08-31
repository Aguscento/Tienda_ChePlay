using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class EditarJuego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                CargarGrillaCompleta();
            }
        }
        protected void CargarGrillaCompleta()
        {
            NegocioJuegos nj = new NegocioJuegos();
            grdEditar.DataSource = nj.TodosLosJuegos();
            grdEditar.DataBind();
        }
        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void grdEditar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMensaje.Text = "";
            grdEditar.PageIndex = e.NewPageIndex;
            CargarGrillaCompleta();
        }

        protected void grdEditar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            TextBox txtNombreJuego = (TextBox)grdEditar.Rows[rowIndex].Cells[1].Controls[0];
            string NombreJuego = txtNombreJuego.Text;

            TextBox txtNombrePlataforma = (TextBox)grdEditar.Rows[rowIndex].Cells[2].Controls[0];
            string NombrePlataforma = txtNombrePlataforma.Text;

            TextBox txtPrecio = (TextBox)grdEditar.Rows[rowIndex].Cells[3].Controls[0];
            string nuevoPrecio = txtPrecio.Text;

            NegocioPlataformaPorJuego neg = new NegocioPlataformaPorJuego();
            Boolean estado = false;

            //lblMensaje.Text = NombreJuego + NombrePlataforma + nuevoPrecio;

            estado = neg.editarPrecio(NombreJuego, NombrePlataforma, nuevoPrecio);

            if (estado == true)
            {
                lblMensaje.Text = "Precio editado con exito";
            }
            else
            {
                lblMensaje.Text = "No se pudo editar el precio";
            }

            grdEditar.EditIndex = -1;
            CargarGrillaCompleta();
        }

        protected void grdEditar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMensaje.Text = "";
            grdEditar.EditIndex = e.NewEditIndex;
            CargarGrillaCompleta();
        }
        protected void grdEditar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEditar.EditIndex = -1;
            CargarGrillaCompleta();
        }

        protected void grdEditar_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow && (grdEditar.EditIndex == e.Row.RowIndex))
            {
                e.Row.Cells[1].Enabled = false;
                e.Row.Cells[2].Enabled = false;
            }

        }
    }
}