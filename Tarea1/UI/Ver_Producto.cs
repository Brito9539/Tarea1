using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Tarea1.DAO;

namespace Proyecto_SCI_
{
    public partial class Modificar_Producto : Form
    {

        MySqlCommand cmd;
        MySqlConnection cn;
        string query;
        DataSet Inventario = new DataSet();
        string idProducto;
        string Matricula;
        public Modificar_Producto()
        {
            InitializeComponent();
          
        }

        #region Eventos y validaciones
        private void txtFiltrar_MouseDown(object sender, MouseEventArgs e)
        {
            txtFiltrar.Clear();
        }


        #endregion


      


        public void CargarDatos()
        {
            ProductoDAO listaProducto = new ProductoDAO();
            this.dataGridView1.DataSource = listaProducto.listaProductos();
        }



        private void Modificar_Producto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.SelectedRows[0].Selected = false;
                }

                DataGridView.HitTestInfo Hitest = this.dataGridView1.HitTest(e.X, e.Y);
                if (Hitest.Type == DataGridViewHitTestType.Cell)
                {

                    dataGridView1.Rows[Hitest.RowIndex].Selected = true;
                    idProducto = dataGridView1.SelectedCells[0].Value.ToString();
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;

            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dataGridView1.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    cmsEditar.Show(dataGridView1, new Point(e.X, e.Y));
            }

        }

    
        private void cmsEditar_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ContenedorRegi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoDAO Delete = new ProductoDAO();
            DialogResult resultado = MessageBox.Show("Estas seguro que desea eliminarlo?", "Unimodelo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (resultado == DialogResult.Yes)
            {
                Delete.EliminarProducto(idProducto, true);
                MessageBox.Show("El producto ha sido eliminado");
                Inventario.Clear();
                CargarDatos();
            }
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            Inventario.Clear();

            try
            {
                ProductoDAO listaProducto = new ProductoDAO();
                this.dataGridView1.DataSource = listaProducto.FiltrarProducto(txtFiltrar.Text);
            }
            catch
            {
                MessageBox.Show("Ingrese datos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
 

