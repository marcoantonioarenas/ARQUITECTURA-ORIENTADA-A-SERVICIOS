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
    public partial class DatosEmisor : MetroFramework.Forms.MetroForm
    {
        string Tipo1 = "Emisor";
        ValidarDatosIngresados Validar = new ValidarDatosIngresados();

        public DatosEmisor()
        {
            InitializeComponent();
        }

        private void btnReceptor_Click(object sender, EventArgs e)
        {
            DatosReceptor Receptor = new DatosReceptor(txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtCalle.Text, int.Parse(txtNumero.Text), txtColonia.Text, txtEstado.Text, int.Parse(txtCodigoPostal.Text), txtTelefono.Text, txtMunicipio.Text, Tipo1);


            //Guardar lo que Tienen las Cajas de Texto en Variables.
            ////Nombre = txtNombre.Text;
            ////ApellidoPaterno = txtApellidoPaterno.Text;
            ////ApellidoMaterno = txtApellidoMaterno.Text;
            ////Calle = txtCalle.Text;
            ////Numero = int.Parse(txtNumero.Text);
            ////Colonia = txtColonia.Text;
            ////Estado = txtEstado.Text;
            ////Colonia = txtColonia.Text;
            ////Estado = txtEstado.Text;
            ////CodigoPostal = int.Parse(txtCodigoPostal.Text);
            ////Telefono = txtTelefono.Text;
            ////Municipio = txtMunicipio.Text;

            Receptor.Show();
            this.Hide();

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarLetras(e);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarNumericos(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que Desea Cancelar su Envio?", "Cancelar", MessageBoxButtons.YesNo);
            Login Log = new Login();

            if (result == DialogResult.Yes)
            {
                this.Close();
                Log.Show();
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }
    }
}
