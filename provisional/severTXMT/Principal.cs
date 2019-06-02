using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace severTXMT {
   public class Principal {
        
        static void Main(string[] args) {

            int puerto = 8080;
            IPAddress direccionIP = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(direccionIP,puerto);
            TcpClient clientSocket = default(TcpClient);


            int counter = 0;

            serverSocket.Start();
            Console.WriteLine("Servidor iniciado en la direccion y puerto {0} {1}"
                ,Convert.ToString(direccionIP),Convert.ToString(puerto));

            counter = 0;

            while(true) {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >>> " + "Cliente No:" + Convert.ToString(counter) + "se ha conectado!");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, Convert.ToString(counter));
            }


        }//cierre del main
    }//cierre de la clase principal
}
