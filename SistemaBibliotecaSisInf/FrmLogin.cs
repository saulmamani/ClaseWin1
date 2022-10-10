using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaBibliotecaSisInf
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string cuenta = txtCuenta.Text;
            string password = txtPassword.Text;

            if (cuenta == "admin" && password == "123")
            {
                this.Visible= true;
                this.ShowInTaskbar = false;
                Form1 frmPrincipal = new Form1();
                frmPrincipal.ShowDialog();
            }
            else {
                MessageBox.Show("Cuenta o password incorrectos",
                    "SIS-INF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
