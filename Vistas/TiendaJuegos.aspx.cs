using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class TiendaJuegos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = (string)Session["Usuario"];
        }

        protected void chk_categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTabla(null);
        }

        protected void ddl_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTabla(null);
        }

        protected void listJuegos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (listJuegos.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ActualizarTabla(null);
        }

        protected void ActualizarTabla(string texto)
        {
            //Almaceno toda la lista de valores chequeados
            bool minimoCheck = false;
            string plataforma = ddl_categoria.SelectedValue.ToString();
            List<string> valores = new List<string>();
            foreach (ListItem item in chk_categorias.Items)
            {
                if (item.Selected)
                {
                    string valor = "'" + item.Value.ToString() + "'";
                    valores.Add(valor);
                    minimoCheck = true;
                }
            }
            if (minimoCheck)
            {
                NegocioJuegos consulta = new NegocioJuegos();
                listJuegos.DataSource = consulta.JuegosFiltrados(valores,plataforma,texto);
                listJuegos.DataBind();
            }
            else
            {
                NegocioJuegos consulta = new NegocioJuegos();
                listJuegos.DataSource = consulta.JuegosFiltrados(null, plataforma,texto);
                listJuegos.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            if(txtNombreFiltro.Text != null)
            {
                string nombrejuego = txtNombreFiltro.Text.Trim();
                txtNombreFiltro.Text = null;
                ActualizarTabla(nombrejuego);
                
            }
        }

        protected void btnAgregar_Carrito(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "AgregarAlCarrito")
            {
                if (Session["Carrito"] == null)
                {
                    Session["Carrito"] = crearTablaCarrito();
                }
            }
            string[] datosJuego = e.CommandArgument.ToString().Split('#');
            agregarAlCarrito((DataTable)Session["Carrito"], datosJuego);
        }

        protected DataTable crearTablaCarrito()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("Nombre", System.Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("Plataforma", System.Type.GetType("System.String"));
            table.Columns.Add(column);
            column = new DataColumn("Precio", System.Type.GetType("System.String"));
            table.Columns.Add(column);
            return table;
        }

        protected void agregarAlCarrito(DataTable table, string[] datosJuego)
        {
            if (!repetido(table, datosJuego))
            {
                DataRow row = table.NewRow();
                row.ItemArray = datosJuego;
                table.Rows.Add(row);
            }
        }
        protected bool repetido(DataTable table, string[] datosJuego)
        {
            bool existe = false;
            string preCarrito = datosJuego[0] + datosJuego[1];
            foreach (DataRow dataRow in table.Rows)
            {
                string enCarrito = dataRow["Nombre"].ToString() + dataRow["Plataforma"];
                if (preCarrito == enCarrito)
                {
                    existe = true;
                }
            }
            return existe;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("Inicio.aspx");
        }
    }
}