using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace serverTexas {
    class Server {
        static void Main(string[] args) {


            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            int puerto = 8080;
            TcpListener server = new TcpListener(ip, puerto);
            TcpClient client = default(TcpClient);

            try {

                server.Start();
                Console.WriteLine("Iniciando el server ('localhost') {0}", ip);
               

            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

            while (true) {

                client = server.AcceptTcpClient();

                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                StringBuilder msg = new StringBuilder();


                foreach (byte b in receivedBuffer) {
                    if (b.Equals(00)) {
                        break;
                    } else {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }

                Console.WriteLine(msg.ToString());

            }



        }
    }
}
