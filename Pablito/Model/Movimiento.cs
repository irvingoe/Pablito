using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pablito.Model
{
     public class Movimiento
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }
        private decimal _importe;
        public decimal Importe
        {
            get
            {
                return _importe;
            }
            set
            {
                _importe = Cantidad * Costo;
            }
        }
    }
}
