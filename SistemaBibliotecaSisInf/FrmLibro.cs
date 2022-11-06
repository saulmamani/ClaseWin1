using SistemaBibliotecaSisInf.Controladores;
using SistemaBibliotecaSisInf.Modelos;
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
    public partial class FrmLibro : Form
    {
        LibroController libroController = new LibroController();
        public FrmLibro()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void buscar() { 
            libroBindingSource.DataSource = libroController.buscar(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            this.libroBindingSource.AddNew();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            this.libroBindingSource.CancelEdit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Libro libro = new Libro();
            libro = (Libro)libroBindingSource.Current;

            if (this.idLabel1.Text == "0")
                libroController.insertar(libro);
            else
                libroController.modificar(libro);

            MessageBox.Show("Datos guardados correctamente!!");
            buscar();

            this.groupBox1.Enabled = false;
        }

        private void FrmAlumno_Load(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void estudianteDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == estudianteDataGridView.Columns["btnEditar"].Index)
            { 
                this.groupBox1.Enabled = true;
            }

            if (e.ColumnIndex == estudianteDataGridView.Columns["btnEliminar"].Index)
            {
                this.eliminar();
            }
        }

        private void eliminar()
        {
            DialogResult dlr = MessageBox.Show("Estas seguro?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                libroController.eliminar(Convert.ToInt32(idLabel1.Text));
                this.buscar();
            }
        }
    }
}
