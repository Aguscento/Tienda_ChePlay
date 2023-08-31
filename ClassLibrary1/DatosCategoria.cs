using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosCategoria
    {
        private Conexion conex = new Conexion();

        public DataTable getTabaCategorias()
        {
            DataTable tabla = conex.obtenerTaba("Categoria", "select * from Categorias");
            return tabla;
        }
        public bool existeCategoria(Categoria obj)
        {
            string consultaSql = ""
                + "select * from Categorias where CodCategoria_CT = '" + obj.CodCategoria + "'";
            return conex.existe(consultaSql);
        }
        public bool existeCategoria(string codCategoria)
        {
            string consultaSql = ""
                + "select * from Categorias where CodCategorias_CT = '" + codCategoria + "'";
            return conex.existe(consultaSql);
        }
    }
}
