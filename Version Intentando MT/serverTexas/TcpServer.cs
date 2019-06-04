using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace serverTexas {
    class TcpServer {

        IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
        int puerto = 8080;

        TcpListener ServerSocket;
        TcpClient clientSocket;
        
        int contadorUsuarios=0;


        public TcpServer() {
             ServerSocket = new TcpListener(ip, puerto);
             clientSocket = default(TcpClient);
            this.IniciarServer();
        }
        public void IniciarServer() {

            
            try {

                ServerSocket.Start();
                Console.WriteLine("Iniciando el server ('localhost') {0}", ip);
                Console.WriteLine("En el puerto {0}", Convert.ToString(puerto));

            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

            for(; ; ) {

                clientSocket = ServerSocket.AcceptTcpClient();
                contadorUsuarios += 1;

                

                //Aqui se debe crear al handler del cliente 
                handleClinet client = new handleClinet(clientSocket,Convert.ToString(contadorUsuarios));
            }

            clientSocket.Close();
            ServerSocket.Stop();
            Console.WriteLine(">>" + "exit");
            Console.ReadLine();

        }
           


    }
}
