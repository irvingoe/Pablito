using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pablito
{
    class TestingDictionary
    {

        static void main()
        {
            List<Articulo> articulos = new List<Articulo>();
            articulos.Add(new Articulo("0123","0123","Ariel Detergente"));
            articulos.Add(new Articulo("0123", "0123", "Ariel Detergente 500g"));
            articulos.Add(new Articulo("0123", "0123", "Ariel Detergente 1kg"));
            articulos.Add(new Articulo("0123", "0123", "Acxion 500mg"));
            articulos.Add(new Articulo("0123", "0123", "Acxion 1mg"));
            articulos.Add(new Articulo("0123", "0123", "Acxion Suspension"));

            Console.WriteLine(articulos.Select(s => s.Nombre).ToList().BinarySearch("Acxi"));
            Console.ReadLine();
        }

    }
}

