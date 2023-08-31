using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plataforma
    {
        private string id_Plataforma;
        private string descripcion;

        public Plataforma() { }
        public Plataforma(string id_Plataforma, string descripcion)
        {
            this.id_Plataforma = id_Plataforma;
            this.descripcion = descripcion;
        }

        public string Id_Plataforma { get { return id_Plataforma; } set { descripcion = value; }  }
        public string Descripcion { get { return descripcion; }set { descripcion = value; } }
    }
}
