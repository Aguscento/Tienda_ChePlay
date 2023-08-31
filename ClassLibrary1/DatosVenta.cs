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
    public class DatosVenta
    {
        private Conexion conex = new Conexion();

        public DataTable ObtenerGrillaDetalles(string NombreTabla,string codVenta)
        {
            string ConsultaSql = "select CodVenta_VN_DV as 'Codigo de Venta',Nombre_JU as 'Nombre del Juego',NombreDePlataforma_PL as 'Plataforma',Cantidad_DV as 'Cantidad',PrecioUnitario_DV as 'Precio Unitario' " +
                "from ((Ventas inner join DetalleVentas on CodVenta_VN = CodVenta_VN_DV) inner join Juegos on CodJuego_PXJ_DV = CodJuego_JU)" +
                $"inner join Plataformas on CodPlataforma_PL = CodPlataforma_PXJ_DV where CodVenta_VN_DV = '{codVenta}' ";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = conex.ObtenerAdaptador(ConsultaSql);
            adp.Fill(ds, NombreTabla);
            conex.ObtenerConexion().Close();
            return ds.Tables[NombreTabla];
        }

        public bool AgregarVenta(Venta regVn)
        {
            string consulta = "insert into Ventas (DniUsuario_US_VN) " +
            $"select '{regVn.getDniUsuario()}'";
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
