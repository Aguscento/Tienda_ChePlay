using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Fecha
    {
        private string dia;
        private string mes;
        private string anio;

        public Fecha() { }
        public Fecha(string dia, string mes, string anio)
        {
            this.dia = dia;
            this.mes = mes;
            this.anio = anio;
        }
        public string Dia { set { dia = value; } get { return dia; } }
        public string Mes { set { mes = value; } get { return mes; } }
        public string Anio { set { anio = value; } get { return anio; } }
    }
}
