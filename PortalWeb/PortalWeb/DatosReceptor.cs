using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalWeb
{
    public partial class DatosReceptor : MetroFramework.Forms.MetroForm
    {
        string Tipo02 = "Receptor";
        string Tipo01;

        ValidarDatosIngresados Vali = new ValidarDatosIngresados();

        public string Nombre0;
        public string ApellidoPaterno0;
        public string ApellidoMaterno0;
        public string Municipio0;
        public string Calle0;
        public int Numero0;
        public string Colonia0;
        public string Estado0;
        public int CodigoPostal0;
        public string Telefono0;
        public string EntreCalle10;
        public string EntreCalle20;
        //public string Tipo;
        //public double Peso;

        //public string valorSeleccionado = cBoxTipo2.SelectedValue.ToString();



        public DatosReceptor(string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Calle, int Numero, string Colonia, string Estado, int CodigoPostal, string Telefono, string Municipio, string Tipo1)
        {
            InitializeComponent();

            Nombre0 = Nombre;
            ApellidoPaterno0 = ApellidoPaterno;
            ApellidoMaterno0 = ApellidoMaterno;
            Calle0 = Calle;
            Numero0 = Numero;
            Colonia0 = Colonia;
            Estado0 = Estado;
            CodigoPostal0 = CodigoPostal;
            Telefono0 = Telefono;
            Municipio0 = Municipio;
            Tipo01 = Tipo1;
            
        }

        private void btnEmisor_Click(object sender, EventArgs e)
        {
            Form1 Emis = new Form1();

            Emis.Show();
            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login Logi = new Login();

            DialogResult result = MessageBox.Show("Seguro que Desea Cerrar Sesión?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Logi.Show();
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDatosEnvio_Click(object sender, EventArgs e)
        {
            DatosEnvio DatosEn = new DatosEnvio(Nombre0, ApellidoPaterno0, ApellidoMaterno0, Calle0, Numero0, Colonia0, Estado0, CodigoPostal0, Telefono0, Municipio0, Tipo01, txtNombre1.Text, txtApellidoPaterno1.Text, txtApellidoMaterno1.Text, txtMunicipio1.Text, txtCalle1.Text, int.Parse(txtNumero1.Text), txtColonia1.Text, txtEstado1.Text, int.Parse(txtCodigoP1.Text), txtTelefono1.Text, txtEntreCalle1.Text, txtEntreCalle2.Text, Tipo02,cbxTipo.Text, double.Parse(txtPeso.Text));

            //Nombre1 = txtNombre1.Text;
            //ApellidoPaterno1 = txtApellidoP1.Text;
            //ApellidoMaterno1 = txtApellidoM1.Text;
            //Municipio1 = txtMunicipio1.Text;
            //Calle1 = txtCalle1.Text;
            //Numero1 = int.Parse(txtNumero1.Text);
            //Colonia1 = txtColonia1.Text;
            //Estado1 = txtEstado1.Text;
            //CodigoPostal1 = int.Parse(txtCodigoP1.Text);
            //Telefono1 = txtTelefono1.Text;
            //EntreCalle1 = txtEntreCalle1.Text;
            //EntreCalle2 = txtEntreCalle2.Text;
            //Tipo = cbxTipo.Text;
            //Peso = double.Parse(txtPeso.Text);


            DatosEn.Show();
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que Desea Cancelar su Envio?", "Cancelar", MessageBoxButtons.YesNo);
            Login Lo = new Login();

            if (result == DialogResult.Yes)
            {
                this.Close();
                Lo.Show();
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DatosReceptor_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vali.ValidarLetras(e);
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vali.ValidarNumericos(e);
        }
    }
}
