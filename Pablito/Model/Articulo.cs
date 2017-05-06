using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pablito
{
    public class Articulo
    {
        public string WClave { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }

        public Articulo(string WClave, string CodigoBarras, string Nombre)
        {
            this.WClave = WClave;
            this.CodigoBarras = CodigoBarras;
            this.Nombre = Nombre;
        }
    }
}
