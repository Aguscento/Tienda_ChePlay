using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatoPlataforma
    {
        private Conexion conex = new Conexion();

        public DataTable getTablaPlataforma()
        {
            DataTable tabla = conex.obtenerTaba("Plataformas", "select * from Plataformas");
            return tabla;
        }
        public DataTable getTablaPlataforma(string codPlataforma)
        {
            DataTable tabla = conex.obtenerTaba("Plataformas", "select *from Plataformas where CodPlataforma_PL = '" + codPlataforma.ToString() + "'");
            return tabla;
        }
        public bool existeCodPlataforma(string codPlataforma)
        {
            string consultaSql = "select * from Plataforma where CodPlataforma_PL = '" + codPlataforma + "'";
            return conex.existe(consultaSql);
        }
        public bool existeNombrePlataforma(string nombrePlataforma)
        {
            string consultaSql = "select * from Plataforma where NombreDePlataforma_PL = '" + nombrePlataforma + "'";
            return conex.existe(consultaSql);
        }
        public int agregarPlataforma(Plataforma obj)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosPlataforma(ref comando, obj);
            return conex.ejecutarSentenciar(ref comando, "" +
                "insert into Juegos (CodPlataforma_PL, NombreDePlataforma_PL) " +
                "values ( @CodPlataforma, @NombrePlataforma)");
        }
        public void armarParametrosPlataforma(ref SqlCommand comando, Plataforma obj)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@CodPlataforma", SqlDbType.NVarChar);
            parametros.Value = obj.Id_Plataforma;
            parametros = comando.Parameters.Add("@NombrePlataforma", SqlDbType.NVarChar);
            parametros.Value = obj.Descripcion;
        }
    }
}
