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
    public class DatosCategoriaPorJuego
    {
        private Conexion conex = new Conexion();

        public DataTable getTablaCategoriasPorJuegos()
        {
            DataTable tabla = conex.obtenerTaba("CategoriasPorJuegos", "select * from CategoriasxJuegos");
            return tabla;
        }
        public DataTable getTablaCategoriasPorJuegos(CategoriaPorJuego obj)
        {
            DataTable tabla = conex.obtenerTaba("CategoriasPorJuegos", "select * from CategoriasxJuegos where CodJuego_JU_CXJ = '" + obj.Juego.CodJuego + "' and CodCategoria_CT_CXJ = '" + obj.Categoria.CodCategoria + "'");
            return tabla;
        }
        public DataTable getTablaCategoriasPorJuegos(string codJuego, string codCategoria)
        {
            DataTable tabla = conex.obtenerTaba("CategoriasPorJuegos", "select * from CategoriasxJuegos where CodJuego_JU_CXJ = '" + codJuego + "' and CodCategoria_CT_CXJ = '" + codCategoria + "'");
            return tabla;
        }
        public bool existeCategoriasPorJuegos(CategoriaPorJuego obj)
        {
            string consultaSql = ""
                + "select * from CategoriasxJuegos where CodJuego_JU_CXJ = '" + obj.Juego.CodJuego + "' and CodCategoria_CT_CXJ = '" + obj.Categoria.CodCategoria + "'";
            return conex.existe(consultaSql);
        }
        public bool existeCategoriasPorJuegos(string codJuego, string codCategoria)
        {
            string consultaSql = ""
                + "select * from CategoriasxJuegos where CodJuego_JU_CXJ = '" + codJuego + "' and CodCategoria_CT_CXJ = '" + codCategoria + "'";
            return conex.existe(consultaSql);
        }
        public int agregarCategoriasPorJuegos(CategoriaPorJuego obj)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosJuego(ref comando, obj);
            return conex.ejecutarSentenciar(ref comando, "" +
                "insert into CategoriasxJuegos (CodJuego_JU_CXJ, CodCategoria_CT_CXJ) " +
                "values ( @CodJuego, @CodCategoria)");
        }
        public void armarParametrosJuego(ref SqlCommand comando, CategoriaPorJuego obj)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@CodJuego", SqlDbType.NVarChar);
            parametros.Value = obj.Juego.CodJuego;
            parametros = comando.Parameters.Add("@CodCategoria", SqlDbType.NVarChar);
            parametros.Value = obj.Categoria.CodCategoria;
        }
    }
}
