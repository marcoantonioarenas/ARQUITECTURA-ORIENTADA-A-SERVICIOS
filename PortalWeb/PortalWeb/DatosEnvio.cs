using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;


namespace PortalWeb
{
    public partial class DatosEnvio : MetroFramework.Forms.MetroForm
    {
        //Emisor
        string Nombre;
        string ApellidoPaterno;
        string ApellidoMaterno;
        string Calle;
        int Numero;
        string Colonia;
        string Estado;
        int CodigoPostal;
        string Telefono;
        string Municipio;
        string Tipo1;


        //Receptor
        string Nombre2;
        string ApellidoPaterno2;
        string ApellidoMaterno2;
        string Municipio2;
        string Calle2;
        int Numero2;
        string Colonia2;
        string Estado2;
        int CodigoPostal2;
        string Telefono2;
        string EntreCalle1;
        string EntreCalle2;
        string Tipo2;

        string Tipo;
        double Peso;

        string iDMaxUsuario;



        public DatosEnvio(string Nombre01, string ApellidoPaterno01, string ApellidoMaterno01, string Calle01, int Numero01, string Colonia01, string Estado01, int CodigoPostal01, string Telefono01, string Municipio01, string Tipo01, string nombre1, string apellidoPaterno1, string apellidoMaterno1, string municipio1, string calle1, int numero1, string colonia1, string estado1, int codigoPostal1, string telefono1, string EntreCalle10, string EntreCalle20, string Tipo02, string tipo, double peso)
        {
            InitializeComponent();

            ////Mostrar Datos Receptor en Cajas de Texto.
            //MessageBox.Show(estado1);
            //MessageBox.Show(nombre1);
            //MessageBox.Show(apellidoPaterno1);
            //MessageBox.Show(apellidoMaterno1);
            //txtEstado.Text = estado1;
            txtMunicipio.Text = municipio1;
            txtCodigoPostal.Text = codigoPostal1.ToString();
            txtColonia.Text = colonia1;
            txtNombre.Text = nombre1;


            Nombre = Nombre01;
            ApellidoPaterno = ApellidoPaterno01;
            ApellidoMaterno = ApellidoMaterno01;
            Calle = Calle01;
            Numero = Numero01;
            Colonia = Colonia01;
            Estado = Estado01;
            CodigoPostal = CodigoPostal01;
            Telefono = Telefono01;
            Municipio = Municipio01;
            Tipo1 = Tipo01;

            Nombre2 = nombre1;
            ApellidoPaterno2 = apellidoPaterno1;
            ApellidoMaterno2 = apellidoMaterno1;
            Municipio2 = municipio1;
            Calle2 = calle1;
            Numero2 = numero1;
            Colonia2 = colonia1;
            Estado2 = estado1;
            CodigoPostal2 = codigoPostal1;
            Telefono2 = telefono1;
            EntreCalle1 = EntreCalle10;
            EntreCalle2 = EntreCalle20;
            Tipo2 = Tipo02;
            Tipo = tipo;
            Peso = peso;


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //
            ////MessageBox.Show(Nombre);
            ////MessageBox.Show(Nombre2);
            ////MessageBox.Show(ApellidoMaterno);
            ////MessageBox.Show(ApellidoMaterno2);
            ////MessageBox.Show(Calle);
            ////MessageBox.Show(Calle2);
            ////MessageBox.Show(Numero.ToString());
            ////MessageBox.Show(Numero2.ToString());
            ////MessageBox.Show(Colonia);
            ////MessageBox.Show(Colonia2);
            ////MessageBox.Show(Estado);
            ////MessageBox.Show(Estado2);
            ////MessageBox.Show(CodigoPostal.ToString());
            ////MessageBox.Show(CodigoPostal2.ToString());
            ////MessageBox.Show(Telefono);
            ////MessageBox.Show(Telefono2);
            ////MessageBox.Show(Municipio);
            ////MessageBox.Show(Municipio2);
            ////MessageBox.Show(Tipo1);
            ////MessageBox.Show(Tipo2);

            ////Mostrar Datos Receptor en Cajas de Texto.
            //Estado2 = txtEstado.Text;
            //MessageBox.Show(Estado2);
            //Municipio2 = txtMunicipio.Text;
            ////CodigoPostal2 = int.Parse(txtCodigoPostal.Text);
            //Colonia2 = txtColonia.Text;
            //Nombre2 = txtNombre.Text;


            MenuPrincipal Men = new MenuPrincipal();

            DatosEmisor DE = new DatosEmisor();

            Servicio NuevoSer = new Servicio();

            InsertarDatosPaquete Parametros = new InsertarDatosPaquete(Nombre, ApellidoPaterno, ApellidoMaterno, Calle, Numero, Colonia, Estado, CodigoPostal, Telefono, Municipio, Tipo1, Nombre2, ApellidoPaterno2, ApellidoMaterno2, Municipio2, Calle2, Numero2, Colonia2, Estado2, CodigoPostal2, Telefono2, EntreCalle1, EntreCalle2, Tipo2, Tipo, Peso, txtFechaSalida.Text, txtFechaEstimada.Text, txtEstado.Text);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            string body = ser.Serialize(Parametros);
            //MessageBox.Show(body);

            string Resultados = NuevoSer.llamarServicio(body);

            //MessageBox.Show(Resultados);
            // string Resultados = NuevoSer.llamarServicio(body);
            MessageBox.Show("Datos del Paquete Registrados!");
            //Men.Show();
            //this.Hide();

            ObtenerIDGuia ObIDGui = new ObtenerIDGuia();
            JavaScriptSerializer ser1 = new JavaScriptSerializer();
            string body1 = ser1.Serialize(Parametros);

            //Bloquear Boton
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;

        }

        private void txtFechaSalida_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DatosEnvio_Load(object sender, EventArgs e)
        {
            //Mostrar Fecha
            txtFechaSalida.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Servicio NuevoSer1 = new Servicio();

            ObtenerIDMaximo Parametros = new ObtenerIDMaximo();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string body = ser.Serialize(Parametros);
            MessageBox.Show(body);

            string Resultados = NuevoSer1.llamarServicio(body);


            iDMaxUsuario = Resultados;
            MessageBox.Show(iDMaxUsuario);
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que Desea Cancelar su Envio?", "Cancelar", MessageBoxButtons.YesNo);
            MenuPrincipal MenuPri = new MenuPrincipal();

            if (result == DialogResult.Yes)
            {
                this.Close();
                MenuPri.Show();
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal Men = new MenuPrincipal();

            Men.Show();
            this.Close();
        }
    }
}
