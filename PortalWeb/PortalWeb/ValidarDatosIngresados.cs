using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PortalWeb
{
    class ValidarDatosIngresados
    {
        ////public cs_Aux()
        ////{

        ////}

        public static bool ValidarCorreoElectronico(string Correo)
        {
            string Expresion = "\\W+([-+.']\\W+)*@\\W+([-.]\\W+)*\\.\\W+([-.]\\W+)*";

            if (Regex.IsMatch(Correo, Expresion))
            {
                if (Regex.Replace(Correo, Expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// No Permitir Ingresar Números

        public void ValidarLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        // No permitir ingresar Letras.
        public void ValidarNumericos(KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            {
                e.Handled = true;
            }

        }

        ///// <summary>
        ///// Al Presionar Enter en el TextBox salta al próx
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public void Funcion(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        e.Handled = true;

        //        SendKeys.Send("{TAB}");
        //    }
        //}



        ///// <summary>
        ///// Solo datos numéricos para precios
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e">e</param>
        ///// <param name="tBox1"></param>
        //public void Validacion(object sender, KeyPressEventArgs e, Control tBox1)
        //{
        //    if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
        //    {
        //        e.Handled = true;
        //    }
        //    if (e.KeyChar == ',')
        //        e.KeyChar = '.';
        //    //Permitir comas y puntos (si es punto )
        //    if (e.KeyChar == ',' || e.KeyChar == '.')
        //        //si ya hay una coma no permite un nuevo ingreso de esta
        //        if (tBox1.Text.Contains(",") || tBox1.Text.Contains("."))
        //            e.Handled = true;
        //        else
        //            e.Handled = false;
        //}


        //public void Llenar_Con_Ceros(Control parent)
        //{
        //    TextBox t;
        //    foreach (Control c in parent.Controls)
        //    {
        //        {
        //            t = c as TextBox;
        //            if (t != null)
        //            {
        //                t.Text = "0";

        //            }
        //            if (c.Controls.Count > 0)
        //            {
        //                Llenar_Con_Ceros(c);
        //            }
        //        }
        //    }
        //}

        //public void Limpiar_RichTextBoxes(Control parent)
        //{
        //    RichTextBox t;
        //    foreach (Control c in parent.Controls)
        //    {
        //        t = c as RichTextBox;
        //        if (t != null)
        //        {
        //            t.Clear();

        //        }
        //        if (c.Controls.Count > 0)
        //        {
        //            Limpiar_RichTextBoxes(c);
        //        }
        //    }

        //}

        //public void limpiarTextBoxes(Control parent)
        //{
        //    TextBox t;
        //    foreach (Control c in parent.Controls)
        //    {
        //        t = c as TextBox;
        //        if (t != null)
        //        {
        //            t.Clear();
        //        }
        //        if (c.Controls.Count > 0)
        //        {
        //            limpiarTextBoxes(c);
        //        }
        //    }
        //}
        ///// <summary>
        ///// Comprueba si los textboxs estás vacíos
        ///// </summary>
        ///// <param name="parent"></param>
        ///// <returns></returns>
        //public bool ValidarTextBoxes(Control parent)
        //{
        //    TextBox t;
        //    foreach (Control c in parent.Controls)
        //    {
        //        t = c as TextBox;
        //        if (t != null)
        //        {
        //            if (t.Text == "")
        //                return false;
        //        }
        //        if (c.Controls.Count > 0)
        //        {
        //            ValidarTextBoxes(c);
        //        }
        //    }
        //    return true;
        //}


        //public void limpiar_Combos(Control parent)
        //{
        //    ComboBox t;
        //    foreach (Control c in parent.Controls)
        //    {
        //        t = c as ComboBox;
        //        if (t != null)
        //        {
        //            t.Text = "";
        //        }
        //        if (c.Controls.Count > 0)
        //        {
        //            limpiarTextBoxes(c);
        //        }
        //    }
        //}
    }
}
