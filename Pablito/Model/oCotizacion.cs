﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pablito
{
    public class oCotizacion
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Existencia { get; set; }
        public string Laboratorio { get; set; }
        public string Fiscal { get; set; }
        
        private decimal _Descuento;
        public decimal Descuento
        {
            get
            {
                return _Descuento;
            }
            set
            {

                decimal valor = 0;

                switch (Fiscal)
                {
                    case "F":
                    case "N":
                    case "O":
                        valor = 0;
                        break;
                    case "B":
                        valor = 0.2179M;
                        break;
                    case "H":
                    case "HA":
                        valor = value < 18 ? .15M : value/100;
                        break;
                    case "FA":
                    case "NA":
                    case "OA":
                        valor = -0.16M;
                        break;
                    case "BA":
                        valor = 0.2179M;
                        break;
                    default:
                        break;

                }

                _Descuento = valor;
            }
        }
        public decimal PrecioFarmacia { get; set; }
        private decimal _Costo;
        private decimal _PrecioFarmaciaCemain;
        public decimal PrecioFarmaciaCemain
        {
            get
            {
                decimal temporal;
                temporal = PrecioFarmacia - (PrecioFarmacia * Descuento);
                switch (Fiscal)
                {
                    case "F":
                    case "N":
                    case "O":
                    case "B":
                    case "H":
                    case "FA":
                    case "NA":
                    case "OA":
                        _PrecioFarmaciaCemain = temporal;
                        break;
                    case "HA":
                    case "BA":
                        _PrecioFarmaciaCemain = temporal + (temporal * 0.16M);
                        break;
                    default:
                        break;
                }
                return _PrecioFarmaciaCemain;
            }
            set
            {
                _PrecioFarmaciaCemain = value;
            }
        }
        public decimal PrecioPublico
        {
            get
            {
                switch (Fiscal)
                {
                    case "F":
                    case "N":
                    case "O":
                    case "B":
                    case "H":
                    case "FA":
                    case "NA":
                    case "OA":
                        _Costo = PrecioFarmaciaCemain + (PrecioFarmaciaCemain * 0.15M);
                        break;
                    case "HA":
                    case "BA":
                        _Costo = PrecioFarmaciaCemain + (PrecioFarmaciaCemain * 0.15M);
                        break;
                    default:
                        break;
                }
                return _Costo;
            }
            set
            {
                _Costo = value;
            }
        }


    }
}