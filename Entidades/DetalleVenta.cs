using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVenta
    {
        private string NombreJuego;
        private string NombrePlataforma;
        private decimal PrecioJuego;

        public DetalleVenta() { }
        public DetalleVenta(string nombreJuego, string nombrePlataforma, decimal precioJuego)
        {
            NombreJuego = nombreJuego;
            NombrePlataforma = nombrePlataforma;
            PrecioJuego = precioJuego;
        }

        public void setNombreJuego(string nombre) { NombreJuego = nombre; }
        public void setNombrePlataforma(string plataforma) { NombrePlataforma = plataforma;}
        public void setPrecioJuego(decimal precio) { PrecioJuego = precio; }

        public string getNombreJuego() { return NombreJuego; }
        public string getNombrePlataforma() { return NombrePlataforma; }
        public decimal getPrecioJuego() { return PrecioJuego; }
    }
}
