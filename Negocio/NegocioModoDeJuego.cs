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
    public class NegocioModoDeJuego
    {
        public DataTable getTablaModoDeJuegos()
        {
            DatosModoDeJuego conex = new DatosModoDeJuego();
            return conex.getTabaModoDeJuegos();
        }
        public bool agregarModoDeJuego(ModoDeJuego obj)
        {
            DatosModoDeJuego conex = new DatosModoDeJuego();
            return Convert.ToBoolean(conex.agregarModoDeJuegos(obj));
        }
        public bool existeModoDeJuego(ModoDeJuego obj)
        {
            DatosCategoria conex = new DatosCategoria();
            return conex.existeCategoria(obj.Id_Modo); ;
        }
    }
}
