using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class IngresarUsuario : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.setNickName(txtNomUsuarioIng.Text.Trim());
            us.setContraseña(txtContraseñaIng.Text.Trim());
            NegocioUsuario negUs = new NegocioUsuario();
            bool existe = negUs.IniciarSession(us);

            if (existe == true)
            {
                Session["Usuario"] = txtNomUsuarioIng.Text.Trim();
                Response.Redirect("TiendaJuegos.aspx");
            }
            else
            {
                lblNoExiste.Text = "Usuario o Contraseña incorrecto";
                txtContraseñaIng.Text = "";
                txtNomUsuarioIng.Text = "";
            }
        }
    }
}