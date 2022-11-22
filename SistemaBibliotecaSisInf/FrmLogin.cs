using SistemaBibliotecaSisInf.Controladores;
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
        FrmBusquedaLibros frmBusquedaLibros;
        public FrmLogin(FrmBusquedaLibros frmBusquedaLibros)
        {
            InitializeComponent();
            this.frmBusquedaLibros = frmBusquedaLibros;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string cuenta = txtCuenta.Text;
            string password = txtPassword.Text;

            UsuarioController usuarioController = new UsuarioController();
            bool isLogin = usuarioController.login(cuenta, password);

            if (isLogin == true)
            {
                // Ocultando el formulario de busqueda de libros
                this.frmBusquedaLibros.ShowInTaskbar = false;
                this.frmBusquedaLibros.Visible = false;

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
