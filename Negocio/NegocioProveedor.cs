using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioProveedor
    {
        public bool agregarProveedor(Proveedor obj)
        {
            return false;
        }
        public bool existePlataforma(Proveedor obj)
        {
            return false;
        }
        public DataTable getTablaProveedor()
        {
            DatoProveedor obj = new DatoProveedor();
            return obj.getTablaProveedores();
        }
    }
}
