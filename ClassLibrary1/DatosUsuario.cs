using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Datos
{
    public class DatosUsuario
    {
        private Conexion conex = new Conexion();

        public bool UsuarioExiste(Usuario reg)
        {
            string consulta = $"select * from Usuarios where NombreDeUsuario_US='{reg.getNickName()}' and Contraseña_US='{reg.getContraseña()}'";
            SqlCommand cmd = conex.obtenerComando(consulta);
            SqlDataReader lector;
            lector = cmd.ExecuteReader();

            if(lector.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Registrarse(Usuario reg)
        {
            string consulta = "insert into Usuarios (DniUsuario_US,NombreDeUsuario_US,Nombre_US,Apellido_US,Telefono_US,Direccion_US,Contraseña_US) " +
                $"select '{reg.getDniUsuario()}','{reg.getNickName()}','{reg.getNombre()}','{reg.getApellido()}','{reg.getTelefono()}','{reg.getDireccion()}','{reg.getContraseña()}'";
            SqlCommand cmd = conex.obtenerComando(consulta);
            int filas = cmd.ExecuteNonQuery();
            if (filas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string getDNIFromUser(string name)
        {
            string query = $"SELECT Usuarios.DniUsuario_US FROM Usuarios WHERE Usuarios.NombreDeUsuario_US = '{name}'";
            using (DataTable table = conex.obtenerTaba("Usuario", query))
            {
                return table.Rows[0]["DniUsuario_US"].ToString();
            }
        }
    }
}
