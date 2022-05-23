using MedidoresModel;
using MedidoresModel.DAL;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medidores.Comunicacion
{
    class ThreadClient
    {
        //Singleton
        private static IMedidoresDAL medidoresDAL = new MedidorDALText();
        private static ILecturaDAL lecturasDAL = LecturaDALText.GetInstancia();

        private ClienteCom clienteCom;

        public ThreadClient(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            List<Medidor> medidores = medidoresDAL.ObtenerMedidores();
            clienteCom.Escribir("Ingrese Codigo de Medidor: ");
            string idMedidor = clienteCom.Leer();

            if (medidores.Find(med => med.Codigo == int.Parse(idMedidor)) == null)
            {
                clienteCom.Escribir("ERROR");
                clienteCom.Desconectar();
            }

            clienteCom.Escribir("Ingrese Kilowatt por Hora (kWh): ");
            string kWh = clienteCom.Leer();

            Medidor medidor = new Medidor()
            {
                Codigo = int.Parse(idMedidor),
                KWh = Convert.ToUInt32(kWh),
                FechaUnix = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")
            };
            //ThreadSafe
            lock (lecturasDAL)
            {
                lecturasDAL.IngresarLectura(medidor);
            }

            clienteCom.Desconectar();
        }
    }
}
