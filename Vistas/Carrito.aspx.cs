using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = (string)Session["Usuario"];

            if (Session["Carrito"] != null)
            {
                refreshTable();
                //decimal PrecioTotal = 0;
                //foreach (DataRow row in ((DataTable)Session["Carrito"]).Rows)
                //{
                //    PrecioTotal += decimal.Parse(row["Precio"].ToString());
                //}
                //lblTotal.Text = $"El total de la compra seria de {PrecioTotal}$";
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            NegocioUsuario negUs = new NegocioUsuario();
            NegocioVenta negVent = new NegocioVenta();
            NegocioDetalleVenta negDV = new NegocioDetalleVenta();
            Venta Venta = new Venta();
            if (Session["Usuario"] == null)
            {
                lblPrueba.Text = "Debe Iniciar Session";
                return;
            }
            Venta.setDniUsuario(negUs.getDni((string)Session["Usuario"]));
            if (Session["Carrito"] != null)
            {
                DataTable tablaSession = (DataTable)Session["Carrito"];
                if (tablaSession.Rows.Count > 0)
                {
                    if (negVent.EjecutarInsertVentas(Venta) == false)
                    {
                        lblPrueba.Text = "Error al ejecutar la venta";
                        return;
                    }

                    foreach (DataRow row in tablaSession.Rows)
                    {
                        DetalleVenta detalleVenta = new DetalleVenta
                        (
                            row["Nombre"].ToString(),
                            row["Plataforma"].ToString(),
                            decimal.Parse(row["Precio"].ToString())
                        );
                        if (negDV.EjecutarInsertDetalle(detalleVenta) == false)
                        {
                            lblPrueba.Text = "Error al crear los detalles de venta";
                            return;
                        }
                    }
                }

            }
            else
            {
                lblPrueba.Text = "No selecciono ningun juego";
                return;
            }
            Session["Carrito"] = null;
            GrdJuegosCarrito.DataSource = null;
            GrdJuegosCarrito.DataBind();
            lblTotal.Text = "";
            lblPrueba.Text = "Compra exitosa!";
            return;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("Inicio.aspx");
        }

        protected void GrdJuegosCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowId = e.RowIndex;
            ((DataTable)Session["Carrito"]).Rows[rowId].Delete();
            Session["Carrito"] = (DataTable)Session["Carrito"];
            refreshTable();
            GrdJuegosCarrito.EditIndex = -1;
        }

        protected void refreshTable()
        {
            GrdJuegosCarrito.DataSource = (DataTable)Session["Carrito"];
            GrdJuegosCarrito.DataBind();
            decimal PrecioTotal = 0;
            foreach (DataRow row in ((DataTable)Session["Carrito"]).Rows)
            {
                PrecioTotal += decimal.Parse(row["Precio"].ToString());
            }
            lblTotal.Text = $"El total de la compra seria de {PrecioTotal}$";
        }
    }
}