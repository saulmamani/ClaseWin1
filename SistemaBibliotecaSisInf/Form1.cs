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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openForm(new FrmLibro());
        }

        private void openForm(Form frm) {
            this.closeForm(this);

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.ControlBox = false;
            frm.Show();
        }

        private void closeForm(Form frm) {
            if (frm.ActiveMdiChild != null) { 
                frm.ActiveMdiChild.Close();
            }
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openForm(new FrmAlumno());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolUser.Text = String.Format("(c) 2022 {0} | {1}",
                App.usuarioAuth.Cuenta,
                App.usuarioAuth.NombreCompleto);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmBusquedaLibro = new FrmBusquedaLibros();
            this.openForm(frmBusquedaLibro);
        }
    }
}
