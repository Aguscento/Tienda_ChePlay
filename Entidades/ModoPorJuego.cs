using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ModoPorJuego
    {
        private Juego juego;
        private ModoDeJuego modoDeJuego;

        public ModoPorJuego() { }
        public ModoPorJuego(Juego juego,ModoDeJuego modoDeJuego)
        {
            this.Juego = juego;
            this.ModoDeJuego = modoDeJuego;
        }

        public Juego Juego { get => juego; set => juego = value; }
        public ModoDeJuego ModoDeJuego { get => modoDeJuego; set => modoDeJuego = value; }
    }
}
