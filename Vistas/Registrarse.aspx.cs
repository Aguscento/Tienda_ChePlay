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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            NegocioUsuario negUsu = new NegocioUsuario();
            us.setNombre(txtNombreReg.Text.Trim());
            us.setApellido(txtApellidoReg.Text.Trim());
            us.setDniUsuario(txtDNIReg.Text.Trim());
            us.setTelefono(txtTelefonoReg.Text.Trim().ToString());
            us.setNickName(txtNickNameReg.Text.Trim());
            us.setContraseña(txtRepConstraseñaReg.Text.Trim());
            bool registro = negUsu.Registrarse(us);
            if (registro == true)
            {
                Response.Redirect("TiendaJuegos.aspx");
            }
            else
            {
                lblErorRegistro.Text = "Error al registrarse";
                borrarTxt();
            }
        }

        private void borrarTxt()
        {
            txtApellidoReg.Text = "";
            txtContraseñaReg.Text = "";
            txtDireccionReg.Text = "";
            txtDNIReg.Text = "";
            txtNickNameReg.Text = "";
            txtNombreReg.Text = "";
            txtRepConstraseñaReg.Text = "";
            txtTelefonoReg.Text = "";
        }
       
    }
}