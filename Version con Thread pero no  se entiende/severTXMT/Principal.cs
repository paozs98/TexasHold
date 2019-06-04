using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace severTXMT {
   public class Principal {
        
        static void Main(string[] args) {

            int port = 13000;
            string IpAddress = "127.0.0.1";
            Socket ServerLister = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            ServerLister.Bind(ep);
            ServerLister.Listen(2);
            Console.WriteLine("El servidor a iniciado");
            Socket ClientSocket = default(Socket);
            int counter = 0;
            Principal p = new Principal();
            while(true) {
                counter++;
                ClientSocket = ServerLister.Accept();
                Console.WriteLine(counter + "Clientes conectados");
                Thread UserThread = new Thread(new ThreadStart(() => p.User(ClientSocket)));
                UserThread.Start();

            }


        }//cierre del main

        public void User(Socket client) {
            while(true) {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                client.Send(msg, 0, SocketFlags.None);

            }
        }
    }//cierre de la clase principal
}
