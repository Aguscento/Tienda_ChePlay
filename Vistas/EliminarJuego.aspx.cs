using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class EliminarJuego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
        protected void btnEliminarJuego_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoEliminar")
            {
                NegocioJuegos neg = new NegocioJuegos();
                Boolean estado;
                estado = neg.eliminarJuego(txtCodigoEliminar.Text);
                if (estado == true)
                {
                    lblMensaje.Text = "Juego eliminada con exito";
                }
                else
                {
                    lblMensaje.Text = "No se puedo eliminar el juego";
                }

                txtCodigoEliminar.Text = "";
            }
        }
    }
}