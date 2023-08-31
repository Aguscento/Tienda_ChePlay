using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private string DniUsuario;
        private string NickName;
        private string Nombre;
        private string Apellido;
        private string Telefono;
        private string Direccion;
        private string Contraseña;

        public Usuario() { }

        public Usuario(string dni, string nick, string nom, string ape, string tel, string direc, string contra)
        {
            DniUsuario = dni;
            NickName = nick;
            Nombre = nom;
            Apellido = ape;
            Telefono = tel;
            Direccion = direc;
            Contraseña = contra;
        }

        public string getDniUsuario() { return DniUsuario; }
        public string getNickName() { return NickName; }
        public string getNombre() { return Nombre; }
        public string getApellido() { return Apellido; }
        public string getTelefono() { return Telefono; }
        public string getDireccion() { return Direccion; }
        public string getContraseña() { return Contraseña; }

        public void setDniUsuario(string dni) { DniUsuario = dni; }
        public void setNickName(string nick) { NickName = nick; }
        public void setNombre(string nom) { Nombre = nom; }
        public void setApellido (string ape) { Apellido = ape; }
        public void setTelefono(string Tel) { Telefono = Tel; }
        public void setDireccion(string dir) { Direccion = dir; }
        public void setContraseña(string con) { Contraseña=con; }


    }
}
