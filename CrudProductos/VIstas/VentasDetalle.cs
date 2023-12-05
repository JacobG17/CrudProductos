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
    public partial class VentasDetalle : Form
    {
        Datos datos = new Datos();
        int folio = 0;
        int nFila = 0;
        string FolioString = "";
        List<DatosVentaDetalle> datosList = new List<DatosVentaDetalle>();
        public VentasDetalle()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = datos.obtenerInventarioDetalle();
        }

        private void obtenerFilas(int folioFila)
        {
            foreach (DataGridViewRow fila  in dataGridView1.Rows)
            {
                // Obtén los valores de las celdas específicas
                int valorFolio = Convert.ToInt32(fila.Cells["Folio"].Value);
                string valorMovimiento = fila.Cells["TipoMovimiento"].Value.ToString();

                // Verifica las condiciones deseadas
                if (valorFolio != null && valorFolio == folioFila &&
                    valorMovimiento != null && valorMovimiento.ToString() == "Salida")
                {
                    DatosVentaDetalle datosVentaDetalle = new DatosVentaDetalle
                    {
                        Folio = Convert.ToInt32(fila.Cells["Folio"].Value),
                        Fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value),
                        ProductID = Convert.ToInt32(fila.Cells["ProductID"].Value),
                        Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value),
                        Total = Convert.ToDecimal(fila.Cells["Total"].Value),
                        TipoMovimiento = Convert.ToString(fila.Cells["TipoMovimiento"].Value)
                    };
                    // Agrega la fila a la lista
                    datosList.Add(datosVentaDetalle);
                }
            }
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
                    FolioString = filaSeleccionada.Cells["Folio"].Value.ToString();
                    folio = Convert.ToInt32(FolioString);
                    string tipoMovimiento = filaSeleccionada.Cells["TipoMovimiento"].Value.ToString();
                    if (tipoMovimiento == "Salida")
                    {
                        this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
                else
                {
                    filaSeleccionada.Selected = true;
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                obtenerFilas(folio);
                datos.rollbackTransaccion(datosList);
                MessageBox.Show($"!La transaccion de la Venta del folio {folio} se deshizo correctamente!", "CORRECTO", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                cargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
