using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEmServer
{
    class Server
    {
        public Server()
        {
            try
            {
                TcpListener myList = new TcpListener(IPAddress.Any, 8010);
                myList.Start();

                Console.WriteLine("Server running at port 8001...");
                Console.WriteLine("Waiting for a connection...");

                Socket s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = s.Receive(b);
                Console.WriteLine("Recieved...");
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
                /* clean up */
                s.Close();
                Console.Read();
                myList.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.Read();
            }
        }
    }
        
}
