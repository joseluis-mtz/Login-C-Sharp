using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Se ponen globos de AYUDA EN LOS CONTROLES
            this.toolTip1.SetToolTip(txtUser, "Escriba por favor su usuario");
            this.toolTip1.SetToolTip(txtPass, "Escriba por favor su contraseña");
            this.toolTip1.SetToolTip(btnAcceso, "ACCEDER");
            this.toolTip1.SetToolTip(btnSalir, "CANCELAR Y SALIR");
        }

        // Metodo para validar que las cajas tengan datos
        private bool validar_campos()
        {
            // Se establece que SÍ hay datos desde el principio
            bool resultado = true;
            // Se revisa que la caja de usuario este vacía para darle un error y que ponga datos
            // Si no hay datos, se establece en Resultado que es falso para que no pase la validación
            if (txtUser.Text.Trim() == string.Empty)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtUser, "Debes escribir tu nombre de usuario.");
                txtUser.Focus();
                resultado = false;
            }
            // Si tiene datos la primer caja se revisa la segunda y se hace lo mismo que anteriormente
            else
            {
                if (txtPass.Text.Trim() == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtPass, "Debes escribir tu contraseña.");
                    txtPass.Focus();
                    resultado = false;
                }
            }
            // Se regresa si hay datos en las cajas o no
            return resultado;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Se establece el botón activo al presionar ENTER
            AcceptButton = btnAcceso;
        }
        private void btnAcceso_Click(object sender, EventArgs e)
        {
            // Se valida la información
            if (validar_campos())
            {
                // Se limpian los errores
                errorProvider1.Clear();
                // Se verifca el usuario INVITADO y su contraseña para dar acceso
                if (txtUser.Text == "Invitado" && txtPass.Text == "12345")
                {
                    Acceso cambia = new Acceso();
                    cambia.Show();
                    this.Hide();
                }
                // Si no es el invitado
                else
                {
                    // Se verifca el usuario Administrador y su contraseña para dar acceso
                    if (txtUser.Text == "Administrador" && txtPass.Text == "Admin")
                    {
                        Acceso cambia = new Acceso();
                        cambia.Show();
                        this.Hide();
                    }
                    // Si no es NINGUNO DE LOS ANTERIORES, se da error de datos y no hay ACCESO.
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Incorrectos", "Error Al Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Se cierra la aplicación
            Application.Exit();
        }

        private void chkbShPass_CheckedChanged(object sender, EventArgs e)
        {
            // Se revisa el el CheckBox este ACTIVO
            if (chkbShPass.Checked == true)
            {
                // Si esta activo se desenmascara la CAJA de Contraseña
                if (txtPass.UseSystemPasswordChar == true)
                {
                    txtPass.UseSystemPasswordChar = false;
                }
            }
            else
            {
                // Si NO esta activo se enmascara la CAJA de Contraseña
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si se presiona ENTER se ejecuta el código del Botón de ACCESO
            if (e.KeyChar == (char)13)
            {
                btnAcceso.PerformClick();
            }
        }
    }
}
