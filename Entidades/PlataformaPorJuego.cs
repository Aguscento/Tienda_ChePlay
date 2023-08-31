using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlataformaPorJuego
    {
        private Juego juego;
        private Plataforma plataforma;
        private int stock;
        private float precioUnitario;
        private bool activo;

        public PlataformaPorJuego() { }

        public PlataformaPorJuego(Juego juego, Plataforma plataforma, int stock, int precioUnitario, bool activo)
        {
            this.Juego = juego;
            this.Plataforma = plataforma;
            this.stock = stock;
            this.precioUnitario = precioUnitario;
            this.activo = activo;
        }

        public int Stock { get => stock; set => stock = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public bool Activo { get => activo; set => activo = value; }
        public Juego Juego { get => juego; set => juego = value; }
        public Plataforma Plataforma { get => plataforma; set => plataforma = value; }
    }
}
