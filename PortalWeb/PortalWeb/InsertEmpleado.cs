using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWeb
{
    class InsertEmpleado
    {
        public string nombre { get; set; }
        public string apellidos;
        public string correo;
        public string contraseña;
        public string action;

        public InsertEmpleado(string Nombre, string Apellidos, string Correo, string Contraseña)
        {
            action = "Empleado";
            nombre = Nombre;
            apellidos = Apellidos;
            correo = Correo;
            contraseña = Contraseña;
        }
    }
}
