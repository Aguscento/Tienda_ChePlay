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
    public partial class HistorialVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void gridVentas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string codigoVenta = ((Label)gridVentas.Rows[e.NewSelectedIndex].FindControl("lblCodVenta")).Text.Trim();
            NegocioVenta negVen = new NegocioVenta();
            CargarGrillaDetalle(negVen.ObtenerGrillaDetalle("TablaDetalla", codigoVenta));

        }
        protected void CargarGrillaDetalle(DataTable datos)
        {
            gridDetalleVenta.DataSource = datos;
            gridDetalleVenta.DataBind();
        }
    }
}