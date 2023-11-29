using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudProductos.VIstas;
using opDatos;

namespace CrudProductos
{
    public partial class Ventas : Form
    {
        Datos datos = new Datos();
        int total = 0;
        Producto Producto = new Producto();
        private List<Producto> listaProductos = new List<Producto>();
        public Ventas()
        {
            InitializeComponent();
            MostrarFechaActual();
            this.KeyPreview = true;
            this.KeyDown += Ventas_KeyUp;
            obtenerCantidadFolio();
        }

        //Funcion para obtener la fecha actual y mostrarla
        private void MostrarFechaActual()
        {
            DateTime fechaActual = DateTime.Now;
            string fechaActualStr = fechaActual.ToString("dd/MM/yyyy");
            lblFecha.Text = fechaActualStr;
        }

        private void Ventas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Productos frmProductos = new Productos();
                frmProductos.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txbProductoID.Text != "")
                {
                    try
                    {
                        int idProducto = Convert.ToInt32(txbProductoID.Text);
                        List<Producto> datosProducto = datos.datosProducto(idProducto);
                        txbCantidad.Text = Convert.ToString(datosProducto[0].Cantidad);
                        txbDescripcion.Text = datosProducto[0].Descripcion;
                        txbPrecioVenta.Text = Convert.ToString(datosProducto[0].PrecioVenta);
                        btnAgregarProducto.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El ID no cuencuerda con ningun producto asociado, porfavor vuelva a intentarlo", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void obtenerCamposProducto(string ProductoID, string Descripcion, string precioVenta, int Cantidad)
        {
            txbProductoID.Text = ProductoID;
            txbDescripcion.Text = Descripcion;
            txbPrecioVenta.Text = precioVenta;
            txbCantidad.Text = Cantidad.ToString();
            btnAgregarProducto.Focus();
        }

        private void obtenerCantidadFolio()
        {
            int opcion = 2;
            int cantidadID = datos.obtenerConteoProductos(opcion);
            cantidadID = cantidadID + 1;
            txbFolio.Text = cantidadID.ToString();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbProductoID.Text) &&
                !string.IsNullOrEmpty(txbDescripcion.Text) &&
                !string.IsNullOrEmpty(txbPrecioVenta.Text) &&
                !string.IsNullOrEmpty(txbCantidad.Text))
            {
                dgvDetallesVenta.Rows.Add(txbProductoID.Text, txbDescripcion.Text, txbCantidad.Text, txbPrecioVenta.Text);
                SumarTotal(txbPrecioVenta.Text);
                limpiarCampos();
                this.Focus();
            }
        }

        private void limpiarCampos()
        {
            txbProductoID.Clear();
            txbDescripcion.Clear();
            txbPrecioVenta.Clear();
            txbCantidad.Clear();
        }

        private void SumarTotal(string precio)
        {
            int precioProducto = Convert.ToInt32(precio);
            total = total + precioProducto;
            txbTotal.Text = $"${total.ToString()}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbProductoID.Clear();
            txbDescripcion.Clear();
            txbPrecioVenta.Clear();
            txbCantidad.Clear();
            total = 0;
            txbTotal.Text = "$0";
            dgvDetallesVenta.Rows.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetallesVenta.Rows.Count > 0)
                {
                    ObtenerDatosDataGridView();
                    int folio = Convert.ToInt32(txbFolio.Text);
                    datos.transaccionGuardarDatos(listaProductos, folio);
                    txbCantidad.Clear();
                    total = 0;
                    txbTotal.Clear();
                    dgvDetallesVenta.Rows.Clear();
                    MessageBox.Show("!Los Datos de venta se registraron con exito!", "CORRECTO", MessageBoxButtons.OK);
                    obtenerCantidadFolio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatosDataGridView()
        {
            listaProductos.Clear();

            foreach (DataGridViewRow fila in dgvDetallesVenta.Rows)
            {
                Producto producto = new Producto
                {
                    ProductID = Convert.ToInt32(fila.Cells["dgvProductID"].Value),
                    Descripcion = Convert.ToString(fila.Cells["dgvDescripcion"].Value),
                    PrecioVenta = Convert.ToDecimal(fila.Cells["dgvPrecioVenta"].Value),
                    Cantidad = Convert.ToInt32(fila.Cells["dgvCantidad"].Value)
                };

                listaProductos.Add(producto);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            VentasDetalle ventasDetalle = new VentasDetalle();
            ventasDetalle.ShowDialog();
            obtenerCantidadFolio();
        }

        private void txbProductoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbProductoID_TextChanged(object sender, EventArgs e)
        {
            if (txbProductoID.Text == "")
            {
                txbProductoID.Clear();
                txbCantidad.Clear();
                txbDescripcion.Clear();
                txbPrecioVenta.Clear();
            }
        }
    }
}
