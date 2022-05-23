using Medidores.Comunicacion;
using MedidoresModel;
using MedidoresModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medidores
{
    public class Program
    {
        private static IMedidoresDAL medidoresDAL = new MedidorDALText();
        private static ILecturaDAL lecturasDAL = LecturaDALText.GetInstancia();
        static void Main(string[] args)
        {
            ThreadServer threadServer = new ThreadServer();
            Thread t = new Thread(new ThreadStart(threadServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (Menu());
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine(" 1. Ingresar \n 2. Obtener Listado \n 3. Obtener Medidor \n 0. Salir\n");
            switch (Console.ReadLine().Trim())
            {
                case "1": IngresarLectura();
                    break;
                case "2": ObtenerLecturas();
                    break;
                case "3": ObtenerMedidores();
                    break;
                case "0": continuar = false;
                    break;
                default: Console.WriteLine("Opción no encontrada.");
                    break;
            }
            return continuar;
        }

    static void IngresarLectura()
        {
            string idMedidor;
            uint kWh;

            //Console.WriteLine("Aplicación iniciada.");
            do
            {
                Console.WriteLine("Ingrese ID del Medidor: ");
                idMedidor = Console.ReadLine().Trim();
            } while (idMedidor == string.Empty);

            do
            {
                Console.WriteLine("Ingrese kWh: ");
                kWh = (uint)Convert.ToInt32(Console.ReadLine().Trim());
            } while (kWh == null);

            Medidor medidor = new Medidor()
            {
                Codigo = int.Parse(idMedidor),
                KWh = kWh,
                FechaUnix = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")
            };

            lock (lecturasDAL)
            {
                lecturasDAL.IngresarLectura(medidor);
            }
        }

    static void ObtenerLecturas()
        {
            List<Medidor> medidor = null;
            lock (lecturasDAL)
            {
                medidor = lecturasDAL.ObtenerLecturas();
            }
            foreach (Medidor values in medidor)
            {
                Console.WriteLine(values);
            }
        }

    static void ObtenerMedidores()
        {
            List<Medidor> medidores = medidoresDAL.ObtenerMedidores();
            for (int i = 0; i < medidores.Count(); i++)
            {
                Medidor actual = medidores[i];
                Console.WriteLine("\n{0}. Código Medidor: {1}", i, actual.Codigo);
            }
        }
    }
}
