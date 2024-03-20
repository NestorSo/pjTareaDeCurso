using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Numerics;

namespace pjTareaDeCurso
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Funciones Básicas

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
               txtUsuario.ForeColor = Color.Black;
            }

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "USUARIO")
            {
                if (txtPassword.Text != "CONTRASEÑA")
                {
                    Inicio mainMenu = new Inicio();
                    mainMenu.Show();
                    mainMenu.FormClosed += Logout;
                    this.Hide();

                    msgError("Usuario o contraseña incorrecta. \nIntente nuevamente. ");
                    txtPassword.Clear();
                    txtUsuario.Focus();
                }

                else msgError("Por favor ingrese una contraseña");
            }
            else msgError("Por favor ingrese un usuario");
        }
            private void msgError(string msg) 
            {
                lblErrorMessage.Text = "   " + msg;
                lblErrorMessage.Visible = true;
            }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtPassword.Clear();
            txtUsuario.Clear();
            lblErrorMessage.Visible = false;
            this.Show();
            txtUsuario.Focus();
       }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

    }
}

