using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ModoDeJuego
    {
        string id_Modo;
        string nombreModo;

        public ModoDeJuego() { }
        public ModoDeJuego(string id_Modo, string nombreModo)
        {
            this.id_Modo = id_Modo;
            this.nombreModo = nombreModo;
        }

        public string Id_Modo { get => id_Modo; set => id_Modo = value; }
        public string NombreModo { get => nombreModo; set => nombreModo = value; }
    }
}
