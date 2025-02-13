using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.singleton
{
    public static class UsuarioSingleton
    {
        public static int id { get; set; }
        public static string Nombre { get; set; }
        public static string Password { get; set; }

        public static void setUsuario(int id, string Nombre, string Password)
        {
            UsuarioSingleton.id = id;
            UsuarioSingleton.Nombre = Nombre;
            UsuarioSingleton.Password = Password;
        }


    }
}
