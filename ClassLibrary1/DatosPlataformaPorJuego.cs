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
    public class DatosPlataformaPorJuego
    {
        private Conexion conex = new Conexion();

        public DataTable getTablaPlataformaPorJuegos()
        {
            DataTable tabla = conex.obtenerTaba("PlataformaPorJuegos", "select * from PlataformasxJuegos");
            return tabla;
        }
        public DataTable getTablaPlataformaPorJuegos(PlataformaPorJuego obj)
        {
            DataTable tabla = conex.obtenerTaba("PlataformaPorJuegos", "select * from PlataformasxJuegos where CodJuego_JU_PXJ = '" + obj.Juego.CodJuego + "' and CodPlataforma_PL_PXJ = '" + obj.Plataforma.Id_Plataforma + "'");
            return tabla;
        }
        public DataTable getTablaPlataformaPorJuegos(string codJuego, string codPlataforma)
        {
            DataTable tabla = conex.obtenerTaba("PlataformaPorJuegos", "select * from PlataformasxJuegos where CodJuego_JU_PXJ = '" + codJuego + "' and CodPlataforma_PL_PXJ = '" + codPlataforma + "'");
            return tabla;
        }
        public bool existeCodPlataformaPorJuegos(PlataformaPorJuego obj)
        {
            string consultaSql = ""
                +"select * from PlataformasxJuegos where CodJuego_JU_PXJ = '" + obj.Juego.CodJuego + "' and CodPlataforma_PL_PXJ = '" + obj.Plataforma.Id_Plataforma + "'";
            return conex.existe(consultaSql);
        }
        public bool existeCodPlataformaPorJuegos(string codJuego, string codPlataforma)
        {
            string consultaSql = ""
                + "select * from PlataformasxJuegos where CodJuego_JU_PXJ = '" + codJuego + "' and CodPlataforma_PL_PXJ = '" + codPlataforma + "'";
            return conex.existe(consultaSql);
        }
        public int agregarPlataformaPorJuego(PlataformaPorJuego obj)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosJuego(ref comando, obj);
            return conex.ejecutarSentenciar(ref comando, "" +
                "insert into PlataformasxJuegos (CodJuego_JU_PXJ, CodPlataforma_PL_PXJ, Stock_PXJ, PrecioUnitario_PXJ, Activo_PXJ) " +
                "values ( @CodJuego, @CodPlataforma, @Stock, @Precio, @Activo)");
        }
        public void armarParametrosJuego(ref SqlCommand comando, PlataformaPorJuego obj)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@CodJuego", SqlDbType.NVarChar);
            parametros.Value = obj.Juego.CodJuego;
            parametros = comando.Parameters.Add("@CodPlataforma", SqlDbType.NVarChar);
            parametros.Value = obj.Plataforma.Id_Plataforma;
            parametros = comando.Parameters.Add("@Stock", SqlDbType.Int);
            parametros.Value = obj.Stock;
            parametros = comando.Parameters.Add("@Precio", SqlDbType.Int);
            parametros.Value = obj.PrecioUnitario;
            parametros = comando.Parameters.Add("@Activo", SqlDbType.Bit);
            parametros.Value = obj.Activo;
        }

        public int editarPrecioUnitario(PlataformaPorJuego pxj, Juego j, Plataforma p)
        {
            string consulta1 = "SELECT CodJuego_JU FROM Juegos WHERE Nombre_JU = @nombreJuego";
            string codJuego = conex.buscarCodigoJuego(consulta1, j);

            string consulta2 = "SELECT CodPlataforma_PL FROM  Plataformas WHERE NombreDePlataforma_PL = @nombrePlataforma";
            string codPlataforma = conex.buscarCodigoPlataforma(consulta2, p);

            if (codJuego != "0")
            {
                pxj.Juego.CodJuego = codJuego;
            }
            else
            {
                return 0;
            }
            if (codPlataforma != "0")
            {
                pxj.Plataforma.Id_Plataforma = codPlataforma;
            }
            else
            {
                return 0;
            }

            SqlCommand comando = new SqlCommand();
            ArmarParametros(ref comando, pxj);
            return conex.EjecutarProcedimientoAlmacenado(comando, "spEditarPrecio");
        }

        private void ArmarParametros(ref SqlCommand Comando, PlataformaPorJuego pxj)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODJUEGO", SqlDbType.Char);
            SqlParametros.Value = pxj.Juego.CodJuego;
            SqlParametros = Comando.Parameters.Add("@CODPLATAFORMA", SqlDbType.Char);
            SqlParametros.Value = pxj.Plataforma.Id_Plataforma;
            SqlParametros = Comando.Parameters.Add("@PRECIOUNITARIO", SqlDbType.Int);
            SqlParametros.Value = pxj.PrecioUnitario;
        }
    }
}
