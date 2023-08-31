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
    public class DatoProveedor
    {
        private Conexion conex = new Conexion();

        public DataTable getTablaProveedores()
        {
            DataTable tabla = conex.obtenerTaba("Proveedores", "select * from Proveedores");
            return tabla;
        }
        public DataTable getTablaProveedores(string codProveedor)
        {
            DataTable tabla = conex.obtenerTaba("Proveedores", "select *from proveedores where CodProveedor_PR = '" + codProveedor.ToString() + "'");
            return tabla;
        }
    }
}
