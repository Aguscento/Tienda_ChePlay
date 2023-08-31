using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CategoriaPorJuego
    {
        private Categoria categoria;
        private Juego juego;

        public CategoriaPorJuego() { }
        public CategoriaPorJuego(Categoria categoria, Juego juego)
        {
            this.categoria = categoria;
            this.juego = juego;
        }

        public Categoria Categoria { get { return categoria; } set { categoria = value; } }
        public Juego Juego { get { return juego; } set { juego = value; } }
    }
}
