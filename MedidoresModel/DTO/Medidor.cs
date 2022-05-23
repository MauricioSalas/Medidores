using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel
{
    public class Medidor
    {
        private int codigo;
        private uint kWh;
        private string fechaUnix;

        public int Codigo { get => codigo; set => codigo = value; }
        public uint KWh { get => kWh; set => kWh = value; }
        public string FechaUnix { get => fechaUnix; set => fechaUnix = value; }

        public override string ToString()
        {
            return "\n" + Codigo + " " + kWh + "\n" + FechaUnix + "\n";
        }
    }
}
