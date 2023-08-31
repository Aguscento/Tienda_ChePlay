using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioPlataforma
    {
        public bool agregarPlataforma(Plataforma obj)
        {
            DatoPlataforma conex = new DatoPlataforma();
            return Convert.ToBoolean(conex.agregarPlataforma(obj));
        }
        public bool existeCodPlataforma(Plataforma obj)
        {
            DatoPlataforma conex = new DatoPlataforma();
            return conex.existeCodPlataforma(obj.Id_Plataforma);
        }
        public DataTable getTablaPlataforma()
        {
            DatoPlataforma obj = new DatoPlataforma();
            return obj.getTablaPlataforma();
        }
    }
}
