using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public class MedidoresDALText : IMedidoresDAL
    {
        //Singleton
        private MedidoresDALText()
        {

        }

        private static MedidoresDALText instancia;

        public static IMedidoresDAL GetInstancia()
        {
            if(instancia == null)
            {
                instancia = new MedidoresDALText();
            }
            return instancia;
        }

        private static string archivo = "lecturas.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;

        public void IngresarLectura(Medidor medidor)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(ruta, true))
                {
                    writer.WriteLine(medidor.Nombre + "|" + medidor.KWh + "|" + medidor.FechaUnix);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        public List<Medidor> ObtenerMedidores()
        {
            throw new NotImplementedException();
        }

        public List<Medidor> ObtenerLecturas()
        {
            List<Medidor> datos = new List<Medidor>();
            using (StreamReader reader = new StreamReader(ruta))
            {
                string texto;
                do
                {
                    texto = reader.ReadLine();
                    if (!String.IsNullOrEmpty(texto))
                    {
                        string[] textoArr = texto.Trim().Split('|');
                        Medidor med = new Medidor()
                        {
                            Nombre = textoArr[0],
                            KWh = Convert.ToUInt32(textoArr[1]),
                            FechaUnix = Convert.ToUInt32(textoArr[2])
                        };
                        datos.Add(med);
                    }
                } while (texto != null);
            }
            return datos;
        }
    }
}
