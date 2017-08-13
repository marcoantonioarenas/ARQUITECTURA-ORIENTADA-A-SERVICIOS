using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWeb
{
    class AgregarUsuario
    {
        public string action { get; set; }

        public AgregarUsuario()
        {
            action = "";
        }

        class ResultsUsuario
        {
            public string Usuario { get; set; }
        }
    }
}
