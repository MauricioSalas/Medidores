using Medidores.Comunicacion;
using MedidoresModel.DAL;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimuladorMedidor
{
    public class Program
    {
        private ThreadClient threadClient;
        static void Main(string[] args)
        {
            string servidor = "127.0.0.1";
            int puerto = 5000;

            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado a Servidor {0} en Puerto {1}", servidor, puerto);
                threadClient.Ejecutar();
            }
            else
            {
                Console.WriteLine("Error de Comunicación.");
            }
            Console.ReadKey();
        }
    }
}
