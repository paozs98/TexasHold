using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace severTXMT {
    class handleClinet {

        TcpClient clientSocket;
        string clNo;

        public void startClient(TcpClient inClientSocket, string clineNo) {

            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();

        }

        private void doChat() {

            int conteoDeSolicitud = 0;
            byte[] bytesFrom = new byte[10028];

            string datosDelCliente = null;
            Byte[] sendBytes = null;

            string respuestaServidor = null;
            string rCount = null;

            conteoDeSolicitud = 0;

            while((true)) {
                try {

                    conteoDeSolicitud = conteoDeSolicitud + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    datosDelCliente = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    datosDelCliente = datosDelCliente.Substring(0, datosDelCliente.IndexOf("$"));
                    Console.WriteLine(" >> " + "Del Cliente - " + clNo + datosDelCliente);

                    rCount = Convert.ToString(conteoDeSolicitud);
                    respuestaServidor = "Servidor para el cliente (" + clNo + ") " + rCount;

                    sendBytes = Encoding.ASCII.GetBytes(respuestaServidor);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + respuestaServidor);

                } catch(Exception ex) {
                    Console.WriteLine(" >> " + ex.ToString());
                }
            }
        }


    }//cierre de las clases
}
