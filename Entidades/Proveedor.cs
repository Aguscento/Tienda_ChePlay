using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor
    {
        private string id_Proveedor;
        private string direccion;
        private string provincia;
        private string telefono;
        private string email;
        private bool activo;

        public Proveedor() { }
        public Proveedor(string id_Proveedor, string direccion, string provincia, string telefono, string email, bool activo)
        {
            this.Id_Proveedor = id_Proveedor;
            this.Direccion = direccion;
            this.Provincia = provincia;
            this.Telefono = telefono;
            this.Email = email;
            this.Activo = activo;
        }

        public string Id_Proveedor { get => id_Proveedor; set => id_Proveedor = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
