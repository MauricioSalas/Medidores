using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel
{
    public class Medidor
    {
        private string nombre;
        private uint kWh;
        private double fechaUnix;

        public string Nombre { get => nombre; set => nombre = value; }
        public uint KWh { get => kWh; set => kWh = value; }
        public double FechaUnix { get => fechaUnix; set => fechaUnix = value; }

        public override string ToString()
        {
            return "\n" + nombre + " " + kWh + "\n" + FechaUnix + "\n";
        }
    }
}
