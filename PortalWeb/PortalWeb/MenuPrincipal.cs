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
    public partial class MenuPrincipal : MetroFramework.Forms.MetroForm
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login Log = new Login();

            DialogResult result = MessageBox.Show("Seguro que Desea Cerrar Sesión?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Log.Show();
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            //Servicio NuevoSer1 = new Servicio();

            //ObtenerIDMaximo Parametros = new ObtenerIDMaximo();
            //JavaScriptSerializer ser = new JavaScriptSerializer();
            //string body = ser.Serialize(Parametros);
            //MessageBox.Show(body);

            //string Resultados = NuevoSer1.llamarServicio(body);

            ////MessageBox.Show(Resultados);
            //txtUltimo.Text = Resultados;

            //// string Resultados = NuevoSer.llamarServicio(body);
            //MessageBox.Show("Datos del Paquete Registrados!");
        }

        private void btnRegistarDatosPaquete_Click(object sender, EventArgs e)
        {
            DatosEmisor Emisor = new DatosEmisor();

            Emisor.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Servicio NuevoSer1 = new Servicio();

            ObtenerDatosReceptor Parametros1 = new ObtenerDatosReceptor();

            JavaScriptSerializer ser = new JavaScriptSerializer();
            string body = ser.Serialize(Parametros1);
            MessageBox.Show(body);

            string Resultados1 = NuevoSer1.llamarServicio(body);

            MessageBox.Show(Resultados1);
    
        }
    }
}
