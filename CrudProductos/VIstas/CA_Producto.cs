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
    public partial class CA_Producto : Form
    {
        Datos datos = new Datos();
        public CA_Producto(int opcion, int productID)
        {
            InitializeComponent();
            if (opcion == 1)
            {
                this.Text = "Agregar Producto";
                btnActualizar.Enabled = false;
                btnActualizar.Hide();
                obtenerConteoID();
            }
            else
            {
                this.Text = "Actualizar Producto";
                label1.Text = "        Actualizar producto";
                txbID.ReadOnly = true;
                txbID.TabStop = false;
                txbID.BackColor = Color.White;
                btnAgregar.Enabled = false;
                btnAgregar.Hide();
                int idProduct = productID;
                obtenerProducto(idProduct);
            }
        }

        private void limpiar()
        {
            txbID.Clear();
            txbDescripcion.Clear();
            txbPrecio.Clear();
            txbSaldo.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txbID.Text) &&
                !string.IsNullOrWhiteSpace(txbDescripcion.Text) &&
                !string.IsNullOrWhiteSpace(txbPrecio.Text) &&
                !string.IsNullOrWhiteSpace(txbSaldo.Text))
                {
                    int folio = Convert.ToInt32(txbID.Text);
                    int precio = Convert.ToInt32(txbPrecio.Text);
                    int saldo = Convert.ToInt32(txbSaldo.Text);
                    datos.agregarProducto(folio, txbDescripcion.Text, precio, saldo);
                    DialogResult resultado = MessageBox.Show("!El producto se ha agregado con Exito!, ¿Desea seguir agregando?", "CORRECTO", MessageBoxButtons.YesNo);

                    if (resultado == DialogResult.Yes)
                    {
                        limpiar();
                        obtenerConteoID();
                    }
                    else if (resultado == DialogResult.No)
                    {
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, llene todos los TextBox.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void CA_Producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Hide();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txbID.Text) &&
                !string.IsNullOrWhiteSpace(txbDescripcion.Text) &&
                !string.IsNullOrWhiteSpace(txbPrecio.Text) &&
                !string.IsNullOrWhiteSpace(txbSaldo.Text))
                {
                    int idProducto = Convert.ToInt32(txbID.Text);
                    int precio = Convert.ToInt32(txbPrecio.Text);
                    int saldo = Convert.ToInt32(txbSaldo.Text);
                    datos.actualizarProducto(idProducto, txbDescripcion.Text, precio, saldo);
                    DialogResult resultado = MessageBox.Show("!El producto se ha actualizado con Exito!", "CORRECTO", MessageBoxButtons.OK);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Por favor, llene todos los TextBox.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerConteoID()
        {
            int opcion = 1;
            int cantidadID = datos.obtenerConteoProductos(opcion);
            cantidadID = cantidadID + 1;
            txbID.Text = cantidadID.ToString();
        }

        private void obtenerProducto(int idProducto)
        {
            try
            {
                string[] datosProducto = new string[4];
                datosProducto = datos.ObtenerDatosProducto(idProducto);
                txbID.Text = datosProducto[0];
                txbDescripcion.Text = datosProducto[1];
                txbPrecio.Text = datosProducto[2];
                txbSaldo.Text = datosProducto[3];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
