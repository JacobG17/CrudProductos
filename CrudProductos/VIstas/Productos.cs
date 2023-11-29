using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using opDatos;

namespace CrudProductos.VIstas
{
    public partial class Productos : Form
    {
        Datos opDatos = new Datos();
        string productoId = "";
        int IDproducto = 0;
        int conteo = 0;
        public Productos()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Productos_KeyUp;
            cargarProductos();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            int opcion = 1;
            CA_Producto newProducto = new CA_Producto(opcion, opcion);
            newProducto.Show();
        }
        private void cargarProductos()
        {
            try
            {
                conteo = dataGridView1.Rows.Count;
                dataGridView1.DataSource = opDatos.obtenerProductos();
                conteo = dataGridView1.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                this.Hide();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conteo = dataGridView1.Rows.Count;
            dataGridView1.DataSource = null;
            conteo = dataGridView1.Rows.Count;
            cargarProductos();
            MessageBox.Show("!Datos Actualizados Correctamente!", "ACTUALIZADO", MessageBoxButtons.OK);
            conteo = dataGridView1.Rows.Count;
        }


        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila que se hizo clic
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                dataGridView1.ClearSelection();
                if (e.Button == MouseButtons.Right)
                {
                    filaSeleccionada.Selected = true;
                    this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                    productoId = filaSeleccionada.Cells["ProductID"].Value.ToString();
                    IDproducto = Convert.ToInt32(productoId);
                }
                else
                {
                    filaSeleccionada.Selected = true;
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int opcion = 2;
            CA_Producto updateProducto = new CA_Producto(opcion, IDproducto);
            updateProducto.ShowDialog();
            dataGridView1.DataSource = null;
            cargarProductos();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IDproducto = Convert.ToInt32(productoId);
                opDatos.eliminarProducto(IDproducto);
                MessageBox.Show("!El producto ha sido eliminado con Exito!", "CORRECTO", MessageBoxButtons.OK);
                cargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                string Producto = fila.Cells["ProductID"].Value.ToString();
                string Descripcion = fila.Cells["Descripcion"].Value.ToString();
                string PrecioVenta = fila.Cells["PrecioVenta"].Value.ToString();
                int Cantidad = 1;
                if (Application.OpenForms["Ventas"] is Ventas ventas)
                {
                    ventas.obtenerCamposProducto(Producto, Descripcion, PrecioVenta, Cantidad);
                }

                this.Dispose();
                this.Hide();
            }
        }

        private void Productos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Hide();
            }
        }
    }
}
