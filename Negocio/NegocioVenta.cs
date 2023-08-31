using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioVenta
    {
        public DataTable ObtenerGrillaDetalle(string nomTabla,string codVenta)
        {
            DatosVenta datVen = new DatosVenta();
            return datVen.ObtenerGrillaDetalles(nomTabla, codVenta);
        }

        public bool EjecutarInsertVentas(Venta regVn)
        {
            DatosVenta datVen = new DatosVenta();
            return datVen.AgregarVenta(regVn);
        }

    }
}
