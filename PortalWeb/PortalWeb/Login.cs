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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que dese salir?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else if (result == DialogResult.No)
            {
            }
            else if (result == DialogResult.Cancel)
            {
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = txtUsuario.Text.ToLower();

            MenuPrincipal MenuPrinc = new MenuPrincipal();

            Servicio NuevoSer = new Servicio();
            IniciarSesionEmpleado parametros = new IniciarSesionEmpleado(txtUsuario.Text, txtContrasena.Text);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            string body = ser.Serialize(parametros);
            //MessageBox.Show(body);
            string Resultados = NuevoSer.llamarServicio(body);
            //MessageBox.Show(Resultados);

            if (Resultados == "1")
            {
                MenuPrinc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta!");
                MessageBox.Show("Vuelva a Insertar Usuario y Contraseña");
                txtUsuario.Clear();
                txtContrasena.Clear();
            }

            //MenuPrinc.Show();

        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            NuevoUsuario NuevoUsu = new NuevoUsuario();
            NuevoUsu.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            //if (ValidarDatosIngresados.ValidarCorreoElectronico(txtUsuario.Text))
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Dirección de Correo Electronico Incorrecto, El Correo debe Tener el Formato: nombre@gmail/hotmail.com, " + " Ingrese un Correo Electronico con Formato Correcto", "Validación de Correo Electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            //    ////No Poder Seleccionar Nada Hasta que se Ingrese el Formato Correcto.
            //    //txtUsuario.SelectAll();
            //    //txtUsuario.Focus();

            //    txtUsuario.Clear();
            //}


            string Texto = txtUsuario.Text;
            bool Verificar = Texto.Contains('@') && Texto.Contains("hotmail") || Texto.Contains("gmail") || Texto.Contains("uppenjamo") && Texto.Contains(".com") || Texto.Contains(".edu") || Texto.Contains(".mx");

            if (Verificar == true)
            {

            }
            else
            {
                MessageBox.Show("Correo Electronico Invalido!, Ingresa un Correo Valido!");
                txtUsuario.Clear();

                //txtUsuario.Focus();
                txtUsuario.SelectAll();
            }
        }
    }
}
