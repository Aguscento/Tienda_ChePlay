using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioCategoria
    {
        public DataTable getTablaCategorias()
        {
            DatosCategoria conex = new DatosCategoria();
            return conex.getTabaCategorias();
        }
        public bool agregarCategoria(Categoria obj)
        {
            DatosCategoria conex = new DatosCategoria();
            return Convert.ToBoolean(conex.existeCategoria(obj));
        }
        public bool existeCategoria(Categoria obj)
        {
            DatosCategoria conex = new DatosCategoria();
            return conex.existeCategoria(obj.CodCategoria); ;
        }
    }
}
