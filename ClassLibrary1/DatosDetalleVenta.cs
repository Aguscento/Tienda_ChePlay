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
    public class DatosDetalleVenta
    {
        private Conexion conex = new Conexion();
        public bool AgregarDetalleVenta(DetalleVenta regDV)
        {
            string consulta = "insert into DetalleVentas (CodVenta_VN_DV,CodJuego_PXJ_DV,CodPlataforma_PXJ_DV,Cantidad_DV,PrecioUnitario_DV) " +
                "select(select top(1) CodVenta_VN from Ventas order by CodVenta_VN desc) ," +
                $" (select CodJuego_JU from Juegos where Nombre_JU = '{regDV.getNombreJuego()}') ," +
                $" (select CodPlataforma_PL from Plataformas where NombreDePlataforma_PL = '{regDV.getNombrePlataforma()}'),1," +
                $"{regDV.getPrecioJuego()}";
            SqlCommand cmd = conex.obtenerComando(consulta);
            int filas = cmd.ExecuteNonQuery();
            if (filas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
