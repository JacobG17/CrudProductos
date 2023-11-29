using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opDatos
{
    public class Producto
    {
        public int ProductID { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
    }

    public class DatosVentaDetalle
    {
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductID { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
