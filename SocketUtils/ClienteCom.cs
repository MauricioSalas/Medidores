﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils
{
    public class ClienteCom
    {
        private Socket cliente;
        private StreamReader reader;
        private StreamWriter writer;

        public ClienteCom(Socket socket)
        {
            this.cliente = socket;
            Stream stream = new NetworkStream(this.cliente);
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream);
        }

        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public String Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Desconectar()
        {
            try
            {
                this.cliente.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
