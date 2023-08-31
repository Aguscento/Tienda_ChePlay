using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class AgregarJuego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                cargarOpciones();
            }
        }
        protected void btnAgregarJuego_Click(object sender, EventArgs e)
        {
            Juego objJuego = new Juego();
            NegocioJuegos objNegocioJuego = new NegocioJuegos();

            PlataformaPorJuego objPlataformaPorJuego = new PlataformaPorJuego();
            NegocioPlataformaPorJuego objNegocioPlataformaPorJuego = new NegocioPlataformaPorJuego();

            List<ModoPorJuego> objListaModoPorJuego = new List<ModoPorJuego>();

            List<CategoriaPorJuego> objListaCategoriaPorJuego = new List<CategoriaPorJuego>();


            guardarSeleccion(ref objJuego, ref objPlataformaPorJuego, ref objListaModoPorJuego, ref objListaCategoriaPorJuego);
            if (objListaModoPorJuego.Count > 0 && objListaCategoriaPorJuego.Count > 0)
            {
                if (objNegocioPlataformaPorJuego.existePlataformaPorJuego(objPlataformaPorJuego.Juego.CodJuego, objPlataformaPorJuego.Plataforma.Id_Plataforma) == false)
                {
                    mostrarMensaje(objNegocioJuego.agregarJuegoRelacionado(objJuego, objPlataformaPorJuego, objListaModoPorJuego, objListaCategoriaPorJuego));
                }
                else { lblMensajeBtnAceptar.Text = "No se pudo agregar a la BASE DE DATOS, EL JUEGO INGRESADO YA EXISTE EN LA PLATAFORMA INDICADA"; }
            }
            else { lblMensajeBtnAceptar.Text = "seleccione al menos un Modo y Categoria"; }
        }
        /***** *****/
        protected void guardarSeleccionListaModos(ref List<ModoPorJuego> objListaMXJ, string codJuego)
        {
            foreach (ListItem item in cblModoDeJuego.Items)
            {
                if (item.Selected)
                {
                    ModoPorJuego objMXJ = new ModoPorJuego();
                    objMXJ.ModoDeJuego.Id_Modo = item.Value;
                    objMXJ.Juego.CodJuego = codJuego;
                    objListaMXJ.Add(objMXJ);
                }
            }
        }
        protected void guardarSeleccionListaCategorias(ref List<CategoriaPorJuego> objListaCXJ, string codJuego)
        {
            foreach (ListItem item in cblCategoria.Items)
            {
                if (item.Selected)
                {
                    CategoriaPorJuego objCXJ = new CategoriaPorJuego();
                    objCXJ.Categoria.CodCategoria = item.Value;
                    objCXJ.Juego.CodJuego = codJuego;
                    objListaCXJ.Add(objCXJ);
                }
            }
        }
        protected void guardarSeleccion(ref Juego obj1, ref PlataformaPorJuego obj2, ref List<ModoPorJuego> obj3, ref List<CategoriaPorJuego> obj4)
        {
            obj1.CodJuego = txtCodJuego.Text.ToString().Trim();
            obj1.Proveedor.Id_Proveedor = ddlProveedores.SelectedValue;
            obj1.NombreJuego = txtNomJuego.Text.ToString().Trim();
            obj1.Descripcion = txtDescripcion.Text.ToString().Trim();
            obj1.FechaDeLanzamiento = txtFechaLanz.Text.ToString().Trim();
            obj1.UrlPortada = txtUrlPortada.Text.ToString().Trim();
            obj1.Activo = true;

            obj2.Juego.CodJuego = txtCodJuego.Text.ToString().Trim();
            obj2.Plataforma.Id_Plataforma = ddlPlataformas.SelectedValue;
            obj2.Stock = Convert.ToInt32(TxtStock.Text.ToString().Trim());
            obj2.PrecioUnitario = Convert.ToInt32(txtPrecio.Text.ToString().Trim());
            obj2.Activo = true;

            guardarSeleccionListaModos(ref obj3, obj1.CodJuego);
            guardarSeleccionListaCategorias(ref obj4, obj1.CodJuego);
        }
        protected void cargarCblModoDejuego()
        {
            NegocioModoDeJuego obj = new NegocioModoDeJuego();
            cblModoDeJuego.DataSource = obj.getTablaModoDeJuegos();
            cblModoDeJuego.DataTextField = "NombreModo_MDJ";
            cblModoDeJuego.DataValueField = "CodModoDeJuego_MDJ";
            cblModoDeJuego.DataBind();
        }
        protected void cargarCategoria()
        {
            NegocioCategoria obj = new NegocioCategoria();
            cblCategoria.DataSource = obj.getTablaCategorias();
            cblCategoria.DataTextField = "NombreDeCategoria_CT";
            cblCategoria.DataValueField = "CodCategoria_CT";
            cblCategoria.DataBind();
        }
        protected void cargarDdlProveedores()
        {
            NegocioProveedor obj = new NegocioProveedor();
            ddlProveedores.DataSource = obj.getTablaProveedor();
            ddlProveedores.DataTextField = "CodProveedor_PR";
            ddlProveedores.DataValueField = "CodProveedor_PR";
            ddlProveedores.DataBind();
            ddlProveedores.Items.Insert(0, "--Seleccionar--");
        }
        protected void cargarDdlPlataforma()
        {
            NegocioPlataforma obj = new NegocioPlataforma();
            ddlPlataformas.DataSource = obj.getTablaPlataforma();
            ddlPlataformas.DataTextField = "NombreDePlataforma_PL";
            ddlPlataformas.DataValueField = "CodPlataforma_PL";
            ddlPlataformas.DataBind();
            ddlPlataformas.Items.Insert(0, "--Seleccionar--");
        }

        protected void cargarOpciones()
        {
            cargarCategoria();
            cargarCblModoDejuego();
            cargarDdlPlataforma();
            cargarDdlProveedores();
        }
        protected void mostrarMensaje(bool valor1, bool valor2, bool valor3, bool valor4)
        {
            if (valor1 && valor2 && valor3 && valor4) { lblMensajeBtnAceptar.Text = "Se Agrego De Forma Exitosa"; }
            else { lblMensajeBtnAceptar.Text = "No se pudo agregar a la BASE DE DATOS"; }
        }
        protected void mostrarMensaje(bool valor1)
        {
            if (valor1)
            {
                lblMensajeBtnAceptar.Text = "Se Agrego De Forma Exitosa";
                limpiarDatosBox();
                cargarDdlProveedores();
            }
            else { lblMensajeBtnAceptar.Text = "No se pudo agregar a la BASE DE DATOS"; }
        }
        protected void limpiarDatosBox()
        {
            txtCodJuego.Text = "";  //codigo del juego
            txtNomJuego.Text = "";  //nombre del juego
            txtDescripcion.Text = "";//descripcion del juego
            txtFechaLanz.Text = ""; //fecha de lanzamiento
            txtUrlPortada.Text = "";//direccion URL de la fotod e portada
            TxtStock.Text = "";     //stock cantidad disponible
            txtPrecio.Text = "";    //Precio del juego
            cblCategoria.ClearSelection();
            cblModoDeJuego.ClearSelection();
            //ddlPlataformas.Items.Insert(0,"--Seleccionar--");//lista desplegable de plataformas
            //ddlProveedores.Items.Insert(0,"--Seleccionar--");//lista desplegable de proveedores
            ddlPlataformas.ClearSelection();
            ddlProveedores.ClearSelection();
        }
        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void txtCodJuego_TextChanged(object sender, EventArgs e)
        {
            NegocioJuegos objNegocioJuego = new NegocioJuegos();
            if (objNegocioJuego.existeJuego(txtCodJuego.Text.ToString()))
            {

                ddlProveedores.DataSource = objNegocioJuego.obtenerJuego(txtCodJuego.Text.ToString());
                ddlProveedores.DataTextField = "CodProveedor_PR_JU";
                ddlProveedores.DataValueField = "CodProveedor_PR_JU";
                ddlProveedores.DataBind();
                //ddlProveedores.Items.Insert(0, "--Seleccionar--");
            }
            else
            {
                cargarDdlProveedores();
                ddlProveedores.ClearSelection();
            }
        }
    }
}