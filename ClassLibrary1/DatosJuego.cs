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
    public class DatoJuego
    {
        private Conexion conex = new Conexion();
        
        public DataTable getTablaJuegos()
        {
            DataTable tabla = conex.obtenerTaba("Juegos","select * from Juegos");
            return tabla;
        }
        public DataTable getTablaJuegos(string codJuego)
        {
            DataTable tabla = conex.obtenerTaba("Juegos","select *from Juegos where CodJuego_JU = '"+codJuego.ToString()+"'");
            return tabla;
        }
        public bool existeCodJuego(string codJuego)
        {
            string consultaSql = "select * from Juegos where CodJuego_JU = '" + codJuego + "'";
            return conex.existe(consultaSql);
        }
        public bool existeCodJuego(Juego obj)
        {
            string consultaSql = "select * from Juegos where CodJuego_JU = '" + obj.CodJuego + "'";
            return conex.existe(consultaSql);
        }
        public bool existeNombreJuego(string nombreJuego)
        {
            string consultaSql = "select * from Juegos where Nombre_JU = '" + nombreJuego + "'";
            return conex.existe(consultaSql);
        }
        public int agregarJuego(Juego obj)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosJuego(ref comando,obj);
            return conex.ejecutarSentenciar(ref comando, "" +
                "insert into Juegos (CodJuego_JU, CodProveedor_PR_JU, Nombre_JU,Descripcion_JU, FechaDeLanzamiento_JU, URLportada_JU, Activo_JU) "+
                "values ( @CodJuego, @CodProveedor, @Nombre, @Descripcion, @FechaLanzamiento, @UrlPortada, @Activo)");
        }
        public void armarParametrosJuego(ref SqlCommand comando, Juego obj) 
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@CodJuego",SqlDbType.NVarChar);
            parametros.Value = obj.CodJuego;
            parametros = comando.Parameters.Add("@CodProveedor", SqlDbType.NVarChar);
            parametros.Value = obj.Proveedor.Id_Proveedor;
            parametros = comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
            parametros.Value = obj.NombreJuego;
            parametros = comando.Parameters.Add("@Descripcion",SqlDbType.NVarChar);
            parametros.Value = obj.Descripcion;
            parametros = comando.Parameters.Add("@FechaLanzamiento", (SqlDbType.DateTime));
            parametros.Value = obj.FechaDeLanzamiento;
            parametros = comando.Parameters.Add("@UrlPortada", SqlDbType.NVarChar);
            parametros.Value = obj.UrlPortada;
            parametros = comando.Parameters.Add("@Activo", SqlDbType.Bit);
            parametros.Value = obj.Activo;
        }
        public bool eliminarJuego1(Juego juego)
        {
            string sql = "DELETE FROM Juegos WHERE CodJuego_JU = '" + juego.CodJuego + "'";
            bool b = conex.existe(sql);
            return b;
        }
        /*
        private void ArmarParametrosJuegoEliminar(ref SqlCommand Comando, Juego j)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CODJUEGO", SqlDbType.Char);
            SqlParametros.Value = j.CodJuego;
        }
        */
        public bool agregarJuegoRelacionados(Juego objJuego, PlataformaPorJuego objPXJ, List<ModoPorJuego> objListaMXJ, List<CategoriaPorJuego> objListaCXJ)
        {

            DatosPlataformaPorJuego conexPXJ = new DatosPlataformaPorJuego();
            DatosModoPorJuego conexMXJ = new DatosModoPorJuego();
            DatosCategoriaPorJuego conexCXJ = new DatosCategoriaPorJuego();

            SqlConnection conexion = conex.ObtenerConexion();
            SqlCommand comando = conex.ObtenerConexion().CreateCommand();
            SqlTransaction transaccion = null;
            transaccion = conexion.BeginTransaction();
            comando.Connection = conexion;
            comando.Transaction = transaccion;

            try
            {
                if (!existeCodJuego(objJuego))
                {
                    if (!Convert.ToBoolean(agregarJuego(objJuego)))
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }
                if (!Convert.ToBoolean(conexPXJ.agregarPlataformaPorJuego(objPXJ)))
                {
                    transaccion.Rollback();
                    return false;
                }

                CategoriaPorJuego objCXJ = new CategoriaPorJuego();
                bool agregadoCXJ = true;
                foreach (CategoriaPorJuego variable in objListaCXJ)
                {
                    objCXJ = variable;
                    if (conexCXJ.existeCategoriasPorJuegos(objCXJ) == false)
                    {
                        agregadoCXJ = Convert.ToBoolean(conexCXJ.agregarCategoriasPorJuegos(objCXJ));
                        if (!agregadoCXJ)
                        {
                            transaccion.Rollback();
                            return false;
                        }
                    }
                }
                ModoPorJuego objMXJ = new ModoPorJuego();
                bool agregadoMXJ = true;
                foreach (ModoPorJuego variable in objListaMXJ)
                {
                    objMXJ = variable;
                    if (conexMXJ.existeModosPorJuegos(objMXJ) == false)
                    {
                        agregadoMXJ = Convert.ToBoolean(conexMXJ.agregarModoPorJuegos(objMXJ));
                        if (!agregadoMXJ)
                        {
                            transaccion.Rollback();
                            return false;
                        }
                    }
                }
                transaccion.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                transaccion.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return false;
            }
            finally
            {
                transaccion?.Dispose();
                conexion.Close();
            }
        }

    }
}
