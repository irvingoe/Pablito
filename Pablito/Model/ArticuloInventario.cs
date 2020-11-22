using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pablito
{
    public class ArticuloInventario
    {
        public string IdArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public int CantidadRegular { get; set; }
        public int TotalVentasMO { get; set; }
        public int TotalVentasC1 { get; set; }
        public int TotalVentasAE { get; set; }
        public int TotalVentasNT { get; set; }
        public int TotalVentasLP { get; set; }
        public int TotalVentasC2 { get; set; }
        public int TotalExistenciasMO { get; set; }
        public int TotalExistenciasC1 { get; set; }
        public int TotalExistenciasAE { get; set; }
        public int TotalExistenciasNT { get; set; }
        public int TotalExistenciasLP { get; set; }
        public int TotalExistenciasC2 { get; set; }
        public string FechaUltimaVenta { get; set; }
        public string SucursalUltimaVenta { get; set; }
        public ArticuloInventario()
        {
            
        }
    }
}
