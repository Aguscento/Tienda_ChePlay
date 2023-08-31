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
    public class NegocioReporte
    {
        public DataTable getGrillaReporteFecha(string nomTabla, string fecha1,string fecha2)
        {
            DatosReporte datRep = new DatosReporte();
            return datRep.ObtenerGrillaReporteFechas(nomTabla, fecha1, fecha2);
        }
        public DataTable getJuegosTopVendidos(string fechaInicio, string fechaFinal)
        {
            DatosReporte conex = new DatosReporte();
            return conex.obtenerJuegosTopVendidos(fechaInicio, fechaFinal);
        }
        public DataTable getTopUsuarios()
        {
            DatosReporte conex = new DatosReporte();
            return conex.obtenerTopUsuarios();
        }
        public DataTable getInventario()
        {
            DatosReporte conex = new DatosReporte();
            return conex.obtenerInventario();
        }
    }
}
