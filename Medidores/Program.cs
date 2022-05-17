using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medidores
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese medidor: \n");
            string valorMedidor = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese valor de consumo: \n");
            string valorConsumoMedidor = Console.ReadLine().Trim();
            Console.WriteLine("Medidor: {0} | Consumo: {1} | Fecha: {2} | Timestamp: {3}", valorMedidor, valorConsumoMedidor, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTimeOffset.Now.ToUnixTimeSeconds());
            //2019-02-03 03:04:00
            //YYYY-MM-DD HH:MM:SS
            //Formato a Guardar -> Medidor|Fecha|ValorConsumo
            Console.ReadKey();
        }
    }
}
