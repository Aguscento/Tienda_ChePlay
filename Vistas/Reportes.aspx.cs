using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;


using System.Data;
using System.Data.SqlClient;

namespace Vistas
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnReporteFechas_Click(object sender, EventArgs e)
        {
            NegocioReporte regRepo = new NegocioReporte();
            gridReporteFechas.DataSource = regRepo.getGrillaReporteFecha("tableReporteFechas",txtFecha1.Text.Trim(),txtFecha2.Text.Trim());
            gridReporteFechas.DataBind();
            txtFecha1.Text = "";
            txtFecha2.Text = "";
        }

        protected void btnTopVentas_Click(object sender, EventArgs e)
        {
            
            NegocioReporte reporte = new NegocioReporte();
            gridTopVentas.DataSource = reporte.getJuegosTopVendidos(txtFechaDesde.Text.ToString(), txtFechaHasta.Text.ToString());
            gridTopVentas.DataBind();
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";
        }

        protected void btnFiltroTopUsuarios_Click(object sender, EventArgs e)
        {
            NegocioReporte obj = new NegocioReporte();
            gridTopUsuarios.DataSource = obj.getTopUsuarios();
            gridTopUsuarios.DataBind();
        }

        protected void btnInventario_Click(object sender, EventArgs e)
        {
            NegocioReporte obj = new NegocioReporte();
            GridInventario.DataSource = obj.getInventario();
            GridInventario.DataBind();
        }
    }
}