using SistemaBibliotecaSisInf.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBibliotecaSisInf
{
    public partial class FrmBusquedaLibros : Form
    {
        LibroController lc = new LibroController();

        public FrmBusquedaLibros()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            libroBindingSource.DataSource = 
                lc.buscarLibroEstudiante(txtBuscar.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin(this);
            login.ShowDialog();
        }

        private void FrmBusquedaLibros_Load(object sender, EventArgs e)
        {
            if (App.isLogin)
            {
                this.button1.Visible = false;
            }
            else 
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
