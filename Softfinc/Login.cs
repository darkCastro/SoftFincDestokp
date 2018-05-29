using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Softfinc
{
    public partial class Login : Form
<<<<<<< HEAD
    {

             
=======
    {    
>>>>>>> a40a00ccced5b32560b3c7bbb998ad4cca0f8465

        public Login()
        {
            InitializeComponent();
        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

            Text = "cambio de texto  ";





            //txtmonto.Text = "$0.00";
            //txtmonto.SelectionStart = txtmonto.Text.Length;

            
            this.Text = Vrpublicas.Napp;
            timer1.Interval = 200;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtusuario.Focus();
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //       const string message =
            //    "Esta Seguro de X cosa?";
            //const string caption = "Verifique..";
            //var result = MessageBox.Show(message, caption,
            //                             MessageBoxButtons.YesNo,
            //      MessageBoxIcon.Question);

            Entrar();
        }

        private void txtusuario_KeyDown(object sender, KeyEventArgs e)
        {      
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode == Keys.Enter)
            {

                if (string.IsNullOrEmpty(txtusuario.Text))
                {
                    MessageBox.Show("ingrese nombre");
                }
                else
                {
                    txtclave.Focus();
                }

                //eliminar el sonido 
                e.SuppressKeyPress = true;

            }
        }

        private void txtclave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtclave.Text))
                {
                    MessageBox.Show("ingrese Clave");
                }
                else
                {
                    //intento entrar                  
                    button1.Focus();
                }

                //eliminar el sonido 
                e.SuppressKeyPress = true;

            }
        }

      
        private void Entrar()
        {


            Vrpublicas.usuario = "Usuario xxx";
           
            Principal p = new Principal();
            p.Show();
            this.Close();

          
        }

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {       Currencychange(sender, e);

          //  txtmonto.Focus();
           
        }

        #region" CONVERTIR A CURRENCY MIETRAS ESCRIBO"


        private void Currencychange(object sender, EventArgs e)
        {

            TextBox textb = (TextBox)sender;

            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = textb.Text.Replace(",", "")
                .Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                ul /= 100;
                //Unsub the event so we don't enter a loop
                //  this.txt.TextChanged -= txtmonto_TextChanged;
                //Format the text as currency
                textb.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
                //  this.txt.TextChanged += txtmonto_TextChanged;
                textb.Select(textb.Text.Length, 0);
            }
            bool goodToGo = TextisValid(textb.Text);
            // enterButton.Enabled = goodToGo;
            if (!goodToGo)
            {
                textb.Text = "$0.00";
                textb.Select(textb.Text.Length, 0);
            }
        }


        private bool TextisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
        }



        #endregion

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {
            Currencychange(sender, e);
        }

        private void txtvalor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                          
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtusuario.Text = CapitalizeFirstLetters(txtusuario.Text);
            txtusuario.Select(txtusuario.Text.Length, 0);

        }

        public static string CapitalizeFirstLetters(string sValue)
        {
            char[] array = sValue.ToCharArray();
            // handle the first letter in the string
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            // scan through the letters, checking for spaces
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
           
            return new string(array);
        }
    }
}
