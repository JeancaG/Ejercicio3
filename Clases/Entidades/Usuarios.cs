using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Entidades
{
    public class Usuarios
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Clave { get; set; }

        public Usuarios()
        {
        }

        public Usuarios(string codigo, string nombre, string rol, string clave)
        {
            Codigo = codigo;
            Nombre = nombre;
            Rol = rol;
            Clave = clave;
        }
    }
}
