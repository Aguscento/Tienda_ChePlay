using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Juego
    {
        private string codJuego;
        private string nombreJuego;
        private string descripcion;
        private string fechaDeLanzamiento;
        private string urlPortada;
        private bool activo;

        public Juego() { }
        public Juego(string codJuego, Proveedor codProvedor, string nombreJuego, string descripcion, string fechaDeLanzamiento, string urlPortada, bool activo)
        {
            this.codJuego = codJuego;
            this.Proveedor = codProvedor;
            this.nombreJuego = nombreJuego;
            this.descripcion = descripcion;
            this.fechaDeLanzamiento = fechaDeLanzamiento;
            this.urlPortada = urlPortada;
            this.activo = activo;
        }

        public string CodJuego { get => codJuego; set => codJuego = value; }
        public Proveedor Proveedor { get; set; }
        public string NombreJuego { get => nombreJuego; set => nombreJuego = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FechaDeLanzamiento { get => fechaDeLanzamiento; set => fechaDeLanzamiento = value; }
        public string UrlPortada { get => urlPortada; set => urlPortada = value; }
        public bool Activo { get { return activo; } set { activo = value; } }
    }
}
