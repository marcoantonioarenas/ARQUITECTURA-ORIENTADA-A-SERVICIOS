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
    public partial class NuevoUsuario : Form
    {
        ValidarDatosIngresados Validar = new ValidarDatosIngresados();

        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Solo Letras Minusculas en Correo.
            txtCorreo.Text = txtCorreo.Text.ToLower();

            Login Lo = new Login();

            Servicio NuevoSer = new Servicio();
            InsertEmpleado parametros = new InsertEmpleado(txtNombre.Text, txtApellidos.Text, txtCorreo.Text, txtContraseña.Text);
            //Insertar parametros = new Insertar(txtNombre.Text, txtArtista.Text, txtGenero.Text);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            string body = ser.Serialize(parametros);

            string Resultados = NuevoSer.llamarServicio(body);
            MessageBox.Show("Empleado Registrado");
            Lo.Show();
            this.Hide();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Login Log = new Login();

            DialogResult result = MessageBox.Show("Seguro que Desea Cancelar?", "Cancelar", MessageBoxButtons.YesNo);

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

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarLetras(e);
        }
    }
}
