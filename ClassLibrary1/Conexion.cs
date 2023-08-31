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
    public class Conexion
    {
        private string rutaBase = "Data Source=localhost\\sqlexpress;Initial Catalog=ChePlay;Integrated Security=True";
        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBase);
            try
            {
                cn.Open();
                return cn;
            }
            catch
            {
                return null;
            }
        }
        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter adap;
            try
            {
                adap = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return adap;
            }
            catch
            {
                return null;
            }
        }
        public DataTable ObtenerTablaCompleta(string NombreTabla)
        {
            string ConsultaSql = "select Nombre_JU as 'nombre Del Juego',NombreDePlataforma_PL as 'Plataforma',PrecioUnitario_PXJ as 'Precio' " +
                "from (Juegos inner join PlataformasxJuegos  on CodJuego_JU = CodJuego_JU_PXJ) " +
                "inner join Plataformas on CodPlataforma_PL = CodPlataforma_PL_PXJ";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = ObtenerAdaptador(ConsultaSql);
            adp.Fill(ds, NombreTabla);
            ObtenerConexion().Close();
            return ds.Tables[NombreTabla];
        }

        public DataTable ObtenerTablaFiltrada(string Categorias,string plataforma,string texto)
        {
            string ConsultaSql = "SELECT Juegos.Nombre_JU,NombreDePlataforma_PL, Juegos.URLportada_JU, Juegos.Descripcion_JU, PlataformasxJuegos.PrecioUnitario_PXJ " +
                "from Juegos " +
                "inner join PlataformasxJuegos on CodJuego_JU = CodJuego_JU_PXJ " +
                "inner join Plataformas on CodPlataforma_PL = CodPlataforma_PL_PXJ " +
                "inner join CategoriasxJuegos on CodJuego_JU = CodJuego_JU_CXJ " +
                "inner join Categorias on CodCategoria_CT = CodCategoria_CT_CXJ "+
                "WHERE CodPlataforma_PL = '"+plataforma+"' ";
                
                if(Categorias != null)
                {
                    ConsultaSql += "AND CodCategoria_CT IN (" + Categorias + ") ";
                }
                if (texto != null)
                {
                    ConsultaSql += "AND Nombre_JU LIKE '"+texto+"%'";
                }

            DataSet ds = new DataSet();
            SqlDataAdapter adp = ObtenerAdaptador(ConsultaSql);
            adp.Fill(ds,"TablaFinal");
            ObtenerConexion().Close();
            return ds.Tables["TablaFinal"];
        }


        public DataTable obtenerTaba(string nombreTabla, string consultaSql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adaptador = ObtenerAdaptador(consultaSql);
            adaptador.Fill(ds,nombreTabla);
            ObtenerConexion().Close();
            return ds.Tables[nombreTabla];
        }
        public int ejecutarSentenciar(ref SqlCommand cmd, string consultaSql)
        {
            SqlCommand comando = new SqlCommand();
            comando=cmd;
            comando.Connection=ObtenerConexion();
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSql;
            int numFilas = comando.ExecuteNonQuery();
            return numFilas;
        }
        public bool existe(string consultaSql)
        {
            Boolean estado;
            SqlCommand comando = new SqlCommand(consultaSql, ObtenerConexion());
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read())
            {
                estado = true;
            }
            else
            {
                estado = false;
            }
            return estado;
        }
        public SqlCommand obtenerComando(string consulta)
        {
            SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
            return comando;
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public string buscarCodigoJuego(string consulta, Juego j)
        {
            SqlConnection cn = ObtenerConexion();
            SqlCommand sql = new SqlCommand(consulta, cn);
            sql.Parameters.AddWithValue("@nombreJuego", j.NombreJuego);

            SqlDataReader reader = sql.ExecuteReader();

            if (reader.Read())
            {
                string codJuego = reader.GetString(0);
                return codJuego;
            }

            return "0";
        }
        public string buscarCodigoPlataforma(string consulta, Plataforma p)
        {
            SqlConnection cn = ObtenerConexion();
            SqlCommand sql = new SqlCommand(consulta, cn);
            sql.Parameters.AddWithValue("@nombrePlataforma", p.Descripcion);

            SqlDataReader reader = sql.ExecuteReader();

            if (reader.Read())
            {
                string codPlataforma = reader.GetString(0);
                return codPlataforma;
            }
            return "0";
        }
    }
}
