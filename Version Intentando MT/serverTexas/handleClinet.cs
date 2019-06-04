using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace serverTexas {
    class handleClinet {

        TcpClient clientSocket;
        string clNo;
        Thread clienteHilo;

        public handleClinet() {
           
        }


        public void iniciarHandleClient(TcpClient inClientSocket, string clineNo) {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clienteHilo = new Thread(doChat);
            clienteHilo.Start();
        }


        public void doChat() {

            int requestCount = 0;

            byte[] receivedBuffer = new byte[100];
            NetworkStream stream = clientSocket.GetStream();
            stream.Read(receivedBuffer, 0, receivedBuffer.Length);

            StringBuilder msg = new StringBuilder();

         
                try {

                    foreach(byte b in receivedBuffer) {
                        if(b.Equals(00)) {
                            break;
                        } else {
                            msg.Append(Convert.ToChar(b).ToString());
                        }
                    }
                Console.Write(">>" + "Cliente No: " +
                this.clNo +
                " se ha conectado");
                Console.WriteLine(msg.ToString());

                } catch(Exception ex) {
                    Console.WriteLine(">>" + ex.ToString());
                }
            

            
        }
    }
}
