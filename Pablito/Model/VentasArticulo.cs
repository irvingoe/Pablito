using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pablito
{
    public class VentasArticulo
    {
        public int IdAlmacen { get; set; }
        public string IdArticulo { get; set; }
        public int CantidadRegular { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionAlmacen { get; set; }

        public VentasArticulo(int IdAlmacen, string IdArticulo, int CantidadRegular, DateTime Fecha, string DescripcionAlmacen)
        {
            this.IdAlmacen = IdAlmacen;
            this.IdArticulo = IdArticulo;
            this.CantidadRegular = CantidadRegular;
            this.Fecha = Fecha;
            this.DescripcionAlmacen = DescripcionAlmacen;
        }
    }
}
