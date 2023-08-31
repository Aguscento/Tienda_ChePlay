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
    public class NegocioCategoriaPorJuego
    {
        public bool agregarCategoriaPorJuego(CategoriaPorJuego obj)
        {
            DatosCategoriaPorJuego conex = new DatosCategoriaPorJuego();
            return Convert.ToBoolean(conex.agregarCategoriasPorJuegos(obj));
        }
        public bool agregarCategoriaPorJuego(List<CategoriaPorJuego> obj)
        {
            DatosCategoriaPorJuego conex = new DatosCategoriaPorJuego();
            CategoriaPorJuego objCXJ = new CategoriaPorJuego();
            bool agregado = true;
            foreach (CategoriaPorJuego variable in obj)
            {
                objCXJ.Categoria.CodCategoria = variable.Categoria.CodCategoria.ToString();
                objCXJ.Juego.CodJuego = variable.Juego.CodJuego.ToString();
                if (conex.existeCategoriasPorJuegos(objCXJ) == false)
                {
                    agregado = Convert.ToBoolean(conex.agregarCategoriasPorJuegos(objCXJ));
                    if (!agregado)
                        break;
                }
            }
            return agregado;
        }
        public bool existeCategoriaPorJuego(CategoriaPorJuego obj)
        {
            DatosCategoriaPorJuego conex = new DatosCategoriaPorJuego();
            return conex.existeCategoriasPorJuegos(obj);
        }
        public bool existeCategoriaPorJuego(string codJuego, string codCategoria)
        {
            DatosCategoriaPorJuego conex = new DatosCategoriaPorJuego();
            return conex.existeCategoriasPorJuegos(codJuego, codCategoria);
        }
        public bool existeCategoriaPorJuego(List<CategoriaPorJuego> obj)
        {
            DatosCategoriaPorJuego conex = new DatosCategoriaPorJuego();
            CategoriaPorJuego objCXJ = new CategoriaPorJuego();
            foreach (CategoriaPorJuego variable in obj)
            {
                objCXJ.Categoria.CodCategoria = variable.Categoria.CodCategoria.ToString();
                objCXJ.Juego.CodJuego = variable.Juego.CodJuego.ToString();
                if (conex.existeCategoriasPorJuegos(objCXJ))
                    return true;
            }
            return false;
        }
    }
}
