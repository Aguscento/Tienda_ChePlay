using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        private string dniUsuario;

        public Venta() { }
        public void setDniUsuario(string d) { dniUsuario = d; }

        public string getDniUsuario() { return dniUsuario; }
    }
}
