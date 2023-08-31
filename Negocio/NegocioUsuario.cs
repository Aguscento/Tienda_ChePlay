using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NegocioUsuario
    {
        public bool IniciarSession(Usuario reg)
        {
            DatosUsuario datUs = new DatosUsuario();
            return datUs.UsuarioExiste(reg);
        }
        public bool Registrarse(Usuario reg)
        {
            DatosUsuario dat = new DatosUsuario();
            return dat.Registrarse(reg);
        }

        public string getDni(string name)
        {
            DatosUsuario datos = new DatosUsuario();
            return datos.getDNIFromUser(name);
        }
    }
}
