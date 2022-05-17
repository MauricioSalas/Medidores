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
        private static IMedidoresDAL medidoresDAL = MedidoresDALText.GetInstancia();
        private ClienteCom clienteCom;

        public ThreadClient(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Ingrese Nombre: ");
            string nombre = clienteCom.Leer();
            clienteCom.Escribir("Ingrese Kilowatt por Hora (kWh): ");
            string kWh = clienteCom.Leer();

            Medidor medidor = new Medidor()
            {
                Nombre = nombre,
                KWh = Convert.ToUInt32(kWh),
                FechaUnix = DateTimeOffset.Now.ToUnixTimeSeconds()
        };
            //ThreadSafe
            lock (medidoresDAL)
            {
                medidoresDAL.IngresarLectura(medidor);
            }

            clienteCom.Desconectar();
        }
    }
}
