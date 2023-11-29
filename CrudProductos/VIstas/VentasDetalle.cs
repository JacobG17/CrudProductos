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

        private void obtenerFilas(int nFila)
        {
            datosList.Clear();

            DataGridViewRow fila = dataGridView1.Rows[nFila];

            foreach (DataGridViewCell celda in fila.Cells)
            {
                if (celda.OwningColumn.Name == "ProductID" && celda.Value != null)
                {
                    int productIDActual = Convert.ToInt32(celda.Value);
                    bool existeEnLista = datosList.Any(f => f.ProductID == productIDActual);

                    if (!existeEnLista)
                    {
                        DatosVentaDetalle datosVentaDetalle = new DatosVentaDetalle
                        {
                            Folio = Convert.ToInt32(fila.Cells["Folio"].Value),
                            Fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value),
                            ProductID = productIDActual,
                            Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value),
                            Total = Convert.ToDecimal(fila.Cells["Total"].Value),
                            TipoMovimiento = Convert.ToString(fila.Cells["TipoMovimiento"].Value)
                        };

                        datosList.Add(datosVentaDetalle);
                    }
                }
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nFila = e.RowIndex;
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
                obtenerFilas(nFila);
                datos.rollbackTransaccion(datosList);
                MessageBox.Show($"!La transaccion de la Venta del folio {folio} se deshizo correctamente!", "CORRECTO", MessageBoxButtons.OK);
                dataGridView1.Rows.Clear();
                cargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
