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
    public class NegocioModoPorJuego
    {
        public bool agregarModoPorjuego(ModoPorJuego obj)
        {
            DatosModoPorJuego conex = new DatosModoPorJuego();
            return Convert.ToBoolean(conex.agregarModoPorJuegos(obj));
        }
        public bool agregarModoPorJuego(List<ModoPorJuego> obj)
        {
            DatosModoPorJuego conex = new DatosModoPorJuego();
            ModoPorJuego objMXJ = new ModoPorJuego();
            bool agregado = true;
            foreach (ModoPorJuego variable in obj)
            {
                objMXJ.ModoDeJuego.Id_Modo = variable.ModoDeJuego.Id_Modo.ToString();
                objMXJ.Juego.CodJuego = variable.Juego.CodJuego.ToString();
                if (conex.existeModosPorJuegos(objMXJ) == false)
                {
                    agregado = Convert.ToBoolean(conex.agregarModoPorJuegos(objMXJ));
                    if (!agregado)
                        break;
                }
            }
            return agregado;
        }
        public bool existeModoPorJuego(ModoPorJuego obj)
        {
            DatosModoPorJuego conex = new DatosModoPorJuego();
            return conex.existeModosPorJuegos(obj);
        }
        public bool existeModoPorJuego(string codJuego, string codCategoria)
        {
            DatosModoPorJuego conex = new DatosModoPorJuego();
            return conex.existeModosPorJuegos(codJuego, codCategoria);
        }
        public bool existeModoPorJuego(List<ModoPorJuego> obj)
        {
            DatosModoPorJuego conex = new DatosModoPorJuego();
            ModoPorJuego objMXJ = new ModoPorJuego();
            foreach (ModoPorJuego variable in obj)
            {
                objMXJ.ModoDeJuego.Id_Modo = variable.ModoDeJuego.Id_Modo.ToString();
                objMXJ.Juego.CodJuego = variable.Juego.CodJuego.ToString();
                if (conex.existeModosPorJuegos(objMXJ))
                    return true;
            }
            return false;
        }
    }
}
