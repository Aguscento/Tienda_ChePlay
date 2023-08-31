using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DatosReporte
    {
        private Conexion conex = new Conexion();
        public DataTable ObtenerGrillaReporteFechas(string NombreTabla, string fecha1,string fecha2)
        {
            string ConsultaSql = "SELECT SUM(TotalVenta_VN) as 'Total De Ventas' " +
                "FROM Ventas INNER JOIN Usuarios " +
                "on Ventas.DniUsuario_US_VN = Usuarios.DniUsuario_US " +
                $"WHERE Ventas.FechaVenta_VN BETWEEN '{fecha1}' AND '{fecha2}'";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = conex.ObtenerAdaptador(ConsultaSql);
            adp.Fill(ds, NombreTabla);
            conex.ObtenerConexion().Close();
            return ds.Tables[NombreTabla];
        }
        public DataTable obtenerJuegosTopVendidos(string fechaInicio,string fechaFinal)
        {
            string consultaSql = "SELECT TOP 10 Juegos.CodJuego_JU, Juegos.Nombre_JU, SUM(DetalleVentas.Cantidad_DV) AS TotalVentas " +
                                 "FROM Juegos " +
                                 "INNER JOIN PlataformasxJuegos ON Juegos.CodJuego_JU = PlataformasxJuegos.CodJuego_JU_PXJ " +
                                 "INNER JOIN DetalleVentas ON PlataformasxJuegos.CodJuego_JU_PXJ = DetalleVentas.CodJuego_PXJ_DV " +
                                 "INNER JOIN Ventas ON DetalleVentas.CodVenta_VN_DV = Ventas.CodVenta_VN " +
                                 "WHERE Ventas.FechaVenta_VN >= '" + fechaInicio + "' AND Ventas.FechaVenta_VN <= '" + fechaFinal + "' " +
                                 "GROUP BY Juegos.CodJuego_JU, Juegos.Nombre_JU " +
                                 "ORDER BY TotalVentas DESC";

            DataTable tablaDeDatos = new DataTable();
            tablaDeDatos = conex.obtenerTaba("Tabla", consultaSql);
            return tablaDeDatos;
        }
        public DataTable obtenerTopUsuarios() 
        {
            string consultaSql =    "SELECT TOP 5 " +
                                    "Usuarios.DniUsuario_US AS DniUsuario, " +
                                    "Usuarios.NombreDeUsuario_US AS NombreUsuario, " +
                                    "Usuarios.Telefono_US AS Telefono, " +
                                    "SUM(Ventas.TotalVenta_VN) AS TotalGastado " +
                                    "FROM Ventas " +
                                    "INNER JOIN Usuarios ON Ventas.DniUsuario_US_VN = Usuarios.DniUsuario_US " +
                                    "WHERE YEAR(Ventas.FechaVenta_VN) = YEAR(GETDATE()) " +
                                    "GROUP BY Usuarios.DniUsuario_US, Usuarios.NombreDeUsuario_US, Usuarios.Telefono_US " +
                                    "ORDER BY TotalGastado DESC";
            return conex.obtenerTaba("Tabla", consultaSql);
        }       
        public DataTable obtenerInventario()
        {
            string consultaSql = "SELECT Juegos.Nombre_JU AS Producto, " +
                                //Si la fecha de venta es nula, utilizar la fecha actual formateada
                                "ISNULL(FORMAT(Ventas.FechaVenta_VN, 'dd/MM/yyyy'), FORMAT(GETDATE(), 'dd/MM/yyyy')) AS Fecha, " +
                                //Sumar la cantidad vendida de cada juego en detalle de ventas 
                                "COALESCE(SUM(DetalleVentas.Cantidad_DV), 0) AS CantidadVendida, " +
                                //Calcular el stock actual restando la cantidad vendida del stock inicial                   
                                "(SUM(PlataformasxJuegos.Stock_PXJ) - COALESCE(SUM(DetalleVentas.Cantidad_DV), 0)) AS StockActual " +                              
                                //Tabla base de datos Juegos"
                                "FROM Juegos " +
                                //Unir la tabla PlataformasxJuegos utilizando el código de juego
                                "LEFT JOIN PlataformasxJuegos ON Juegos.CodJuego_JU = PlataformasxJuegos.CodJuego_JU_PXJ " +
                                //nir la tabla DetalleVentas utilizando el código de juego y el código de plataforma +
                                "LEFT JOIN DetalleVentas ON PlataformasxJuegos.CodJuego_JU_PXJ = DetalleVentas.CodJuego_PXJ_DV AND PlataformasxJuegos.CodPlataforma_PL_PXJ = DetalleVentas.CodPlataforma_PXJ_DV " +
                                //Unir la tabla Ventas utilizando el código de venta
                                "LEFT JOIN Ventas ON DetalleVentas.CodVenta_VN_DV = Ventas.CodVenta_VN " +
                                //Agrupar los resultados por el nombre del juego y la fecha de venta
                                "GROUP BY Juegos.Nombre_JU, ISNULL(FORMAT(Ventas.FechaVenta_VN, 'dd/MM/yyyy'), FORMAT(GETDATE(), 'dd/MM/yyyy')) " +
                                //Ordenar los resultados por el nombre del producto y la fecha en orden ascendente\n" +
                                "ORDER BY Producto, Fecha ASC";
            return conex.obtenerTaba("Tabla", consultaSql);
        }
    }
}