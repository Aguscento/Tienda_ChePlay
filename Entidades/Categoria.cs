using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        private string codCategoria;
        private string nombreCategoria;

        public Categoria() { }
        public Categoria(string codCategoria, string nombreCategoria)
        {
            this.CodCategoria = codCategoria;
            this.NombreCategoria = nombreCategoria;
        }

        public string CodCategoria { get => codCategoria; set => codCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
    }
}
