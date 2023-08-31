using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioDetalleVenta
    {
        public bool EjecutarInsertDetalle(DetalleVenta regDV)
        {
            DatosDetalleVenta datDV = new DatosDetalleVenta();
            return datDV.AgregarDetalleVenta(regDV);
        }
    }
}
