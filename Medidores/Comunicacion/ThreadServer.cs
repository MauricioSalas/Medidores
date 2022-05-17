using MedidoresModel;
using MedidoresModel.DAL;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medidores.Comunicacion
{
    public class ThreadServer
    {
        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("S: Iniciando servidor en puerto: {0}", puerto);
            ServerSocket server = new ServerSocket(puerto);
            if (server.Iniciar())
            {
                while (true) {
                    Console.WriteLine("S: Esperando Cliente...");
                    Socket cliente = server.ObtenerCliente();
                    Console.WriteLine("S: Cliente Recibido.");
                    ClienteCom clienteCom = new ClienteCom(cliente);
                    ThreadClient clienteThread = new ThreadClient(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteThread.Ejecutar));
                    t.IsBackground = true;
                    t.Start(); 
                }
            }
            else
            {
                Console.WriteLine("Servidor no iniciado. Error con el puerto: {0}", puerto);
            }
        }
    }
}
