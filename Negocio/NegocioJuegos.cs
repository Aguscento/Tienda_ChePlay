using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Datos;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioJuegos
    {
        public DataTable TodosLosJuegos()
        {
            Conexion cx = new Conexion();
            return cx.ObtenerTablaCompleta("Juegos");
        }
        public bool agregarJuego(Juego obj)
        {
            DatoJuego conexJuego = new DatoJuego();
            return Convert.ToBoolean(conexJuego.agregarJuego(obj));
        }
        public bool existeJuego(Juego obj)
        {
            DatoJuego conex = new DatoJuego();
            return conex.existeCodJuego(obj.CodJuego); ;
        }
        public bool existeJuego(string codJuego)
        {
            DatoJuego conex = new DatoJuego();
            return conex.existeCodJuego(codJuego); ;
        }
        public DataTable obtenerJuego(string codJuego)
        {
            DatoJuego conex = new DatoJuego();
            return conex.getTablaJuegos(codJuego);
        }
        public DataTable JuegosFiltrados(List<string>valores,string plat,string texto)
        {
            string filtros;
            if (valores == null)
            {
                filtros = null;
            }
            else
            {
                filtros = string.Join(", ", valores);
            }
            Conexion cx = new Conexion();
            return cx.ObtenerTablaFiltrada(filtros,plat,texto);
        }
        public bool eliminarJuego(string cod)
        {
            DatoJuego dao = new DatoJuego();
            Juego j = new Juego();
            j.CodJuego = cod;
            bool op = dao.eliminarJuego1(j);
            return op;
        }
        public bool agregarJuegoRelacionado(Juego objJuego, PlataformaPorJuego objPXJ, List<ModoPorJuego> objMXJ, List<CategoriaPorJuego> objCXJ)
        {
            DatoJuego conexJuego = new DatoJuego();
            return conexJuego.agregarJuegoRelacionados(objJuego, objPXJ, objMXJ, objCXJ);
        }
    }
}
