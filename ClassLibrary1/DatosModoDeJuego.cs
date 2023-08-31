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
    public class DatosModoDeJuego
    {
        private Conexion conex = new Conexion();
        public DataTable getTabaModoDeJuegos()
        {
            DataTable tabla = conex.obtenerTaba("ModoDeJuego", "select * from ModosDeJuego");
            return tabla;
        }
        public DataTable getTablaModoDeJuego(ModoDeJuego obj)
        {
            DataTable tabla = conex.obtenerTaba("ModoDeJuego", "select * from ModosDeJuego where CodModoDeJuego_MDJ = '" + obj.Id_Modo + "'");
            return tabla;
        }
        public DataTable getTablaModoDeJuego(string codModoDeJuego)
        {
            DataTable tabla = conex.obtenerTaba("ModoDeJuego", "select * from ModosDeJuego where CodModoDeJuego_MDJ = '" + codModoDeJuego + "'");
            return tabla;
        }
        public bool existeModoDeJuego(ModoDeJuego obj)
        {
            string consultaSql = ""
                + "select * from ModosDeJuego where CodModoDeJuego_MDJ = '" + obj.Id_Modo + "'";
            return conex.existe(consultaSql);
        }
        public bool existeModoDeJuego(string codModoDeJuego)
        {
            string consultaSql = ""
                + "select * from ModosDeJuego where CodModoDeJuego_MDJ = '" + codModoDeJuego + "'";
            return conex.existe(consultaSql);
        }
        public int agregarModoDeJuegos(ModoDeJuego obj)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosModoDeJuego(ref comando, obj);
            return conex.ejecutarSentenciar(ref comando, "" +
                "insert into ModoDeJuegos (CodModoDeJuego_MDJ, NombreModo_MDJ) " +
                "values ( @CodJuego, @CodModoDeJuego)");
        }
        public void armarParametrosModoDeJuego(ref SqlCommand comando, ModoDeJuego obj)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@CodJuego", SqlDbType.NVarChar);
            parametros.Value = obj.Id_Modo;
            parametros = comando.Parameters.Add("@CodModoDeJuego", SqlDbType.NVarChar);
            parametros.Value = obj.NombreModo; ;
        }
    }
}
