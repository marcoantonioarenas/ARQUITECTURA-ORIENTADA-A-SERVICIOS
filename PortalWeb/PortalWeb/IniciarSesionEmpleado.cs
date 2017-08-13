using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWeb
{
    class IniciarSesionEmpleado
    {
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string action { get; set; }


        public IniciarSesionEmpleado(string Correo, string Contraseña)
        {
            action = "LoginEmpleado";
            correo = Correo;
            contraseña = Contraseña;
        }

    }

    class ResultsEmpleado
    {
        public int ResultEmple { get; set; }
    }
}
