using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWeb
{
    class InsertarDatosPaquete
    {
        public string action;

        //Datos del Receptor.
        public string nombre;
        public string apellidoPaterno;
        public string apellidoMaterno;
        public string calle;
        public int numero;
        public string colonia;
        public string estado;
        public int codigoPostal;
        public string telefono;
        public string municipio;
        public string tipo1;

        //Datos de Receptor.
        public string nombre2;
        public string apellidoPaterno2;
        public string apellidoMaterno2;
        public string municipio2;
        public string calle2;
        public int numero2;
        public string colonia2;
        public string estado2;
        public int codigoPostal2;
        public string telefono2;
        public string entreCalle1;
        public string entreCalle2;
        public string tipo2;

        public string tipo;
        public double peso;

        //Datos de Paquete de Envio.
        public string fechaSalida;
        public string fechaLlegada;
        public string estado1;

        //public string IDMaxUsuario;

        //Datos del Paquete.
        //public string tipo;
        //public double peso;

        //Datos del Emisor



        public InsertarDatosPaquete(string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Calle, int Numero, string Colonia, string Estado, int CodigoPostal, string Telefono, string Municipio, string Tipo1, string Nombre2, string ApellidoPaterno2, string ApellidoMaterno2, string Municipio2, string Calle2, int Numero2, string Colonia2, string Estado2, int CodigoPostal2, string Telefono2, string EntreCalle1, string EntreCalle2, string Tipo2, string Tipo, double Peso, string FechaSalida, string FechaLlegada, string Estado1)
        {
            action = "DatosUsuario";

            nombre = Nombre;
            apellidoPaterno = ApellidoPaterno;
            apellidoMaterno = ApellidoMaterno;
            calle = Calle;
            numero = Numero;
            colonia = Colonia;
            estado = Estado;
            codigoPostal = CodigoPostal;
            telefono = Telefono;
            municipio = Municipio;
            tipo1 = Tipo1;

            nombre2 = Nombre2;
            apellidoPaterno2 = ApellidoPaterno2;
            apellidoMaterno2 = ApellidoMaterno2;
            municipio2 = Municipio2;
            calle2 = Calle2;
            numero2 = Numero2;
            colonia2 = Colonia2;
            estado2 = Estado2;
            codigoPostal2 = CodigoPostal2;
            telefono2 = Telefono2;
            entreCalle1 = EntreCalle1;
            entreCalle2 = EntreCalle2;
            tipo2 = Tipo2;

            //Datos del Paquete
            tipo = Tipo;
            peso = Peso;

            //Datos del Envio del Paquete.
            // IDMaxUsuario = iDMaxUsuario;

            //Datos Paquete Envio.
            fechaSalida = FechaSalida;
            fechaLlegada = FechaLlegada;
            estado1 = Estado1;

            //Datos Paquete

        }
    }
}
