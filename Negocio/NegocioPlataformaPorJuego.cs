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
    public class NegocioPlataformaPorJuego
    {
        public bool agregarPlataformaPorjuego(PlataformaPorJuego obj)
        {
            DatosPlataformaPorJuego conex = new DatosPlataformaPorJuego();
            return Convert.ToBoolean(conex.agregarPlataformaPorJuego(obj));
        }
        public bool existePlataformaPorJuego(PlataformaPorJuego obj)
        {
            DatosPlataformaPorJuego conex = new DatosPlataformaPorJuego();
            return conex.existeCodPlataformaPorJuegos(obj);
        }
        public bool existePlataformaPorJuego(string codJuego, string codPlataforma)
        {
            DatosPlataformaPorJuego conex = new DatosPlataformaPorJuego();
            return conex.existeCodPlataformaPorJuegos(codJuego, codPlataforma);
        }
        public bool editarPrecio(string NombreJuego, string NombrePlataforma, string precio)
        {
            PlataformaPorJuego pxj = new PlataformaPorJuego();
            Juego j = new Juego();
            Plataforma p = new Plataforma();

            j.NombreJuego = NombreJuego;
            p.Descripcion = NombrePlataforma;
            pxj.PrecioUnitario = float.Parse(precio);

            DatosPlataformaPorJuego dao = new DatosPlataformaPorJuego();

            int op = dao.editarPrecioUnitario(pxj, j, p);

            if (op == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
